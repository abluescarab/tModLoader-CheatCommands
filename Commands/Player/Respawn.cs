using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class Respawn : CheatCommand {
        public override string Command => "respawn";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.Respawn.Description");
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().KillMeEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();
            PlayerDeathReason reason = new PlayerDeathReason() {
                SourceCustomReason = Language.GetTextValue(
                    "Mods.CheatCommands.Commands.Respawn.DeathReason",
                    caller.Player.name)
            };

            bool godMode = GodMode.Enabled;

            GodMode.Enabled = false;
            caller.Player.KillMe(reason, caller.Player.statLifeMax, 0);
            GodMode.Enabled = godMode;

            return CommandReply.Empty;
        }
    }
}
