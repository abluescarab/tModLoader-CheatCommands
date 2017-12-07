using System.Collections.Generic;
using System.Linq;
using CheatCommands.Commands;
using CheatCommands.Commands.NPCs;
using CheatCommands.Commands.Player;
using CheatCommands.Commands.World;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheatCommands {
    public static class CommandUtils {
        private static List<CheatCommand> commands = new List<CheatCommand>() {
            new KillAll(),
            new KillNPC(),
            new SpawnNPC(),
            new Buff(),
            new Debuff(),
            new GiveCoins(),
            new GiveItem(),
            new GodMode(),
            new InfiniteAmmo(),
            new KillMe(),
            new SetLife(),
            new SetMana(),
            new FreezeTime(),
            new SetSpawn(),
            new SettleLiquids(),
            new Time()
        };

        public static void LoadCommands(Mod mod, string[] disabled) {
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

        public static void ChangePlayerMana(Player player) {
            if(CheatCommands.MaxMana >= 400) {
                player.statManaMax = 400;
            }

            player.statManaMax2 = CheatCommands.MaxMana;
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
