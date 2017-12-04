using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class GiveItem : CheatCommand {
        public override string CommandName => "Give Item";
        public override string Command => "give";
        public override string Description => "Give yourself an item.";
        public override string Usage => base.Usage + " <type/name> [amount]";
        public override int MinimumArguments => 1;

        public override void Action(CommandCaller caller, string[] args) {
            int itemType = 0;
            int amount = 1;

            if(!int.TryParse(args[0], out itemType)) {
                itemType = CommandUtils.GetItemType(args[0]);
            }

            if(itemType == 0 || itemType >= ItemLoader.ItemCount) {
                throw new UsageException("Unknown item type: " + itemType);
            }

            if(args.Length > 1) {
                if(!int.TryParse(args[0], out amount)) {
                    amount = 1;
                }
            }

            caller.Player.QuickSpawnItem(itemType, amount);
            caller.Reply("Gave you item type " + itemType + ".");
        }
    }
}
