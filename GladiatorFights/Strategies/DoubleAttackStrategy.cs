using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class DoubleAttackStrategy : IAttackStrategy
    {
        public string Description => "двойной удар";

        public int CalculateDamage(FighterBase attacker, IDamageable target)
        {
            return attacker.Damage * 2;
        }
    }
}
