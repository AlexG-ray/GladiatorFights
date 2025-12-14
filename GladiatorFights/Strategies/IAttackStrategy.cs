using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal interface IAttackStrategy
    {
        string Description { get; }

        int CalculateDamage(FighterBase attacker, IDamageable target);
    }
}
