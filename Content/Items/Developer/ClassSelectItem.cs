using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MEPMod.Common.Class;
using Terraria.ModLoader.IO;

namespace MEPMod.Content.Items.Developer
{
    public class ClassSelectItem : ModItem
    {
        public override string Texture => "MEPMod/Assets/DevelopingAssets/DevItemPlaceholder";
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Class Selection Item");
            Tooltip.SetDefault("Makes you a Mage" +
                "\n'Boo hoo, my selection.' Cry about it");
        }
        public override void SetDefaults(){
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 1;
            Item.useTime = 25;
            Item.useAnimation = 25;

            Item.consumable = true;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item1;
        }
        public override bool? UseItem(Player player){
            switch (player.GetModPlayer<ClassPlayer>().CurrentClass){
                case 1:
                    Main.NewText("You're already a Mage! (How'd you even access this?)");
                    return false;
                case 2:
                    Main.NewText("You're already a Mage! (Am I talkin' to me?)");
                    return false;
                case 3:
                    Main.NewText("You're already a Mage! (How'd you even access this?)");
                    return false;
                case 4:
                    Main.NewText("You're already a Mage! (How'd you even access this?)");
                    return false;
                default:
                    player.GetModPlayer<ClassPlayer>().CurrentClass = 2;
                    Main.NewText(player.name + " became a Mage!");
                    return true;
            }
        }
    }
}