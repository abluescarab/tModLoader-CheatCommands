﻿using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    internal class Knockback : CheatCommand {
        public static bool Enabled { get; set; } = true;

        public override string Command => "knockback";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.Knockback.Description");
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().KnockbackEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            Enabled = !Enabled;
            return new CommandReply(
                Language.GetTextValue("Mods.CheatCommands.Commands.Knockback." + (
                Enabled
                ? "Enable"
                : "Disable")));
        }
    }
}
