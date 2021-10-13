using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Cleric
{
    public class Absorbance : AbilityType
    {
        public override void SetStaticDefaults(){
            AbilityName = "Absorbance"; //name is the same (usually)
        }
        public override void SetDefaults(){
            AbilityEnergyCost = 5; //costs 5 energy every 30 ticks (interval logic below) (non-static for changes in value)
            AbilityCastCooldown = 60; //takes 1 second to recast
            IsHoldout = true; // able to be held out for continual effects
        }
        public override bool CanCast(Player player){
            return base.CanCast(player);
        }
        public override void Cast(Player player){
            Main.NewText("Absorbance Successfully Cast (This is test text and will not be used post v0.25)");
        }
    }
}