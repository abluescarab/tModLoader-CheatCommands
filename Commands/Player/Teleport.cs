using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    public class Teleport : CheatCommand {
        public override string Command => "tp";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.Teleport_Description");
        public override string Usage => base.Usage + " <player>/<x> <y>";
        public override int MinimumArguments => 1;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().TeleportEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();
            int x = -1;
            int y = -1;

            if(args.Length == 1) {
                string playerName = args[0];

                if(playerName == caller.Player.name) {
                    return new CommandReply(
                        Language.GetTextValue("Mods.CheatCommands.Commands.Teleport_SamePosition"),
                        Color.Red);
                }

                int otherPlayer = Array.FindIndex(Main.player, p => p.name == playerName);

                if(otherPlayer == -1) {
                    return new CommandReply(
                        Language.GetTextValue(
                            "Mods.CheatCommands.Commands.Teleport_PlayerNotFound",
                            playerName),
                        Color.Red);
                }

                x = (int)Main.player[otherPlayer].position.X;
                y = (int)Main.player[otherPlayer].position.Y;
            }
            else {
                if(!int.TryParse(args[0], out x)) {
                    return new CommandReply(
                        Language.GetTextValue(
                            "Mods.CheatCommands.Invalid",
                            "x"),
                        Color.Red);
                }

                if(!int.TryParse(args[1], out y)) {
                    return new CommandReply(
                        Language.GetTextValue(
                            "Mods.CheatCommands.Invalid",
                            "y"),
                        Color.Red);
                }

                if(x == caller.Player.position.X
                    && y == caller.Player.position.Y) {
                    return new CommandReply(
                        Language.GetTextValue("Mods.CheatCommands.Commands.Teleport_SamePosition"), 
                        Color.Red);
                }
            }

            caller.Player.Teleport(new Vector2(x, y));
            return new CommandReply(
                Language.GetTextValue(
                    "Mods.CheatCommands.Commands.Teleport_Success",
                    x,
                    y));
        }
    }
}
