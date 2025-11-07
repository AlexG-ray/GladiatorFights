using System;

namespace GladiatorFights
{
    abstract class FighterBase
    {
        protected FighterBase(string name, int health, int armor, int damage)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public string Name { get; protected set; }

        public int Health { get; protected set; }

        public int Armor { get; protected set; }

        public int Damage { get; protected set; }

        protected abstract void TakeDamage();
        protected abstract void Attack();
        protected abstract bool IsAlive();
    }
}
