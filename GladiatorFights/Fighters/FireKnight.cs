using GladiatorFights.Interfaces;
using GladiatorFights.Strategies;

namespace GladiatorFights.Fighters
{
    internal class FireKnight : FighterBase
    {
        private readonly IAttackStrategy _fireballAttack;
        private int _mana;
        private int _manaCostFireball;
        private int _regenerationMana;
        private bool _canUsedFireball;

        public FireKnight(string name, int health, int armor, int damage, int mana)
            : base(name, health, armor, damage)
        {
            _mana = mana;
            _manaCostFireball = 8;
            _regenerationMana = 10;
            _fireballAttack = new FireballAttackStrategy();
        }

        protected override void BeforeAttack(IDamageable target)
        {
            if (_mana >= _manaCostFireball)
            {
                SetAttackStrategy(_fireballAttack);
                _canUsedFireball = true;
            }
            else
            {
                SetAttackStrategy(S_StandardAttack);
                _canUsedFireball = false;
            }
        }

        protected override void AfterAttack(IDamageable target)
        {
            if (_canUsedFireball)
            {
                _mana -= _manaCostFireball;
            }

            _mana += _regenerationMana;
        }

        public override string GetSpecialAbilities()
        {
            return $"Огненная атака";
        }

        public override FighterBase Clone()
        {
            var clone = new FireKnight(Name, Health, Armor, Damage, _mana);
            return clone;
        }
    }
}
