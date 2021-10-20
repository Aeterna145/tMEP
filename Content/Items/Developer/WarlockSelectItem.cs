using MEPMod.Common.Class;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MEPMod.Content.Items.Developer
{
    public class WarlockSelectItem : ModItem
    {
        public override string Texture => "MEPMod/Assets/DevelopingAssets/DevItemPlaceholder";
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Warlock Selection Item");
            Tooltip.SetDefault("Makes you a Warlock" +
                "\nI told you I was gonna add it.");
        }
        public override void SetDefaults(){
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 1;
            Item.useTime = 1;
            Item.useAnimation = 25;

            Item.consumable = true;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item104;
        }
        public override bool? UseItem(Player player){
            switch (player.GetModPlayer<ClassPlayer>().CurrentClass){
                case 1:
                    if (player.whoAmI == Main.myPlayer) Main.NewText("You can't become a Warlock if you aren't a Mage! (Literally how)");
                    return false;
                case 2:
                    switch (player.GetModPlayer<ClassPlayer>().CurrentSubclass){
                        case 5:
                            player.GetModPlayer<ClassPlayer>().CurrentSubclass = 6;
                            Main.NewText(player.name + " became a Warlock!");
                            return true;
                        case 6:
                            if (player.whoAmI == Main.myPlayer) Main.NewText("You're already a Warlock! (Am I talkin' to me?)");
                            return false;
                        default:
                            player.GetModPlayer<ClassPlayer>().CurrentSubclass = 6;
                            Main.NewText(player.name + " became a Warlock!");
                            return true;
                    }
                case 3:
                    return false;
                case 4:
                    return false;
                default:
                    if (player.whoAmI == Main.myPlayer) Main.NewText("You hear the words of a short disgruntled man in your head: 'You suck! You're a no talent!'");
                    return false;
            }
        }
    }
}