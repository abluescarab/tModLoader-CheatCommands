using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player.Home {
    internal class ClearHomes : CheatCommand {
        public override string Command => "clearhomes";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.ClearHomes_Description");
        public override string Usage => base.Usage + " <world/all>";
        public override int MinimumArguments => 1;
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().HomeEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();

            string delete = args[0].ToLower();
            int cleared = 0;

            if(delete == "world") {
                cleared = player.Homes.ClearWorld();
            }
            else if(delete == "all") {
                cleared = player.Homes.Clear();
            }
            else {
                return new CommandReply("Invalid argument.", Color.Red);
            }

            return new CommandReply($"Cleared {cleared} home(s).");
        }
    }
}
