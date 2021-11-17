//using Microsoft.Xna.Framework;
//using Terraria;
//using Terraria.ModLoader;

//namespace MEPMod.Content.NPCs.Enemy.Caverns
//{
//    public abstract class Lurker : ModNPC
//    {
//        public override void SetStaticDefaults()
//        {
//            DisplayName.SetDefault("Lurker");
//        }
//        public override void SetDefaults(){
//            NPC.damage = 35;
//            NPC.defense = 50;
//            NPC.lifeMax = 3000;
//            NPC.aiStyle = -1;

//            NPC.knockBackResist = 0F;
//            NPC.npcSlots = 2F;
//        }
//        private int ScanTimer = 240;
//        private int OutOfRangeTimer = 420;
//        private int ScanDespawnTimer = 1200;

//        private bool IsStunned;
//        private bool IsHunting;
//        private bool IsStalking;
//        private void StatModifier()
//        {
//            if (Main.hardMode)
//            {
//                NPC.lifeMax = 10000;
//                NPC.defense = 50;
//                NPC.damage = 75;
//            }
//        }
//        public virtual void PassiveAbility(Player player)
//        {
//            //if the player is within a general range, play eerie music and slowly increase a vignette shader (shader to be coded)
//            for (int i = 0; i < Main.maxPlayers; i++)
//            {
//                float playerRange = player.DistanceSQ(Main.player[i].Center);
//                const float ScanDistance = 16 * 30;
//                if (playerRange < ScanDistance * ScanDistance)
//                {
//                    //do the funny here
//                }
//            }
//        }
//        public virtual void WanderMode(Player player)
//        {
//            ScanTimer--;
//            if (ScanTimer < 0)
//            {
//                //launch harmless scan projectile here
//                ScanTimer = 240;
//            }
//            ScanDespawnTimer--;
//            if (ScanDespawnTimer < 0)
//            {
//                Main.NewText("A Lurker has lost your scent. You are safe... for now.");
//                NPC.EncourageDespawn(10);
//            }
//        }
//        public virtual void StalkMode(Player player)
//        {
//            ScanDespawnTimer--;
//            //pursue in the last known scanned position of the player, scans are more frequent.
//        }
//        public virtual void HuntMode(Player player)
//        {
//            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
//            {
//                NPC.TargetClosest();
//            }
//            for (int i = 0; i < Main.maxPlayers; i++)
//            {
//                float playerRange = player.DistanceSQ(Main.player[i].Center);
//                const float VisibilityDistance = 16 * 30;
//                if (playerRange > VisibilityDistance * VisibilityDistance)
//                {
//                    OutOfRangeTimer--;
//                    if (OutOfRangeTimer < 0)
//                    {
//                        IsHunting = false;
//                        Main.NewText("The Lurker has lost sight of its prey... for now.");
//                        StalkMode(player);
//                        OutOfRangeTimer = 420;
//                    }
//                }
//            }
//        }
//        public virtual void WoundedMode(Player player)
//        {
//            //if the player stuns the Lurker, enter this mode and be staggered for 5 seconds (a damage phase)

//        }
//        public override void AI()
//        {
//            Player player = new();
//            StatModifier();

//            if (NPC.justHit && !IsStunned)
//            {
//                IsHunting = true;
//                HuntMode(player);
//            }
//            if (IsStunned)
//            {
//                WoundedMode(player);
//            }
//        }
//        public override void OnKill()
//        {
//            Main.NewText("A Lurker has been defeated!");
//        }
//        public override void ModifyNPCLoot(NPCLoot npcLoot)
//        {
//            base.ModifyNPCLoot(npcLoot);
//        }
//        public override void ResetEffects()
//        {
//            IsStunned = false;
//            IsHunting = false;
//            IsStalking = false;
//        }
//    }
//}