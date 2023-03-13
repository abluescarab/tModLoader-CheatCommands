using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player.Home {
    public class SetHome : CheatCommand {
        public override string Command => "sethome";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.SetHome_Description");
        public override string Usage => base.Usage + " <name> [<x> <y>]";
        public override int MinimumArguments => 1;
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().HomeEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            if(args.Length == 2) {
                return new CommandReply(Usage, Color.Red);
            }

            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();
            string name = args[0];
            Vector2 pos = caller.Player.Top;

            if(args.Length > 1) {
                if(!int.TryParse(args[1], out int x)) {
                    return new CommandReply("Invalid x value.", Color.Red);
                }

                if(!int.TryParse(args[2], out int y)) {
                    return new CommandReply("Invalid y value.", Color.Red);
                }

                pos = new Vector2(x, y);
            }

            if(player.Homes.Has(name)) {
                return new CommandReply("A home with that name already exists.", Color.Red);
            }

            player.Homes.Add(name, pos);
            return new CommandReply($"Added \"{name}\" at {pos.X}, {pos.Y}.");
        }
    }
}
