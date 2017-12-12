using System.Collections.Generic;
using System.Linq;
using CheatCommands.Commands;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheatCommands {
    static class CommandUtils {
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
            return npc.active && IsValidNPC(npc.type);
        }

        public static bool IsFriendlyNPC(NPC npc) {
            return npc.friendly || npc.townNPC;
        }
    }
}
