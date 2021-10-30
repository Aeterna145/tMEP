using Terraria;
using Terraria.ModLoader;

namespace MEPMod.Content.Buffs
{
    public class TimewatchersGripBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Timewatcher's Grip");
            Description.SetDefault("You will be spared from death.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            CanBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex){
            if (player.statLife <= 0){
                player.statLife += player.statLifeMax2 * (int)1.75;
                player.ClearBuff(ModContent.BuffType<TimewatchersGripBuff>());
            }
        }
    }
}
