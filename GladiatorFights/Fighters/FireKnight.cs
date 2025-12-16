using GladiatorFights.Interfaces;
using GladiatorFights.Strategies;

namespace GladiatorFights.Fighters
{
    internal class FireKnight : FighterBase
    {
        private readonly IAttackStrategy _fireballAttack;
        private readonly int _manaCostFireball;
        private readonly int _regenerationMana;
        private int _mana;
        private bool _canUsedFireball;

        public FireKnight(string name, int health, int armor, int damage, int mana)
            : base(name, health, armor, damage)
        {
            _mana = mana;
            _manaCostFireball = 8;
            _regenerationMana = 10;
            _fireballAttack = new FireballAttackStrategy();
        }

        public override string GetSpecialAbilities()
        {
            return $"Огненная атака";
        }

        public override FighterBase Clone()
            => new FireKnight(Name, Health, Armor, Damage, _mana);

        protected override void RunPreAttack(IDamageable target)
        {
            if (_mana >= _manaCostFireball)
            {
                SetAttackStrategy(_fireballAttack);
                _canUsedFireball = true;
            }
            else
            {
                SetAttackStrategy(StandardAttack);
                _canUsedFireball = false;
            }
        }

        protected override void RunPostAttack(IDamageable target)
        {
            if (_canUsedFireball)
            {
                _mana -= _manaCostFireball;
            }

            _mana += _regenerationMana;
        }
    }
}
