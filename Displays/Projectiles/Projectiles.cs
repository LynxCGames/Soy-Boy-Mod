using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;

namespace SoyBoyMod.Displays.Projectiles
{
    public class SoyBeanDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }

    public class StrongSoyBeanDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }

    public class SoyBeanSpikedDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }

    public class SoyBeanLargeDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }

    public class SoyBeanSuperDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }

    public class DarkSoyBeanDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }

    public class CookedSoyBeanDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }

    public class ApocolypseDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, Name);
        }
    }
}
