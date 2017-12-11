using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class KillMe : CheatCommand {
        public override string CommandName => "Kill Me";
        public override string Command => "killme";
        public override string Description => "Kill your character.";
        public override int MinimumArguments => 0;
        public override CommandType Type => CommandType.Chat;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();
            PlayerDeathReason reason = new PlayerDeathReason() {
                SourceCustomReason = caller.Player.name + " killed " + (caller.Player.Male ? "him" : "her") + "self."
            };

            bool godMode = player.GodMode;
            player.GodMode = false;

            caller.Player.KillMe(reason, caller.Player.statLifeMax, 0);

            if(godMode) {
                player.GodMode = true;
            }
            
            return CommandReply.Empty;
        }
    }
}
