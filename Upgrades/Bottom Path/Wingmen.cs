using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using Clones;
using SoyBoyMod.Displays.Projectiles;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity.Display;

namespace SoyBoyMod.Upgrades.Bottom_Path
{
    public class Wingmen : ModUpgrade<SoyBoy>
    {
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 1100;

        public override string Description => "Soy Boy is figuring out how to clone himself for world domination.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();

            attackModel.weapons[0].Rate *= .8f;

            var towersoyboy = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
            towersoyboy.range = towerModel.range;
            towersoyboy.name = "SoyBoy_Tower";
            towersoyboy.weapons[0].Rate = 10f;
            towersoyboy.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            towersoyboy.weapons[0].projectile.ApplyDisplay<SoyBeanDisplay>();
            towersoyboy.weapons[0].projectile.AddBehavior(new CreateTowerModel("SoyBoy000place", GetTowerModel<SoyBoy000>().Duplicate(), 0f, true, false, false, true, true));
            towerModel.AddBehavior(towersoyboy);
        }
    }
}

namespace Clones
{
    public class SoyBoy000 : ModTower
    {
        public override string Portrait => "SoyBoy-Portrait";
        public override string Name => "000 SoyBoy";
        public override TowerSet TowerSet => TowerSet.Support;
        public override string BaseTower => TowerType.DartMonkey;

        public override bool DontAddToShop => true;
        public override int Cost => 0;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;


        public override string DisplayName => "Soy Boy Clone";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<SoyBeanDisplay>();

            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().damage += 1;
            }

            towerModel.isSubTower = true;
            towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 30f, 1, false, false));
        }

        public class SoyBoy1Display : ModTowerDisplay<SoyBoy000>
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
