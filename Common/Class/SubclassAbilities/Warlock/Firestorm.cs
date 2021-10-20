using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Warlock
{
    public class Firestorm : BaseAbility
    {
        public override void SetStaticDefaults(){
            AbilityName = "Firestorm";
            AbilityDamage = 50;
            AbilityEnergyCost = 75;
        }
        public override void Cast(Player player)
        {
        }
    }
}
