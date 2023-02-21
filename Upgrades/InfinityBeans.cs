using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Weapons;


namespace SoyBoyMod.Upgrades
{
    public class InfinityBeans : ModUpgrade<SoyBoy>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 116000;

        public override string DisplayName => "Infinity Beans";
        public override string Description => "I am... inevitable";

        //       public override string Portrait => "";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 6, 0, 30, null, false);

            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().damage += 46;

                weaponModel.Rate *= .5f;
            }
        }
    }
}