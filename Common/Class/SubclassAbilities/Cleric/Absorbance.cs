using MEPMod.Content.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace MEPMod.Common.Class.SubclassAbilities.Cleric
{
    public class Absorbance : BaseAbility
    {
        public override void SetStaticDefaults(){ //might add more descriptive data here, maybe specify individual cooldown.
            AbilityName = "Absorbance"; //name is the same (usually)
            AbilityEnergyCost = 50; //cost
        }
        public override void Cast(Player player){ //sometimes casts don't have to be long drawn out things
            if (player.whoAmI == Main.myPlayer){ //depending on the subclass, of course
                player.AddBuff(ModContent.BuffType<AbsorbanceBuff>(), 600); //because cleric is very support intensive, to be fair.
            }
        }
    }
}