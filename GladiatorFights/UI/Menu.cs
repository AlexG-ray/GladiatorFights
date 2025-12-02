using GladiatorFights.Game;
using GladiatorFights.Interfaces;
using System;
using System.Threading;

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

        public Menu()
        {

            _sprite = new ObjectPainter();
            _fighters = new FighterList();
        }

        public void Run()
        {
            ShowSplashScreen();
            ShowAllFighters();
            GetNumberFighters(out _indexFirstFighter, out _indexSecondFighter);
            ShowVersusScreen(_indexFirstFighter,_indexSecondFighter);
            FighterBase firstFighter = _fighters.GetFighter(_indexFirstFighter).Clone();
            FighterBase secondFighter = _fighters.GetFighter(_indexSecondFighter).Clone();
            _arena = new BattleEngine(firstFighter, secondFighter);
            // battleLogger
            ShowWinner();
        }

        private void ShowVersusScreen(int indexFirstFighter, int indexSecondFighter)
        {
            Console.Clear();

            Thread.Sleep(500);
            int positionX = 20;
            int positionY = 5;
            _sprite.DrawFighterNameByIndex(indexFirstFighter,ref positionX,ref positionY);
            Thread.Sleep(700);

            positionX += 30;
            positionY += 2;
            _sprite.DrawTextVersus(ref positionX, ref positionY);
            Thread.Sleep(700);

            positionX += 7;
            positionY += 2;
            _sprite.DrawFighterNameByIndex(indexSecondFighter,ref positionX,ref positionY);
            Thread.Sleep(1000);

            Console.Clear();
            _sprite.DrawTextFight(30, 10);
            Thread.Sleep(1500);
        }

        private void ShowSplashScreen()
        {
            Console.Clear();
            _sprite.DrawSplashScreen();
            int positionX = 55;
            int positionY = 19;
            Console.CursorVisible = false;

            bool isVisible = true;

            while (Console.KeyAvailable == false)
            {
                _sprite.DrawPressAnyKey(positionX, positionY, isVisible);
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
            Console.SetCursorPosition(40,22);
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
            int positionX = 25;
            int positionY = 3;
            _sprite.DrawWinnerScreen(ref positionX,ref  positionY);
            
            int indexWinner = _fighters.GetIndexByName(_arena.Winner.Name);
            positionX += 15;
            positionY += 5;
            _sprite.DrawFighterNameByIndex(indexWinner, ref positionX , ref positionY);
            Console.ReadKey();
        }
    }
}
