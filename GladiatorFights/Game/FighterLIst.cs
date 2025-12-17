using System.Collections.Generic;
using GladiatorFights.Fighters;

namespace GladiatorFights.Game
{
    internal class FighterList
    {
        private readonly List<FighterBase> _fighters;

        public FighterList()
        {
            _fighters = new List<FighterBase>()
            {
                new Barbarian("Nomad", 100, 20, 30, 50),
                new FireKnight("Warlord", 90, 25, 35, 40),
                new Gladiator("Gladus", 100, 30, 40),
                new Monk("Hermit", 80, 15, 25, 40),
                new Paladin("Crusader", 90, 20, 30, 40),
                new Rogue("Bandit", 70, 10, 30, 50),
            };
        }

        public int Count => _fighters.Count;

        public FighterBase GetFighter(int index)
        {
            if (index >= 0 && index < _fighters.Count)
            {
                return _fighters[index];
            }

            return null;
        }

        public List<FighterBase> GetAllFighters() =>
            new List<FighterBase>(_fighters);

        public int GetIndexByName(string name) =>
            _fighters.FindIndex(figter => figter.Name == name);
    }
}
