using MEPMod.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MEPMod.Common.Class.SubclassAbilities.Cleric
{
    public class UniversalSoul : BaseAbility
    {
        public int SoulType;
        public int TypeSwitchTimer = 90;
        public override void SetStaticDefaults(){
            AbilityName = "Universal Soul";
            AbilityEnergyCost = 25;
        }
        public override void Cast(Player player){
            //Casts a soul projectile to the nearest player.
            //Player recieves the buff of the specific type.
            //SoulType is changed in ProcessTriggers using AltKey
            for (int i = 0; i < Main.maxPlayers; i++){
                if (i == player.whoAmI && Main.netMode == NetmodeID.SinglePlayer){
                    switch (SoulType){
                        case 0:
                            player.AddBuff(ModContent.BuffType<UniversalSoulBuffOne>(), 600);
                            break;
                        case 1:
                            player.AddBuff(ModContent.BuffType<UniversalSoulBuffTwo>(), 600);
                            break;
                        case 2:
                            player.AddBuff(ModContent.BuffType<UniversalSoulBuffThree>(), 300);
                            break;
                    }
                }
                if (i == player.whoAmI || Main.player[i].dead || !Main.player[i].active) continue;
                float playerDist = player.DistanceSQ(Main.player[i].Center);
                const float reqDist = 16 * 10; //if the player is within 10 blocks
                if (playerDist < reqDist * reqDist){
                    switch (SoulType){
                        case 0:
                            player.AddBuff(ModContent.BuffType<UniversalSoulBuffOne>(), 600);
                            break;
                        case 1:
                            player.AddBuff(ModContent.BuffType<UniversalSoulBuffTwo>(), 600);
                            break;
                        case 2:
                            player.AddBuff(ModContent.BuffType<UniversalSoulBuffThree>(), 300);
                            break;
                    }
                }
            }
        }
    }
}