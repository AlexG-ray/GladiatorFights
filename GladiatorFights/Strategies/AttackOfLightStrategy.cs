using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class AttackOfLightStrategy : IAttackStrategy
    {
        private int _damageMultiplierForLightAttack = 3;

        public string Description => "атака света";

        public int CalculateDamage(FighterBase attacker, IDamageable target)
        {
            return attacker.Damage * _damageMultiplierForLightAttack;
        }
    }
}
