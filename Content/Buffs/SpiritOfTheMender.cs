using Terraria;
using Terraria.ModLoader;

namespace MEPMod.Content.Buffs
{
    public class SpiritOfTheMender : ModBuff
    {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Spirit of the Mender");
            Description.SetDefault("You revive allies twice as fast");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }
    }
}