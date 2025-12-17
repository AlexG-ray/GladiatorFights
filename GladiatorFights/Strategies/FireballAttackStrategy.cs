using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class FireballAttackStrategy : IAttackStrategy
    {
        private int _damageMultiplierForFireballAttack = 2;

        public string Description => "огненный шар";

        public int CalculateDamage(FighterBase attacker, IDamageable target)
        {
            int damageFireball = attacker.Damage * _damageMultiplierForFireballAttack;

            return damageFireball;
        }
    }
}
