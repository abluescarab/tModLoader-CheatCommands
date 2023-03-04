using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheatCommands.Commands.NPCs {
    class KillAll : CheatCommand {
        public override string Command => "killall";
        public override string Description => "Kill all NPCs.";
        public override string Usage => base.Usage + " [friendly/hostile]";
        public override bool CommandEnabled => CheatCommandsConfig.Instance.KillAllEnabled;

        // based on jopojelly's Cheat Sheet
        public override CommandReply Action(CommandCaller caller, string[] args) {
            string killType = (args.Length > 0 ? args[0] : "");
            int amount = 0;

            for(int i = 0; i < Main.npc.Length; i++) {
                NPC npc = Main.npc[i];

                if(CommandUtils.IsValidNPC(npc)) {
                    if(killType.Equals("friendly") && !CommandUtils.IsFriendlyNPC(npc)) continue;
                    if(killType.Equals("hostile") && CommandUtils.IsFriendlyNPC(npc)) continue;

                    npc.StrikeNPCNoInteraction(npc.lifeMax, 0, -npc.direction, crit: true);
                    NetMessage.SendData(MessageID.DamageNPC, -1, -1, null, i, npc.lifeMax, 0f, -npc.direction, 1);
                    amount++;
                }
            }

            return new CommandReply($"{caller.Player.name} killed {amount} NPC{(amount == 1 ? "" : "s")}.");
        }
    }
}
