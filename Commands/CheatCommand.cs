using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace CheatCommands.Commands {
    abstract class CheatCommand : ModCommand {
        public abstract string CommandName { get; }
        public abstract int MinimumArguments { get; }
        public override bool Autoload(ref string name) => false;
        public override CommandType Type => CommandType.Chat;

        public override void Action(CommandCaller caller, string input, string[] args) {
            string command = input.Replace("/" + Command, "");

            List<string> argList = new List<string>();
            while(command.Contains("\"")) {
                int first = command.IndexOf("\"");
                int last = command.IndexOf("\"", first + 1);

                string arg = command.Substring(first, last - first + 1);
                command = command.Replace(arg, "");

                argList.Add(arg.Trim(' ', '"'));
            }

            argList.AddRange(command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            if(argList.Count < MinimumArguments) {
                throw new UsageException();
            }

            Action(caller, argList.ToArray());
        }

        public abstract void Action(CommandCaller caller, string[] args);
    }
}
