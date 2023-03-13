using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player.Home {
    public class Homes : CheatCommand {
        public override string Command => "homes";
        public override string Description => "List available homes in this world.";
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().HomeEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();
            IEnumerable<string> homes = player.Homes.GetWorldHomes().Select(h => h.Name);

            if(homes.Count() > 0) {
                return new CommandReply($"Current homes: {string.Join(", ", homes)}");
            }
            else {
                return new CommandReply("No homes added.");
            }
        }
    }
}
