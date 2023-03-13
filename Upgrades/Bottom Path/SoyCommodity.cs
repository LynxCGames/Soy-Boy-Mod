using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;

namespace SoyBoyMod.Upgrades.Bottom_Path
{
    public class SoyCommodity : ModUpgrade<SoyBoy>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 540;

        public override string DisplayName => "Soy Commodity";
        public override string Description => "Soy Boy generates cash every round.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var bananaFarmAttackModel = Game.instance.model.GetTowerFromId("BananaFarm-003").GetAttackModel().Duplicate();
            bananaFarmAttackModel.name = "BananaFarm_";
            bananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().maximum = 8;
            bananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().minimum = 8;
            bananaFarmAttackModel.weapons[0].GetBehavior<EmissionsPerRoundFilterModel>().count = 12;
            towerModel.AddBehavior(bananaFarmAttackModel);
        }
    }
}
