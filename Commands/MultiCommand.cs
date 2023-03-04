using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace CheatCommands.Commands {
    public class MultiCommandDefinition {
        public string Name;
        public List<string> Commands = new List<string>();
    }

    public class MultiCommand : CheatCommand {
        public override int MinimumArguments => 1;
        public override string Description => "Run a multicommand.";
        public override string Usage => base.Usage + " <multicommand name>";
        public override bool CommandEnabled => true;
        public override string Command => "m";

        public override CommandReply Action(CommandCaller caller, string[] args) {
            MultiCommandDefinition def = CheatCommandsConfig.Instance.MultiCommands.FirstOrDefault(c => c.Name == args[0], null);

            if(def == null || def.Commands.Count == 0) {
                return new CommandReply("Multicommand not configured.", Color.Red);
            }

            foreach(string command in def.Commands) {
                Main.ExecuteCommand(command, caller);
            }

            return CommandReply.Empty;
        }
    }
}
