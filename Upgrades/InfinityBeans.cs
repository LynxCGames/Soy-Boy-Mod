using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Towers;

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

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();

            towerModel.range += 20;
            towerModel.GetAttackModel().range += 20;

            towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 6, 0, 45, null, false);

            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.pierce -= 3;

                weaponModel.projectile.GetDamageModel().damage += 12;
            }

            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-001").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-001").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-001").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
            attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage = 10.0f;
            attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce = 25.0f;
        }
    }
}