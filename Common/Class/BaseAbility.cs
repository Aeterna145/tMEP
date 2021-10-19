using Terraria;

namespace MEPMod.Common.Class
{
    public abstract class BaseAbility : AbilityType
    {
        public override bool CanCast(Player player){
            return base.CanCast(player);
        }
    }
}