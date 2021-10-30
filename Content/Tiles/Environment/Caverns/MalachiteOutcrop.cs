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
                TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
                TileObjectData.addTile(Type);

                MineResist = 8F;
                MinPick = 200;
            }
            private MalachiteGrowthState GetMGrowthState(Tile tile) => (MalachiteGrowthState)(tile.frameX / FrameWidth);
            public override void RandomUpdate(int i, int j){
                Tile tile = Framing.GetTileSafely(i, j);
                MalachiteGrowthState state = GetMGrowthState(tile);
                if (state != MalachiteGrowthState.Grown){
                    int x = i - Main.tile[i, j].frameX / 18 % 3;
                    int y = j - Main.tile[i, j].frameY / 18 % 3;
                    for (int l = x; l < x + 3; l++){
                        for (int m = y; m < y + 3; m++){
                            if (Main.tile[l, m] == null){
                                Main.tile[l, m] = new Tile();
                            }
                            if (Main.tile[l, m].IsActive && Main.tile[l, m].type == Type){
                                if (Main.tile[l, m].frameX < 270){
                                    Main.tile[l, m].frameX += FrameWidth;
                                    state++;
                                }
                            }
                        }
                    }
                }
                if (Main.netMode != NetmodeID.SinglePlayer) NetMessage.SendTileSquare(-1, i, j, 1); 
            }
            public override void KillMultiTile(int i, int j, int frameX, int frameY){
                Tile tile = Framing.GetTileSafely(i, j);
                MalachiteGrowthState state = GetMGrowthState(tile);
                if (state == MalachiteGrowthState.Grown){
                    Item.NewItem(new Vector2(i, j).ToWorldCoordinates(), ModContent.ItemType<MalachiteCrystal>(), Main.rand.Next(3, 9));
                    Item.NewItem(new Vector2(i, j).ToWorldCoordinates(), ModContent.ItemType<MalachiteSeed>(), Main.rand.Next(2));
                }
            }
        }
    }