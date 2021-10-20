using System;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MEPMod.Common
{
    public class PINPlayer : ModPlayer
    {
        //The PIN Value is a value that is set when using a certain item.
        //Once set, the PIN Value cannot be changed, and its item cannot be reused.
        //Most PIN Values don't have defined effects, however certain ones do.
        //PIN Values can only be between 0-99. More may be added in the future.
        //Fun fact: PIN stands for "Player Individualizing Number".
        private int CurrentPINValue;
        public override void SaveData(TagCompound tag) => tag[nameof(CurrentPINValue)] = CurrentPINValue;
        public override void LoadData(TagCompound tag) => CurrentPINValue = tag.Get<int>(nameof(CurrentPINValue));

        public void PINValueEffects(){
            switch (CurrentPINValue){
                case 0: 
                    break;
                case 1:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 10:
                    break;
                case 33:
                    Environment.Exit(0);
                    break;
                case 69:
                    break;
                case 99:
                    break;
                case 100:
                    break;
                default:
                    break;
            }
        }
    }
}