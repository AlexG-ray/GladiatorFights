using GladiatorFights;
using GladiatorFights.Interfaces;

namespace GladiatorFights.Game
{
    internal class BattleEngine
    {
        private FighterBase _fighterFirst;
        private FighterBase _fighterSecond;
        private IBattleLogger _logger;

        public BattleEngine(FighterBase fighterFirst, FighterBase fighterSecond, IBattleLogger logger)
        {
            logger = _logger;
            _fighterFirst = fighterFirst;
            _fighterSecond = fighterSecond;
            Winner = GetWinner();
        }

        public FighterBase Winner { get; private set; } 

        private FighterBase GetWinner()
        {

            while (_fighterFirst.IsAlive && _fighterSecond.IsAlive)
            {
                _fighterFirst.Attack(_fighterSecond);
                _fighterSecond.Attack(_fighterFirst);
            }

            if (_fighterFirst.IsAlive == true)
            {
                Winner = _fighterFirst;
            }

            if (_fighterSecond.IsAlive == true)
            {
                Winner = _fighterSecond;
            }

            return Winner;
        }
    }
}
