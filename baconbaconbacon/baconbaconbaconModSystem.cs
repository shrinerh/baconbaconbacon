using System.Linq;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace baconbaconbacon
{
    public class baconbaconbaconModSystem : ModSystem
    {
        private BaconConfig config;

        public override void Start(ICoreAPI api)
        {
            Mod.Logger.Notification("Bacon Bacon Bacon: " + api.Side + " started");
        }

        public override void StartServerSide(ICoreServerAPI api)
        {
            Mod.Logger.Notification("Bacon Bacon Bacon got itself up and running on the server. You're lucky it decided to get up off the couch...");
        }

        public override void StartClientSide(ICoreClientAPI api)
        {
            Mod.Logger.Notification("Bacon Bacon Bacon got itself up and running on your client. You're lucky it decided to get up off the couch...");
        }

        public override void AssetsFinalize(ICoreAPI api)
        {
            // Set up Config
            config = api.LoadModConfig<BaconConfig>("BaconBaconBaconConfig.json");
            if (config == null)
            {
                config = new BaconConfig();
            }
            api.StoreModConfig(config, "BaconBaconBaconConfig.json");

            // Disable Bacon Crop Stuff
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
                var items = api.World.Items.Where(i => i.Code?.Path != null
                    && (i.Code.Path.ToLower().Contains("baconcrop")
                    || i.Code.Path.ToLower().Contains("headofbacon")
                    || i.Code.Path.ToLower().Contains("infusedbaconwrappedomokpiece")))
                    .ToList();
                foreach (var i in items)
                    api.World.Items.Remove(i);

                var recipes = api.World.GridRecipes.Where(r => (r.Output.Code?.Path != null && r.Output.Code.Path.ToLower().Contains("infusedbaconwrappedomokpiece"))
                    || (r.Ingredients != null && r.Ingredients.Any(i => i.Value.Code.Path.Contains("headofbacon"))))
                    .ToList();
                foreach (var r in recipes)
                    api.World.GridRecipes.Remove(r);

                var blocks = api.World.Blocks.Where(b => b.Code?.Path != null && b.Code.Path.ToLower().Contains("baconcrop"));
                foreach (var b in blocks)
                    b.CreativeInventoryTabs = null;
            }
        }

    }
}