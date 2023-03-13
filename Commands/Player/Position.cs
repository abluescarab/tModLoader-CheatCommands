using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    public class Position : CheatCommand {
        public override string Command => "pos";
        public override string Description => "Get your current coordinates.";
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().PositionEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            Vector2 pos = caller.Player.Top;
            return new CommandReply($"Current position: {pos.X}, {pos.Y}");
        }
    }
}
