using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class StandardAttackStrategy : IAttackStrategy
    {
        public string Description => "обычный удар";

        public void ExecuteAttack(FighterBase attacker, IDamageable target)
        {
            target.TakeDamage(attacker.Damage);
        }
    }
}
