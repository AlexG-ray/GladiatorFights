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

        private void PerformAttack(FighterBase attacker, FighterBase assailed)
        {
            attacker.Attack(assailed);
            if (assailed.ReceivedDamagesThisAttack.Count == 0)
            {
                _logger.LogAttack(attacker, assailed, 0);
                _logger.LogDamage(assailed, 0);
            }
            else
            {
                foreach (int hitDamage in assailed.ReceivedDamagesThisAttack)
                {
                    _logger.LogAttack(attacker, assailed, hitDamage);
                    _logger.LogDamage(assailed, hitDamage);
                }
            }

            _logger.LogAbility(attacker);
            _logger.LogStats(assailed);
        }
    }
}
