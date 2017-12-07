using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class KillMe : CheatCommand {
        public override string CommandName => "Kill Me";
        public override string Command => "killme";
        public override string Description => "Kill your character.";
        public override int MinimumArguments => 0;

        public override void Action(CommandCaller caller, string[] args) {
            bool godMode = CheatCommands.GodMode;
            CheatCommands.GodMode = false;

            var reason = new PlayerDeathReason() {
                SourceCustomReason = caller.Player.name + " killed " + (caller.Player.Male ? "him" : "her") + "self."
            };

            caller.Player.KillMe(reason, caller.Player.statLifeMax, 0);

            if(godMode) {
                CheatCommands.GodMode = true;
            }
        }
    }
}
