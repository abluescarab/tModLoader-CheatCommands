﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.NPCs {
    class KillNPC : CheatCommand {
        public override string Command => "kill";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.Kill_Description");
        public override string Usage => base.Usage + " <type/name>";
        public override int MinimumArguments => 1;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().KillEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            int npcType = 0;
            int amount = 0;

            if(!int.TryParse(args[0], out npcType)) {
                npcType = CommandUtils.GetNPCType(args[0]);
            }

            if(!CommandUtils.IsValidNPC(npcType)) {
                return new CommandReply($"Invalid NPC type: {npcType}", Color.Red);
            }

            for(int i = 0; i < Main.npc.Length; i++) {
                NPC npc = Main.npc[i];

                if(CommandUtils.IsValidNPC(npc) && (npc.type == npcType || npc.TypeName.Equals(args[0]))) {
                    npc.StrikeNPCNoInteraction(npc.lifeMax, 0, -npc.direction, crit: true);
                    NetMessage.SendData(MessageID.DamageNPC, -1, -1, null, i, npc.lifeMax, 0f, -npc.direction, 1);
                    amount++;
                }
            }

            return new CommandReply($"{caller.Player.name} killed {amount} NPC{(amount == 1 ? "" : "s")}.");
        }
    }
}
