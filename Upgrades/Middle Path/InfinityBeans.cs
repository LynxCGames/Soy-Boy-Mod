using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using SoyBoyMod.Displays.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2Cpp;

namespace SoyBoyMod.Upgrades.Middle_Path
{
    public class InfinityBeans : ModUpgrade<SoyBoy>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 116000;

        public override string DisplayName => "Infinity Beans";
        public override string Description => "I am... inevitable.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();

            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<DarkSoyBeanDisplay>();

            towerModel.range += 25;
            towerModel.GetAttackModel().range += 25;

            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

            towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 8, 0, 100, null, false);

            attackModel.weapons[0].projectile.GetDamageModel().damage += 9;

            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-001").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-001").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-001").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
            attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage = 12.0f;
            attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce = 25.0f;
        }
    }
}