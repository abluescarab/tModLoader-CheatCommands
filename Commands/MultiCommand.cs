using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands {
    public class MultiCommandDefinition {
        public string Name;
        public List<string> Commands = new List<string>();
    }

    public class MultiCommand : CheatCommand {
        public override string Command => "mc";
        public override string Description 
            => Language.GetTextValue("Mods.CheatCommands.Commands.MultiCommand.Description");
        public override string Usage => base.Usage + " <name>";
        public override int MinimumArguments => 1;
        public override CommandType Type => CommandType.Chat;
        public override bool CommandEnabled => true;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            MultiCommandDefinition def = ModContent
                .GetInstance<CheatCommandsConfig>()
                .MultiCommands
                .FirstOrDefault(c => c.Name == args[0]);

            if(def == null || def.Commands.Count == 0) {
                return new CommandReply(
                    Language.GetTextValue("Mods.CheatCommands.Commands.MultiCommand.NotConfigured"), 
                    Color.Red);
            }

            foreach(string command in def.Commands) {
                Main.ExecuteCommand(command, caller);
            }

            return CommandReply.Empty;
        }
    }
}
