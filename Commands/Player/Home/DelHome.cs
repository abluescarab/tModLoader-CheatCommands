using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace CheatCommands.Commands.Player.Home {
    public class DelHome : CheatCommand {
        public override string Command => "delhome";
        public override string Description => "Delete a home for this world.";
        public override string Usage => base.Usage + " <name>";
        public override int MinimumArguments => 1;
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().HomeEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            CheatCommandsPlayer player = caller.Player.GetModPlayer<CheatCommandsPlayer>();

            string name = args[0];
            
            if(player.Homes.Has(name)) {
                player.Homes.Remove(name);
                return new CommandReply($"Removed \"{name}\" from world.");
            }
            else {
                return new CommandReply($"Home \"{name}\" does not exist.", Color.Red);
            }
        }
    }
}
