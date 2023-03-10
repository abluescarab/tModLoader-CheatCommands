using CheatCommands.Commands;
using CheatCommands.Commands.NPCs;
using CheatCommands.Commands.Player;
using CheatCommands.Commands.World;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace CheatCommands {
    class CheatCommands : Mod {
        private static readonly List<CheatCommand> Commands = new List<CheatCommand>() {
            new KillAll(),
            new KillNPC(),
            new SpawnNPC(),
            new Buff(),
            new RemoveBuff(),
            new GiveCoins(),
            new GiveItem(),
            new GodMode(),
            new InfiniteAmmo(),
            new Respawn(),
            new Teleport(),
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
