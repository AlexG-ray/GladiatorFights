using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class DoubleDamageStrategy : IAttackStrategy
    {
        private int _damageMultiplierForDoubleDamageAttack = 2;

        public string Description => "двойной урон";

        public void ExecuteAttack(FighterBase attacker, IDamageable target)
        {
            target.TakeDamage(attacker.Damage * _damageMultiplierForDoubleDamageAttack);
        }
    }
}
