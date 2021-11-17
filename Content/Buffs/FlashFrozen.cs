using Terraria;
using Terraria.ModLoader;

namespace MEPMod.Content.Buffs
{
    public class FlashFrozen : ModBuff
    {
        public int CrashTimer = 240;
        public int storedDamage = 0;
        private int damageLimiter = 1000;
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Flash-Frozen");
            Description.SetDefault("You struggle against the ice...");
            Main.debuff[Type] = true;
            CanBeCleared = true;
        }
        public override void Update(NPC npc, ref int buffIndex){
            CrashTimer--;
            if (storedDamage == damageLimiter) storedDamage = damageLimiter;
            if (CrashTimer < 0){
                npc.life -= storedDamage;
                CrashTimer = 240;
                storedDamage = 0;
                buffIndex--;
            }
        }
    }
}