using MEPMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MEPMod.Common.Class.SubclassAbilities.Warlock
{
    public class GlacialWrath : BaseAbility
    {
        public override void SetStaticDefaults(){
            AbilityName = "Glacial Wrath";
            AbilityDamage = 35;
            AbilityEnergyCost = 45;
        }
        public override void Cast(Player player){
            Projectile.NewProjectile(Projectile.GetNoneSource(), new Vector2(player.Center.X, player.Center.Y), Main.MouseWorld.ToScreenPosition(), ModContent.ProjectileType<GlacialWrathProj>(), AbilityDamage, player.GetKnockback(DamageClass.Generic));
        }
    }
}
