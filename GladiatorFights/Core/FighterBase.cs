using GladiatorFights.Interfaces;
using GladiatorFights.Strategies;
using System;

namespace GladiatorFights
{
    internal abstract class FighterBase : IAttacker, IDamageable
    {
        protected static readonly StandardAttackStrategy s_standardAttack = new StandardAttackStrategy();

        protected FighterBase(string name, int health, int armor, int damage)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Damage = damage;
            TypeAttack = s_standardAttack;
        }

        protected IAttackStrategy TypeAttack { get; private set; }

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

        protected virtual int CalculateDamage(IDamageable target) =>
            TypeAttack.CalculateDamage(this, target);

        protected virtual void AfterAttack(IDamageable target) { }

        protected virtual void BeforeAttack(IDamageable target) { }

        protected bool CanAttack(IDamageable target) =>
            IsAlive && target != null && target.IsAlive && target != this;

        protected void SetAttackStrategy(IAttackStrategy typeAttack)
        {
            TypeAttack = typeAttack;
        }

        public virtual string GetSpecialAbilities()
        {
            return "Обычный боец";
        }

        public abstract FighterBase Clone();
    }
}
