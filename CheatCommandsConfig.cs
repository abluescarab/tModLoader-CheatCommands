using CheatCommands.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace CheatCommands {
    public class CheatCommandsConfig : ModConfig {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [SeparatePage]
        public List<MultiCommandDefinition> MultiCommands = new();

        [Header("$Mods.CheatCommands.Config.NPCCommands_Header")]
        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.KillAll_Label")]
        public bool KillAllEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.Kill_Label")]
        public bool KillEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.Spawn_Label")]
        public bool SpawnNPCEnabled;

        [Header("$Mods.CheatCommands.Config.PlayerCommands_Header")]
        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.Buff_Label")]
        public bool BuffEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.RemoveBuff_Label")]
        public bool DebuffEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.GiveCoins_Label")]
        public bool GiveCoinsEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.GiveItem_Label")]
        public bool GiveItemEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.GodMode_Label")]
        public bool GodModeEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.Home_Label")]
        public bool HomeEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.InfiniteAmmo_Label")]
        public bool InfiniteAmmoEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.KillMe_Label")]
        public bool KillMeEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.Knockback_Label")]
        public bool KnockbackEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.Position_Label")]
        public bool PositionEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.Prefix_Label")]
        public bool PrefixEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.Teleport_Label")]
        public bool TeleportEnabled;

        [Header("$Mods.CheatCommands.Config.WorldCommands_Header")]
        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.Event_Label")]
        public bool EventEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.FreezeTime_Label")]
        public bool FreezeTimeEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.SetSpawn_Label")]
        public bool SetSpawnEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.SettleLiquids_Label")]
        public bool SettleLiquidsEnabled;

        [DefaultValue(true)]
        [LabelKeyAttribute("$Mods.CheatCommands.Config.Time_Label")]
        public bool TimeEnabled;
    }
}
