using GladiatorFights.Strategies;

namespace GladiatorFights.Fighters
{
    internal class FireKnight : FighterBase
    {
        private int _mana;

        public FireKnight(string name, int health, int armor, int damage, IAttackStrategy strategyAttack, int mana) 
            : base(name, health, armor, damage, strategyAttack)
        {
            _mana = mana;
        }


        // пока есть манна аттакует огенным шаром. Огненный шар наносит урон больше обычного
    }
}
