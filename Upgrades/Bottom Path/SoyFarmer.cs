using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Extensions;

namespace SoyBoyMod.Upgrades.Bottom_Path
{
    public class SoyFarmer : ModUpgrade<SoyBoy>
    {
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 720;

        public override string DisplayName => "Soy Farmer";
        public override string Description => "Soy Boy makes more money per round.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            AttackModel? bananaFarmAttackModel = default;
            foreach (var attackModel in towerModel.GetAttackModels())
            {
                if (!attackModel.name.Equals("BananaFarm_"))
                    continue;
                bananaFarmAttackModel = attackModel;
                break;
            }

            if (bananaFarmAttackModel != null)
            {
                bananaFarmAttackModel.weapons[0].GetBehavior<EmissionsPerRoundFilterModel>().count = 10;
                bananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().maximum = 15;
                bananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().minimum = 15;
            }
        }
    }
}
