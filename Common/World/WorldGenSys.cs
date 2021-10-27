using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace MEPMod.Common.World
{
    public class WorldGenSys : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight){
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex != -1){
                tasks.Insert(ShiniesIndex + 1, new MalachiteGenPass("Generating Malachite...", 237.4298f));
            }
        }
    }
}
