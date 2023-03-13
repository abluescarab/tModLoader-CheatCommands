using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player.Home {
    public class Home : CheatCommand {
        public override string Command => "home";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.Home_Description");
        public override string Usage => base.Usage + " <name>";
        public override int MinimumArguments => 1;
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().HomeEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();
            string name = args[0];
            HomeLocation home = player.Homes.Get(name);

            if(home == null) {
                return new CommandReply("That home does not exist.", Color.Red);
            }

            caller.Player.Teleport(home.Position);
            return new CommandReply($"Teleported to \"{name}\".");
        }
    }
}
