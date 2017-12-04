using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.World {
    class Dawn : CheatCommand {
        public override string CommandName => "Dawn";
        public override string Command => Language.GetTextValue("CLI.Dawn_Command");
        public override string Description => "Set world time to dawn.";
        public override int MinimumArguments => 0;

        // from Terraria server commands
        public override void Action(CommandCaller caller, string[] args) {
            Main.dayTime = true;
            Main.time = 0.0;
        }
    }
}
