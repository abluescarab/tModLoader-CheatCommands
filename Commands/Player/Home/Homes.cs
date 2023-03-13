using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player.Home {
    public class Homes : CheatCommand {
        public override string Command => "homes";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.Homes_Description");
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().HomeEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();
            IEnumerable<string> homes = player.Homes.GetWorldHomes().Select(h => h.Name);

            if(homes.Count() > 0) {
                return new CommandReply(
                    Language.GetTextValue(
                        "Mods.CheatCommands.Commands.Homes_Current",
                        string.Join(", ", homes)));
            }
            else {
                return new CommandReply(
                    Language.GetTextValue("Mods.CheatCommands.Commands.Homes_None"));
            }
        }
    }
}
