using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CheatCommands.Commands.World {
    class Time : CheatCommand {
        public override string CommandName => "Time";
        public override string Command => Language.GetTextValue("CLI.Time_Command");
        public override string Description => "Get the world time.";
        public override int MinimumArguments => 0;

        // from Terraria server commands
        public override void Action(CommandCaller caller, string[] args) {
            string ampm = "AM";
            double time = Main.time;
            double num = 7.5;

            if(!Main.dayTime) {
                time += 54000.0;
            }

            time = time / 86400.0 * 24.0;
            time = time - num - 12.0;

            if(time < 0.0) {
                time += 24.0;
            }

            if(time >= 12.0) {
                ampm = "PM";
            }

            int hours = (int)time;
            double minutes = time - hours;

            minutes = (int)(minutes * 60.0);

            string minutesString = minutes.ToString();

            if(minutes < 10.0) {
                minutesString = "0" + minutesString;
            }

            if(hours > 12) {
                hours -= 12;
            }

            if(hours == 0) {
                hours = 12;
            }

            caller.Reply(Language.GetTextValue("CLI.Time", string.Concat(new object[] {
                hours, ":", minutesString, " ", ampm
            })));
        }
    }
}
