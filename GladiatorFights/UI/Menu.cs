using System;
using System.Threading;
using GladiatorFights.Game;
using GladiatorFights.Interfaces;

namespace GladiatorFights.UI
{
    internal class Menu
    {
        private FighterList _fighters;
        private BattleEngine _arena;
        private IBattleLogger _logger;
        private ObjectPainter _sprite;
        private int _indexFirstFighter;
        private int _indexSecondFighter;
        private int _positionCursoreX;
        private int _positionCursoreY;
        private int _offsetCursoreX;
        private int _offsetCursoreY;

        public Menu()
        {
            _logger = new BattleLogger();
            _sprite = new ObjectPainter();
            _fighters = new FighterList();
        }

        public void Run()
        {
            bool isWork;

            do
            {
                ShowSplashScreen();
                ShowAllFighters();
                GetNumberFighters(out _indexFirstFighter, out _indexSecondFighter);
                ShowVersusScreen(_indexFirstFighter, _indexSecondFighter);
                FighterBase firstFighter = _fighters.GetFighter(_indexFirstFighter).Clone();
                FighterBase secondFighter = _fighters.GetFighter(_indexSecondFighter).Clone();
                _arena = new BattleEngine(firstFighter, secondFighter, _logger);
                Console.Clear();
                _arena.StarFight();
                ShowWinner();
                isWork = ChoseRestartOrExit();
            }
            while (isWork);
        }

        private void ShowVersusScreen(int indexFirstFighter, int indexSecondFighter)
        {
            Console.Clear();
            Console.CursorVisible = false;

            Thread.Sleep(500);
            _positionCursoreX = 20;
            _positionCursoreY = 5;
            _sprite.DrawFighterNameByIndex(indexFirstFighter, ref _positionCursoreX, ref _positionCursoreY);
            Thread.Sleep(700);

            _offsetCursoreX = 30;
            _offsetCursoreY = 2;
            _positionCursoreX += _offsetCursoreX;
            _positionCursoreY += _offsetCursoreY;
            _sprite.DrawTextVersus(ref _positionCursoreX, ref _positionCursoreY);
            Thread.Sleep(700);

            _offsetCursoreX = 7;
            _positionCursoreX += _offsetCursoreX;
            _positionCursoreY += _offsetCursoreY;
            _sprite.DrawFighterNameByIndex(indexSecondFighter, ref _positionCursoreX, ref _positionCursoreY);
            Thread.Sleep(1000);

            Console.Clear();
            _sprite.DrawTextFight(30, 10);
            Thread.Sleep(1500);
        }

        private void ShowSplashScreen()
        {
            Console.Clear();
            _positionCursoreX = 15;
            _positionCursoreY = 5;
            _sprite.DrawSplashScreen(_positionCursoreX, _positionCursoreY);
            _positionCursoreX = 55;
            _positionCursoreY = 19;
            Console.CursorVisible = false;

            bool isVisible = true;

            while (Console.KeyAvailable == false)
            {
                _sprite.DrawPressAnyKey("Нажмите любую кнопку", _positionCursoreX, _positionCursoreY, isVisible);
                isVisible = !isVisible;
                Thread.Sleep(400);
            }

            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;
        }

        private void ShowAllFighters()
        {
            Console.Clear();
            _sprite.DrawCharacterCardTable(_fighters.GetAllFighters());
        }

        private void GetNumberFighters(out int indexFirstFighter, out int indexSecondFighter)
        {
            Console.SetCursorPosition(40, 22);
            Console.WriteLine("Кто будет сегодня драться?");
            indexFirstFighter = GetValidIndex("Введите номер бойца:");
            indexSecondFighter = GetValidIndex("Введите номер соперника:");
        }

        private int GetValidIndex(string text)
        {
            int number;
            int maxFighters = _fighters.Count;

            while (true)
            {
                Console.Write(text + " ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number) == false)
                {
                    Console.WriteLine("Ошибка: Введите число!");
                    continue;
                }

                if (number <= 0)
                {
                    Console.WriteLine($"Ошибка: Номер должен быть больше нуля!");
                    continue;
                }

                if (number > maxFighters)
                {
                    Console.WriteLine($"Ошибка: Номер не должен быть больше {maxFighters}!");
                    continue;
                }

                return number - 1;
            }
        }

        private void ShowWinner()
        {
            Console.Clear();
            _positionCursoreX = 25;
            _positionCursoreY = 3;
            _sprite.DrawWinnerScreen(ref _positionCursoreX, ref _positionCursoreY);

            int indexWinner = _fighters.GetIndexByName(_arena.Winner.Name);
            _offsetCursoreX = 15;
            _offsetCursoreY = 5;
            _positionCursoreX += _offsetCursoreX;
            _positionCursoreY += _offsetCursoreY;
            _sprite.DrawFighterNameByIndex(indexWinner, ref _positionCursoreX, ref _positionCursoreY);

            _offsetCursoreY = 8;
            _positionCursoreY += _offsetCursoreY;
            _positionCursoreX = 35;
            Console.SetCursorPosition(_positionCursoreX, _positionCursoreY);
        }

        private bool ChoseRestartOrExit()
        {
            bool isRestarting;
            ConsoleKey restartKey = ConsoleKey.Enter;
            ConsoleKey exitKey = ConsoleKey.Escape;
            Console.WriteLine($"Нажмите {restartKey} для перезапуска или {exitKey} для выхода");
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            while (true)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == restartKey)
                {
                    isRestarting = true;
                    break;
                }

                if (keyInfo.Key == exitKey)
                {
                    isRestarting = false;
                    break;
                }
            }

            Console.CursorVisible = true;

            return isRestarting;
        }
    }
}
