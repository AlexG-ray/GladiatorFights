using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class DoubleDamageStarategy : IAttackStrategy
    {
        private int _damageMultiplierForDoubleDamageAttack = 2;

        public string Description => "двойной урон";

        public int CalculateDamage(FighterBase attacker, IDamageable target)
        {
            return attacker.Damage * _damageMultiplierForDoubleDamageAttack;
        }
    }
}
