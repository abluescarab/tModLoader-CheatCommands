using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.World {
    public class Event : CheatCommand {
        private enum WorldEvent {
            None = 0,
            BloodMoon,
            GoblinArmy,
            SlimeRain,
            FrostLegion,
            SolarEclipse,
            PirateInvasion,
            PumpkinMoon,
            FrostMoon,
            MartianMadness
        }

        private Dictionary<WorldEvent, string[]> Options = new Dictionary<WorldEvent, string[]>() {
            { WorldEvent.BloodMoon, new string[] { "blood moon", "blood" } },
            { WorldEvent.GoblinArmy, new string[] { "goblin invasion", "goblins" } },
            { WorldEvent.SlimeRain, new string[] { "slime rain", "slimes" } },
            { WorldEvent.FrostLegion, new string[] { "frost legion", "legion" } },
            { WorldEvent.SolarEclipse, new string[] { "solar eclipse", "eclipse" } },
            { WorldEvent.PirateInvasion, new string[] { "pirate invasion", "pirates" } },
            { WorldEvent.PumpkinMoon, new string[] { "pumpkin moon", "pumpkin" } },
            { WorldEvent.FrostMoon, new string[] { "frost moon", "frost" } },
            { WorldEvent.MartianMadness, new string[] { "martian madness", "martians" } }
        };

        public override string Command => "event";
        public override string Description
            => Language.GetTextValue("Mods.CheatCommands.Commands.Event_Description");
        public override string Usage => base.Usage + " <stop/name>\n" + GetOptions();
        public override int MinimumArguments => 1;
        public override CommandType Type => CommandType.World;
        public override bool CommandEnabled => ModContent.GetInstance<CheatCommandsConfig>().EventEnabled;

        public override CommandReply Action(CommandCaller caller, string[] args) {
            string name = args[0].ToLower();
            var worldEvent = Options.FirstOrDefault(i => i.Value.Contains(name));

            if(name == "stop") {
                Main.stopMoonEvent();
                Main.StopSlimeRain();
                Main.bloodMoon = false;
                Main.eclipse = false;
                StopInvasion();

                return new CommandReply(Language.GetTextValue("Mods.CheatCommands.Commands.Event_Stop"));
            }

            // below code modified from Terraria source
            switch(worldEvent.Key) {
                case WorldEvent.BloodMoon:
                    Main.bloodMoon = true;

                    if(Main.netMode == NetmodeID.SinglePlayer) {
                        Main.NewText(Lang.misc[8].Value, 50, 255, 130);
                    }
                    else if(Main.netMode == NetmodeID.Server) {
                        ChatHelper.BroadcastChatMessage(Lang.misc[8].ToNetworkText(),
                            new Color(50, 255, 130), -1);
                    }

                    name = Language.GetTextValue("Bestiary_Events.BloodMoon");
                    break;
                case WorldEvent.GoblinArmy:
                    StopInvasion();
                    Main.StartInvasion(InvasionID.GoblinArmy);
                    name = Language.GetTextValue("Bestiary_Invasions.Goblins");
                    break;
                case WorldEvent.SlimeRain:
                    Main.StartSlimeRain();
                    name = Language.GetTextValue("Bestiary_Events.SlimeRain");
                    break;
                case WorldEvent.FrostLegion:
                    StopInvasion();
                    Main.StartInvasion(InvasionID.SnowLegion);
                    name = Language.GetTextValue("Bestiary_Invasions.FrostLegion");
                    break;
                case WorldEvent.SolarEclipse:
                    Main.eclipse = true;

                    if(Main.netMode == NetmodeID.SinglePlayer) {
                        Main.NewText(Lang.misc[20].Value, 50, 255, 130);
                    }
                    else if(Main.netMode == NetmodeID.Server) {
                        ChatHelper.BroadcastChatMessage(
                            Lang.misc[20].ToNetworkText(),
                            new Color(50, 255, 130),
                            -1);
                    }

                    name = Language.GetTextValue("Bestiary_Events.Eclipse");
                    break;
                case WorldEvent.PirateInvasion:
                    StopInvasion();
                    Main.StartInvasion(InvasionID.PirateInvasion);
                    name = Language.GetTextValue("Bestiary_Invasions.Pirates");
                    break;
                case WorldEvent.PumpkinMoon:
                    StopInvasion();
                    Main.startPumpkinMoon();
                    name = Language.GetTextValue("Bestiary_Invasions.PumpkinMoon");
                    break;
                case WorldEvent.FrostMoon:
                    StopInvasion();
                    Main.startSnowMoon();
                    name = Language.GetTextValue("Bestiary_Invasions.FrostMoon");
                    break;
                case WorldEvent.MartianMadness:
                    StopInvasion();
                    Main.StartInvasion(InvasionID.MartianMadness);
                    name = Language.GetTextValue("Bestiary_Invasions.Martian");
                    break;
                default:
                    name = "";
                    break;
            }

            NetMessage.SendData(MessageID.WorldData);

            if(string.IsNullOrEmpty(name)) {
                return new CommandReply(
                    Language.GetTextValue("Mods.CheatCommands.Commands.Event_Unknown"), Color.Red);
            }

            return new CommandReply(
                Language.GetTextValue("Mods.CheatCommands.Commands.Event_Start", name));
        }

        private void StopInvasion() {
            if(Main.invasionType > 0) {
                Main.invasionType = 0;
                NetMessage.SendData(MessageID.InvasionProgressReport);
            }
        }

        private string GetOptions() {
            string result = "names: ";

            for(int i = 0; i < Options.Values.Count; i++) {
                result += string.Join('/', Options.Values.ElementAt(i));

                if(i < Options.Values.Count - 1) {
                    result += ", ";
                }

                if((i + 1) % 3 == 0) {
                    result += "\n         ";
                }
            }

            return result;
        }
    }
}
