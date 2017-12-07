using Terraria.ModLoader;

namespace CheatCommands.Commands.World {
    class FreezeTime : CheatCommand {
        public override string CommandName => "Freeze Time";
        public override string Command => "freeze";
        public override string Description => "Freeze/unfreeze world time.";
        public override int MinimumArguments => 0;

        // based on HERO's mod
        public override void Action(CommandCaller caller, string[] args) {
            CheatCommands.TimeFrozen = !CheatCommands.TimeFrozen;
            caller.Reply("Time has been " + (CheatCommands.TimeFrozen ? "frozen" : "unfrozen") + "!");
        }
    }
}
