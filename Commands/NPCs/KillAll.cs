using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.NPCs {
    class KillAll : CheatCommand {
        public override string Command => "killall";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.KillAll_Description");
        public override string Usage => base.Usage + " [friendly/hostile]";
        public override CommandType Type => CommandType.World;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().KillAllEnabled;

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

            return new CommandReply(
                Language.GetTextValue(
                    "Mods.CheatCommands.Commands.Kill_Success",
                    caller.Player.name,
                    amount));
        }
    }
}
