using Terraria;
using Terraria.ModLoader;

namespace MEPMod.Common.Class.SubclassAbilities.Warlock
{
    public class SpellOfReaping : HoldOutAbility
    {
        public override void SetStaticDefaults(){
            AbilityName = "Spell of Reaping";
            AbilityDamage = 10;
            AbilityEnergyCost = 20;
        }
        public override void Cast(Player player){
            NPC npc = new();
            const float reqDist = 16 * 20;
            float playerDist = player.DistanceSQ(player.Center);
            if (playerDist < reqDist * reqDist){
                npc.AddBuff(ModContent.BuffType<>(), 300);
            }
        }
    }
}