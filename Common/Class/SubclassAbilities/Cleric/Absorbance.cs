using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Cleric
{
    public class Absorbance : HoldOutAbility
    {
        public override void SetStaticDefaults(){
            AbilityName = "Absorbance"; //name is the same (usually)
            AbilityEnergyCost = 5; //costs 5 energy every 30 ticks (interval logic below)
        }
        public override void Cast(Player player){
            if (player.whoAmI == Main.myPlayer){
                Main.NewText("Absorbance Successfully Cast (This is test text and will not be used post v0.25)");
            }
        }
    }
}