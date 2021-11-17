using MEPMod.Common.Class.SubclassAbilities.Warlock;
using MEPMod.Content.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MEPMod.Content.Projectiles
{
    public class GlacialWrathProj : ModProjectile
    {
        public override string Texture => "MEPMod/Content/Projectiles/GlacialWrathShardLarge";
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Large Shard");
        }
        public override void SetDefaults(){
            Projectile.aiStyle = 0;
            Projectile.width = 20;
            Projectile.height = 44;
            Projectile.timeLeft = 420;
            Projectile.damage = ModContent.GetInstance<GlacialWrath>().AbilityDamage;

            Projectile.friendly = true;
            Projectile.tileCollide = true;
        }
        public override void Kill(int timeLeft)
        {
            Player player = new();
            for (int i = 0; i < 5; i++){
                Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(),
                    new Vector2(Projectile.Center.X, Projectile.Center.Y), Projectile.velocity * 1.5f,
                    ModContent.ProjectileType<GlacialWrathProj2>(),
                    ModContent.GetInstance<GlacialWrath>().AbilityDamage / 2, Projectile.knockBack,
                    player.whoAmI);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit){
            target.AddBuff(ModContent.BuffType<FlashFrozen>(), 240);
        }
    }
    public class GlacialWrathProj2 : ModProjectile
    {
        public override string Texture => "MEPMod/Content/Projectiles/GlacialWrathShardSmall";
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Small Shard");
            ProjectileID.Sets.CountsAsHoming[Projectile.type] = true;
        }
        public override void SetDefaults(){
            Projectile.aiStyle = 0;
            Projectile.width = 10;
            Projectile.height = 22;
            Projectile.timeLeft = 180;
            Projectile.damage = ModContent.GetInstance<GlacialWrath>().AbilityDamage / 2;

            Projectile.friendly = true;
            Projectile.tileCollide = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit){
            target.AddBuff(ModContent.BuffType<FlashFrozen>(), 240);
        }
    }
}