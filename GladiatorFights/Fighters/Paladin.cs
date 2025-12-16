using System;
using GladiatorFights.Interfaces;
using GladiatorFights.Strategies;

namespace GladiatorFights.Fighters
{
    internal class Paladin : FighterBase
    {
        private readonly IAttackStrategy _lightOfAttack;
        private readonly int _maxSanctity;
        private int _sanctity;

        public Paladin(string name, int health, int armor, int damage, int maxSanctity)
            : base(name, health, armor, damage)
        {
            _sanctity = 0;
            _maxSanctity = maxSanctity;
            _lightOfAttack = new AttackOfLightStrategy();
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            _sanctity += damage / 2;
            _sanctity = Math.Min(_sanctity, _maxSanctity);
        }

        public override string GetSpecialAbilities()
        {
            return $"Святость";
        }

        public override FighterBase Clone()
        {
            return new Paladin(Name, Health, Armor, Damage, _maxSanctity);
        }

        protected override void RunPreAttack(IDamageable target)
        {
            if (_sanctity >= _maxSanctity)
            {
                SetAttackStrategy(_lightOfAttack);
            }
            else
            {
                SetAttackStrategy(StandardAttack);
            }
        }

        protected override void RunPostAttack(IDamageable target)
        {
            if (_sanctity >= _maxSanctity)
            {
                int healAmount = _sanctity;
                _sanctity = 0;
                Health += healAmount;
            }
        }
    }
}
