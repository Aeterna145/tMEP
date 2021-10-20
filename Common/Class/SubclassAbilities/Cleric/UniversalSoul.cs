using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Cleric
{
    public class UniversalSoul : BaseAbility
    {
        public int SoulType;
        public int TypeSwitchTimer;
        public override void SetStaticDefaults(){
            AbilityName = "Universal Soul";
            AbilityEnergyCost = 25;
        }
        public override void Cast(Player player){
            //Casts a soul projectile to the nearest player.
            //Player recieves the buff of the specific type.
            if (player.whoAmI == Main.myPlayer) Main.NewText("Universal Soul Successfully Cast (This is test text and will not be used post v0.25)");
        }
    }
}