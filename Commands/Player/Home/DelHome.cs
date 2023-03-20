using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player.Home {
    public class DelHome : CheatCommand {
        public override string Command => "delhome";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.DelHome_Description");
        public override string Usage => base.Usage + " <name>";
        public override int MinimumArguments => 1;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().HomeEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();

            string name = args[0];

            if(player.Homes.Has(name)) {
                player.Homes.Remove(name);
                return new CommandReply(
                    Language.GetTextValue(
                        "Mods.CheatCommands.Commands.DelHome_Remove",
                        name));
            }
            else {
                return new CommandReply(
                    Language.GetTextValue(
                        "Mods.CheatCommands.Commands.Home_DoesNotExist",
                        name),
                    Color.Red);
            }
        }
    }
}
