using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Cleric
{
    public class Wellspring : ChargeAbility
    {

        public override void SetStaticDefaults(){
            AbilityName = "Wellspring";
            AbilityEnergyCost = 75;
            AbilityChargeTime = 90;
            ResetTimer = 90;
        }
        public override void Cast(Player player){
            
        }
    }
}
