using Terraria;
using Terraria.ModLoader;

namespace MEPMod.Content.Buffs
{
    public class AbsorbanceBuff : ModBuff
    {
        public int DamageAbsorbed = 0; //privates and publics
        private int DamageAbsorbLimit = 1000;
        private int DamageReturn;
        public int AbsorbTimer = 600;

        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Absorbance"); 
            Description.SetDefault("Absorbing damage!");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            CanBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex){
            AbsorbTimer--; //decrease timer
            if (DamageAbsorbed > DamageAbsorbLimit) DamageAbsorbed = DamageAbsorbLimit; //if absrobed damage goes over limit, set it to limit
            if (AbsorbTimer == 0){ //if timer ends
                DamageReturn = DamageAbsorbed / 2; //divide damage by 2 (allows max to be 500, subject to change)
                for (int i = 0; i < Main.maxPlayers; i++){ //iterates through all players within 7 blocks
                    if (i == player.whoAmI || Main.player[i].dead || !Main.player[i].active){
                        float playerDist = player.DistanceSQ(Main.player[i].Center);
                        const float reqDist = (16 * 7);
                        if (playerDist <= reqDist * reqDist){ //if within the radius
                            player.statLife += DamageReturn; //heal for damage return
                            player.HealEffect(DamageReturn); //do the funny text
                        }
                    }
                }
                if (player.whoAmI == Main.myPlayer) Main.NewText("All players healed for " + DamageReturn + " !"); //tell cleric it went through
                DamageAbsorbed = 0; //reset absorb value
                AbsorbTimer = 600; //reset timer
            }
        }
    }
}