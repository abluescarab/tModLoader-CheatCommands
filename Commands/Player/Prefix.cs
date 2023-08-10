using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player {
    public class Prefix : CheatCommand {
        public override string Command => "prefix";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.Prefix.Description");
        public override string Usage => base.Usage + " <name>";
        public override int MinimumArguments => 1;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().PrefixEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            if(caller.Player.HeldItem.IsAir) {
                return new CommandReply(
                    Language.GetTextValue("Mods.CheatCommands.Commands.Prefix.NoItem"),
                    Color.Red);
            }

            string prefix = args[0];
            int id = -1;

            if(!CommandUtils.GetPrefixType(prefix, out id, out string properName) 
                || (!Main.mouseItem.Prefix(id)
                && !caller.Player.HeldItem.Prefix(id))) { 
                return new CommandReply(
                    Language.GetTextValue("Mods.CheatCommands.Commands.Prefix.Invalid"),
                    Color.Red);
            }

            return new CommandReply(
                Language.GetTextValue("Mods.CheatCommands.Commands.Prefix.Success",
                caller.Player.HeldItem.Name,
                properName));
        }
    }
}
