using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Cleric
{
    public class Wellspring : ChargeAbility
    {

        public override void SetStaticDefaults(){
            AbilityName = "Wellspring";
            AbilityEnergyCost = 75;
            AbilityChargeTime = 300;
            ResetTimer = 300;
        }
        public override void Cast(Player player){
            if (player.whoAmI == Main.myPlayer) Main.NewText("Wellspring Successfully Cast (This is test text and will not be used post v0.25)");
        }
    }
}
