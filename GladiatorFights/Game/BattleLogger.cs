using GladiatorFights.Interfaces;
using System;

namespace GladiatorFights.Game
{
    internal class BattleLogger : IBattleLogger 
    {
        private BattleEngine _engine;

        public BattleLogger(BattleEngine engine)
        {
            _engine = engine;
        }

        public void LogAbility(FighterBase fighter, string ability)
        {
            throw new NotImplementedException();
        }

        public void LogAttack(FighterBase attacker, FighterBase target, int damage)
        {
            throw new NotImplementedException();
        }

        public void LogStats(FighterBase firstFighter, FighterBase secondFighter)
        {
            throw new NotImplementedException();
        }

        public void ShowBattleProgress()
        {

        }


        
    }
}
