using Microsoft.Xna.Framework;
using System;
using Terraria.ModLoader.IO;

namespace CheatCommands {
    internal class HomeLocation : TagSerializable {
        internal readonly int WorldId;
        internal readonly string Name;
        internal readonly Vector2 Position;

        public static Func<TagCompound, HomeLocation> DESERIALIZER 
            = tag => new HomeLocation(tag);

        public HomeLocation(int worldId, string name, Vector2 position) {
            WorldId = worldId;
            Name = name;
            Position = position;
        }

        private HomeLocation(TagCompound tag) {
            WorldId = tag.Get<int>(nameof(WorldId));
            Name = tag.Get<string>(nameof(Name));
            Position = tag.Get<Vector2>(nameof(Position));
        }

        public TagCompound SerializeData() {
            return new TagCompound {
                { nameof(WorldId), WorldId },
                { nameof(Name), Name },
                { nameof(Position), Position }
            };
        }
    }
}
