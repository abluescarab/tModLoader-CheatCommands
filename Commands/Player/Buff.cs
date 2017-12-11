using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class Buff : CheatCommand {
        private const int DEFAULT_LENGTH = 60 * 30; // 60 ticks * 30 seconds

        public override string CommandName => "Add Buff";
        public override string Command => "buff";
        public override string Description => "Add a buff.";
        public override string Usage => base.Usage + " <type/name> [time]";
        public override int MinimumArguments => 1;
        public override CommandType Type => CommandType.Chat;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            int buffType = 0;
            int length = 0;

            if(!int.TryParse(args[0], out buffType)) {
                buffType = CommandUtils.GetBuffType(args[0]);
            }

            if(buffType == 0 || buffType >= BuffLoader.BuffCount) {
                throw new UsageException("Unknown buff type: " + buffType);
            }

            if(args.Length > 1) {
                if(!int.TryParse(args[1], out length)) {
                    length = DEFAULT_LENGTH;
                }
            }

            caller.Player.AddBuff(buffType, length);
            return new CommandReply("Added buff type " + buffType + "!");
        }
    }
}
