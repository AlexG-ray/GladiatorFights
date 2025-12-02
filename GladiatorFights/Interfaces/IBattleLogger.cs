namespace GladiatorFights.Interfaces
{
    internal interface IBattleLogger
    {
        void LogAttack(FighterBase attacker, FighterBase target, int damage);
        void LogAbility(FighterBase fighter, string ability);
        void LogStats(FighterBase firstFighter, FighterBase secondFighter);
    }
}
