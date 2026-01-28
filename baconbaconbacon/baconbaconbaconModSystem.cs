using System.Linq;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace baconbaconbacon
{
    public class baconbaconbaconModSystem : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            Mod.Logger.Notification("Bacon Bacon Bacon: " + api.Side + " started");
        }

        public override void StartPre(ICoreAPI api)
        {
            // Set up Config
            var config = api.LoadModConfig<BaconConfig>("BaconBaconBaconConfig.json");
            if (config == null)
            {
                config = new BaconConfig();
            }
            api.StoreModConfig(config, "BaconBaconBaconConfig.json");

            // Bacon Crop Stuff - Only disable if ALL of the sarcastic settings have been changed
            var enableBaconCrops = true;
            var d1  = config.TurnOnBaconCrops != true;
            var d2  = config.TurnOffBaconCrops != false;
            var d3  = config.DefinitelyTurnOffBaconCrops != false;
            var d4  = config.GrowableBacon != true;
            var d5  = config.DoNotUseBaconCrops != false;
            var d6  = config.TurnOffFun != false;
            var d7  = config.TurnOffWhimsey != false;
            var d8  = config.TurnOnChildlikeWondermentRecapturedAsAnAdult != true;
            var d9  = config.SetThisValueToThePasswordOnTheModPageIfYouWantToTurnOffGrowableBacon == "FlankSteak";
            var d10 = config.SeriouslyActuallyTurnOffTheWeirdBaconCrops != false;
            var d11 = config.ISincerelyDontWantTheCabbageBacon != false;
            var d12 = config.AreYouGettingTiredOfThisYetBecauseIfSoSetThisOneToTrue != false;
            var d13 = config.GrowingBaconIsLame != false;
            var d14 = config.TurnOnHumor != true;
            var d15 = config.SetThisToTheAnswerToLifeTheUniverseAndEverythingToTurnOffBaconCrops == 42;
            var d16 = config.MeatableCrops != true;
            var d17 = config.CroppableMeats != true;
            var d18 = config.BaconFarmingMechanics != true;
            var d19 = config.SlavishDevotionToRealism != false;
            var d20 = config.SetThisToTheIntegerNumberOneThousandTwoHundredAndTwentyFiveToTurnOffBaconCrops == 1225;
            if (d1 && d2 && d3 && d4 && d5 && d6 && d7 && d8 && d9 && d10 && d11 && d12 && d13 && d14 && d15 && d16 && d17 && d18 && d19 && d20)
            {
                enableBaconCrops = false;
            }
            api.World.Config.SetBool("BaconBaconBacon_EnableBaconCrops", enableBaconCrops);
        }

    }
}