using GladiatorFights.Game;
using System;

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
            _sprite.DrawVersusScreen();
            
            Console.ReadKey();
            ShowSplashScreen();
            ShowAllFighters();
            GetNumberFighters(out _indexFirstFighter, out _indexSecondFighter);
            _arena = new BattleEngine(_fighters.GetFighter(_indexFirstFighter),_fighters.GetFighter(_indexSecondFighter));
            ShowWinner();
        }

        private void ShowSplashScreen()
        {
            Console.Clear();
            _sprite.DrawSplashScreen(true);
            //todo:  сделать подтверждение кнопи
            //todo: определить надо ли метоd
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
