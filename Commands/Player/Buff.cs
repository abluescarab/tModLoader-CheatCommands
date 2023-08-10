using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class Buff : CheatCommand {
        private const int TICKS_PER_SECOND = 60;
        private const int DEFAULT_LENGTH = 30; // 30 seconds

        public override string Command => "buff";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.Buff.Description");
        public override string Usage => base.Usage + " <type/name> [seconds]";
        public override int MinimumArguments => 1;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().BuffEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            int buffType = 0;
            int length = DEFAULT_LENGTH;

            if(!int.TryParse(args[0], out buffType)) {
                buffType = CommandUtils.GetBuffType(args[0]);
            }

            if(buffType == 0 || buffType >= BuffLoader.BuffCount) {
                return new CommandReply(
                    Language.GetTextValue(
                        "Mods.CheatCommands.Commands.Buff.Unknown",
                        buffType),
                    Color.Red);
            }

            if(args.Length > 1) {
                if(!int.TryParse(args[1], out length)) {
                    length = DEFAULT_LENGTH;
                }
            }

            caller.Player.AddBuff(buffType, length * TICKS_PER_SECOND);
            return new CommandReply(
                Language.GetTextValue(
                    "Mods.CheatCommands.Commands.Buff.Success",
                    buffType));
        }
    }
}
