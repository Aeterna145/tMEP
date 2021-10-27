using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.ID;
using MEPMod.Content.Items.Materials;

namespace MEPMod.Content.Tiles.Environment.Caverns
{
    public class MalachiteOutcrop : ModTile
    {
        private const int FrameWidth = 54;
        private const int FrameHeight = 56;
        public enum MalachiteGrowthState : byte
        {
            Base,
            Budding,
            Growing1,
            Growing2,
            Grown
        }
        public override void SetStaticDefaults(){
            Main.tileOreFinderPriority[Type] = 500;
            Main.tileShine[Type] = 1230;

            Main.tileSpelunker[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileWaterDeath[Type] = false;
            Main.tileLavaDeath[Type] = false;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Malachite Outcrop");
            AddMapEntry(Color.SeaGreen, name);

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);

            MineResist = 4F;
            MinPick = 200;

        }
        private MalachiteGrowthState GetMGrowthState(int i, int j){
            Tile tile = Framing.GetTileSafely(i, j);
            return (MalachiteGrowthState)(tile.frameX / FrameWidth);
        }
        public override void RandomUpdate(int i, int j){
            Tile tile = Framing.GetTileSafely(i, j);
            MalachiteGrowthState state = GetMGrowthState(i, j);
            int x = tile.frameX % FrameWidth;
            int y = tile.frameY % FrameHeight;
            if (state != MalachiteGrowthState.Grown){
                const int width = 3;
                const int height = 3;
                for (int ii = 0; ii < width; ii++)
                    for (int jj = 0; jj < height; jj++)
                        Main.tile[i + ii - x, j + jj + y].frameX += FrameWidth;
            }
            if (Main.netMode != NetmodeID.SinglePlayer) NetMessage.SendTileSquare(-1, i, j, 1);
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY){
            MalachiteGrowthState state = GetMGrowthState(i, j);
            if (state == MalachiteGrowthState.Grown){
                Item.NewItem(new Vector2(i, j).ToWorldCoordinates(), ModContent.ItemType<MalachiteCrystal>(), Main.rand.Next(3, 9));
                Item.NewItem(new Vector2(i, j).ToWorldCoordinates(), ModContent.ItemType<MalachiteSeed>(), Main.rand.Next(0, 2));
            }
        }
    }
}