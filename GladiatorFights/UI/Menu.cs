using GladiatorFights.Game;
using System;
using System.Threading;

namespace GladiatorFights.UI
{
    internal class Menu
    {
        private FighterList _fighters;
        private BattleEngine _arena;
        private ObjectPainter _sprite;
        private int _indexFirstFighter;
        private int _indexSecondFighter;

        public Menu()
        {
            _sprite = new ObjectPainter();
            _fighters = new FighterList();
            //ShowSplashScreen();
            //GetNumberFighters(out _indexFirstFighter, out _indexSecondFighter);
            //_arena = new BattleEngine(_fighters.GetFighter(_indexFirstFighter),_fighters.GetFighter(_indexSecondFighter));
            //ShowWinner();
            //todo; очистить конструктор только для обьектов
        }

        public void Run()
        {
            ShowSplashScreen();
            ShowAllFighters();
            GetNumberFighters(out _indexFirstFighter, out _indexSecondFighter);
            ShowVersusScreen();
            _arena = new BattleEngine(_fighters.GetFighter(_indexFirstFighter),_fighters.GetFighter(_indexSecondFighter));
            ShowWinner();
        }

        private void ShowVersusScreen()
        {
            Console.Clear();
            
            Thread.Sleep(500);
            int positionX = 20;
            int positionY = 5;
            _sprite.DrawNameBarbarian(ref positionX, ref positionY);
            Thread.Sleep(700);
            
            positionX += 30;
            positionY += 2;
            _sprite.DrawTextVersus(ref positionX, ref positionY);
            Thread.Sleep(700);
            
            positionX += 7;
            positionY += 2;
            _sprite.DrawNameFireKnight(ref positionX, ref positionY);
            Thread.Sleep(1000);
            
            Console.Clear();
            _sprite.DrawTextFight(30, 10);
            Thread.Sleep(1500);
        }

        private void ShowSplashScreen()
        {
            Console.Clear();
            _sprite.DrawSplashScreen();
            
            int textX = 55;
            int textY = 19;
            Console.CursorVisible = false;
            
            bool isVisible = true;
            while (!Console.KeyAvailable)
            {
                _sprite.DrawPressAnyKey(textX, textY, isVisible);
                isVisible = !isVisible;
                Thread.Sleep(400);
            }
            
            Console.ReadKey(); // Очистить буфер нажатой клавиши
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
            Console.WriteLine($"{_arena.Winner.Name}");
            Console.ReadKey();
        }
    }
}
