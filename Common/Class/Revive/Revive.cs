using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MEPMod.Common.Class.Revive
{
    public class Revive : ModPlayer
    {
        private int revivePointTimer = 90; //time it takes to set a revive point (1.5s)
        private Vector2 revivePoint; //set variable for where we want the player's point to be
        public bool isRevived = false;

        public override void PreUpdate(){
            for (int i = 0; i < Main.maxPlayers; i++){ //server for-loop
                if (!Main.player[i].active) continue; //if inactive, continue
                if (Main.player[i].velocity == Vector2.Zero) revivePointTimer--; //if the player isn't moving, decrease the timer
                if (revivePointTimer == 0){ //if the revive timer is at or below 0...
                    revivePoint = Main.player[i].Center; //set the player's position to the revive position
                    Player.ChangeSpawn((int)revivePoint.X, (int)revivePoint.Y);
                    revivePointTimer = 90; //reset the timer manually
                }// end of logic pt.I
                if (Main.player[i].dead) Projectile.NewProjectile(spawnSource:null, revivePoint, Vector2.Zero, ModContent.ProjectileType<ReviveAnchor>(), 0, 0);
                if (isRevived && Main.player[i].dead){ //if the player is revived but is still dead
                    Main.player[i].respawnTimer = 0; //instantly set the respawn timer to 0 for instant respawn
                    Main.player[i].Teleport(revivePoint); //immediately teleport the player to the revive point
                    //reminder to add more effects and sounds here to make it less of a normal TP
                    Main.NewText(Main.player[i].name + " has been revived!", Color.LightGreen); //play text
                    isRevived = false; //set to false so no more code is executed
                }// end of logic pt.II
            }
        }
    }
    public class ReviveAnchor : ModProjectile
    {
        public int reviveTimer = 90; //time it takes to revive a player when right-click is held down
        public override void SetDefaults() //some stuff probably missing here
        {
            Projectile.width = 20; //hitbox width
            Projectile.height = 20; //hitbox height
            Projectile.friendly = true; //friendly (so it doesn't attack the player)
        }
        public Player player;
        public override void AI(){ //if any player isn't dead, is active, cursor is hovering over projectile, and holding right
            if (!player.dead && player.active && Projectile.Hitbox.Contains(Main.MouseWorld.ToPoint()) && Main.mouseRight) reviveTimer--;
            if (reviveTimer == 0){ //when the revive timer is 0 or below
                player.GetModPlayer<Revive>().isRevived = true; //set the bool to true
                Projectile.Kill(); //kill this projectile
                reviveTimer = 90; //reset the timer
            }//reminder to add animation and other crap to this when finishing up, dont want it looking boring
            if (Main.mouseRightRelease || !Projectile.Hitbox.Contains(Main.MouseWorld.ToPoint())) reviveTimer = 90; //resets timer if let go of
            if (player.respawnTimer == 0 && !player.GetModPlayer<Revive>().isRevived){
                player.GetModPlayer<Revive>().isRevived = true; //set the bool to true
                Projectile.Kill(); //kill this projectile
            }
        }
    }
}