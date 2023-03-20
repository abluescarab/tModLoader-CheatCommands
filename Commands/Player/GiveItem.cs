using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class GiveItem : CheatCommand {
        public override string Command => "give";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.GiveItem_Description");
        public override string Usage => base.Usage + " <type/name> [amount] [prefix]";
        public override int MinimumArguments => 1;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().GiveItemEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            int amount = 1;
            int prefixId = 0;

            if(!int.TryParse(args[0], out int itemType)) {
                itemType = CommandUtils.GetItemType(args[0]);
            }

            if(itemType == 0 || itemType >= ItemLoader.ItemCount) {
                return new CommandReply(
                    Language.GetTextValue(
                        "Mods.CheatCommands.Commands.GiveItem_Unknown", 
                        itemType), 
                    Color.Red);
            }

            if(args.Length > 1 && !int.TryParse(args[1], out amount)) {
                amount = 1;
                CommandUtils.GetPrefixType(args[1], out prefixId);
            }

            if(args.Length > 2) {
                CommandUtils.GetPrefixType(args[2], out prefixId);
            }

            Item item = new Item(itemType, prefix: prefixId);
            int maxStack = item.maxStack;
            int adjustedAmount = amount;

            while(adjustedAmount > 0) {
                int spawnAmount = (adjustedAmount > maxStack ? maxStack : adjustedAmount);

                if(prefixId > 0) {
                    caller.Player.QuickSpawnClonedItem(caller.Player.GetSource_Loot(), item, spawnAmount);
                }
                else {
                    caller.Player.QuickSpawnItem(caller.Player.GetSource_Loot(), itemType, spawnAmount);
                }

                adjustedAmount -= maxStack;
            }

            return new CommandReply(
                Language.GetTextValue(
                    "Mods.CheatCommands.Commands.GiveItem_Success",
                    amount,
                    itemType));
        }
    }
}
