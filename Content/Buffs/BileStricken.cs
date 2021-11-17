using Terraria;
using Terraria.ModLoader;

namespace MEPMod.Content.Buffs
{
    public class BileStricken : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bile-Stricken");
            Description.SetDefault("You suddenly feel weaker...");

            Main.debuff[Type] = true;
            CanBeCleared = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            
        }
    }
}