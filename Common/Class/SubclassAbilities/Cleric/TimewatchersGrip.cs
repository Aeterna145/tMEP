using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Cleric
{
    public class TimewatchersGrip : BaseAbility
    {
        public override void SetStaticDefaults(){
            AbilityName = "Timewatcher's Grip";
            AbilityEnergyCost = 100;
        }
        public override void Cast(Player player){
            if (player.whoAmI == Main.myPlayer) Main.NewText("Timewatcher's Grip Successfully Cast (This is test text and will not be used post v0.25)");
        }
    }
}
