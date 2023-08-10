using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.World {
    class FreezeTime : CheatCommand {
        public override string Command => "freeze";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.FreezeTime.Description");
        public override CommandType Type => CommandType.World;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().FreezeTimeEnabled;

        // based on HERO's mod
        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsSystem.TimeFrozen = !CheatCommandsSystem.TimeFrozen;
            return new CommandReply(
                Language.GetTextValue("Mods.CheatCommands.Commands.FreezeTime." + (
                CheatCommandsSystem.TimeFrozen
                ? "Enable"
                : "Disable"
                ),
                caller.Player.name));
        }
    }
}
