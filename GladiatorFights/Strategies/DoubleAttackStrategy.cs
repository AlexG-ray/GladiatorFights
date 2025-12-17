using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class DoubleAttackStrategy : IAttackStrategy
    {
        private int _damageMultiplierForDoubleAttack = 2;

        public string Description => "двойной удар";

        public int CalculateDamage(FighterBase attacker, IDamageable target)
        {
            return attacker.Damage * _damageMultiplierForDoubleAttack;
        }
    }
}
