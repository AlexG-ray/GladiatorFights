using System.Runtime.InteropServices;

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
                PerformAttack(_fighterFirst, _fighterSecond);

                if (_fighterSecond.IsAlive == false)
                {
                    break;
                }

                PerformAttack(_fighterSecond, _fighterFirst);
            }

            if (_fighterFirst.IsAlive)
            {
                Winner = _fighterFirst;
                _logger.LogDead(_fighterSecond);
            }
            else if (_fighterSecond.IsAlive)
            {
                Winner = _fighterSecond;
                _logger.LogDead(_fighterFirst);
            }
        }

        private void PerformAttack(FighterBase attaker, FighterBase assailed)
        {
            _logger.LogAttack(attaker, assailed, attaker.Damage);
            attaker.Attack(assailed);
            _logger.LogAbility(attaker);
            _logger.LogDamage(assailed, assailed.ReceivedDamage);
            _logger.LogStats(assailed);
        }
    }
}
