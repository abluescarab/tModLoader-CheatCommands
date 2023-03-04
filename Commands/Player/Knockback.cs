using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    internal class Knockback : CheatCommand {
        public static bool Enabled { get; set; } = true;

        public override string CommandName => "Toggle Knockback";
        public override string Command => "knockback";
        public override string Description => "Enable/disable knockback.";
        public override int MinimumArguments => 0;
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => CheatCommandsConfig.Instance.KnockbackEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            Enabled = !Enabled;
            return new CommandReply($"Knockback {(Enabled ? "enabled" : "disabled")}.");
        }
    }
}
