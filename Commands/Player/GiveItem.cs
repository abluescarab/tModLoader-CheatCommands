using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class GiveItem : CheatCommand {
        public override string Command => "give";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.GiveItem_Description");
        public override string Usage => base.Usage + " <type/name> [amount]";
        public override int MinimumArguments => 1;
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().GiveItemEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            int itemType = 0;
            int maxStack = 99;
            int amount = 1;

            if(!int.TryParse(args[0], out itemType)) {
                itemType = CommandUtils.GetItemType(args[0]);
            }

            if(itemType == 0 || itemType >= ItemLoader.ItemCount) {
                return new CommandReply($"Unknown item type: {itemType}", Color.Red);
            }
            else {
                Item item = new Item();
                item.SetDefaults(itemType);
                maxStack = item.maxStack;
            }

            if(args.Length > 1) {
                if(!int.TryParse(args[1], out amount)) {
                    amount = 1;
                }
            }

            int adjustedAmount = amount;

            while(adjustedAmount > 0) {
                int spawnAmount = (adjustedAmount > maxStack ? maxStack : adjustedAmount);

                caller.Player.QuickSpawnItem(caller.Player.GetSource_Loot(), itemType, spawnAmount);
                adjustedAmount -= maxStack;
            }

            return new CommandReply($"Gave you {amount} of item type {itemType}.");
        }
    }
}
