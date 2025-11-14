using GladiatorFights.Strategies;

namespace GladiatorFights.Fighters
{
    internal class Paladin : FighterBase
    {
        public Paladin(string name, int health, int armor, int damage, IAttackStrategy strategyAttack) : 
            base(name, health, armor, damage, strategyAttack)
        {
        }
    }
}
