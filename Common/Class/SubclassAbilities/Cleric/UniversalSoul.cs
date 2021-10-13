using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Cleric
{
    public class UniversalSoul : AbilityType
    {
        public override void SetStaticDefaults(){
            AbilityName = "Universal Soul";
        }
        public override void SetDefaults(){
            AbilityCastCooldown = 120;
            AbilityEnergyCost = 25;
            IsToggle = true;
            HasAltFunc = true;
        }
        public override void Cast(Player player)
        {
            Main.NewText("Universal Soul Successfully Cast (This is test text and will not be used post v0.25)");
        }
    }
}
