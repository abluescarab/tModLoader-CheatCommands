using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands {
    public abstract class CheatCommand : ModCommand {
        public virtual int MinimumArguments => 0;
        public override CommandType Type => CommandType.Chat;
        public abstract bool CommandEnabled { get; }

        public override void Action(CommandCaller caller, string input, string[] args) {
            CommandReply reply;

            if(!CommandEnabled) {
                reply = new CommandReply(
                    Language.GetTextValue("Mods.CheatCommands.CommandDisabled"),
                    Color.Red);
                caller.Reply(reply.Text, reply.TextColor);
                return;
            }

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
                reply = new CommandReply(
                    $"{Language.GetTextValue("Mods.CheatCommands.Usage")}: {Usage}", Color.Red);
                caller.Reply(reply.Text, reply.TextColor);
                return;
            }

            reply = Action(caller, argList.ToArray());

            if(!reply.IsEmpty) {
                if(Main.netMode == NetmodeID.SinglePlayer || Type.HasFlag(CommandType.Chat)) {
                    caller.Reply(reply.Text, reply.TextColor);
                }
                else {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(reply.Text), reply.TextColor);
                }
            }
        }

        public abstract CommandReply Action(CommandCaller caller, string[] args);
    }
}
