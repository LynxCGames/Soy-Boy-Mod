using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2Cpp;

namespace SoyBoyMod.Upgrades.Top_Path
{
    public class CrushingBeans : ModUpgrade<SoyBoy>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 820;

        public override string DisplayName => "Crushing Beans";
        public override string Description => "Soy Boy throws soy beans hard enough to pop Lead Bloons.";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        }
    }
}