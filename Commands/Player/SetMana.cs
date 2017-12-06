using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class SetMana : CheatCommand {
        public override string CommandName => "Set Mana";
        public override string Command => "mana";
        public override string Description => "Set player mana.";
        public override string Usage => base.Usage + " <amount>";
        public override int MinimumArguments => 1;

        public override void Action(CommandCaller caller, string[] args) {
            int mana = 0;

            if(!int.TryParse(args[0], out mana)) {
                throw new UsageException("Invalid number: " + args[0]);
            }

            CheatCommands.MaxMana = mana;
            CommandUtils.ChangePlayerMana(caller.Player);
            caller.Player.GetModPlayer<CheatCommandsPlayer>().RefillMana(true);
            caller.Reply("Set mana to " + mana + "!");
        }
    }
}
