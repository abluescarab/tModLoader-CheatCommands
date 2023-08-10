using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.World {
    class SetSpawn : CheatCommand {
        public override string Command => "setspawn";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.SetSpawn.Description");
        public override CommandType Type => CommandType.World;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().SetSpawnEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            Vector2 tilePosition = (caller.Player.Bottom + Vector2.UnitY) * 0.0625f;
            int x = (int)tilePosition.X;
            int y = (int)tilePosition.Y;

            Main.spawnTileX = x;
            Main.spawnTileY = y;

            NetMessage.SendData(MessageID.WorldData);
            return new CommandReply(
                Language.GetTextValue("Mods.CheatCommands.Commands.SetSpawn.Success",
                caller.Player.name,
                x,
                y));
        }
    }
}
