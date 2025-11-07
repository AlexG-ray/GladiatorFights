using System;

namespace GladiatorFights.Fighters
{
    internal class FireKnight : FighterBase
    {
        private int _mana;

        public FireKnight(string name, int health, int armor, int mana, int damage) : base(name, health, armor, damage)
        {
            _mana = mana;
        }

        // пока есть манна аттакует огенным шаром. Огненный шар наносит урон больше обычного
    }
}
