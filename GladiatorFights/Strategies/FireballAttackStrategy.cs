using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class FireballAttackStrategy : IAttackStrategy
    {
        private int _damageMultiplierForFireballAttack = 2;

        public string Description => "огненный шар";

        public void ExecuteAttack(FighterBase attacker, IDamageable target)
        {
            target.TakeDamage(attacker.Damage * _damageMultiplierForFireballAttack);
        }
    }
}
