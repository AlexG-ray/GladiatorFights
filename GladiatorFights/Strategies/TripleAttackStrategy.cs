using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal class TripleAttackStrategy : IAttackStrategy
    {
        public string Description => "тройной урон";

        public int CalculateDamage(FighterBase attacker, IDamageable target)
        {
            return attacker.Damage * 3;
        }
    }
}
