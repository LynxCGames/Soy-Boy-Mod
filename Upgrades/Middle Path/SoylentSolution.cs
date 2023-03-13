using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;


namespace SoyBoyMod.Upgrades.Middle_Path
{
    public class SoylentSolution : ModUpgrade<SoyBoy>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 4750;

        public override string DisplayName => "Soylent Solution";
        public override string Description => "Soy Boy gains super fast attacking.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += 5;
            towerModel.GetAttackModel().range += 5;


            towerModel.GetAttackModel().weapons[0].rate *= .5f;

            towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 1;
        }
    }
}