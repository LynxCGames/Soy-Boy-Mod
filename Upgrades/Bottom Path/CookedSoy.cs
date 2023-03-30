using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using SoyBoyMod.Displays.Projectiles;
using Il2Cpp;
using SoyBoyMod.Upgrades.Top_Path;

namespace SoyBoyMod.Upgrades.Bottom_Path
{
    public class CookedSoy : ModUpgrade<SoyBoy>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 540;

        public override string DisplayName => "Cooked Soy";
        public override string Description => "Heated soy beans set Bloons on fire.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.GetAttackModel().weapons[0].projectile = Game.instance.model.GetTowerFromId("Gwendolin 6").GetAttackModel().weapons[0].projectile.Duplicate();
            towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 1;
            towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Lead;

            towerModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<CookedSoyBeanDisplay>();

            if (towerModel.appliedUpgrades.Contains(UpgradeID<StrongerSoy>()))
            {
                towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 1;
            }
        }
    }
}
