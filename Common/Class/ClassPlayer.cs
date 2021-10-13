using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;
using Terraria.GameInput;
using MEPMod.Common.Class.SubclassAbilities.Cleric;
using Terraria.ModLoader.IO;

namespace MEPMod.Common.Class
{
    public class ClassPlayer : ModPlayer
    {
        //Energy vars
        public int EnergyCurrent;
        public int EnergyMax;
        public int EnergyRegen;

        //Class / subclass vars
        public int CurrentClass { get; internal set; }
        public int CurrentSubclass { get; internal set; }
        //Hotkey vars
        public static ModKeybind tempSubclassSwitch;
        private (ModKeybind keybind, AbilityType ability)[] AbilityKeybinds = null!;
        public override void Load(){
            AbilityKeybinds = new (ModKeybind, AbilityType)[]{
                (KeybindLoader.RegisterKeybind(Mod, "First Ability", Keys.Z), null),
                (KeybindLoader.RegisterKeybind(Mod, "Second Ability", Keys.X), null),
                (KeybindLoader.RegisterKeybind(Mod, "Third Ability", Keys.V), null),
                (KeybindLoader.RegisterKeybind(Mod, "Ultimate Ability", Keys.F), null)
            };
        }
        public override void SaveData(TagCompound tag){
            tag[nameof(CurrentClass)] = CurrentClass;
            tag[nameof(CurrentSubclass)] = CurrentSubclass;
        }
        public override void LoadData(TagCompound tag){
            CurrentClass = tag.Get<int>(nameof(CurrentClass));
            CurrentSubclass = tag.Get<int>(nameof(CurrentSubclass));
        }
        public virtual void AbilitySwitch(){
            switch (CurrentClass){
                case 1:
                    switch (CurrentSubclass){
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                    break;
                case 2:
                    switch (CurrentSubclass){
                        case 5:
                            SetAbilities<Absorbance, UniversalSoul, Wellspring, TimewatchersGrip>();
                            break;
                        case 6:
                            break;
                        case 7: //Do nothing
                            break;
                        case 8: //Do nothing
                            break;
                    }
                    break;
            }
        }
        public virtual void SetHandler(Player player) {
            for (int i = 0; i < Main.maxPlayers; i++){
                switch (CurrentClass){
                    case 1:
                        Main.player[i].GetDamage(DamageClass.Melee) += 1.10F;
                        break;
                    case 2:
                        Main.player[i].GetDamage(DamageClass.Magic) += 1.10F;
                        break;
                    case 3:
                        Main.player[i].GetDamage(DamageClass.Ranged) += 1.10F;
                        break;
                    case 4:
                        Main.player[i].GetDamage(DamageClass.Summon) += 1.10F;
                        break;
                }
                switch (CurrentSubclass){
                    case 5: //Cleric
                        Main.player[i].GetDamage(DamageClass.Magic) += 1.35F;
                        Main.player[i].statDefense -= 10;
                        Main.player[i].statLifeMax2 += 50;
                        Main.player[i].statManaMax2 += 100;
                        break;
                    case 6: //Warlock
                        break;
                    case 7: //CONFIDENTIAL (EW)
                        break;
                    case 8: //CONFIDENTIAL (MR)
                        break;
                }
            }
        }
        public override void ProcessTriggers(TriggersSet triggersSet) {
            foreach ((ModKeybind keybind, AbilityType ability) in AbilityKeybinds) {
                if (!keybind.JustPressed || ability is null) continue;
                if (ability.CanCast(Player)){
                    ability.Cast(Player);
                    Main.NewText(Player.name + " casted " + ability.AbilityName + "!");
                }
            }
        }
        public void SetAbilities<T1, T2, T3, T4>() 
            where T1 : AbilityType 
            where T2 : AbilityType
            where T3 : AbilityType
            where T4 : AbilityType
        {
            AbilityKeybinds[0].ability = ModContent.GetInstance<T1>();
            AbilityKeybinds[1].ability = ModContent.GetInstance<T2>();
            AbilityKeybinds[2].ability = ModContent.GetInstance<T3>();
            AbilityKeybinds[3].ability = ModContent.GetInstance<T4>();
        }
        public override void PostUpdateBuffs() => SetHandler(Player);
        public override void PostUpdateMiscEffects(){
            AbilitySwitch();
        }
        public override void Unload(){
            AbilityKeybinds = null!;
        }
    }
    //Credit to ExterminatorX99 for help with the code.

    //Enums (not actually being used, just for guidance)
    public enum ClassID
    {
        None,
        Melee,
        Mage,
        Ranger,
        Summoner
    }
    public enum SubclassID
    {
        None,
        //Melee
        Paladin,
        Berserker,
        EWSubclass1,
        MRSubclass1,
        //Mage
        Cleric,
        Warlock,
        EWSubclass2,
        MRSubclass2,
        //Ranger
        Marksman,
        Gunner,
        EWSubclass3,
        MRSubclass3,
        //Summoner
        Whisperer,
        Projector,
        EWSubclass4,
        MRSubclass4,
    }
}