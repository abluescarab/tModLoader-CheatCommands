using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class GiveCoins : CheatCommand {
        public override string Command => "coins";
        public override string Description => "Give yourself money.";
        public override string Usage => base.Usage + " <platinum> <gold> <silver> <copper>";
        public override int MinimumArguments => 4;
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().GiveCoinsEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            int platinum = 0;
            int gold = 0;
            int silver = 0;
            int copper = 0;

            if(!int.TryParse(args[0], out platinum)) {
                return new CommandReply($"Invalid number: {args[0]}", Color.Red);
            }

            if(!int.TryParse(args[1], out gold)) {
                return new CommandReply($"Invalid number: {args[1]}", Color.Red);
            }

            if(!int.TryParse(args[2], out silver)) {
                return new CommandReply($"Invalid number: {args[2]}", Color.Red);
            }

            if(!int.TryParse(args[3], out copper)) {
                return new CommandReply($"Invalid number: {args[3]}", Color.Red);
            }

            if(platinum == 0 && gold == 0 && silver == 0 && copper == 0) {
                return new CommandReply($"No coins given.", Color.Red);
            }

            caller.Player.QuickSpawnItem(caller.Player.GetSource_Loot(), ItemID.PlatinumCoin, platinum);
            caller.Player.QuickSpawnItem(caller.Player.GetSource_Loot(), ItemID.GoldCoin, gold);
            caller.Player.QuickSpawnItem(caller.Player.GetSource_Loot(), ItemID.SilverCoin, silver);
            caller.Player.QuickSpawnItem(caller.Player.GetSource_Loot(), ItemID.CopperCoin, copper);

            return new CommandReply(
                "Gave you " +
                Join(", ", new List<string>() {
                    (platinum > 0 ? platinum + " platinum" : ""),
                    (gold > 0 ? gold + " gold" : ""),
                    (silver > 0 ? silver + " silver" : ""),
                    (copper > 0 ? copper + " copper" : "")
                }) +
                ".");
        }

        private string Join(string separator, List<string> strings) {
            strings.RemoveAll(m => string.IsNullOrEmpty(m));
            return string.Join(separator, strings);
        }
    }
}
