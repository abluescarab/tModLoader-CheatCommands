using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader.IO;

namespace CheatCommands {
    internal class HomeList {
        private const string HOMES_TAG = "homes";
        private IList<HomeLocation> _homes;

        public int Count => _homes.Count;

        public HomeList() {
            _homes = new List<HomeLocation>();
        }

        public List<HomeLocation> GetWorldHomes() {
            return _homes.Where(h => h.WorldId == Main.worldID).ToList();
        }

        public void Add(string name, Vector2 position) {
            _homes.Add(new HomeLocation(Main.worldID, name, position));
        }

        public bool Remove(string name) {
            List<HomeLocation> homes = GetWorldHomes();
            return _homes.Remove(homes.FirstOrDefault(h => h.Name == name));
        }

        public int ClearWorld() {
            int count = 0;

            foreach(HomeLocation home in GetWorldHomes()) {
                _homes.Remove(home);
                count++;
            }

            return count;
        }

        public int Clear() {
            int count = _homes.Count;
            _homes.Clear();
            return count;
        }

        public bool Has(string name) {
            return GetWorldHomes().Any(h => h.Name == name);
        }

        public HomeLocation Get(string name) {
            return GetWorldHomes().FirstOrDefault(h => h.Name == name);
        }

        public void SaveData(TagCompound tag) {
            tag.Add(HOMES_TAG, _homes);
        }

        public void LoadData(TagCompound tag) {
            _homes = tag.GetList<HomeLocation>(HOMES_TAG);
        }
    }
}
