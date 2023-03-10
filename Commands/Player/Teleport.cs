using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    internal class Teleport : CheatCommand {
        public override string Command => "tp";
        public override string Description => "Teleport yourself to a coordinate or another player.";
        public override string Usage => base.Usage + " <player>/<x> <y>";
        public override int MinimumArguments => 1;
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().TeleportEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();
            int x = -1;
            int y = -1;

            if(args.Length == 1) {
                string playerName = args[0];

                if(playerName == caller.Player.name) {
                    return new CommandReply("Cannot teleport to your current position.", Color.Red);
                }

                int otherPlayer = Array.FindIndex(Main.player, p => p.name == playerName);

                if(otherPlayer == -1) {
                    return new CommandReply($"Player {playerName} not found.", Color.Red);
                }

                x = (int)Main.player[otherPlayer].position.X;
                y = (int)Main.player[otherPlayer].position.Y;
            }
            else {
                if(!int.TryParse(args[0], out x)) {
                    return new CommandReply($"Invalid x value.", Color.Red);
                }

                if(!int.TryParse(args[1], out y)) {
                    return new CommandReply($"Invalid y value.", Color.Red);
                }

                if(x == caller.Player.position.X 
                    && y == caller.Player.position.Y) {
                    return new CommandReply("Cannot teleport to your current position.", Color.Red);
                }
            }

            caller.Player.Teleport(new Vector2(x, y));
            return new CommandReply($"Teleported you to {x}, {y}.");
        }
    }
}
