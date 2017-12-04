using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.World {
    class SettleLiquids : CheatCommand {
        public override string CommandName => "Settle Liquids";
        public override string Command => Language.GetTextValue("CLI.Settle_Command");
        public override string Description => "Settle liquids.";
        public override int MinimumArguments => 0;

        // from Terraria server commands
        public override void Action(CommandCaller caller, string[] args) {
            if(!Liquid.panicMode) {
                caller.Reply(Language.GetTextValue("Misc.ForceWaterSettling"));
                Liquid.StartPanic();
            }
            else {
                caller.Reply(Language.GetTextValue("CLI.WaterIsAlreadySettling"));
            }
        }
    }
}
