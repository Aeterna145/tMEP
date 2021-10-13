using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Cleric
{
    public class TimewatchersGrip : AbilityType
    {
        public override void SetStaticDefaults(){
            AbilityName = "Timewatcher's Grip";
        }
        public override void SetDefaults(){
            AbilityCastCooldown = 1200;
            AbilityEnergyCost = 100;
        }
        public override void Cast(Player player){
            Main.NewText("Timewatcher's Grip Successfully Cast (This is test text and will not be used post v0.25)");
        }
    }
}
