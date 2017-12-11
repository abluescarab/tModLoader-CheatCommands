using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class SetLife : CheatCommand {
        public override string CommandName => "Set Life";
        public override string Command => "life";
        public override string Description => "Set player life.";
        public override string Usage => base.Usage + " <amount>";
        public override int MinimumArguments => 1;
        public override CommandType Type => CommandType.Chat;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            int life = 0;

            if(!int.TryParse(args[0], out life)) {
                throw new UsageException("Invalid number: " + args[0]);
            }

            caller.Player.statLifeMax = life;
            caller.Player.GetModPlayer<CheatCommandsPlayer>().RefillLife();
            return new CommandReply("Set life to " + life + "!");
        }
    }
}
