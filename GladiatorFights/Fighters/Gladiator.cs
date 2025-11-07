using System;

namespace GladiatorFights.Fighters
{
    internal class Gladiator : FighterBase
    {
        public Gladiator(string name, int health, int armor, int damage) : base(name, health, armor, damage)
        {
        }
        
        // умение - каждый третий удар наносит удвоенный урон
    }
}
