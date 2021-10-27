using Terraria;
using Terraria.ModLoader;

namespace MEPMod.Content.Buffs
{
    public class AbsorbanceBuff : ModBuff
    {
        public int DamageAbsorbed;
        private int DamageAbsorbLimit = 1000;
        private int DamageReturn;
        public int AbsorbTimer = 600;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Absorbance");
            Description.SetDefault("Absorbing damage!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            AbsorbTimer--;
            if (DamageAbsorbed > DamageAbsorbLimit) DamageAbsorbed = DamageAbsorbLimit;
            if (AbsorbTimer == 0){
                AbsorbTimer = 600;
            }
        }
    }
}