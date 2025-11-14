using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class StandardAttackStrategy : IAttackStrategy
    {
        public string Description => "обычный удар";

        public int CalculateDamage(FighterBase attacker, IDamageable target)
        {
            return attacker.Damage;
        }
    }
}
