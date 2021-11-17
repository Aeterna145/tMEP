using MEPMod.Content.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MEPMod.Common.Globals
{
    public class BaseGlobalNPC : GlobalNPC
    {
        private const string assetPath = "MEPMod/Assets/AbilityAssets";
        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit){
            if (npc.HasBuff<FlashFrozen>() && ModContent.GetInstance<FlashFrozen>().CrashTimer > 0){
                ModContent.GetInstance<FlashFrozen>().storedDamage += damage;
                damage = 0;
            }
        }
        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit){
            if (npc.HasBuff<FlashFrozen>() && ModContent.GetInstance<FlashFrozen>().CrashTimer > 0){
                ModContent.GetInstance<FlashFrozen>().storedDamage += damage;
                damage = 0;
            }
        }
        public override void AI(NPC npc){
            if (npc.HasBuff<FlashFrozen>() && !npc.boss){
                npc.noGravity = false;
                npc.aiStyle = -1;
                npc.defense /= 2;
            }
            if (npc.HasBuff<FlashFrozen>() && npc.boss) {
                npc.defense /= 2;
                npc.velocity *= 0.5F;
            }
        }
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (npc.HasBuff<FlashFrozen>() && !npc.boss){
                Texture2D texture = ModContent.Request<Texture2D>($"{assetPath}/GlacialWrathNPCOverlay").Value;
                spriteBatch.Draw(texture, 
                    new Vector2(npc.position.X - screenPos.X + texture.Width * 0.5f, npc.position.Y - screenPos.Y + 50 - texture.Height * 0.5f + 2f), 
                    new Rectangle(0, 0, texture.Width, texture.Height), 
                    drawColor, 
                    npc.rotation,
                    texture.Size() * 0.5f, 
                    1f, 
                    SpriteEffects.None, 
                    0f);
            }
            if (npc.HasBuff<FlashFrozen>() && npc.boss) {
                npc.color = Color.LightSkyBlue;
            }
        }
    }
}