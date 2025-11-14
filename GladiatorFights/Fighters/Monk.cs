using GladiatorFights.Strategies;

namespace GladiatorFights.Fighters
{
    internal class Monk : FighterBase
    {
        private int _agility;
        public Monk(string name, int health, int armor, int damage, IAttackStrategy strategyAttack, int agility) : 
            base(name, health, armor, damage, strategyAttack)
        {
            _agility = agility;
        }

        // умение - уклониться
    }
}
