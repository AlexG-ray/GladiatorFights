using GladiatorFights.Utils;

namespace GladiatorFights.Fighters
{
    internal class Monk : FighterBase
    {
        private int _agility;

        public Monk(string name, int health, int armor, int damage, int agility) :
            base(name, health, armor, damage)
        {
            _agility = agility;
        }

        public override void TakeDamage(int damage)
        {
            if (TryDodge() == false)
            {
                base.TakeDamage(damage);
            }
        }

        private bool TryDodge()
        {
            int roll = UserUtils.GenerateRandomNumber(1,101);

            return roll <= _agility;
        }

        public override string GetSpecialAbilities()
        {
            return $"Уклонение";
        }
    }
}
