using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Warlock
{
    public class CoronalEjection : HoldOutAbility
    {
        public override void SetStaticDefaults(){
            AbilityName = "Coronal Ejection";
            AbilityDamage = 100;
            AbilityEnergyCost = 15;
        }
        public override void Cast(Player player){
            base.Cast(player);
        }
    }
}
