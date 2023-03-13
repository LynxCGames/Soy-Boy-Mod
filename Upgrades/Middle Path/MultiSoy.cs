using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;


namespace SoyBoyMod.Upgrades.Middle_Path
{
    public class MultiSoy : ModUpgrade<SoyBoy>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 1200;

        public override string DisplayName => "Multi Soy";
        public override string Description => "Soy Boy now throws three soy beans at a time.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            foreach (var weaponModel in towerModel.GetWeapons())
            {
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
        }
    }
}