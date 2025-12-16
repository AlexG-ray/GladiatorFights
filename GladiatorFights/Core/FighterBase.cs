using System;

using GladiatorFights.Interfaces;
using GladiatorFights.Strategies;

namespace GladiatorFights
{
    internal abstract class FighterBase : IAttacker, IDamageable
    {
        protected static readonly StandardAttackStrategy StandardAttack = new StandardAttackStrategy();

        protected FighterBase(string name, int health, int armor, int damage)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Damage = damage;
            TypeAttack = StandardAttack;
        }

        public string Name { get; protected set; }

        public int Health { get; protected set; }

        public int Armor { get; protected set; }

        public int Damage { get; protected set; }

        public int ReceivedDamage { get; protected set; }

        public bool IsAlive => Health > 0;

        protected IAttackStrategy TypeAttack { get; private set; }

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
            ReceivedDamage = damage;
        }

        public virtual string GetSpecialAbilities()
        {
            return "Обычный боец";
        }

        public virtual string GetUsedAbilityDescription()
        {
            if (TypeAttack != StandardAttack)
            {
                return TypeAttack.Description;
            }

            return null;
        }

        public abstract FighterBase Clone();

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
    }
}
