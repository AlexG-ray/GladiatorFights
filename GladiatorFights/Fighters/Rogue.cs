using GladiatorFights.Strategies;

namespace GladiatorFights.Fighters
{
    internal class Rogue : FighterBase
    {
        public Rogue(string name, int health, int armor, int damage, IAttackStrategy strategyAttack) : base(name, health, armor, damage, strategyAttack)
        {
        }

        // умение нанести удвоенный урон
    }
}
