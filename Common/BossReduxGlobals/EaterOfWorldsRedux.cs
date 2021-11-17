using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MEPMod.Common.BossReduxGlobals
{
    public class EaterOfWorldsRedux : GlobalNPC
    {
        private int BurrowTimer = 120;
        private int SurfaceTimer = 600;
        private int WyrmTimer = 600;
        private int EnrageTimer = 18000;
        private int EnrageStateTimer = 1800;
        private int EnrageCounter;
        public override bool InstancePerEntity => true;
        public override void SetDefaults(NPC npc) {
            switch (npc.type) { 
                case NPCID.EaterofWorldsHead:
                    npc.GivenName = "Idh-yaa, The Eater of Worlds";
                    npc.width = 62;
                    npc.height = 80;
                    npc.lifeMax = 230;
                    npc.damage = 50;
                    npc.defense = 10;
                    break;
                case NPCID.EaterofWorldsBody:
                    npc.GivenName = "Idh-yaa, The Eater of Worlds";
                    npc.width = 48;
                    npc.height = 50;
                    npc.lifeMax = 200;
                    npc.damage = 20;
                    npc.defense = 10;
                    break;
                case NPCID.EaterofWorldsTail:
                    npc.GivenName = "Idh-yaa, The Eater of Worlds";
                    npc.width = 50;
                    npc.height = 62;
                    npc.lifeMax = 210;
                    npc.damage = 35;
                    npc.defense = 14;
                    break;
            }
        }
        private static int IdhyaaHeadSlot = 0;
        public override void Load(){
            IdhyaaHeadSlot = Mod.AddBossHeadTexture($"{assetPath}/Idhyaa_Head_Boss", 0);
        }
        public override void BossHeadSlot(NPC npc, ref int index){
            if (npc.type == NPCID.EaterofWorldsHead){
                int slot = IdhyaaHeadSlot;
                if (slot != -1) index = slot;
            }
        }
        private static bool PlayerWithinRange(Player target){
            float targetDist = target.DistanceSQ(target.Center);
            const float burrowDistance = 16 * 5;
            if (targetDist > burrowDistance * burrowDistance){
                return false;
            }
            else return true;
        }
        private void PhaseOne(NPC npc){
            if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail){
                npc.aiStyle = -1;
                if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active){
                    npc.TargetClosest();
                }
            }
        }
        private static bool PhaseTwo(NPC npc) { //simple private bool to change phase based on health
            if (npc.life < npc.lifeMax / 2) return true;
            else return false;
        }
        private bool EnrageState(NPC npc){
            if (EnrageTimer < 0){
                Main.NewText("Idh-yaa is enraged!");
                return true;
            }
            else return false;
        }
        public override bool PreAI(NPC npc) {
            //return false for all this shit
            return base.PreAI(npc);
        }
        public override void AI(NPC npc) {
            Player player = new();
            if (PhaseTwo(npc)) {
                EnrageTimer--;
                switch (npc.type) {
                    case NPCID.EaterofWorldsHead:
                        npc.damage = 65;
                        npc.defense = 8;
                        break;
                    case NPCID.EaterofWorldsBody:
                        npc.damage = 25;
                        npc.defense = 8;
                        break;
                    case NPCID.EaterofWorldsTail:
                        npc.damage = 40;
                        npc.defense = 10;
                        break;
                }
                WyrmTimer--;
                if (WyrmTimer < 0){
                    for (int i = 0; i < 3; i++){
                        if (i == 1) Main.NewText("Idh-yaa summons her brood!");
                        NPC.NewNPC((int)player.Center.X - 5, (int)player.Center.Y + 5, NPCID.EaterofSouls);
                    }
                    WyrmTimer = 600;
                }
                if (EnrageState(npc)){
                    EnrageStateTimer--;
                    switch (npc.type){
                        case NPCID.EaterofWorldsHead:
                            npc.damage = 65;
                            npc.defense = 25;
                            break;
                        case NPCID.EaterofWorldsBody:
                            npc.damage = 25;
                            npc.defense = 25;
                            break;
                        case NPCID.EaterofWorldsTail:
                            npc.damage = 40;
                            npc.defense = 15;
                            break;
                    }
                    if (EnrageStateTimer < 0){
                        Main.NewText("Idh-yaa is no longer enraged.");
                        int TimerVar1 = 18000;
                        int TimerVar2 = 1800;
                        EnrageCounter++;
                        EnrageStateTimer = TimerVar2 + (600 * EnrageCounter);
                        EnrageTimer = TimerVar1 / EnrageCounter;
                    }
                    if (EnrageCounter == 6)
                    {

                    }
                }
            }
            //do the funny here
        }
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor) {
            if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail) return false;
            else return true;
        }
        private const string assetPath = "MEPMod/Assets/BossAssets/EoW";
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor){
            Texture2D HeadTexture = ModContent.Request<Texture2D>($"{assetPath}/IdhyaaHead").Value;
            Texture2D BodyTexture = ModContent.Request<Texture2D>($"{assetPath}/IdhyaaBody").Value;
            Texture2D TailTexture = ModContent.Request<Texture2D>($"{assetPath}/IdhyaaTail").Value;
            switch (npc.type){
                case NPCID.EaterofWorldsHead:
                    spriteBatch.Draw(HeadTexture, 
                        new Vector2(npc.position.X - screenPos.X + 62 * 0.5f, npc.position.Y - screenPos.Y + 80 - HeadTexture.Height * 0.5f + 2f), 
                        new Rectangle(0, 0, HeadTexture.Width, HeadTexture.Height), 
                        drawColor,
                        npc.rotation,
                        HeadTexture.Size() * 0.5f,
                        1.5F,
                        SpriteEffects.None,
                        0);
                    break;
                case NPCID.EaterofWorldsBody:
                    spriteBatch.Draw(BodyTexture, 
                        new Vector2(npc.position.X - screenPos.X + 48 * 0.5f, npc.position.Y - screenPos.Y + 50 - BodyTexture.Height * 0.5f + 2f), 
                        new Rectangle(0, 0, BodyTexture.Width, BodyTexture.Height), 
                        drawColor,                       
                        npc.rotation,
                        BodyTexture.Size() * 0.5f,
                        1.5F,
                        SpriteEffects.None,
                        0);
                    break;
                case NPCID.EaterofWorldsTail:
                    spriteBatch.Draw(TailTexture,
                        new Vector2(npc.position.X - screenPos.X + 50 * 0.5f, npc.position.Y - screenPos.Y + 62 - TailTexture.Height * 0.5f + 2f),
                        new Rectangle(0, 0, TailTexture.Width, TailTexture.Height),
                        drawColor,
                        npc.rotation,
                        TailTexture.Size() * 0.5f,
                        1.5F,
                        SpriteEffects.None,
                        0);
                    break;
            }
        }
    }
}
