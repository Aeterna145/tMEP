using Terraria;
using Terraria.ModLoader;

namespace MEPMod.Content.Buffs
{
    public class UniversalSoulBuffOne : ModBuff
    { //note: every time you're hit, you'll gain increased defense and durability
        public int SoulOneTimer = 600;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Sotera");
            Description.SetDefault("Supplant your weakness with fortification");
            Main.debuff[Type] = false;
            CanBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex){
            SoulOneTimer--;
        }
    }
    public class UniversalSoulBuffTwo : ModBuff
    { //note: every time you hit an enemy will leech health and ability energy.
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Chiro");
            Description.SetDefault("What is taken shall be returned");
            Main.debuff[Type] = false;
            CanBeCleared = false;
        }
    }
    public class UniversalSoulBuffThree : ModBuff
    { //note: every kill leads to greater damage while this buff is active, repeated kills increase the timer
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Aitu");
            Description.SetDefault("Sacrifice leads to sharpening");
            Main.debuff[Type] = false;
            CanBeCleared = false;
        }
    }
}