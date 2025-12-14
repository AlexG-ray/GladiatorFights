using GladiatorFights.Interfaces;
using GladiatorFights.Strategies;
using GladiatorFights.Utils;

namespace GladiatorFights.Fighters
{
    internal class Rogue : FighterBase
    {
        private int _lucky;
        private readonly IAttackStrategy _doubleAttack;

        public Rogue(string name, int health, int armor, int damage, int lucky)
            : base(name, health, armor, damage)
        {
            _lucky = lucky;
            _doubleAttack = new DoubleAttackStrategy();
        }

        public override string GetSpecialAbilities()
        {
            return $"Удача";
        }

        public override FighterBase Clone()
        {
            return new Rogue(Name, Health, Armor, Damage, _lucky);
        }

        protected override void BeforeAttack(IDamageable target)
        {
            if (TryLucky())
            {
                SetAttackStrategy(_doubleAttack);
            }
            else
            {
                SetAttackStrategy(S_StandardAttack);
            }
        }

        private bool TryLucky()
        {
            int roll = UserUtils.GenerateRandomNumber(1, 101);

            return roll <= _lucky;
        }
    }
}
