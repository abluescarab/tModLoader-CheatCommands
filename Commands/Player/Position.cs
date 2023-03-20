using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    public class Position : CheatCommand {
        public override string Command => "pos";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.Position_Description");
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().PositionEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            Vector2 pos = caller.Player.Top;
            return new CommandReply(
                Language.GetTextValue(
                    "Mods.CheatCommands.Commands.Position_Reply",
                    pos.X,
                    pos.Y));
        }
    }
}
