using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Weapons;


namespace SoyBoyMod.Upgrades
{
    public class SoylentSolution : ModUpgrade<SoyBoy>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 3250;

        public override string DisplayName => "Soylent Solution";
        public override string Description => "Soy Boy gains super fast attacking";

        //       public override string Portrait => "";

        public override void ApplyUpgrade(TowerModel tower)
        {
            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.Rate *= .333333f;

                weaponModel.projectile.GetDamageModel().damage += 1;
            }
        }
    }
}