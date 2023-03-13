using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using SoyBoyMod.Displays.Projectiles;

namespace SoyBoyMod.Upgrades.Top_Path
{
    public class SpikedBeans : ModUpgrade<SoyBoy>
    {
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 7200;

        public override string DisplayName => "Spiked Beans";
        public override string Description => "Spiked soy beans deal massive damage and stun MOAB class Bloons.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();

            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<SoyBeanSpikedDisplay>();

            attackModel.weapons[0].projectile.GetDamageModel().damage += 4;

            attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 1, 14, false, false) { tags = new string[] { "Moabs" }, collisionPass = 0 });

            var stun = Game.instance.model.GetTower(TowerType.SniperMonkey, 4).GetWeapon().projectile.Duplicate();
            stun.GetDamageModel().damage = 0;
            projectile.AddBehavior(stun);
        }
    }
}