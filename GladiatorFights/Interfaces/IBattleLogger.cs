namespace GladiatorFights.Interfaces
{
    internal interface IBattleLogger
    {
        void LogAttack(FighterBase attacker, FighterBase target, int damage);

        void LogDamage(FighterBase target, int damage);

        void LogAbility(FighterBase fighter);

        void LogStats(FighterBase fighter);

        void LogDead(FighterBase loser);
    }
}
