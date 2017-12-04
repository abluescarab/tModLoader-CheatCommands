using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class Debuff : CheatCommand {
        public override string CommandName => "Remove Buff";
        public override string Command => "debuff";
        public override string Description => "Remove a buff.";
        public override string Usage => base.Usage + " <type/name>";
        public override int MinimumArguments => 1;

        public override void Action(CommandCaller caller, string[] args) {
            int buffType = 0;

            if(!int.TryParse(args[0], out buffType)) {
                buffType = CommandUtils.GetBuffType(args[0]);
            }

            if(buffType == 0 || buffType >= BuffLoader.BuffCount) {
                throw new UsageException("Unknown buff type: " + buffType);
            }

            caller.Player.ClearBuff(buffType);
            caller.Reply("Cleared buff type " + buffType + ".");
        }
    }
}