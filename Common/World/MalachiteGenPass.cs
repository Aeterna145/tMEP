using MEPMod.Content.Tiles.Environment.Caverns;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace MEPMod.Common.World
{
    public class MalachiteGenPass : GenPass
    {
        public MalachiteGenPass(string name, float loadWeight) : base(name, loadWeight) { }
        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration){
            progress.Message = "Generating Malachite";
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++){
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY);
                WorldGen.TileRunner(x, y, 9, 9, ModContent.TileType<MalachiteOutcrop>());
            }
        }
    }
}