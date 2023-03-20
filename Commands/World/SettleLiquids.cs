using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.World {
    class SettleLiquids : CheatCommand {
        public override string Command => Language.GetTextValue("CLI.Settle_Command");
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.SettleLiquids_Description");
        public override CommandType Type => CommandType.World;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().SettleLiquidsEnabled;

        // from Terraria server commands
        public override CommandReply Action(CommandCaller caller, string[] args) {
            string reply = "";

            if(!Liquid.panicMode) {
                reply = Language.GetTextValue("Misc.ForceWaterSettling");
                Liquid.StartPanic();
            }
            else {
                reply = Language.GetTextValue("CLI.WaterIsAlreadySettling");
            }

            NetMessage.SendData(MessageID.WorldData);
            return new CommandReply(reply);
        }
    }
}
