namespace GladiatorFights.Fighters
{
    internal class Barbarian : FighterBase
    {
        public Barbarian(string name, int health, int armor, int damage) : base(name, health, armor, damage)
        {
        }

        // умение - накапливаает ярость, после накопелния макс, востанавливает здоровье
    }
}
