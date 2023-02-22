using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;


namespace SoyBoyMod.Upgrades
{
    public class MultiSoy : ModUpgrade<SoyBoy>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 950;

        public override string DisplayName => "Multi Soy";
        public override string Description => "Soy Boy now throws three soy beans at a time";

        //       public override string Portrait => "";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 15, null, false);
        }
    }
}