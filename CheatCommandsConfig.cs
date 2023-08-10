using CheatCommands.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CheatCommands {
    public class CheatCommandsConfig : ModConfig {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [SeparatePage]
        public List<MultiCommandDefinition> MultiCommands = new();

        [Header("NPCCommands")]
        [DefaultValue(true)]
        public bool KillAllEnabled;

        [DefaultValue(true)]
        public bool KillEnabled;

        [DefaultValue(true)]
        public bool SpawnNPCEnabled;

        [Header("PlayerCommands")]
        [DefaultValue(true)]
        public bool BuffEnabled;

        [DefaultValue(true)]
        public bool DebuffEnabled;

        [DefaultValue(true)]
        public bool GiveCoinsEnabled;

        [DefaultValue(true)]
        public bool GiveItemEnabled;

        [DefaultValue(true)]
        public bool GodModeEnabled;

        [DefaultValue(true)]
        public bool HomeEnabled;

        [DefaultValue(true)]
        public bool InfiniteAmmoEnabled;

        [DefaultValue(true)]
        public bool KillMeEnabled;

        [DefaultValue(true)]
        public bool KnockbackEnabled;

        [DefaultValue(true)]
        public bool PositionEnabled;

        [DefaultValue(true)]
        public bool PrefixEnabled;

        [DefaultValue(true)]
        public bool TeleportEnabled;

        [Header("WorldCommands")]
        [DefaultValue(true)]
        public bool EventEnabled;

        [DefaultValue(true)]
        public bool FreezeTimeEnabled;

        [DefaultValue(true)]
        public bool SetSpawnEnabled;

        [DefaultValue(true)]
        public bool SettleLiquidsEnabled;

        [DefaultValue(true)]
        public bool TimeEnabled;
    }
}
