using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace MEPMod.Content
{
    public class MEPMenu : ModMenu
    {
        private const string assetPath = "MEPMod/Assets/MenuAssets";
        public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>($"{assetPath}/ATD/ATDLogo");
        public override ModSurfaceBackgroundStyle MenuBackgroundStyle => base.MenuBackgroundStyle;
        public override Asset<Texture2D> MoonTexture => base.MoonTexture;
        public override Asset<Texture2D> SunTexture => base.SunTexture;
        public override int Music => base.Music;
        public override string DisplayName => "ATD Menu";
    }
}
