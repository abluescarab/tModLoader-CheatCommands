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
        public static bool GodModeEnabled { get; set; } = false;
        public static bool InfiniteAmmoEnabled { get; set; } = false;
        public static int MaxMana { get; set; } = 0;

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
            new Dawn(),
            new Dusk(),
            new Midnight(),
            new Noon(),
            new SettleLiquids(),
            new Time()
        };

        public static void LoadCommands(Mod mod, string[] disabled) {
            foreach(string name in disabled) {
                var command = commands.FirstOrDefault(n => n.CommandName.Equals(name));

                if(command != null) {
                    commands.Remove(command);
                }
            }

            foreach(var command in commands) {
                mod.AddCommand(command.CommandName, command);
            }
        }

        public static void ChangePlayerMana(Player player) {
            if(MaxMana >= 400) {
                player.statManaMax = 400;
            }

            player.statManaMax2 = MaxMana;
        }

        public static int GetBuffType(string name) {
            string translated = "";
            return GetBuffType(name, out translated);
        }

        public static int GetBuffType(string name, out string translated) {
            int type = 0;
            string translation = "";

            for(int i = 0; i < BuffLoader.BuffCount; i++) {
                translation = Lang.GetBuffName(i);

                if(name.Equals(translation)) {
                    type = i;
                    break;
                }
            }

            if(type != 0) {
                translated = translation;
            }
            else {
                translated = "";
            }

            return type;
        }

        public static int GetItemType(string name) {
            string translated = "";
            return GetItemType(name, out translated);
        }

        public static int GetItemType(string name, out string translated) {
            int type = 0;
            string translation = "";

            for(int i = 0; i < ItemLoader.ItemCount; i++) {
                if(name.Equals(Lang.GetItemNameValue(i))) {
                    type = i;
                    break;
                }
            }

            if(type != 0) {
                translated = translation;
            }
            else {
                translated = "";
            }

            return type;
        }

        public static int GetNPCType(string name) {
            string translated = "";
            return GetNPCType(name, out translated);
        }

        public static int GetNPCType(string name, out string translated) {
            int type = 0;
            string translation = "";

            for(int i = 0; i < NPCLoader.NPCCount; i++) {
                if(name.Equals(Lang.GetNPCNameValue(i))) {
                    type = i;
                    break;
                }
            }

            if(type != 0) {
                translated = translation;
            }
            else {
                translated = "";
            }

            return type;
        }

        public static string GetSeparatedArguments(string[] args, char separator, int startIndex) {
            int indexAfter = 0;
            return GetSeparatedArguments(out indexAfter, args, separator, startIndex);
        }

        public static string GetSeparatedArguments(out int indexAfter, string[] args, char separator,
            int startIndex) {
            List<string> separated = new List<string>();
            int i = 0;

            for(i = startIndex; i < args.Length; i++) {
                separated.Add(args[i]);

                if(args[i].EndsWith(separator.ToString())) {
                    break;
                }
            }

            indexAfter = i + 1;
            return string.Join(" ", separated).Trim(separator, ' ');
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
