using Terraria.ID;
using Terraria.ModLoader;

namespace MEPMod.Content.Items.Materials.ATDWeaponCraftingMats
{
    public abstract class ATDWeaponMats : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 5;
            Item.value = 10000;

            Item.material = true;

            Item.rare = ItemRarityID.Orange;
        }
    }
}
