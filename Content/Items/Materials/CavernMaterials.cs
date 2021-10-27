using MEPMod.Content.Tiles.Environment.Caverns;
using Terraria.ID;
using Terraria.ModLoader;

namespace MEPMod.Content.Items.Materials
{
    public abstract class CavernMaterials : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
        }
    }
    public class MalachiteCrystal : CavernMaterials
    {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Malachite Crystal");
            Tooltip.SetDefault("A glowing sea green crystal" 
                + "\nIt pulses with radiant energy"
                + "\nAlternatively restores ability energy when consumed");
        }
        public override void SetDefaults(){
            Item.value = 100000;
            Item.maxStack = 99;

            Item.consumable = true;
            Item.material = true;

            Item.rare = ItemRarityID.Orange;
        }
    }
    public class MalachiteSeed : CavernMaterials
    {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Malachite Seed");
            Tooltip.SetDefault("A crystal seed"
                + "\nPlant to grow Malachite crystals");
        }
        public override void SetDefaults(){
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.value = 100000000;
            Item.maxStack = 99;

            Item.material = true;

            Item.rare = ItemRarityID.Orange;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.createTile = ModContent.TileType<MalachiteOutcrop>();
        }
    }
}