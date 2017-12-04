using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.World {
    class Noon : CheatCommand {
        public override string CommandName => "Noon";
        public override string Command => Language.GetTextValue("CLI.Noon_Command");
        public override string Description => "Set world time to noon.";
        public override int MinimumArguments => 0;

        // from Terraria server commands
        public override void Action(CommandCaller caller, string[] args) {
            Main.dayTime = true;
            Main.time = 27000.0;
        }
    }
}
