using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class TripleAttackStrategy : IAttackStrategy
    {
        private int _damageMultiplierForTripleAttack = 3;

        public string Description => "тройной урон";

        public int CalculateDamage(FighterBase attacker, IDamageable target)
        {
            return attacker.Damage * _damageMultiplierForTripleAttack;
        }
    }
}
