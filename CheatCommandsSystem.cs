using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheatCommands {
    internal class CheatCommandsSystem : ModSystem {
        private static double _frozenTime = 0.0;
        private static bool _timeFrozen = false;

        public static bool TimeFrozen {
            get { return _timeFrozen; }
            set {
                _timeFrozen = value;

                if(_timeFrozen) {
                    _frozenTime = Main.time;
                }
            }
        }

        public override void PostUpdateInput() {
            if(!TimeFrozen) {
                return;
            }

            Main.time = _frozenTime;
            NetMessage.SendData(MessageID.WorldData);
        }
    }
}
