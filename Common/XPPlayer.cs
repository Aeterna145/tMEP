using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MEPMod.Common
{
    public class XPPlayer : ModPlayer
    { //note: properly implement XPSource
        private int LevelMax = 40;
        private int LevelXPReq = 10000;
        public int CurrentLevel;
        private int CurrentXP;
        //note 2: properly explain what's going on here
        public override void SaveData(TagCompound tag){
            tag[nameof(CurrentLevel)] = CurrentLevel;
            tag[nameof(CurrentXP)] = CurrentXP;
        }
        public override void LoadData(TagCompound tag){
            CurrentLevel = tag.Get<int>(nameof(CurrentLevel));
            CurrentXP = tag.Get<int>(nameof(CurrentXP));
        }
        private void CalculateLevel(){
            int storedLevel = CurrentXP / LevelXPReq;
            CurrentLevel = storedLevel;
        }
        public override void PostUpdateMiscEffects(){
            CalculateLevel();
        }
        private void XPSource(NPC npc)
        {
        }
    }
}