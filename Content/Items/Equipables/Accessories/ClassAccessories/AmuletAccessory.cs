using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MEPMod.Content.Items.Equipables.Accessories.ClassAccessories
{
    public class EmptyAmulet : ModItem
    {
        public override void SetDefaults(){
            Item.width = 20;
            Item.height = 20;
            Item.value = 10000;

            Item.accessory = true;

            Item.rare = ItemRarityID.White;
        }
    }
    public class AmuletOfPoleia : EmptyAmulet
    {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Amulet of Poleia");
            Tooltip.SetDefault("A once empty amulet, now imbued with the powers of Carnelian.");
        }
        public override void UpdateEquip(Player player)
        {
            
        }
    }
    public class AmuletOfGwyd : EmptyAmulet
    {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Amulet of Gwyd");
            Tooltip.SetDefault("A once empty amulet, now imbued with the powers of Aquamarine.");
        }
    }
    public class AmuletOfKedes : EmptyAmulet
    {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Amulet of Kedes");
            Tooltip.SetDefault("A once empty amulet, now imbued with the powers of Jade.");
        }
    }
    public class AmuletOfElos : EmptyAmulet
    {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Amulet of Elos");
            Tooltip.SetDefault("A once empty amulet, now imbued with the powers of Citrine.");
        }
    }
}
