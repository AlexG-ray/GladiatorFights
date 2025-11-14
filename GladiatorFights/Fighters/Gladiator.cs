using GladiatorFights.Strategies;

namespace GladiatorFights.Fighters
{
    internal class Gladiator : FighterBase
    {

        public Gladiator(string name, int health, int armor, int damage, IAttackStrategy strategyAttack) : 
            base(name, health, armor, damage, strategyAttack)
        {
        }
        // умение - каждый третий удар наносит удвоенный урон
    }
}
