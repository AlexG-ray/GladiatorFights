using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class RageAttackStrategy : IAttackStrategy
    {
        private int _damageMultiplierForRageAttack = 2;

        public string Description => "яростная атака";

        public void ExecuteAttack(FighterBase attacker, IDamageable target)
        {
            target.TakeDamage(attacker.Damage * _damageMultiplierForRageAttack);
        }
    }
}
