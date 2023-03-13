using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using SoyBoyMod.Displays.Projectiles;

namespace SoyBoyMod.Upgrades.Top_Path
{
    public class StrongerSoy : ModUpgrade<SoyBoy>
    {
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 425;

        public override string DisplayName => "Stronger Soy";
        public override string Description => "Soy beans deal extra damage.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();

            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<StrongSoyBeanDisplay>();

            attackModel.weapons[0].projectile.GetDamageModel().damage += 1;
        }
    }
}
