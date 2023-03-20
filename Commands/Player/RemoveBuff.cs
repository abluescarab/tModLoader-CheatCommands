using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    class RemoveBuff : CheatCommand {
        public override string Command => "removebuff";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.RemoveBuff_Description");
        public override string Usage => base.Usage + " <type/name>";
        public override int MinimumArguments => 1;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().DebuffEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            int buffType = 0;

            if(!int.TryParse(args[0], out buffType)) {
                buffType = CommandUtils.GetBuffType(args[0]);
            }

            if(buffType == 0 || buffType >= BuffLoader.BuffCount) {
                return new CommandReply(
                    Language.GetTextValue(
                        "Mods.CheatCommands.Commands.Buff_Unknown",
                        buffType),
                    Color.Red);
            }

            caller.Player.ClearBuff(buffType);
            return new CommandReply(
                Language.GetTextValue(
                    "Mods.CheatCommands.Commands.RemoveBuff_Success",
                    buffType));
        }
    }
}
