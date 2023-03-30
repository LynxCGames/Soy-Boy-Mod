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
        public override int Tier => 2;
        public override int Cost => 720;

        public override string DisplayName => "Soy Commodity";
        public override string Description => "Soy Boy generates cash every round and soy beans deal extra damage.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 1;

            var bananaFarmAttackModel = Game.instance.model.GetTowerFromId("BananaFarm-003").GetAttackModel().Duplicate();
            bananaFarmAttackModel.name = "BananaFarm_";
            bananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().maximum = 20;
            bananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().minimum = 20;
            bananaFarmAttackModel.weapons[0].GetBehavior<EmissionsPerRoundFilterModel>().count = 8;
            towerModel.AddBehavior(bananaFarmAttackModel);
        }
    }
}
