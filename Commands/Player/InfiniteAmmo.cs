using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class InfiniteAmmo : CheatCommand {
        public static bool Enabled { get; set; }

        public override string Command => "ammo";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.InfiniteAmmo_Description");
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().InfiniteAmmoEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            Enabled = !Enabled;
            return new CommandReply(
                Language.GetTextValue(
                    "Mods.CheatCommands.Commands.InfiniteAmmo_" + (
                    Enabled
                    ? "Enable"
                    : "Disable")));
        }
    }
}
