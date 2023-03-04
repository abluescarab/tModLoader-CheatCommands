using CheatCommands.Commands;
using CheatCommands.Commands.NPCs;
using CheatCommands.Commands.Player;
using CheatCommands.Commands.World;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace CheatCommands {
    class CheatCommands : Mod {
        private static readonly List<CheatCommand> Commands = new List<CheatCommand>() {
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
            new FreezeTime(),
            new SetSpawn(),
            new SettleLiquids(),
            new Time()
        };

        public CheatCommands() {
            ContentAutoloadingEnabled = true;
        }
    }
}
