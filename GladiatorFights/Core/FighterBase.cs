using GladiatorFights.Interfaces;
using System;

namespace GladiatorFights
{
    internal abstract class FighterBase : IAttacker, IDamageable
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

        public bool IsAlive => Health > 0;

        public void Attack(IDamageable target)
        {
            if (CanAttack(target) == false)
            {
                OnAttackDenied(target);
                return;
            }

            BeforeAttack(target);
            int damage = CalculateDamage(target);
            ApplyDamage(target, damage);
            AfterAttack(target);
        }

        public virtual void TakeDamage(int damage)
        {
            damage = Math.Max(damage - Armor, 0);
            Health = Math.Max(Health - damage, 0);
        }

        protected virtual void OnAttackDenied(IDamageable target) { }
        protected virtual void ApplyDamage(IDamageable target, int damage) =>
            target.TakeDamage(damage);
        protected abstract int CalculateDamage(IDamageable target);
        protected virtual void AfterAttack(IDamageable target) { }
        protected virtual void BeforeAttack(IDamageable target) { }
        protected bool CanAttack(IDamageable target) =>
            IsAlive && target != null && target.IsAlive;
    }
}
