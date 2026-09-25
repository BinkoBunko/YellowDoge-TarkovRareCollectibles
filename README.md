Do you remember the feeling of finding your first GPU? Do you still remember the excitement of discovering your first LEDX? Don't you feel that looting in Tarkov nowadays has become a lot more boring? Only marked keys, Lab key cards, and maybe LEDX still give you enough adrenaline. This mod aims to fix that.

Inspired by other extraction shooters like Arena Breakout: Infinite and Delta Force, **Tarkov Rare Collectibles** is a mod that adds rare collectible items to Escape from Tarkov. These items are highly valuable and extremely rare, often worth over 1 million rubles. Once you find them, you can sell them for a fortune or collect them in your Hall of Fame.

---

## Installation
- SPT-4.1: Extract SPT_Runtime/ folder to SPT root directory
- SPT-4.0: Extract SPT/ folder to SPT root directory
- SPT-3.11: Extract user/ folder to SPT root directory

---

## Item Spawn Tabset {.tabset}

### Adjust Loot Spawn Modifier

1. Find the config file:
  - (SPT-4.1) Open SPT_Runtime/user/mods/yellowdoge-tarkovrarecollectibles/config/config.json
  - (SPT-4.0) Open SPT/user/mods/yellowdoge-tarkovrarecollectibles/config/config.json
  - (SPT-3.11) Open user/mods/yellowdoge-tarkovrarecollectibles/config/config.json

2. Adjust "staticLootMultiplier" to multiply the spawn rate for containers (value must be a number, or it will break the code). Adjust  "looseLootMultiplier" to multiply the spawn rate for items outside of containers.

3. The final spawn rate is calculated as "defaultSpawnRate" x "LootMultiplier". The defaultSpawnRate can be found on the other tabs.

4. Details on Item Spawn:
  - **Spawn Rate**: contains textual descriptions of where each item spawns
  - **Loose Loot Spawn Locations**: contains textual descriptions of each map's loose loot spawns
  - **Loose Loot Spawn Locations (Spoilers)**: contains images of each spawn point for loose loot spawns

### Spawn Rate

Static Loot spawn chance is per item spawned in each container

#### 20-Carat Diamond:
- 0.05% ~ 0.3% spawn chance in Safes (3% in TerraGroup storage room Safe)
- LooseLoot: very rare on Labs Valuable spawn point
#### 999.9 Gold Bar:
- 0.8% ~ 5% spawn chance in Safes (7.5% in TerraGroup storage room Safe)
- LooseLoot: spawns on various map's Valuable spawn point
#### Gold Clock:
- 0.08% ~ 0.1% spawn chance in Sportbag, Toolbox, Technical supply crate, GroundCache, Suitcase on All maps
- LooseLoot: spawns on various map's Valuable spawn point
#### Gold Statue:
- 0.08% ~ 0.1% spawn chance in Sportbag, Jacket, GroundCache, Suitcase on All maps
- LooseLoot: spawns on various map's Valuable spawn point
#### Pack of Weed:
- 0.2% ~ 1% spawn chance in Medbag, Jacket, GroundCache, Dead NPC on All maps
- LooseLoot: spawns in the drug lab on Lighthouse and Streets
#### Mona Lisa Replica:
- 2.5% spawn chance in GroundCache on All maps that has GroundCache
- LooseLoot: spawns in Tarcone director's office, Beluga restaurant office, "Dostoevski" restaurant, Pikes Peak resort
#### Antique Flintlock Replica:
- 0.5% spawn chance in Weapon Crates on Customs/Interchange/Lighthouse/Shoreline/Streets/Woods
- LooseLoot: spawns on various map's Valuable spawn point
#### Military Recon Drone:
- 0.5% ~ 0.8% spawn chance in all wooden supply crate on Customs/Lighthouse/Reserve/Shoreline/Woods
- LooseLoot: spawns on various map's Military spawn point
#### Military Missile:
- 0.2% ~ 0.8% spawn chance in Weapon Crates on Customs/Labs/Lighthouse/Reserve/Woods
- LooseLoot: spawns on various map's Military spawn point
#### Premium Champagne:
- 0.05% ~ 1% spawn chance in Sportbag, Dead NPC, Suitcase on GroundZero
- LooseLoot: 6 spawns on GroundZero (3 in the winery) and small chance on Labs and Streets' Valuable spawn point
#### TerraGroup Labs Emergency Power Cell:
- LooseLoot: ONLY spawns as loose loot in Labs (most spawn points are in the Technical Level)
#### Golden Deer Skull:
- LooseLoot: ONLY spawns in cultist circles (low chance on exposed ones, higher chance in marked rooms)
#### Gold Lion Figurine:
- 0.2% ~ 1.25% spawn chance in Safes (5% in TerraGroup storage room Safe)
- LooseLoot: spawns on various map's Valuable spawn point
#### Antique Gramophone:
- 0.08% ~ 0.1% spawn chance in Sportbag, Drawer, GroundCache, Suitcase on All maps
- LooseLoot: spawns on various map's Valuable spawn point
#### Dragon Figurine:
- 0.08% ~ 0.1% spawn chance in Sportbag, Drawer, GroundCache, Suitcase on All maps
- LooseLoot: spawns on various map's Valuable spawn point

### Loose Loot Spawn Locations

Loose Loot spawn chance is per spawn point per raid

#### Customs
- 4% ~ 5% Missile/Drone spawns in the 2 USEC stash and fortress
- 4% Monalisa spawns in Tarcone director's office
- 8% Valuable (GoldStatue/Flintlock/Gramophone/WoodDragon) spawns in Tarcone director's office and gas station office
- 8% Gold Deer Skull spawns in market room

#### Woods
- 5% Missile/Drone spawns in the military camp and USEC camp
- 7% Valuable (GoldStatue/Flintlock/Gramophone/WoodDragon) spawns in SCAV camps and sniper mountain bunker
- 1% Gold Deer Skull spawns in 2 cultist circles and the new bunker cultist circle

#### Interchange
- 10% Drone spawns on the shelf in OLI and IDEA as well as Tech Shops

#### Reserve
- 10% Missile spawns in the helicopter, inside locked room in garage, on top of train station, and next to the armored vehicle outside E1/E2 bunkers
- 5% Gold Deer Skull spawns in market rooms

#### Shoreline
- 8% Valuable (GoldBar/GoldClock/GoldStatue/GoldLion) spawns in resort admin and gas station
- 6% Valuable (GoldStatue/Flintlock/Gramophone/WoodDragon) spawns in unlocked cottage, weather station and cabin near car extract
- 1% Gold Deer Skull spawns in 2 cultist circles

#### Lighthouse
- 20% Weed spawns in drug lab
- 4% Champagne spawns in Pikes Peak resort wine locker
- 3% Monalisa spawns on Pikes Peak resort bedroom table
- 8% Valuable (GoldBar/GoldClock/Gramophone/WoodDragon) spawns in room opposite to Pikes Peak resort and grand chalet billards room
- 5% Missile/Drone spawns in grand chalet and the Rogue camp tents
- 3% Gold Deer Skull spawns marked room

#### Labs
- 3% Drone spawns various places
- 8% Power Cell spawns various places (mostly in the Technical level)
- 10% Valuable (ALL valuables are possible including the diamond) spawns various places

#### Streets
- 20% Weed spawns in drug lab
- 4% Monalisa spawns in Beluga restaurant office and "Dostoevski" restaurant's cultist sacrifice location
- 8% Valuable (ALL valuables are possible except the diamond) spawns in grocery store office, real estate office, relaxation room, pinewood hotel restaurant, TerraGroup office
- 1% Gold Deer Skull spawns "Dostoevski" restaurant's cultist circle
- 5% Gold Deer Skull spawns marked rooms

#### GroundZero
- 6%(Lv.1)/10%(Lv.21+) Champagn spawns in Capital Insight meeting room, Fusion bar, TerraGroup kitchen, and 3 spawns in Winery

### Loose Loot Spawn Locations (Spoilers)

#### Customs
![customs_military_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/customs_military_0.png)
![customs_military_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/customs_military_1.png)
![customs_monalisa](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/customs_monalisa.png)
![customs_valuable_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/customs_valuable_0.png)
![customs_valuable_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/customs_valuable_1.png)
![customs_deer](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/customs_deer.png)

#### Woods
![woods_military_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/woods_military_0.png)
![woods_military_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/woods_military_1.png)
![woods_valuable_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/woods_valuable_0.png)
![woods_valuable_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/woods_valuable_1.png)
![woods_valuable_2](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/woods_valuable_2.png)
![woods_deer_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/woods_deer_0.png)
![woods_deer_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/woods_deer_1.png)
![woods_deer_2](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/woods_deer_2.png)

#### Interchange
![interchange_drone_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/interchange_drone_0.png)
![interchange_drone_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/interchange_drone_1.png)
![interchange_drone_2](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/interchange_drone_2.png)
![interchange_drone_3](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/interchange_drone_3.png)
![interchange_drone_4](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/interchange_drone_4.png)
![interchange_drone_5](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/interchange_drone_5.png)

#### Reserve
![reserve_missile_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/reserve_missile_0.png)
![reserve_missile_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/reserve_missile_1.png)
![reserve_missile_2](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/reserve_missile_2.png)
![reserve_missile_3](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/reserve_missile_3.png)
![reserve_missile_4](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/reserve_missile_4.png)
![reserve_missile_5](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/reserve_missile_5.png)
![reserve_deer_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/reserve_deer_0.png)
![reserve_deer_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/reserve_deer_1.png)
![reserve_deer_2](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/reserve_deer_2.png)

#### Shoreline
![shoreline_valuable2_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/shoreline_valuable2_0.png)
![shoreline_valuable2_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/shoreline_valuable2_1.png)
![shoreline_valuable1_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/shoreline_valuable1_0.png)
![shoreline_valuable1_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/shoreline_valuable1_1.png)
![shoreline_valuable1_2](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/shoreline_valuable1_2.png)
![shoreline_deer_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/shoreline_deer_0.png)
![shoreline_deer_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/shoreline_deer_1.png)

#### Lighthouse
![lighthouse_weed_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/lighthouse_weed_0.png)
![lighthouse_weed_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/lighthouse_weed_1.png)
![lighthouse_champagne](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/lighthouse_champagne.png)
![lighthouse_monalisa](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/lighthouse_monalisa.png)
![lighthouse_valuable_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/lighthouse_valuable_0.png)
![lighthouse_valuable_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/lighthouse_valuable_1.png)
![lighthouse_military_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/lighthouse_military_0.png)
![lighthouse_military_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/lighthouse_military_1.png)
![lighthouse_military_2](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/lighthouse_military_2.png)
![lighthouse_deer](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/lighthouse_deer.png)

#### Streets
![streets_weed_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/streets_weed_0.png)
![streets_weed_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/streets_weed_1.png)
![streets_monalisa_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/streets_monalisa_0.png)
![streets_monalisa_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/streets_monalisa_1.png)
![streets_valuable_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/streets_valuable_0.png)
![streets_valuable_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/streets_valuable_1.png)
![streets_valuable_2](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/streets_valuable_2.png)
![streets_valuable_3](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/streets_valuable_3.png)
![streets_valuable_4](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/streets_valuable_4.png)
![streets_deer_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/streets_deer_0.png)
![streets_deer_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/streets_deer_1.png)
![streets_deer_2](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/streets_deer_2.png)

#### GroundZero
![groundzero_champagne_0](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/groundzero_champagne_0.png)
![groundzero_champagne_1](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/groundzero_champagne_1.png)
![groundzero_champagne_2](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/groundzero_champagne_2.png)
![groundzero_champagne_3](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/groundzero_champagne_3.png)
![groundzero_champagne_4](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/groundzero_champagne_4.png)
![groundzero_champagne_5](https://raw.githubusercontent.com/TheYellowDoge/YellowDoge-TarkovRareCollectibles/refs/heads/main/images/groundzero_champagne_5.png)

{.endtabset}

---

## Licence & Credits

## Credits Tabset {.tabset}

### Licence
MIT License

Copyright (c) 2025 TheYellowDoge

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

### Models Credits
- "Diamond" (https://skfb.ly/6VQn8) by RBG_illustrations is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
- "Gold Bar Single" (https://skfb.ly/oTGqw) by ArpitSaini_003 is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
- "Futuristic Smart Power Cell Box Game Ready Props" (https://skfb.ly/oQXuU) by aleksfotoart is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
- "Flintlock" (https://skfb.ly/6CG7C) by fly4xy is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
- "Mona Lisa (PBR hires model)" (https://skfb.ly/6TC79) by SebastianSosnowski is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
- "Weed Brick" (https://skfb.ly/ppFCw) by streetpharmacy is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
- "Eachine E58 Pocket Drone - Game Ready Asset" (https://skfb.ly/orIx8) by the_Thorminator is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
- "Table Clock" (https://skfb.ly/6WQHw) by Mikhail Kadilnikov is licensed under Creative Commons Attribution-ShareAlike (http://creativecommons.org/licenses/by-sa/4.0/).
- "stag lowpoly deer skull" (https://skfb.ly/oMMV9) by Young is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
- "HOXXOH GOLD GOLD" (https://skfb.ly/otyLY) by GregoirePopineau is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
- "Art Deco Statue" (https://skfb.ly/6BVHO) by Grell is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
- "Missile & Bomb Collection - Fighter Jets - Free" (https://skfb.ly/oJECB) by bohmerang is licensed under CC Attribution-NonCommercial-ShareAlike (http://creativecommons.org/licenses/by-nc-sa/4.0/).
- "BakeMyScan - baking example" (https://skfb.ly/6CJuM) by Loïc Norgeot is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
- "Vintage Gramophone" (https://skfb.ly/6SFI6) by Maxim Mavrichev is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).
- "Dragon statuette" (https://skfb.ly/6xPTG) by Loïc Norgeot is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).

{.endtabset}
