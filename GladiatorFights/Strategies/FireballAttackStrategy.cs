using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class FireballAttackStrategy : IAttackStrategy
    {
        public string Description => "огненный шар";

        public int CalculateDamage(FighterBase attacker, IDamageable target)
        {
            int damageFireball = attacker.Damage * 2;

            return damageFireball;
        }
    }
}
