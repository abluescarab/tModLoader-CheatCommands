using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheatCommands.Commands.NPCs {
    class KillNPC : CheatCommand {
        public override string CommandName => "Kill NPC";
        public override string Command => "kill";
        public override string Description => "Kill an NPC.";
        public override string Usage => base.Usage + " <type/name>";
        public override int MinimumArguments => 1;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            int npcType = 0;
            int amount = 0;

            if(!int.TryParse(args[0], out npcType)) {
                npcType = CommandUtils.GetNPCType(args[0]);
            }

            if(!CommandUtils.IsValidNPC(npcType)) {
                throw new UsageException($"Invalid NPC type: {npcType}");
            }

            for(int i = 0; i < Main.npc.Length; i++) {
                NPC npc = Main.npc[i];

                if(CommandUtils.IsValidNPC(npc) && (npc.type == npcType || npc.TypeName.Equals(args[0]))) {
                    npc.StrikeNPCNoInteraction(npc.lifeMax, 0, -npc.direction, crit: true);
                    NetMessage.SendData(MessageID.StrikeNPC, -1, -1, null, i, npc.lifeMax, 0f, -npc.direction, 1);
                    amount++;
                }
            }

            return new CommandReply($"{caller.Player.name} killed {amount} NPC{(amount == 1 ? "" : "s")}!");
        }
    }
}
