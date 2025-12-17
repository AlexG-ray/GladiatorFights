using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class DoubleAttackStrategy : IAttackStrategy
    {
        private readonly StandardAttackStrategy _standardAttack = new StandardAttackStrategy();

        public string Description => "двойная атака";

        public int CalculateDamage(FighterBase attacker, IDamageable target)
        {
            int firstAttack = _standardAttack.CalculateDamage(attacker, target);
            int secondAttack = _standardAttack.CalculateDamage(attacker, target);

            return firstAttack + secondAttack;
        }
    }
}
