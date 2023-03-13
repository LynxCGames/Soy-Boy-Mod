using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using SoyBoyMod.Displays.Projectiles;
using BTD_Mod_Helper.Api.Display;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity.Display;
using BetterClones;

namespace SoyBoyMod.Upgrades.Bottom_Path
{
    public class SoyBoyIndustries : ModUpgrade<SoyBoy>
    {
        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override int Cost => 64000;

        public override string DisplayName => "Soy Boy Industries";
        public override string Description => "The hub of Soy Boy cloning affairs.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var towersoyboyTop = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
            towersoyboyTop.name = "SoyBoyTop_Tower";
            towersoyboyTop.weapons[0].Rate = 7.5f;
            towersoyboyTop.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            towersoyboyTop.weapons[0].projectile.ApplyDisplay<SoyBeanDisplay>();
            towersoyboyTop.weapons[0].projectile.AddBehavior(new CreateTowerModel("SoyBoy400place", GetTowerModel<SoyBoy400>().Duplicate(), 0f, true, false, false, true, true));
            towerModel.AddBehavior(towersoyboyTop);

            var towersoyboyMiddle = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
            towersoyboyMiddle.name = "SoyBoyMiddle_Tower";
            towersoyboyMiddle.weapons[0].Rate = 7.5f;
            towersoyboyMiddle.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            towersoyboyMiddle.weapons[0].projectile.ApplyDisplay<SoyBeanDisplay>();
            towersoyboyMiddle.weapons[0].projectile.AddBehavior(new CreateTowerModel("SoyBoy040place", GetTowerModel<SoyBoy040>().Duplicate(), 0f, true, false, false, true, true));
            towerModel.AddBehavior(towersoyboyMiddle);
        }
    }
}

namespace BetterClones
{
    public class SoyBoy400 : ModTower
    {
        public override string Portrait => "SoyBoy-Portrait";
        public override string Name => "400 SoyBoy";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Spiked Beans Clone";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();

            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<SoyBeanSpikedDisplay>();

            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().damage += 19;
                weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

                towerModel.range += 10;
                towerModel.GetAttackModel().range += 10;

                weaponModel.projectile.pierce += 4;
            }

            var stun = Game.instance.model.GetTower(TowerType.SniperMonkey, 4).GetWeapon().projectile.Duplicate();
            projectile.AddBehavior(stun);

            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 30f, 1, false, false));
        }

        public class BiggerBeansDisplay : ModTowerDisplay<SoyBoy400>
        {
            public override float Scale => .6f;
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

    public class SoyBoy040 : ModTower
    {
        public override string Portrait => "SoyBoy-Portrait";
        public override string Name => "040 SoyBoy";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Multi Soy Clone";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<SoyBeanDisplay>();

            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().damage += 2;
                weaponModel.projectile.pierce += 3;

                towerModel.range += 20;
                towerModel.GetAttackModel().range += 20;

                weaponModel.Rate *= .4f;

                towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 30, null, false);
                if (towerModel.tier == 3)
                {
                    weaponModel.projectile.pierce -= 1;
                }
                else
                {
                    weaponModel.projectile.pierce += 1;
                }
            }

            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 30f, 1, false, false));
        }

        public class BiggerBeansDisplay : ModTowerDisplay<SoyBoy040>
        {
            public override float Scale => .6f;
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