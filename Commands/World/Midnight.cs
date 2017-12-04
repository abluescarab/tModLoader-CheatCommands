using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.World {
    class Midnight : CheatCommand {
        public override string CommandName => "Midnight";
        public override string Command => Language.GetTextValue("CLI.Midnight_Command");
        public override string Description => "Set world time to midnight.";
        public override int MinimumArguments => 0;

        // from Terraria server commands
        public override void Action(CommandCaller caller, string[] args) {
            Main.dayTime = false;
            Main.time = 16200.0;
        }
    }
}
