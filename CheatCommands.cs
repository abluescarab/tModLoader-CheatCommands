using Terraria;
using Terraria.ModLoader;

namespace CheatCommands {
    class CheatCommands : Mod {
        private static bool timeFrozen = false;
        private static double frozenTime = 0.0;

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

            CommandUtils.LoadCommands(this, (string[])config.Get(DISABLED_COMMANDS));
        }

        public override void PostUpdateInput() {
            if(TimeFrozen) {
                Main.time = frozenTime;
            }
        }
    }
}
