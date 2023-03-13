using CheatCommands.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CheatCommands {
    public class CheatCommandsConfig : ModConfig {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [SeparatePage]
        public List<MultiCommandDefinition> MultiCommands = new List<MultiCommandDefinition>();

        [Header("NPC commands")]
        [DefaultValue(true)]
        [Label("Kill all NPCs (/killall)")]
        public bool KillAllEnabled;

        [DefaultValue(true)]
        [Label("Kill an NPC (/kill)")]
        public bool KillEnabled;

        [DefaultValue(true)]
        [Label("Spawn an NPC (/spawn)")]
        public bool SpawnNPCEnabled;

        [Header("Player commands")]
        [DefaultValue(true)]
        [Label("Give yourself a buff (/buff)")]
        public bool BuffEnabled;

        [DefaultValue(true)]
        [Label("Give yourself a debuff (/debuff)")]
        public bool DebuffEnabled;

        [DefaultValue(true)]
        [Label("Give yourself money (/coins)")]
        public bool GiveCoinsEnabled;

        [DefaultValue(true)]
        [Label("Give yourself an item (/give)")]
        public bool GiveItemEnabled;

        [DefaultValue(true)]
        [Label("Toggle god mode (/god)")]
        public bool GodModeEnabled;

        [DefaultValue(true)]
        [Label("Home teleport commands (/sethome, /delhome, /clearhomes, /home, /homes")]
        public bool HomeEnabled;

        [DefaultValue(true)]
        [Label("Toggle infinite ammo (/ammo)")]
        public bool InfiniteAmmoEnabled;

        [DefaultValue(true)]
        [Label("Kill your character (/killme)")]
        public bool KillMeEnabled;

        [DefaultValue(true)]
        [Label("Toggle damage knockback (/knockback)")]
        public bool KnockbackEnabled;

        [DefaultValue(true)]
        [Label("Get your current coordinates (/pos)")]
        public bool PositionEnabled;

        [DefaultValue(true)]
        [Label("Teleport yourself to a coordinate or another player (/tp)")]
        public bool TeleportEnabled;

        [Header("World commands")]
        [DefaultValue(true)]
        [Label("Freeze world time (/freeze)")]
        public bool FreezeTimeEnabled;

        [DefaultValue(true)]
        [Label("Set world spawn (/setspawn)")]
        public bool SetSpawnEnabled;

        [DefaultValue(true)]
        [Label("Settle all liquids (/settle)")]
        public bool SettleLiquidsEnabled;

        [DefaultValue(true)]
        [Label("Change time of day (/time)")]
        public bool TimeEnabled;
    }
}
