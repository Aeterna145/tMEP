using MEPMod.Content.UI;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace MEPMod.Common.System
{ //note: I hate UI
    public class UISystem : ModSystem
    {
        private UserInterface _abilityEnergyUserInterface;
        internal AbilityEnergyBar abilityEnergyBar;
        private GameTime _lastGameTime;
        public override void Load(){
            if (!Main.dedServ){
                abilityEnergyBar = new AbilityEnergyBar();
                _abilityEnergyUserInterface = new UserInterface();
                _abilityEnergyUserInterface.SetState(abilityEnergyBar);
            }
            abilityEnergyBar.Activate();
        }
        public override void UpdateUI(GameTime gameTime){
            _lastGameTime = gameTime;
            if (_abilityEnergyUserInterface?.CurrentState != null) abilityEnergyBar.Update(gameTime);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers){
            int mouseIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseIndex != -1){
                layers.Insert(mouseIndex, new LegacyGameInterfaceLayer("MEPMod: abilityEnergyBar",
                    delegate{
                        if (_lastGameTime != null && _abilityEnergyUserInterface.CurrentState != null){
                            _abilityEnergyUserInterface.Draw(Main.spriteBatch, _lastGameTime);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }
        public override void Unload(){
            abilityEnergyBar = null;
        }
    }
}
