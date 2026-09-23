
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Enums;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Models.Spt.Tables;
using SPTarkov.Common.Models.Logging;
using SPTarkov.Server.Core.Servers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovRareCollectibles
{
    internal class SpawnDataPosition
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }
    internal class LooseLootItem
    {
        public string? _tpl { get; set; }
        public string? _id { get; set; }
        public double relativeProbability { get; set; }
    }

    internal class SpawnData
    {
        public string? Id { get; set; }
        public SpawnDataPosition Position { get; set; } = new();
        public double probability { get; set; }
        public List<LooseLootItem> Items { get; set; } = new();
    }

    internal class DogeItemService
    {
        private readonly ISptLogger<TarkovRareCollectibles> _logger;
        private readonly LocationTable _locationTable;
        private readonly ItemConfig _itemConfig;
        private readonly PmcConfig _pmcConfig;
        private readonly TemplateTable _templateTable;
        private readonly TradersTable _tradersTable;

        public DogeItemService(ISptLogger<TarkovRareCollectibles> logger, LocationTable locationTable, ItemConfig itemConfig, PmcConfig pmcConfig, TemplateTable templateTable, TradersTable tradersTable)
        {
            _logger = logger;
            _locationTable = locationTable;
            _itemConfig = itemConfig;
            _pmcConfig = pmcConfig;
            _templateTable = templateTable;
            _tradersTable = tradersTable;
        }

        public void AddToStaticLoot(Dictionary<string, Dictionary<string, Dictionary<string, double>>> staticLootData, double staticLootMultiplier)
        {
            var lootChangesByMap = new Dictionary<string, List<(MongoId ContainerId, ItemDistribution Item)>>();

            foreach ((string itemId, Dictionary<string, Dictionary<string, double>> staticLootEntry) in staticLootData)
            {
                foreach ((string mapName, Dictionary<string, double> mapLoot) in staticLootEntry)
                {
                    string propertyMapName = _locationTable.GetMappedKey(mapName);

                    if (!_locationTable.GetDictionary().ContainsKey(propertyMapName))
                        continue;

                    Location location = _locationTable.GetDictionary()[propertyMapName];

                    foreach ((string containerName, double spawnProbability) in mapLoot)
                    {
                        if (!ConstantsContainer.containerLookup.TryGetValue(containerName, out string? containerId))
                        {
                            _logger.Warning($"Container {containerName} not found in containerLookup");
                            continue;
                        }

                        var containerMongoID = new MongoId(containerId);

                        if (!ConstantsContainer.containerTotalProbability.TryGetValue(mapName, out var mapProbs) ||
                            !mapProbs.TryGetValue(containerName, out double totalProbability))
                        {
                            _logger.Warning($"containerTotalProbability not found for container {containerId} in map {mapName}");
                            continue;
                        }

                        double calculatedSpawnProbability = spawnProbability * staticLootMultiplier;
                        if (calculatedSpawnProbability >= 0.25)
                        {
                            _logger.Warning($"Force spawnProbability=0.25 for item {itemId} on {mapName}:{containerName}");
                            calculatedSpawnProbability = 0.25;
                        }

                        double relativeProbRaw = (calculatedSpawnProbability * totalProbability) / (1 - spawnProbability);
                        int relativeProbability = (int)Math.Round(relativeProbRaw);

                        if (relativeProbability <= 0)
                        {
                            _logger.Warning($"Skipping {itemId} for {containerName} ({mapName}) — relProb={relativeProbability}");
                            continue;
                        }

                        ItemDistribution newLoot = new ItemDistribution
                        {
                            Tpl = new MongoId(itemId),
                            RelativeProbability = relativeProbability
                        };

                        if (!lootChangesByMap.ContainsKey(propertyMapName))
                            lootChangesByMap[propertyMapName] = new List<(MongoId, ItemDistribution)>();

                        lootChangesByMap[propertyMapName].Add((containerMongoID, newLoot));
                    }
                }
            }

            foreach ((string propertyMapName, List <(MongoId ContainerId, ItemDistribution Item)> changes) in lootChangesByMap)
            {

                Location location = _locationTable.GetDictionary()[propertyMapName];
                if (location.StaticLoot == null)
                {
                    _logger.Warning($"StaticLoot is null for {propertyMapName}");
                    continue;
                }

                location.StaticLoot.AddTransformer(lazyLoadedStaticLoot =>
                {
                    if (lazyLoadedStaticLoot == null)
                        return lazyLoadedStaticLoot;

                    foreach ((MongoId containerId, ItemDistribution newLoot) in changes)
                    {
                        if (!lazyLoadedStaticLoot.TryGetValue(containerId, out StaticLootDetails lootContainer))
                        {
                            _logger.Warning($"Container ID {containerId} not found in map {propertyMapName}");
                            continue;
                        }

                        var containerItemDistribution = lootContainer.ItemDistribution?.ToList() ?? new List<ItemDistribution>();
                        containerItemDistribution.Add(newLoot);
                        lazyLoadedStaticLoot[containerId] = lootContainer with { ItemDistribution = containerItemDistribution };
                    }

                    return lazyLoadedStaticLoot;
                });
            }
        }

        public void AddToHallOfFame(Dictionary<string, string> hallofFameData)
        {
            var hall1 = _templateTable.Items[new MongoId("63dbd45917fff4dee40fe16e")];
            var hall2 = _templateTable.Items[new MongoId("65424185a57eea37ed6562e9")];
            var hall3 = _templateTable.Items[new MongoId("6542435ea57eea37ed6562f0")];
            var halls = new[] { hall1, hall2, hall3 };

            foreach ((string itemId, string itemSize) in hallofFameData)
            {
                if (string.IsNullOrEmpty(itemSize))
                    continue;

                var itemMongoId = new MongoId(itemId);

                foreach (var hall in halls)
                {
                    foreach (var slot in hall.Properties.Slots)
                    {
                        if (slot.Name.StartsWith(itemSize))
                        {
                            foreach (SlotFilter filter in slot.Properties.Filters)
                            {
                                filter.Filter?.Add(itemMongoId);
                            }
                        }
                    }
                }
            }
        }

        public void AddToTraderTrades(Dictionary<string, Dictionary<string, bool>> traderData)
        {
            foreach ((string itemId, Dictionary<string, bool> traderTradesData) in traderData)
            {
                foreach ((string traderName, bool tradeAllowed) in traderTradesData)
                {
                    if (!ConstantsContainer.traderLookup.TryGetValue(traderName, out string? traderId))
                        continue;
                    var traderMongoId = new MongoId(traderId);

                    TraderBase traderBase = _tradersTable[traderMongoId].Base;
                    HashSet<MongoId> buySet = traderBase.ItemsBuy.IdList;
                    HashSet<MongoId> prohibitedSet = traderBase.ItemsBuyProhibited.IdList;

                    var itemMongoId = new MongoId(itemId);

                    if (tradeAllowed)
                    {
                        buySet.Add(itemMongoId);
                    }
                    else
                    {
                        prohibitedSet.Add(itemMongoId);
                    }
                }
            }
        }

        public void RemoveFromRewardPool(Dictionary<string, string> itemIdLookup)
        {
            ItemConfig itemConfig = _itemConfig;
            foreach ((string itemId, string itemCode) in itemIdLookup)
            {
                var itemMongoId = new MongoId(itemId);
                itemConfig.RewardItemBlacklist.Add(itemMongoId);
            }
        }

        public void RemoveFromPMCLootPool(Dictionary<string, string> itemIdLookup)
        {
            PmcConfig pmcConfig = _pmcConfig;
            foreach ((string itemId, string itemCode) in itemIdLookup)
            {
                var itemMongoId = new MongoId(itemId);
                if (!pmcConfig.GlobalLootBlacklist.Contains(itemMongoId))
                {
                    pmcConfig.GlobalLootBlacklist.Add(itemMongoId);
                }
            }
        }

        private double EstimateLooseLootProbability(int totalSpawns, double totalRelativeProbability, double spawnChance)
        {
            double clampedChance = Math.Max(1e-6, Math.Min(spawnChance, 0.98));
            double perDrawProb = 1 - Math.Pow(1 - clampedChance, 1.0 / totalSpawns);
            return perDrawProb * totalRelativeProbability;
        }

        private Spawnpoint CreateLooseLootSpawn(SpawnData spawnData)
        {
            var spawn = new Spawnpoint
            {
                LocationId = $"({spawnData.Position.x}, {spawnData.Position.y}, {spawnData.Position.z})",
                Probability = spawnData.probability,
                Template = new SpawnpointTemplate
                {
                    Id = spawnData.Id,
                    IsContainer = false,
                    UseGravity = true,
                    RandomRotation = true,
                    Position = new Vector3 { X = spawnData.Position.x, Y = spawnData.Position.y, Z = spawnData.Position.z },
                    Rotation = new Vector3 { X = 0, Y = 0, Z = 0 },
                    IsAlwaysSpawn = false,
                    IsGroupPosition = false,
                    GroupPositions = new List<GroupPosition>(),
                    Root = "",
                    Items = spawnData.Items.Select(item => new SptLootItem
                    {
                        ComposedKey = item._id,
                        Id = new MongoId(),
                        Template = new MongoId(item._tpl),
                        Upd = new Upd { StackObjectsCount = 1 }
                    }).ToList()
                },
                ItemDistribution = spawnData.Items.Select(item => new LooseLootItemDistribution
                {
                    ComposedKey = new ComposedKey { Key = item._id },
                    RelativeProbability = item.relativeProbability
                }).ToList()
            };

            return spawn;
        }
        public void AddToLooseLoot(Dictionary<string, List<SpawnData>> looseLootData, double looseLootMultiplier)
        {
            var lootChangesByMap = new Dictionary<string, List<Spawnpoint>>();

            foreach ((string mapName, List<SpawnData> mapLoot) in looseLootData)
            {
                string propertyMapName = _locationTable.GetMappedKey(mapName);

                if (!_locationTable.GetDictionary().ContainsKey(propertyMapName))
                    continue;

                Location location = _locationTable.GetDictionary()[propertyMapName];

                foreach (SpawnData spawnData in mapLoot)
                {
                    double newProbability = spawnData.probability * looseLootMultiplier;
                    double relativeProbability = EstimateLooseLootProbability(
                        ConstantsContainer.looseLootTotalSpawns[mapName],
                        ConstantsContainer.looseLootTotalProbability[mapName],
                        newProbability
                    );

                    spawnData.probability = relativeProbability;
                    Spawnpoint looseLootSpawn = CreateLooseLootSpawn(spawnData);

                    if (!lootChangesByMap.ContainsKey(propertyMapName))
                        lootChangesByMap[propertyMapName] = new List<Spawnpoint>();

                    lootChangesByMap[propertyMapName].Add(looseLootSpawn);
                }
            }

            foreach ((string propertyMapName, List<Spawnpoint> changes) in lootChangesByMap)
            {
                if (!_locationTable.GetDictionary().TryGetValue(propertyMapName, out Location location))
                {
                    _logger.Warning($"Map {propertyMapName} not found in database.");
                    continue;
                }

                if (location.LooseLoot == null)
                {
                    _logger.Warning($"LooseLoot is null for {propertyMapName}");
                    continue;
                }

                location.LooseLoot.AddTransformer(lazyLoadedLooseLoot =>
                {
                    var currentSpawnpoints = lazyLoadedLooseLoot.Spawnpoints?.ToList() ?? new List<Spawnpoint>();

                    foreach (Spawnpoint spawnpoint in changes)
                    {
                        currentSpawnpoints.Add(spawnpoint);
                    }

                    return lazyLoadedLooseLoot with { Spawnpoints = currentSpawnpoints };
                });
            }
        }
    }
}
