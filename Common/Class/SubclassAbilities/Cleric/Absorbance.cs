using MEPMod.Content.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace MEPMod.Common.Class.SubclassAbilities.Cleric
{
    public class Absorbance : BaseAbility
    {
        public override void SetStaticDefaults(){
            AbilityName = "Absorbance"; //name is the same (usually)
            AbilityEnergyCost = 50;
        }
        public override void Cast(Player player){
            if (player.whoAmI == Main.myPlayer){
                player.AddBuff(ModContent.BuffType<AbsorbanceBuff>(), 600);
            }
        }
    }
}