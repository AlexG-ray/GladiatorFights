using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class RageAttackStrategy : IAttackStrategy
    {
        private int _damageMultiplierForRageAttack = 2;

        public string Description => "яростная атака";

        public int CalculateDamage(FighterBase attacker, IDamageable target)
        {
            return attacker.Damage * _damageMultiplierForRageAttack;
        }
    }
}
