using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace SoyBoyMod
{
    public class SoyBoy : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Support;

        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 350;

        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Soy Boy, the ultimate bringer of doom";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            projectile.pierce -= 1;

            foreach (var weaponModel in towerModel.GetWeapons())
            {
                weaponModel.projectile.GetDamageModel().damage += 1;
            }
        }
    }
}
