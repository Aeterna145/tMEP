using MEPMod.Common.Class;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MEPMod.Content.Items.Developer
{
    public class ClericSelectItem : ModItem
    {
        public override string Texture => "MEPMod/Assets/DevelopingAssets/DevItemPlaceholder";
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Cleric Selection Item");
            Tooltip.SetDefault("Makes you a Cleric" +
                "\nWarlock coming... whenever I get to it.");
        }
        public override void SetDefaults(){
            Item.height = 20;
            Item.width = 20;
            Item.maxStack = 1;
            Item.useTime = 1;
            Item.useAnimation = 25;

            Item.consumable = true;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.NPCDeath9;
        }
        public override bool? UseItem(Player player){
            switch (player.GetModPlayer<ClassPlayer>().CurrentClass){
                case 1:
                    if (player.whoAmI == Main.myPlayer) Main.NewText("You can't become a Cleric if you aren't a Mage! (Literally how)");
                    return false;
                case 2:
                    switch (player.GetModPlayer<ClassPlayer>().CurrentSubclass){
                        case 5:
                            if (player.whoAmI == Main.myPlayer) Main.NewText("You're already a Cleric! (Am I talkin' to me?)");
                            return false;
                        case 6:
                            player.GetModPlayer<ClassPlayer>().CurrentSubclass = 5;
                            Main.NewText(player.name + " became a Cleric!");
                            return true;
                        default:
                            player.GetModPlayer<ClassPlayer>().CurrentSubclass = 5;
                            Main.NewText(player.name + " became a Cleric!");
                            return true;
                    }
                case 3:
                    return false;
                case 4:
                    return false;
                default:
                    if(player.whoAmI == Main.myPlayer) Main.NewText("You hear the words of a short disgruntled man in your head: 'You suck! You're a no talent!'");
                    return false;
            }
        }
    }
}