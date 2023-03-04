using Microsoft.Xna.Framework;

namespace CheatCommands {
    public struct CommandReply {
        public static readonly CommandReply Empty = new CommandReply();

        public string Text { get; set; }
        public Color TextColor { get; set; }
        public bool IsEmpty => string.IsNullOrEmpty(Text) && TextColor.PackedValue == 0;

        public CommandReply(string text) : this() {
            Text = text;
            TextColor = Color.White;
        }

        public CommandReply(string text, Color textColor) : this() {
            Text = text;
            TextColor = textColor;
        }
    }
}
