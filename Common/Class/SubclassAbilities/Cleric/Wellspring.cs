using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Cleric
{
    public class Wellspring : AbilityType
    {
        public override void SetStaticDefaults(){
            AbilityName = "Wellspring";
        }
        public override void SetDefaults(){
            AbilityEnergyCost = 75;
            AbilityCastCooldown = 600;
        }
        public override void Cast(Player player){
            Main.NewText("Wellspring Successfully Cast (This is test text and will not be used post v0.25)");
        }
    }
}
