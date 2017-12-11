using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheatCommands.Commands.NPCs {
    class SpawnNPC : CheatCommand {
        public override string CommandName => "Spawn NPC";
        public override string Command => "spawn";
        public override string Description => "Spawn an NPC.";
        public override string Usage => base.Usage + " <type/name> [x] [y] [amount]";
        public override int MinimumArguments => 1;

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
                throw new UsageException("Unknown NPC type: " + npcType);
            }

            if(!CommandUtils.IsValidNPC(npcType)) {
                throw new UsageException("Invalid NPC type: " + npcType);
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

                if(!int.TryParse(args[2], out x)) {
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
                x += (int)caller.Player.Bottom.X;
            }

            if(yRelative) {
                y += (int)caller.Player.Bottom.Y;
            }

            for(int i = 0; i < amount; i++) {
                int newNPC = NPC.NewNPC(x, y, npcType);

                if(newNPC < 200) {
                    NetMessage.SendData(MessageID.SyncNPC, number: newNPC);
                }
                else {
                    break;
                }
            }

            return new CommandReply(caller.Player.name + " spawned " + amount + " NPCs!");
        }
    }
}
