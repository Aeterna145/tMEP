using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Warlock
{
    public class SpellOfReaping : HoldOutAbility
    {
        public override void SetStaticDefaults(){
            AbilityName = "Spell of Reaping";
            AbilityDamage = 10;
            AbilityEnergyCost = 10;
        }
        public override void Cast(Player player){
            base.Cast(player);
        }
    }
}
