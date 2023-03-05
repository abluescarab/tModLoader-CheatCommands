using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class Respawn : CheatCommand {
        public override string Command => "respawn";
        public override string Description => "Respawn your character.";
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => CheatCommandsConfig.Instance.KillMeEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();
            PlayerDeathReason reason = new PlayerDeathReason() {
                SourceCustomReason = $"{caller.Player.name} respawned."
            };
            
            bool godMode = GodMode.Enabled;

            GodMode.Enabled = false;
            caller.Player.KillMe(reason, caller.Player.statLifeMax, 0);
            GodMode.Enabled = godMode;

            return CommandReply.Empty;
        }
    }
}
