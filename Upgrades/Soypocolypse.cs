using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using SoyBoyMod.Displays.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Clones;
using MiniClones;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity.Display;

namespace SoyBoyMod.Upgrades
{
    public class Soypocolypse : ModParagonUpgrade<SoyBoy>
    {
        public override int Cost => 1350000;
        public override string DisplayName => "Soypocolypse";
        public override string Description => "Soy Boy has almost reached his full power. The bringer of doom has risen.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            foreach (var weaponModel in towerModel.GetWeapons())
            {
                towerModel.GetAttackModel().RemoveWeapon(weaponModel);
            }

            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("Tower"))
                {
                    towerModel.RemoveBehavior(attacks);
                }
                if (attacks.name.Contains("BananaFarm"))
                {
                    towerModel.RemoveBehavior(attacks);
                }
            }

            towerModel.range = 110;
            towerModel.GetAttackModel().range = 110;

            var infinityBeans = Game.instance.model.GetTower(TowerType.DartMonkey, 0).GetAttackModel().Duplicate();
            var infinityBeansWeapon = infinityBeans.weapons[0];
            var infinityProjectile = infinityBeansWeapon.projectile;

            infinityBeansWeapon.rate = .15f;
            infinityBeansWeapon.emission = new ArcEmissionModel("ArcEmissionModel_", 12, 0, 85, null, false);
            infinityProjectile.GetDamageModel().damage = 45;
            infinityProjectile.pierce = 12;
            infinityProjectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            infinityProjectile.ApplyDisplay<DarkSoyBeanDisplay>();
            infinityProjectile.GetBehavior<TravelStraitModel>().Lifespan *= 1.5f;

            towerModel.GetAttackModel().AddWeapon(infinityBeansWeapon);


            var superBeans = Game.instance.model.GetTower(TowerType.BombShooter, 5).GetAttackModel().Duplicate();
            var superBeansWeapon = superBeans.weapons[0];
            var superProjectile = superBeansWeapon.projectile;

            superBeansWeapon.rate = .3f;
            superBeansWeapon.emission = new ArcEmissionModel("ArcEmissionModel_", 4, 0, 35, null, false);
            superProjectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<DamageModel>().damage = 100;
            superProjectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce = 100;
            superProjectile.GetBehavior<CreateProjectileOnContactModel>().projectile.AddBehavior(new DamageModifierForTagModel("aaa", "Moabs", 1, 1000, false, false) { tags = new string[] { "Moabs" }, collisionPass = 0 });
            superProjectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<DamageModel>().immuneBloonProperties = BloonProperties.None;
            superProjectile.ApplyDisplay<SoyBeanSuperDisplay>();

            towerModel.GetAttackModel().AddWeapon(superBeansWeapon);


            var apocolypseBean = Game.instance.model.GetTower(TowerType.BombShooter, 3).GetAttackModel().Duplicate();
            var apocolypseWeapon = apocolypseBean.weapons[0];
            var apocolypseProjectile = apocolypseWeapon.projectile;

            apocolypseWeapon.rate = 10;
            apocolypseProjectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<DamageModel>().damage = 25000;
            apocolypseProjectile.radius = 250;
            apocolypseProjectile.pierce = 9999;
            apocolypseProjectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<DamageModel>().immuneBloonProperties = BloonProperties.None;
            apocolypseProjectile.ApplyDisplay<ApocolypseDisplay>();

            towerModel.GetAttackModel().AddWeapon(apocolypseWeapon);


            var apocolypseTowers = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
            apocolypseTowers.range = towerModel.range;
            apocolypseTowers.name = "Apocolypse_Towers";
            apocolypseTowers.weapons[0].Rate = 25f;
            apocolypseTowers.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            apocolypseTowers.weapons[0].projectile.ApplyDisplay<SoyBeanDisplay>();
            apocolypseTowers.weapons[0].projectile.AddBehavior(new CreateTowerModel("ApocolypseCloneplace", GetTowerModel<ApocolypseClone>().Duplicate(), 0f, true, false, false, true, true));
            towerModel.AddBehavior(apocolypseTowers);


            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
        }
    }

    public class SoypocolypseDisplay : ModTowerDisplay<SoyBoy>
    {
        public override float Scale => 1.2f;
        public override string BaseDisplay => GetDisplay(TowerType.DartMonkey, 0, 0, 5);

        public override bool UseForTower(int[] tiers) => IsParagon(tiers);
    }
}

namespace Clones
{
    public class ApocolypseClone : ModTower
    {
        public override string Portrait => "SoyBoy-Portrait";
        public override string Name => "ApocolypseClone";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Soypocolypse Clone";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<SoyBeanSuperDisplay>();

            towerModel.range = 60;
            towerModel.GetAttackModel().range = 60;

            projectile.GetDamageModel().damage = 30;
            attackModel.weapons[0].rate = .65f;
            projectile.pierce = 6;

            attackModel.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 20, null, false);

            var miniTowers = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
            miniTowers.range = towerModel.range;
            miniTowers.name = "Apocolypse_Towers";
            miniTowers.weapons[0].Rate = 5f;
            miniTowers.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            miniTowers.weapons[0].projectile.ApplyDisplay<SoyBeanDisplay>();
            miniTowers.weapons[0].projectile.AddBehavior(new CreateTowerModel("MiniCloneplace", GetTowerModel<MiniClone>().Duplicate(), 0f, true, false, false, true, true));
            towerModel.AddBehavior(miniTowers);

            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 75f, 10, false, false));
        }

        public class ApocolypseCloneDisplay : ModTowerDisplay<ApocolypseClone>
        {
            public override float Scale => .85f;
            public override string BaseDisplay => GetDisplay(TowerType.DartMonkey, 0, 5, 0);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }


        public class MiniClone : ModTower
        {
            public override string Portrait => "SoyBoy-Portrait";
            public override string Name => "MiniClone";
            public override TowerSet TowerSet => TowerSet.Support;
            public override string BaseTower => TowerType.DartMonkey;

            public override bool DontAddToShop => true;
            public override int Cost => 0;

            public override int TopPathUpgrades => 0;
            public override int MiddlePathUpgrades => 0;
            public override int BottomPathUpgrades => 0;


            public override string DisplayName => "Mini Soypocolypse Clone";

            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                var projectile = attackModel.weapons[0].projectile;
                projectile.ApplyDisplay<SoyBeanSuperDisplay>();

                towerModel.range = 45;
                towerModel.GetAttackModel().range = 45;

                projectile.GetDamageModel().damage = 25;
                attackModel.weapons[0].rate = .35f;
                projectile.pierce = 4;

                towerModel.isSubTower = true;
                towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 20f, 5, false, false));
            }

            public class MiniApocolypseCloneDisplay : ModTowerDisplay<MiniClone>
            {
                public override float Scale => .5f;
                public override string BaseDisplay => GetDisplay(TowerType.DartMonkey, 0, 3, 0);

                public override bool UseForTower(int[] tiers)
                {
                    return true;
                }
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {

                }
            }

        }
    }
}

namespace MiniClones
{
    public class MiniClone : ModTower
    {
        public override string Portrait => "SoyBoy-Portrait";
        public override string Name => "MiniClone";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Mini Soypocolypse Clone";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<DarkSoyBeanDisplay>();

            towerModel.range = 45;
            towerModel.GetAttackModel().range = 45;

            projectile.GetDamageModel().damage = 25;
            attackModel.weapons[0].rate = .35f;
            projectile.pierce = 4;

            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 20f, 1, false, false));
        }

        public class MiniApocolypseCloneDisplay : ModTowerDisplay<MiniClone>
        {
            public override float Scale => .5f;
            public override string BaseDisplay => GetDisplay(TowerType.DartMonkey, 0, 3, 0);

            public override bool UseForTower(int[] tiers)
            {
                return true;
            }
            public override void ModifyDisplayNode(UnityDisplayNode node)
            {

            }
        }

    }
}