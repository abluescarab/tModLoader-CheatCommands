using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands {
    abstract class CheatCommand : ModCommand {
        public abstract string CommandName { get; }
        public abstract int MinimumArguments { get; }
        public override bool Autoload(ref string name) => false;
        public override CommandType Type => CommandType.World;

        public override void Action(CommandCaller caller, string input, string[] args) {
            string command = string.Join(" ", args);

            List<string> argList = new List<string>();
            while(command.Contains("\"")) {
                int first = command.IndexOf("\"", StringComparison.Ordinal);
                int last = command.IndexOf("\"", first + 1, StringComparison.Ordinal);

                string arg = command.Substring(first, last - first + 1);
                command = command.Replace(arg, "");

                argList.Add(arg.Trim(' ', '"'));
            }

            argList.AddRange(command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            if(argList.Count < MinimumArguments) {
                throw new UsageException();
            }

            CommandReply reply = Action(caller, argList.ToArray());

            if(!reply.IsEmpty) {
                if(Main.netMode == 0 || Type.HasFlag(CommandType.Chat)) {
                    caller.Reply(reply.Text, reply.TextColor);
                }
                else {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(reply.Text), reply.TextColor);
                }
            }
        }

        public abstract CommandReply Action(CommandCaller caller, string[] args);
    }
}
