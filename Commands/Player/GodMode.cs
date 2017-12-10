using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class GodMode : CheatCommand {
        public override string CommandName => "God Mode";
        public override string Command => "god";
        public override string Description => "Enable/disable god mode.";
        public override int MinimumArguments => 0;

        public override void Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();
            player.GodMode = !player.GodMode;

            if(player.GodMode) {
                player.RefillLife();
                player.RefillMana(true);
                player.RemoveDebuffs();
            }

            caller.Reply("God mode " + (player.GodMode ? "enabled" : "disabled") + "!");
        }
    }
}