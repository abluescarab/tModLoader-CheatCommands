using CheatCommands.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CheatCommands {
    public class CheatCommandsConfig : ModConfig {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [SeparatePage]
        public List<MultiCommandDefinition> MultiCommands = new List<MultiCommandDefinition>();

        [Header("$Mods.CheatCommands.Config.NPCCommands_Header")]
        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.KillAll_Label")]
        public bool KillAllEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.Kill_Label")]
        public bool KillEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.Spawn_Label")]
        public bool SpawnNPCEnabled;

        [Header("$Mods.CheatCommands.Config.PlayerCommands_Header")]
        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.Buff_Label")]
        public bool BuffEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.RemoveBuff_Label")]
        public bool DebuffEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.GiveCoins_Label")]
        public bool GiveCoinsEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.GiveItem_Label")]
        public bool GiveItemEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.GodMode_Label")]
        public bool GodModeEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.Home_Label")]
        public bool HomeEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.InfiniteAmmo_Label")]
        public bool InfiniteAmmoEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.KillMe_Label")]
        public bool KillMeEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.Knockback_Label")]
        public bool KnockbackEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.Position_Label")]
        public bool PositionEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.Teleport_Label")]
        public bool TeleportEnabled;

        [Header("$Mods.CheatCommands.Config.WorldCommands_Header")]
        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.FreezeTime_Label")]
        public bool FreezeTimeEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.SetSpawn_Label")]
        public bool SetSpawnEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.SettleLiquids_Label")]
        public bool SettleLiquidsEnabled;

        [DefaultValue(true)]
        [Label("$Mods.CheatCommands.Config.Time_Label")]
        public bool TimeEnabled;
    }
}
