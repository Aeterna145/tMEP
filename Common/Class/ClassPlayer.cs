using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;
using Terraria.GameInput;
using MEPMod.Common.Class.SubclassAbilities.Cleric;
using Terraria.ModLoader.IO;
using MEPMod.Common.Class.SubclassAbilities.Warlock;

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
                        case 1: //Paladin abilities
                            break;
                        case 2: //Berserker abilities
                            break;
                        case 3: //do nothing
                            break; 
                        case 4: //do nothing
                            break;
                    }
                    break;
                case 2:
                    switch (CurrentSubclass){
                        case 5: //Cleric abilities
                            SetAbilities<Absorbance, UniversalSoul, Wellspring, TimewatchersGrip>();
                            break;
                        case 6: //Warlock abilities
                            SetAbilities<Firestorm, GlacialWrath, SpellOfReaping, CoronalEjection>();
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
            if (player.whoAmI == Main.myPlayer){
                switch (CurrentClass){
                    case 1:
                        player.GetDamage(DamageClass.Melee) += 1.10F;
                        break;
                    case 2:
                        player.GetDamage(DamageClass.Magic) += 1.10F;
                        break;
                    case 3:
                        player.GetDamage(DamageClass.Ranged) += 1.10F;
                        break;
                    case 4:
                        player.GetDamage(DamageClass.Summon) += 1.10F;
                        break;
                }
                switch (CurrentSubclass){
                    case 5: //Cleric
                        player.GetDamage(DamageClass.Magic) += 1.35F;
                        player.statDefense -= 10;
                        player.statLifeMax2 += 50;
                        player.statManaMax2 += 100;
                        break;
                    case 6: //Warlock
                        player.GetDamage(DamageClass.Magic) += 1.50F;
                        player.statDefense += 20;
                        player.statLifeMax2 += 75;
                        player.statManaMax2 += 150;
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
                if (ability is null) continue;
                if (ability is BaseAbility baseAbility && baseAbility.CanCast(Player) && keybind.JustPressed){
                    baseAbility.Cast(Player);
                    Main.NewText(Player.name + " casted " + ability.AbilityName + "!");
                    if (Player.whoAmI == Main.myPlayer){
                        Main.NewText("This ability's damage is " + ability.AbilityDamage);
                        Main.NewText("This ability's energy cost is " + ability.AbilityEnergyCost);
                    }
                }
                if (ability is HoldOutAbility holdOutAbility && keybind.Current){
                    holdOutAbility.Cast(Player);
                    Main.NewText(Player.name + " casted " + ability.AbilityName + "!");
                    if (Player.whoAmI == Main.myPlayer){
                        Main.NewText("This ability's damage is " + ability.AbilityDamage);
                        Main.NewText("This ability's energy cost is " + ability.AbilityEnergyCost);
                    }
                }
                if (ability is ChargeAbility chargeAbility){
                    if (keybind.Current){ 
                        chargeAbility.ChargeTimer--;
                    }
                    if (keybind.JustReleased && chargeAbility.ChargeTimer > 0){
                        if (Player.whoAmI == Main.myPlayer) Main.NewText("Charge timer reset");
                        chargeAbility.AbilityChargeTime = chargeAbility.ResetTimer;
                    }
                    if (chargeAbility.ChargeTimer == 0){
                        chargeAbility.Cast(Player);
                        Main.NewText(Player.name + " casted " + ability.AbilityName + "!");
                        if (Player.whoAmI == Main.myPlayer){
                            Main.NewText("This ability's damage is " + ability.AbilityDamage);
                            Main.NewText("This ability's energy cost is " + ability.AbilityEnergyCost);
                        }
                        chargeAbility.AbilityChargeTime = chargeAbility.ResetTimer;
                    }
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