using GladiatorFights.Interfaces;
using System;
using System.Threading;

namespace GladiatorFights.Game
{
    internal class BattleLogger : IBattleLogger
    {
        public void LogAbility(FighterBase fighter)
        {
            string ability = fighter.GetUsedAbilityDescription();

            if (ability != null)
            {
                ColoringText($"{fighter.Name} применяет способность: {ability}!", 400, ConsoleColor.Cyan);
            }
        }

        public void LogAttack(FighterBase attacker, FighterBase target, int damage)
        {
            ColoringText($"{attacker.Name} наносит {target.Name} урон {damage}.", 400, ConsoleColor.Yellow);
        }

        public void LogStats(FighterBase target)
        {
            ColoringText($"Осталось HP:{target.Health} у {target.Name}.\n", 400, ConsoleColor.DarkYellow);
        }

        public void LogDead(FighterBase loser)
        {
            ColoringText($"{loser.Name} - мертв!!!", 1000, ConsoleColor.DarkRed);
        }

        public void LogDamage(FighterBase target, int damage)
        {
            ColoringText($"{target.Name} получает {damage} урона.", 400, ConsoleColor.DarkYellow);
        }

        private void ColoringText(string text, int delayTime = 0, ConsoleColor color = ConsoleColor.Gray)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Thread.Sleep(delayTime);
            Console.ForegroundColor = defaultColor;
        }
    }
}
