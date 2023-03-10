﻿using Terraria.ModLoader;

namespace CheatCommands.Commands.World {
    class FreezeTime : CheatCommand {
        public override string Command => "freeze";
        public override string Description => "Freeze/unfreeze world time.";
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().FreezeTimeEnabled;

        // based on HERO's mod
        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsSystem.TimeFrozen = !CheatCommandsSystem.TimeFrozen;
            return new CommandReply($"{caller.Player.name} {(CheatCommandsSystem.TimeFrozen ? "froze" : "unfroze")} time.");
        }
    }
}
