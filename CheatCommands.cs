using System.Collections.Generic;
using CheatCommands.Commands;
using CheatCommands.Commands.NPCs;
using CheatCommands.Commands.Player;
using CheatCommands.Commands.World;
using Terraria;
using Terraria.ModLoader;

namespace CheatCommands {
    class CheatCommands : Mod {
        private static bool timeFrozen = false;
        private static double frozenTime = 0.0;
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

        public static bool GodMode { get; set; }
        public static bool InfiniteAmmo { get; set; }
        public static int MaxMana { get; set; }
        public static bool TimeFrozen {
            get { return timeFrozen; }
            set {
                timeFrozen = value;

                if(timeFrozen) {
                    frozenTime = Main.time;
                }
            }
        }
        
        public const string DISABLED_COMMANDS = "disabledCommands";

        public CheatCommands() {
            Properties = new ModProperties() {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load() {
            ModConfiguration.ModConfig config = new ModConfiguration.ModConfig("CheatCommands");
            config.Add(DISABLED_COMMANDS, new string[] { });
            config.Load();

            CommandUtils.LoadCommands(this, commands, (string[])config.Get(DISABLED_COMMANDS));
        }

        public override void PostUpdateInput() {
            if(TimeFrozen) {
                Main.time = frozenTime;
            }
        }
    }
}
