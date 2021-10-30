using MEPMod.Common.Class;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace MEPMod.Content.UI
{
    internal class AbilityEnergyBar : UIState
    {
        private UIText text;
        private UIElement area;
        private UIImage barFrame;
        private Color gradientA;
        private Color gradientB;

        public override void OnInitialize(){
            area = new UIElement();
            area.Left.Set(-area.Width.Pixels - 600, 1f);
            area.Top.Set(30, 0f);
            area.Width.Set(182, 0f);
            area.Height.Set(60, 0f);

            barFrame = new UIImage(ModContent.Request<Texture2D>("MEPMod/Content/UI/AbilityEnergyFrame"));
            barFrame.Left.Set(22, 0f);
            barFrame.Top.Set(0, 0f);
            barFrame.Width.Set(138, 0f);
            barFrame.Height.Set(24, 0f);

            text = new UIText("0/0", 0.8f);
            text.Width.Set(138, 0f);
            text.Height.Set(24, 0f);
            text.Top.Set(40, 0f);
            text.Left.Set(0, 0f);

            gradientA = new Color(0, 0, 139);
            gradientB = new Color(0, 0, 205);

            area.Append(text);
            area.Append(barFrame);
            Append(area);
        }
        public override void Draw(SpriteBatch spriteBatch){
            base.Draw(spriteBatch);
            var abilityPlayer = Main.LocalPlayer.GetModPlayer<ClassPlayer>();
            float quotient = (float)abilityPlayer.EnergyCurrent / abilityPlayer.EnergyMax;
            quotient = Utils.Clamp(quotient, 0F, 1F);
            Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
            hitbox.X += 12;
            hitbox.Width -= 24;
            hitbox.Y += 8;
            hitbox.Height -= 16;

            int left = hitbox.Left;
            int right = hitbox.Right;
            int steps = (int)((right - left) * quotient); //note: FUCK YOU, FLOATS
            for (int i = 0; i < steps; i += 1)
            {
                float percent = (float)i / (right - left);
                spriteBatch.Draw((Texture2D)Terraria.GameContent.TextureAssets.MagicPixel, new Rectangle(left + i, hitbox.Y, 1, hitbox.Height), Color.Lerp(gradientA, gradientB, percent));
            }
        }
        public override void Update(GameTime gameTime){
            var abilityPlayer = Main.LocalPlayer.GetModPlayer<ClassPlayer>();
            text.SetText($"Ability Energy: {abilityPlayer.EnergyCurrent} / {abilityPlayer.EnergyMax}");
            if (text.IsMouseHovering || barFrame.IsMouseHovering || area.IsMouseHovering){
                Main.hoverItemName = $"Ability Energy: {abilityPlayer.EnergyCurrent} / {abilityPlayer.EnergyMax}";
            }
            base.Update(gameTime);
        }
    }
}