using System.Collections.Generic;
using System.Linq;
using CheatCommands.Commands;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheatCommands {
    static class CommandUtils {
        public static void LoadCommands(Mod mod, List<CheatCommand> commands, string[] disabled) {
            foreach(string name in disabled) {
                var command = commands.FirstOrDefault(n => n.Command.Equals(name));

                if(command != null) {
                    commands.Remove(command);
                }
            }

            foreach(var command in commands) {
                mod.AddCommand(command.CommandName, command);
            }
        }
        
        public static int GetBuffType(string name) {
            int type = 0;

            for(int i = 0; i < BuffLoader.BuffCount; i++) {
                if(name.Equals(Lang.GetBuffName(i))) {
                    type = i;
                    break;
                }
            }

            return type;
        }

        public static int GetItemType(string name) {
            int type = 0;

            for(int i = 0; i < ItemLoader.ItemCount; i++) {
                if(name.Equals(Lang.GetItemNameValue(i))) {
                    type = i;
                    break;
                }
            }

            return type;
        }

        public static int GetNPCType(string name) {
            int type = 0;

            for(int i = 0; i < NPCLoader.NPCCount; i++) {
                if(name.Equals(Lang.GetNPCNameValue(i))) {
                    type = i;
                    break;
                }
            }

            return type;
        }

        public static bool IsValidNPC(int type) {
            return
                type != NPCID.TargetDummy &&
                type != NPCID.CultistArcherBlue &&
                type != NPCID.CultistDevote &&
                type != NPCID.CultistTablet;
        }

        public static bool IsValidNPC(NPC npc) {
            return
                npc.active &&
                npc.type != NPCID.TargetDummy &&
                npc.type != NPCID.CultistArcherBlue &&
                npc.type != NPCID.CultistDevote &&
                npc.type != NPCID.CultistTablet;
        }

        public static bool IsFriendlyNPC(NPC npc) {
            return npc.friendly || npc.townNPC;
        }
    }
}
