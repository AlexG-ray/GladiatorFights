using System;
using GladiatorFights.Interfaces;
using GladiatorFights.Strategies;

namespace GladiatorFights.Fighters
{
    internal class Barbarian : FighterBase
    {
        private readonly RageAttackStrategy _rageAttack;
        private readonly int _fullRage;
        private readonly int _healingAmount;
        private int _rage;

        public Barbarian(string name, int health, int armor, int damage, int fullRage)
            : base(name, health, armor, damage)
        {
            _rageAttack = new RageAttackStrategy();
            _rage = 0;
            _fullRage = fullRage;
            _healingAmount = 20;
        }

        public int Rage => _rage;

        public int FullRage => _fullRage;

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            _rage += damage;
            _rage = Math.Min(_rage, _fullRage);
        }

        public override FighterBase Clone()
        {
            return new Barbarian(Name, Health, Armor, Damage, _fullRage);
        }

        public override string GetSpecialAbilities()
        {
            return $"Ярость";
        }

        protected override void RunPreAttack(IDamageable target)
        {
            if (_rage >= _fullRage)
            {
                SetAttackStrategy(_rageAttack);
            }
            else
            {
                SetAttackStrategy(StandardAttack);
            }
        }

        protected override void RunPostAttack(IDamageable target)
        {
            if (_rage >= _fullRage)
            {
                Health += _healingAmount;
                _rage = 0;
            }
        }
    }
}
