using MEPMod.Content.Tiles.Furniture.Crafting;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace MEPMod.Content.Items.Placeable.Crafting
{
    public class ShapersTableItem : ModItem
    {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Shaper's Table");
            Tooltip.SetDefault("Allows you to craft ancient technologies");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults(){
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.value = 0;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.createTile = ModContent.TileType<ShapersTable>();
        }
    }
}
