using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Helpers;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Config;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Models.Spt.Tables;
using SPTarkov.Common.Models.Logging;
using SPTarkov.Server.Core.Servers;
using SPTarkov.Server.Core.Services;
using SPTarkov.Server.Core.Helpers.Server;
using SPTarkov.Server.Core.Services.Modding.Custom;
using System.Reflection;

namespace TarkovRareCollectibles
{
    public record ModMetadata : IModMetadata
    {
        public string ModGuid { get; init; } = "com.binkobunko.tarkovrarecollectibles";
        public string Name { get; init; } = "TarkovRareCollectibles";
        public string Author { get; init; } = "YellowDoge";
        public bool HasPrepatcher { get; init; } = false;
        public List<string>? Contributors { get; init; } = ["BinkoBunko"];
        public SemanticVersioning.Version Version { get; init; } = new("1.2.1");
        public SemanticVersioning.Range SptVersion { get; init; } = new("~4.1.0");
        public List<string>? Incompatibilities { get; init; }
        public Dictionary<string, SemanticVersioning.Range>? ModDependencies { get; init; }
        public string? Url { get; init; }
        public string? License { get; init; } = "MIT";
    }

    [Injectable(TypePriority = OnLoadOrder.Preload)]
    public class TarkovRareCollectibles(
        ISptLogger<TarkovRareCollectibles> logger,
        ModHelper modHelper,
        CustomItemService customItemService,
        LocationTable locationTable, 
        ItemConfig itemConfig, 
        PmcConfig pmcConfig,
        TemplateTable templateTable,
        TradersTable tradersTable)
        : IOnLoad
    {
        public Task OnLoadAsync(CancellationToken cancellationToken)
        {
            var pathToMod = modHelper.GetAbsolutePathToModFolder(Assembly.GetExecutingAssembly());

            // Load JSON files using strongly-typed deserialization
            var config = modHelper.GetJsonDataFromFile<Dictionary<string, double>>(pathToMod, @"config\config.json");
            var itemIdLookup = modHelper.GetJsonDataFromFile<Dictionary<string, string>>(pathToMod, @"db\Items\itemIdLookup.json");
            var itemData = modHelper.GetJsonDataFromFile<Dictionary<string, NewItemFromCloneDetails>>(pathToMod, @"db\Items\itemData.json");
            var staticLootData = modHelper.GetJsonDataFromFile<Dictionary<string, Dictionary<string, Dictionary<string, double>>>>(pathToMod, @"db\Items\staticLootData.json");
            var looseLootData = modHelper.GetJsonDataFromFile<Dictionary<string, List<SpawnData>>>(pathToMod, @"db\Items\looseLootData.json");
            var hallofFameData = modHelper.GetJsonDataFromFile<Dictionary<string, string>>(pathToMod, @"db\Items\hallofFameData.json");
            var traderData = modHelper.GetJsonDataFromFile<Dictionary<string, Dictionary<string, bool>>>(pathToMod, @"db\Items\traderData.json");

            logger.Info("[Tarkov Rare Collectibles] Start loading items");

            var itemService = new DogeItemService(logger, locationTable, itemConfig, pmcConfig, templateTable, tradersTable);

            foreach (var itemId in itemIdLookup.Keys)
            {
                customItemService.CreateItemFromClone(itemData[itemId]);
            }

            itemService.AddToStaticLoot(staticLootData, config["staticLootMultiplier"]);
            itemService.AddToLooseLoot(looseLootData, config["looseLootMultiplier"]);
            itemService.AddToTraderTrades(traderData);
            itemService.AddToHallOfFame(hallofFameData);
            itemService.RemoveFromRewardPool(itemIdLookup);
            itemService.RemoveFromPMCLootPool(itemIdLookup);

            // This is where 
            logger.Success("[Tarkov Rare Collectibles] Finished loading items");
            return Task.CompletedTask;
        }
    }
}
