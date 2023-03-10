﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class RemoveBuff : CheatCommand {
        public override string Command => "removebuff";
        public override string Description => "Remove a buff.";
        public override string Usage => base.Usage + " <type/name>";
        public override int MinimumArguments => 1;
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().DebuffEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            int buffType = 0;

            if(!int.TryParse(args[0], out buffType)) {
                buffType = CommandUtils.GetBuffType(args[0]);
            }

            if(buffType == 0 || buffType >= BuffLoader.BuffCount) {
                return new CommandReply($"Unknown buff type: {buffType}", Color.Red);
            }

            caller.Player.ClearBuff(buffType);
            return new CommandReply($"Cleared buff type {buffType}.");
        }
    }
}
