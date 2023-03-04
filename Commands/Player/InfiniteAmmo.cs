using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class InfiniteAmmo : CheatCommand {
        public static bool Enabled { get; set; }

        public override string CommandName => "Infinite Ammo";
        public override string Command => "ammo";
        public override string Description => "Enable/disable infinite ammo.";
        public override int MinimumArguments => 0;
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => CheatCommandsConfig.Instance.InfiniteAmmoEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            Enabled = !Enabled;
            return new CommandReply($"Infinite ammo {(Enabled ? "enabled" : "disabled")}.");
        }
    }
}