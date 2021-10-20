using Terraria;
using Terraria.ModLoader;

namespace MEPMod.Common.Class
{
    public abstract class ChargeAbility : AbilityType
    {
        public int AbilityChargeTime;
        public int ChargeTimer { get => AbilityChargeTime; set => AbilityChargeTime = value; }
        public int ResetTimer { get; set; }
        public override bool CanCast(Player player){
            return base.CanCast(player);
        }
    }
}
