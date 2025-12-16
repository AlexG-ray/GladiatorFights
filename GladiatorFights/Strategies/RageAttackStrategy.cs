using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class RageAttackStrategy : IAttackStrategy
    {
        public string Description => "яростная атака";

        public int CalculateDamage(FighterBase attacker, IDamageable target)
        {
            return attacker.Damage * 2;
        }
    }
}
