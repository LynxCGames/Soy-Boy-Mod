using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;


namespace SoyBoyMod.Upgrades
{
    public class SoyMilk : ModUpgrade<SoyBoy>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 500;

        public override string DisplayName => "Soy Milk";
        public override string Description => "Soy Boy can throw further and attack faster";

        //       public override string Portrait => "";

        public override void ApplyUpgrade(TowerModel tower)
        {
            foreach (var weaponModel in tower.GetWeapons())
            {
                tower.range += 15;
                tower.GetAttackModel().range += 15;

                weaponModel.Rate *= .333333f;
            }
        }
    }
}