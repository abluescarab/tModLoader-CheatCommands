using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CheatCommands {
    public class CheatCommandsConfig : ModConfig {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        public static CheatCommandsConfig Instance;

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
        [Label("Toggle infinite ammo (/ammo)")]
        public bool InfiniteAmmoEnabled;

        [DefaultValue(true)]
        [Label("Kill your character (/killme)")]
        public bool KillMeEnabled;

        [DefaultValue(true)]
        [Label("Toggle damage knockback (/knockback)")]
        public bool KnockbackEnabled;

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
