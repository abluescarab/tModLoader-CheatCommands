using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands {
    static class CommandUtils {
        public static int GetBuffType(string name) {
            int type = 0;

            for(int i = 0; i < BuffLoader.BuffCount; i++) {
                if(name.ToLower().Equals(Lang.GetBuffName(i).ToLower())) {
                    type = i;
                    break;
                }
            }

            return type;
        }

        public static int GetItemType(string name) {
            int type = 0;

            for(int i = 0; i < ItemLoader.ItemCount; i++) {
                if(name.ToLower().Equals(Lang.GetItemNameValue(i).ToLower())) {
                    type = i;
                    break;
                }
            }

            return type;
        }

        public static int GetNPCType(string name) {
            int type = 0;

            for(int i = 0; i < NPCLoader.NPCCount; i++) {
                if(name.ToLower().Equals(Lang.GetNPCNameValue(i).ToLower())) {
                    type = i;
                    break;
                }
            }

            return type;
        }

        public static bool GetPrefixType(string name, out int id) {
            return GetPrefixType(name, out id, out string properName);
        }

        public static bool GetPrefixType(string name, out int id, out string properName) {
            for(int i = 0; i < PrefixLoader.PrefixCount; i++) {
                string other = Lang.prefix[i].Value.Trim('(', ')');

                if(name.ToLower().Equals(other.ToLower())) {
                    id = i;
                    properName = other;
                    return true;
                }
            }

            id = 0;
            properName = name;
            return false;
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
