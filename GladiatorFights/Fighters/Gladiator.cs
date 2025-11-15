using GladiatorFights.Interfaces;
using GladiatorFights.Strategies;

namespace GladiatorFights.Fighters
{
    internal class Gladiator : FighterBase
    {
        private readonly IAttackStrategy _tripleAttack;
        private int _impactCounter;

        public Gladiator(string name, int health, int armor, int damage) :
            base(name, health, armor, damage)
        {
            _impactCounter = 0;
            _tripleAttack = new DoubleAttackStrategy();
        }

        protected override void BeforeAttack(IDamageable target)
        {
            _impactCounter++;

            if (_impactCounter % 3 == 0)
            {
                SetAttackStrategy(_tripleAttack);
            }
            else
            {
                SetAttackStrategy(s_standardAttack);
            }
        }

        protected override void AfterAttack(IDamageable target)
        {
            if (_impactCounter >= 3)
            {
                _impactCounter = 0;
            }
        }
    }
}
