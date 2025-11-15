using GladiatorFights.Strategies;

namespace GladiatorFights.Fighters
{
    internal class Monk : FighterBase
    {
        private int _agility;
        public Monk(string name, int health, int armor, int damage, int agility) : 
            base(name, health, armor, damage, new StandardAttackStrategy())
        {
            _agility = agility;
        }

        // умение - уклониться
    }
}
