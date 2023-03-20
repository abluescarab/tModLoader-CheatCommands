﻿using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    public class Prefix : CheatCommand {
        public override string Command => "prefix";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.Prefix_Description");
        public override string Usage => base.Usage + " <name>";
        public override int MinimumArguments => 1;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().PrefixEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            if(caller.Player.HeldItem.IsAir) {
                return new CommandReply(
                    Language.GetTextValue("Mods.CheatCommands.Commands.Prefix_NoItem"),
                    Color.Red);
            }

            string prefix = args[0];
            int id = -1;

            if(!CommandUtils.GetPrefixType(prefix, out id, out string properName) 
                || !caller.Player.HeldItem.Prefix(id)) { 
                return new CommandReply(
                    Language.GetTextValue("Mods.CheatCommands.Commands.Prefix_Invalid"),
                    Color.Red);
            }

            return new CommandReply(
                Language.GetTextValue("Mods.CheatCommands.Commands.Prefix_Success",
                caller.Player.HeldItem.Name,
                properName));
        }
    }
}
