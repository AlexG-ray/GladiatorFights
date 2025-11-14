using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal interface IAttackStrategy
    {
        int CalculateDamage(FighterBase attacker, IDamageable target);
        string Description { get; }
    }
}
