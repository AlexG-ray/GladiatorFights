using GladiatorFights.Interfaces;
using System;

namespace GladiatorFights.Strategies
{
    internal class AttackOfLightStrategy : IAttackStrategy
    {
        public string Description => "атака света";

        public int CalculateDamage(FighterBase attacker, IDamageable target)
        {
            return attacker.Damage * 3;
        }
    }
}
