using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Warlock
{
    public class GlacialWrath : BaseAbility
    {
        public override void SetStaticDefaults(){
            AbilityName = "Glacial Wrath";
            AbilityDamage = 35;
            AbilityEnergyCost = 45;
        }
        public override void Cast(Player player){
        }
    }
}
