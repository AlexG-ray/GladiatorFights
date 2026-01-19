using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class DoubleAttackStrategy : IAttackStrategy
    {
        public string Description => "двойная атака";

        public void ExecuteAttack(FighterBase attacker, IDamageable target)
        {
            target.TakeDamage(attacker.Damage);

            if (target.IsAlive)
            {
                target.TakeDamage(attacker.Damage);
            }
        }
    }
}
