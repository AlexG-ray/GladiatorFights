using System;
using System.Collections.Generic;

using GladiatorFights.Interfaces;
using GladiatorFights.Strategies;

namespace GladiatorFights
{
    internal abstract class FighterBase : IAttacker, IDamageable
    {
        private readonly List<int> _receivedDamagesThisAttack = new List<int>();

        protected FighterBase(string name, int health, int armor, int damage)
        {
            StandardAttack = new StandardAttackStrategy();
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

        public IReadOnlyList<int> ReceivedDamagesThisAttack => _receivedDamagesThisAttack;

        public bool IsAlive => Health > 0;

        protected StandardAttackStrategy StandardAttack { get; set; }

        protected IAttackStrategy TypeAttack { get; private set; }

        public void Attack(IDamageable target)
        {
            if (CanAttack(target) == false)
            {
                ProcessAttackDenied(target);
                return;
            }

            if (target is FighterBase targetFighter)
            {
                targetFighter.ReceivedDamage = 0;
                targetFighter._receivedDamagesThisAttack.Clear();
            }

            RunPreAttack(target);
            TypeAttack.ExecuteAttack(this, target);
            RunPostAttack(target);
        }

        public virtual void TakeDamage(int damage)
        {
            damage = Math.Max(damage - Armor, 0);
            Health = Math.Max(Health - damage, 0);
            ReceivedDamage += damage;
            _receivedDamagesThisAttack.Add(damage);
        }

        public virtual string GetSpecialAbilities()
        {
            return "Обычный боец";
        }

        public virtual string GetUsedAbilityDescription()
        {
            if (TypeAttack is StandardAttackStrategy == false)
            {
                return TypeAttack.Description;
            }

            return null;
        }

        public abstract FighterBase Clone();

        protected virtual void ProcessAttackDenied(IDamageable target) { }

        protected virtual void RunPostAttack(IDamageable target) { }

        protected virtual void RunPreAttack(IDamageable target) { }

        protected bool CanAttack(IDamageable target) =>
            IsAlive && target != null && target.IsAlive && target != this;

        protected void SetAttackStrategy(IAttackStrategy typeAttack)
        {
            TypeAttack = typeAttack;
        }
    }
}
