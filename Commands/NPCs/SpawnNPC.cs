﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.NPCs {
    class SpawnNPC : CheatCommand {
        public override string Command => "spawn";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.Spawn.Description");
        public override string Usage => base.Usage + " <type/name> [x] [y] [amount]";
        public override int MinimumArguments => 1;
        public override CommandType Type => CommandType.World;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().SpawnNPCEnabled;

        // based on ExampleMod
        public override CommandReply Action(CommandCaller caller, string[] args) {
            int npcType = 0;
            int x = 0;
            int y = 0;
            int amount = 1;
            bool xRelative = false;
            bool yRelative = false;

            if(!int.TryParse(args[0], out npcType)) {
                npcType = CommandUtils.GetNPCType(args[0]);
            }

            if(npcType == 0 || npcType >= NPCLoader.NPCCount) {
                return new CommandReply(
                    Language.GetTextValue(
                        "Mods.CheatCommands.Commands.Spawn.Unknown",
                        npcType),
                    Color.Red);
            }

            if(!CommandUtils.IsValidNPC(npcType)) {
                return new CommandReply(
                    Language.GetTextValue(
                        "Mods.CheatCommands.Commands.Spawn.Unknown",
                        npcType),
                    Color.Red);
            }

            if(args.Length > 1) {
                if(args[1].StartsWith("~")) {
                    xRelative = true;
                    args[1] = args[1].Remove(0, 1);
                }

                if(!int.TryParse(args[1], out x)) {
                    xRelative = true;
                }
            }
            else {
                xRelative = true;
            }

            if(args.Length > 2) {
                if(args[2].StartsWith("~")) {
                    yRelative = true;
                    args[2] = args[2].Remove(0, 1);
                }

                if(!int.TryParse(args[2], out y)) {
                    yRelative = true;
                }
            }
            else {
                yRelative = true;
            }

            if(args.Length > 3) {
                if(!int.TryParse(args[3], out amount)) {
                    amount = 1;
                }
            }

            if(xRelative) {
                x += (int)caller.Player.MountedCenter.X;
            }

            if(yRelative) {
                y += (int)caller.Player.MountedCenter.Y;
            }

            for(int i = 0; i < amount; i++) {
                int newNPC = NPC.NewNPC(Entity.GetSource_None(), x, y, npcType);

                if(newNPC < 200) {
                    NetMessage.SendData(MessageID.SyncNPC, number: newNPC);
                }
                else {
                    break;
                }
            }

            return new CommandReply(
                Language.GetTextValue(
                    "Mods.CheatCommands.Commands.Spawn.Success",
                    caller.Player.name,
                    amount));
        }
    }
}
