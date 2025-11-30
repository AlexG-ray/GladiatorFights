using GladiatorFights.Fighters;
using System.Collections.Generic;

namespace GladiatorFights.Game
{
    internal class FighterList
    {
        private readonly List<FighterBase> _fighters;

        public FighterList()
        {
            _fighters = new List<FighterBase>()
            {
                new Barbarian("Nomad", 100, 30, 25, 50),
                new FireKnight("Warlord",90, 80, 10, 40),
                new Gladiator("Gladus", 100, 80 , 25),
                new Monk("Hermit", 80, 30, 20, 40),
                new Paladin("Crusader", 90, 30, 15, 40 ),
                new Rogue( "Bandit", 70, 20, 20, 50)
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
             _fighters;
    }
}
