using GladiatorFights.Interfaces;

namespace GladiatorFights.Strategies
{
    internal interface IAttackStrategy
    {
        string Description { get; }

        void ExecuteAttack(FighterBase attacker, IDamageable target);
    }
}
