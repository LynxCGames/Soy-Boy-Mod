using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using SoyBoyMod.Displays.Projectiles;

namespace SoyBoyMod.Upgrades.Top_Path
{
    public class SuperBeans : ModUpgrade<SoyBoy>
    {
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 108000;

        public override string DisplayName => "Super Beans";
        public override string Description => "Highly unstable soy beans that violently explode on contact.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();

            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<SoyBeanSuperDisplay>();

            towerModel.range += 15;
            towerModel.GetAttackModel().range += 15;

            attackModel.weapons[0].projectile.pierce = 1;

            attackModel.weapons[0].projectile.GetDamageModel().damage += 16;

            attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Ceramic", 1, 16, false, false) { tags = new string[] { "Ceramic" }, collisionPass = 0 });

            attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 1, 936, false, false) { tags = new string[] { "Moabs" }, collisionPass = 0 });

            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-500").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-500").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-500").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
            attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage = 48.0f;
            attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce = 50.0f;
        }
    }
}