using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class InfiniteAmmo : CheatCommand {
        public override string CommandName => "Infinite Ammo";
        public override string Command => "ammo";
        public override string Description => "Enable/disable infinite ammo.";
        public override int MinimumArguments => 0;

        public override void Action(CommandCaller caller, string[] args) {
            CheatCommands.InfiniteAmmo = !CheatCommands.InfiniteAmmo;
            caller.Reply("Infinite ammo " + (CheatCommands.InfiniteAmmo ? "enabled" : "disabled") + "!");
        }
    }
}