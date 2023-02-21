using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;


namespace SoyBoyMod.Upgrades
{
    public class PiercingSoy : ModUpgrade<SoyBoy>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 350;

        public override string DisplayName => "Piercing Soy";
        public override string Description => "Soy beans pierce more bloons";

 //       public override string Portrait => "";

        public override void ApplyUpgrade(TowerModel tower)
        {
            foreach (var weaponModel in tower.GetWeapons())
            {
                    weaponModel.projectile.pierce += 3;
            }
        }
    }
}
