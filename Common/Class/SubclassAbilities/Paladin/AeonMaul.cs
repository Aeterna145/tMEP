using Terraria.ModLoader;
using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Paladin
{
    public class AeonMaul : ToggleAbility
    {
        public override void SetStaticDefaults()
        {
            AbilityName = "Aeon Maul";
            initialEnergyCost = 25;
            AbilityEnergyCost = 5;
            AbilityDamage = 60;
        }
        public override void Cast(Player player)
        {
            
        }
    }
}
