using GladiatorFights.Interfaces;
using GladiatorFights.Strategies;

namespace GladiatorFights.Fighters
{
    internal class Gladiator : FighterBase
    {
        private readonly IAttackStrategy _tripleAttack;
        private readonly int _skillActivationHitCount = 3;
        private int _impactCounter;

        public Gladiator(string name, int health, int armor, int damage)
            : base(name, health, armor, damage)
        {
            _impactCounter = 0;
            _tripleAttack = new TripleAttackStrategy();
        }

        public override string GetSpecialAbilities()
        {
            return "Двойной урон";
        }

        public override FighterBase Clone()
        {
            return new Gladiator(Name, Health, Armor, Damage);
        }

        protected override void RunPreAttack(IDamageable target)
        {
            _impactCounter++;

            if (_impactCounter % _skillActivationHitCount == 0)
            {
                SetAttackStrategy(_tripleAttack);
            }
            else
            {
                SetAttackStrategy(StandardAttack);
            }
        }

        protected override void RunPostAttack(IDamageable target)
        {
            if (_impactCounter >= _skillActivationHitCount)
            {
                _impactCounter = 0;
            }
        }
    }
}
