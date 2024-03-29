﻿using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class GodMode : CheatCommand {
        public static bool Enabled { get; set; }

        public override string Command => "god";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.GodMode.Description");
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().GodModeEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();
            Enabled = !Enabled;

            if(Enabled) {
                player.RefillLife();
                player.RefillMana(true);
                player.RemoveDebuffs();
            }

            return new CommandReply(
                Language.GetTextValue(
                    "Mods.CheatCommands.Commands.GodMode." + (
                    Enabled
                    ? "Enable"
                    : "Disable")));
        }
    }
}
