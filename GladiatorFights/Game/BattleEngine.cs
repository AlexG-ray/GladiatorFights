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
            _logger = logger;
            _fighterFirst = fighterFirst;
            _fighterSecond = fighterSecond;
        }

        public FighterBase Winner { get; private set; }

        public void StarFight()
        {
            while (_fighterFirst.IsAlive && _fighterSecond.IsAlive)
            {
                _logger.LogAttack(_fighterFirst, _fighterSecond, _fighterFirst.Damage);
                _fighterFirst.Attack(_fighterSecond);
                _logger.LogAbility(_fighterFirst);
                _logger.LogDamage(_fighterSecond, _fighterSecond.ReceivedDamage);
                _logger.LogStats(_fighterSecond);

                if (_fighterSecond.IsAlive == false)
                    break;

                _logger.LogAttack(_fighterSecond, _fighterFirst, _fighterSecond.Damage);
                _fighterSecond.Attack(_fighterFirst);
                _logger.LogAbility(_fighterSecond);
                _logger.LogDamage(_fighterFirst, _fighterFirst.ReceivedDamage);
                _logger.LogStats(_fighterFirst);
            }

            if (_fighterFirst.IsAlive == true)
            {
                Winner = _fighterFirst;
                _logger.LogDead(_fighterSecond);
            }

            if (_fighterSecond.IsAlive == true)
            {
                Winner = _fighterSecond;
                _logger.LogDead(_fighterFirst);
            }
        }
    }
}
