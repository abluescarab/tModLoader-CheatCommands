using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.World {
    class Dusk : CheatCommand {
        public override string CommandName => "Dusk";
        public override string Command => Language.GetTextValue("CLI.Dusk_Command");
        public override string Description => "Set world time to dusk.";
        public override int MinimumArguments => 0;

        // from Terraria server commands
        public override void Action(CommandCaller caller, string[] args) {
            Main.dayTime = false;
            Main.time = 0.0;
        }
    }
}
