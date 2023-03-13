using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using SoyBoyMod.Displays.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace SoyBoyMod.Upgrades.Top_Path
{
    public class BiggerBeans : ModUpgrade<SoyBoy>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 1650;

        public override string DisplayName => "Bigger Beans";
        public override string Description => "Soy Boy throws larger beans that can pop more Bloons and deal extra damage to ceramics.";

        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();

            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<SoyBeanLargeDisplay>();

            tower.range += 10;
            tower.GetAttackModel().range += 10;

            attackModel.weapons[0].projectile.pierce += 7;

            attackModel.weapons[0].projectile.GetDamageModel().damage += 1;

            attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Ceramic", 1, 4, false, false) { tags = new string[] { "Ceramic" }, collisionPass = 0 });
        }
    }
}