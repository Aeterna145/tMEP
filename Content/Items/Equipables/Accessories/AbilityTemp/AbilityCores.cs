using Terraria.ID;
using Terraria.ModLoader;

namespace MEPMod.Content.Items.Equipables.Accessories.AbilityTemp
{
    public abstract class AbilityCores : ModItem
    {
        public override string Texture => "MEPMod/Assets/ReusedAssets/AbilityCore";
        public override void SetDefaults(){
            Item.width = 20;
            Item.height = 20;

            Item.accessory = true;

            Item.rare = ItemRarityID.LightPurple;
        }
    }
    public class AbsorbanceCore : AbilityCores
    {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Osmosis");
            Tooltip.SetDefault("Temporary alernative ability equippable (until I learn UI)" 
                + "\nAllies within range contribute to Absorbance at half effectiveness.");
        }
    }
}
