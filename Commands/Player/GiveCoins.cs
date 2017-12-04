using System.Collections.Generic;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class GiveCoins : CheatCommand {
        public override string CommandName => "Give Coins";
        public override string Command => "coins";
        public override string Description => "Give yourself money.";
        public override string Usage => base.Usage + " <platinum> <gold> <silver> <copper>";
        public override int MinimumArguments => 4;

        public override void Action(CommandCaller caller, string[] args) {
            int platinum = 0;
            int gold = 0;
            int silver = 0;
            int copper = 0;

            if(!int.TryParse(args[0], out platinum)) {
                throw new UsageException("Invalid number: " + args[0]);
            }

            if(!int.TryParse(args[1], out gold)) {
                throw new UsageException("Invalid number: " + args[1]);
            }

            if(!int.TryParse(args[2], out silver)) {
                throw new UsageException("Invalid number: " + args[2]);
            }

            if(!int.TryParse(args[3], out copper)) {
                throw new UsageException("Invalid number: " + args[3]);
            }

            if(platinum == 0 && gold == 0 && silver == 0 && copper == 0) {
                throw new UsageException();
            }

            caller.Player.QuickSpawnItem(ItemID.PlatinumCoin, platinum);
            caller.Player.QuickSpawnItem(ItemID.GoldCoin, gold);
            caller.Player.QuickSpawnItem(ItemID.SilverCoin, silver);
            caller.Player.QuickSpawnItem(ItemID.CopperCoin, copper);

            caller.Reply(
                "Gave you " +
                Join(", ", new List<string>() {
                    (platinum > 0 ? platinum + " platinum" : ""),
                    (gold > 0 ? gold + " gold" : ""),
                    (silver > 0 ? silver + " silver" : ""),
                    (copper > 0 ? copper + " copper" : "")
                }) +
                "!");
        }

        private string Join(string separator, List<string> strings) {
            strings.RemoveAll(m => string.IsNullOrEmpty(m));
            return string.Join(separator, strings);
        }
    }
}