using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class SetMana : CheatCommand {
        public override string CommandName => "Set Mana";
        public override string Command => "mana";
        public override string Description => "Set player mana.";
        public override string Usage => base.Usage + " <amount>";
        public override int MinimumArguments => 1;
        public override CommandType Type => CommandType.Chat;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();
            int mana = 0;

            if(!int.TryParse(args[0], out mana)) {
                throw new UsageException("Invalid number: " + args[0]);
            }

            player.MaxMana = mana;
            player.RefillMana(true);
            return new CommandReply("Set mana to " + mana + "!");
        }
    }
}
