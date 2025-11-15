using GladiatorFights.Interfaces;
using GladiatorFights.Strategies;
using System;

namespace GladiatorFights.Fighters
{
    internal class Barbarian : FighterBase
    {
        private readonly RageAttackStrategy _rageAttack;
        private int _rage;
        private int _fullRage;
        private int _healingAmount;

        public Barbarian(string name, int health, int armor, int damage, int fullRage) :
            base(name, health, armor, damage)
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

        protected override void BeforeAttack(IDamageable target)
        {
            if (_rage >= _fullRage)
            {
                SetAttackStrategy(_rageAttack);
            }
            else
            {
                SetAttackStrategy(s_standardAttack);
            }
        }

        protected override void AfterAttack(IDamageable target)
        {
            if (_rage >= _fullRage)
            {
                Health += _healingAmount;
                _rage = 0;
            }
        }
    }
}
