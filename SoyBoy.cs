using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using SoyBoyMod.Displays.Projectiles;

namespace SoyBoyMod
{
    public class SoyBoy : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Support;

        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 450;

        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override string Description => "Soy Boy, the ultimate bringer of doom";

        public override ParagonMode ParagonMode => ParagonMode.Base555;

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<SoyBeanDisplay>();

            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().damage += 1;
            }
        }

        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.EngineerMonkey).towerIndex + 1;
        }
    }
}
