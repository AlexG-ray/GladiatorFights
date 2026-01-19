using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class AttackOfLightStrategy : IAttackStrategy
    {
        private int _damageMultiplierForLightAttack = 3;

        public string Description => "атака света";

        public void ExecuteAttack(FighterBase attacker, IDamageable target)
        {
            target.TakeDamage(attacker.Damage * _damageMultiplierForLightAttack);
        }
    }
}
