using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using SoyBoyMod.Displays.Projectiles;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity.Display;
using Clones;

namespace SoyBoyMod.Upgrades.Bottom_Path
{
    public class SoyBoyCloning : ModUpgrade<SoyBoy>
    {
        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override int Cost => 2700;

        public override string DisplayName => "Soy Boy Cloning";
        public override string Description => "SoyBoy clones are now stronger and more plentiful.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("Tower"))
                {
                    towerModel.RemoveBehavior(attacks);
                }
            }

            towerModel.range += 15;
            towerModel.GetAttackModel().range += 15;

            var towersoyboy = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
            towersoyboy.range = towerModel.range;
            towersoyboy.name = "SoyBoy_Tower";
            towersoyboy.weapons[0].Rate = 4.5f;
            towersoyboy.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            towersoyboy.weapons[0].projectile.ApplyDisplay<SoyBeanDisplay>();
            towersoyboy.weapons[0].projectile.AddBehavior(new CreateTowerModel("SoyBoy120place", GetTowerModel<SoyBoy120>().Duplicate(), 0f, true, false, false, true, true));
            towerModel.AddBehavior(towersoyboy);
        }
    }
}

namespace Clones
{
    public class SoyBoy120 : ModTower
    {
        public override string Portrait => "SoyBoy-Portrait";
        public override string Name => "120 SoyBoy";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Soy Boy Clone";
        public override string Description => "";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<SoyBeanDisplay>();

            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().damage += 2;
                weaponModel.Rate *= .666666f;
                weaponModel.projectile.pierce += 3;
            }

            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 20f, 5, false, false));
        }

        public class SoyBoy1Display : ModTowerDisplay<SoyBoy120>
        {
            public override float Scale => .6f;
            public override string BaseDisplay => GetDisplay(TowerType.DartMonkey, 0, 0, 0);

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