using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CheatCommands.Commands.World {
    class SetSpawn : CheatCommand {
        public override string CommandName => "Set Spawn";
        public override string Command => "setspawn";
        public override string Description => "Set world spawn.";
        public override int MinimumArguments => 0;

        public override void Action(CommandCaller caller, string[] args) {
            Vector2 tilePosition = (caller.Player.Bottom + Vector2.UnitY) * 0.0625f;
            int x = (int)tilePosition.X;
            int y = (int)tilePosition.Y;

            Main.spawnTileX = x;
            Main.spawnTileY = y;

            caller.Reply("Set world spawn to (" + x + ", " + y + ")!");
        }
    }
}
