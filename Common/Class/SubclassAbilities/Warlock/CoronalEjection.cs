using Terraria;

namespace MEPMod.Common.Class.SubclassAbilities.Warlock
{
    public class CoronalEjection : BaseAbility
    {
        private int EjectionTimer = 300;
        public override void SetStaticDefaults(){
            AbilityName = "Coronal Ejection";
            AbilityDamage = 250;
            AbilityEnergyCost = 150;
        }
        public override void Cast(Player player){
            EjectionTimer--;
            if (EjectionTimer > 0)
            {
                //do projectile shit here
            }
            if (EjectionTimer < 0)
            {
                //end projectile here
                EjectionTimer = 300;
            }
        }
    }
}