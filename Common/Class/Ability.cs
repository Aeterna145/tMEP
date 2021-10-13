using Terraria;
using Terraria.ModLoader;

namespace MEPMod.Common.Class
{
    public abstract class AbilityType : ModType
    {
        /// <summary>
        /// Internal / display name of the ability.
        /// </summary>
        public string AbilityName { get; internal set; }

        /// <summary>
        /// The amount of energy this ability costs to cast.
        /// </summary>
        public int? AbilityEnergyCost { get; internal set; }

        /// <summary>
        /// How much damage the ability does (if applicable).
        /// </summary>
        public int? AbilityDamage { get; internal set; }

        /// <summary>
        /// How long it will take to recast the ability (if applicable).
        /// </summary>
        public int? AbilityCastCooldown { get; internal set; }

        /// <summary>
        /// Whether this ability is toggleable (switched on or off)
        /// </summary>
        public bool IsToggle { get; internal set; }

        /// <summary>
        /// Whether this ability is held to cast (continuous cast / charge up)
        /// </summary>
        public bool IsHoldout { get; internal set; }

        /// <summary>
        /// Whether this ability has alternative functions (uses a different key to swap functionality)
        /// </summary>
        public bool HasAltFunc { get; internal set; }
        protected sealed override void Register(){ //registers modtype
            ModTypeLookup<AbilityType>.Register(this);
        }
        public sealed override void SetupContent(){ //sets up static and nonstatic defaults
            SetStaticDefaults();
            SetDefaults();
        }   
        public sealed override void Load(){ //loads
            base.Load();
        }
        public sealed override void Unload(){ //unloads
            base.Unload();
        }
        public virtual void SetDefaults(){ //sets defaults when not set while overidden
            AbilityDamage = null;
            AbilityEnergyCost = null;
            AbilityCastCooldown = null;
            IsToggle = false;
            IsHoldout = false;
            HasAltFunc = false;
        }
        /// <summary>
        /// Whether or not this ability can be cast. Returns true by default unless the player is dead or inactive.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public virtual bool CanCast(Player player){
            for (int i = 0; i < Main.maxPlayers; i++){
                if (Main.player[i].dead || !Main.player[i].active) return false;
                else return true;
            }
            return true;
        }
        /// <summary>
        /// What this ability does when casted. (As an example, create projectiles or entities)
        /// </summary>
        /// <param name="player"></param>
        public abstract void Cast(Player player);

        //Credit to ExterminatorX99 for help with the code.
        //Credit to Mirsario for the framework concept.
    }
}