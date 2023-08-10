using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class InfiniteAmmo : CheatCommand {
        public static bool Enabled { get; set; }

        public override string Command => "ammo";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.InfiniteAmmo.Description");
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().InfiniteAmmoEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            Enabled = !Enabled;
            return new CommandReply(
                Language.GetTextValue(
                    "Mods.CheatCommands.Commands.InfiniteAmmo." + (
                    Enabled
                    ? "Enable"
                    : "Disable")));
        }
    }
}
