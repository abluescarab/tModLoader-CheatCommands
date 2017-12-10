using System.Collections.Generic;
using System.IO;
using CheatCommands.Commands;
using CheatCommands.Commands.NPCs;
using CheatCommands.Commands.Player;
using CheatCommands.Commands.World;
using Terraria;
using Terraria.ModLoader;

namespace CheatCommands {
    class CheatCommands : Mod {
        private static bool _timeFrozen = false;
        private static double _frozenTime = 0.0;
        private static List<CheatCommand> _commands = new List<CheatCommand>() {
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

        public static bool TimeFrozen {
            get { return _timeFrozen; }
            set {
                _timeFrozen = value;

                if(_timeFrozen) {
                    _frozenTime = Main.time;
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
            
            CommandUtils.LoadCommands(this, _commands, (string[])config.Get(DISABLED_COMMANDS));
        }

        public override void PostUpdateInput() {
            if(TimeFrozen) {
                Main.time = _frozenTime;
            }
        }
    }
}
