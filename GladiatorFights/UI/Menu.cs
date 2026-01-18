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
        private int _positionCursorX;
        private int _positionCursorY;
        private int _offsetCursorX;
        private int _offsetCursorY;

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
            _positionCursorX = 20;
            _positionCursorY = 5;
            _sprite.DrawFighterNameByIndex(indexFirstFighter, ref _positionCursorX, ref _positionCursorY);
            Thread.Sleep(700);

            _offsetCursorX = 30;
            _offsetCursorY = 2;
            _positionCursorX += _offsetCursorX;
            _positionCursorY += _offsetCursorY;
            _sprite.DrawTextVersus(ref _positionCursorX, ref _positionCursorY);
            Thread.Sleep(700);

            _offsetCursorX = 7;
            _positionCursorX += _offsetCursorX;
            _positionCursorY += _offsetCursorY;
            _sprite.DrawFighterNameByIndex(indexSecondFighter, ref _positionCursorX, ref _positionCursorY);
            Thread.Sleep(1000);

            Console.Clear();
            _sprite.DrawTextFight(30, 10);
            Thread.Sleep(1500);
        }

        private void ShowSplashScreen()
        {
            Console.Clear();
            _positionCursorX = 15;
            _positionCursorY = 5;
            _sprite.DrawSplashScreen(_positionCursorX, _positionCursorY);
            _positionCursorX = 55;
            _positionCursorY = 19;
            Console.CursorVisible = false;

            bool isVisible = true;

            while (Console.KeyAvailable == false)
            {
                _sprite.DrawPressAnyKey("Нажмите любую кнопку", _positionCursorX, _positionCursorY, isVisible);
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
            int number = 1;
            int maxFighters = _fighters.Count;
            bool isRepeated = true;

            while (isRepeated)
            {
                Console.Write(text + " ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number) == false)
                {
                    Console.WriteLine("Ошибка: Введите число!");
                }
                else
                {
                    if (number <= 0)
                    {
                        Console.WriteLine($"Ошибка: Номер должен быть больше нуля!");
                    }
                    else if (number > maxFighters)
                    {
                        Console.WriteLine($"Ошибка: Номер не должен быть больше {maxFighters}!");
                    }
                    else
                    {
                        isRepeated = false;
                    }
                }
            }

            return number - 1;
        }

        private void ShowWinner()
        {
            Console.Clear();
            _positionCursorX = 25;
            _positionCursorY = 3;
            _sprite.DrawWinnerScreen(ref _positionCursorX, ref _positionCursorY);

            int indexWinner = _fighters.GetIndexByName(_arena.Winner.Name);
            _offsetCursorX = 15;
            _offsetCursorY = 5;
            _positionCursorX += _offsetCursorX;
            _positionCursorY += _offsetCursorY;
            _sprite.DrawFighterNameByIndex(indexWinner, ref _positionCursorX, ref _positionCursorY);

            _offsetCursorY = 8;
            _positionCursorY += _offsetCursorY;
            _positionCursorX = 35;
            Console.SetCursorPosition(_positionCursorX, _positionCursorY);
        }

        private bool ChoseRestartOrExit()
        {
            bool isRestarting = true;
            bool isWork = true;
            ConsoleKey restartKey = ConsoleKey.Enter;
            ConsoleKey exitKey = ConsoleKey.Escape;
            Console.WriteLine($"Нажмите {restartKey} для перезапуска или {exitKey} для выхода");
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            while (isWork)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == restartKey)
                {
                    isRestarting = true;
                    isWork = false;
                }

                if (keyInfo.Key == exitKey)
                {
                    isRestarting = false;
                    isWork = false;
                }
            }

            Console.CursorVisible = true;

            return isRestarting;
        }
    }
}
