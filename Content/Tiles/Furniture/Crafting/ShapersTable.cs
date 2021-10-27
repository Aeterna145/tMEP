using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using Terraria.Enums;
using Terraria.DataStructures;
using MEPMod.Content.Items.Placeable.Crafting;

namespace MEPMod.Content.Tiles.Furniture.Crafting
{
    public class ShapersTable : ModTile
    {
        public override void SetStaticDefaults(){
            Main.tileFrameImportant[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileNoAttach[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Shaper's Table");
            AddMapEntry(new Color(20, 150, 50), name);

            AnimationFrameHeight = 56;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b){
            r = 0.0F;
            g = 0.7F;
            b = 0.3F;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY){
            Item.NewItem(i * 16, j * 16, 48, 48, ModContent.ItemType<ShapersTableItem>(), 1);
        }
        public override void AnimateTile(ref int frame, ref int frameCounter){
            frameCounter++;
            if (frameCounter >= 15){
                frameCounter = 0;
                frame++;
                if (frame >= 4) frame = 0;
            }
        }
    }
}