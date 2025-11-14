using GladiatorFights.Strategies;

namespace GladiatorFights.Fighters
{
    internal class Barbarian : FighterBase
    {
        public Barbarian(string name, int health, int armor, int damage, IAttackStrategy attackStrategy) : 
            base (name, health, armor, damage, attackStrategy)
        {
        }

        // умение - накапливаает ярость, после накопелния макс, востанавливает здоровье
    }
}
