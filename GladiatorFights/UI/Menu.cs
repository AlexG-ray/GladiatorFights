using GladiatorFights.Game;
using System;

namespace GladiatorFights.UI
{
    internal class Menu
    {
        private FighterList _fighters;
        private BattleEngine _arena;
        private int _indexFirstFighter;
        private int _indexSecondFighter;
        private int _windowSizeX = 110;
        private int _windowSizeY = 270;

        public Menu()
        {
            Console.SetWindowSize(_windowSizeX, _windowSizeY);
            _fighters = new FighterList();
            ShowSplashScreen();
            DrawAllCharacterCards();
            GetNumberFighters(out _indexFirstFighter, out _indexSecondFighter);
            _arena = new BattleEngine(_fighters.GetFighter(_indexFirstFighter),_fighters.GetFighter(_indexSecondFighter));
            ShowWinner();
        }

        private void ShowSplashScreen()
        {
            int positionX = 15;
            int positionY = 5;
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" ██████╗ ██╗      █████╗ ██████╗ ██╗ █████╗ ████████╗ ██████╗ ██████╗ ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("██╔════╝ ██║     ██╔══██╗██╔══██╗██║██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("██║  ███╗██║     ███████║██║  ██║██║███████║   ██║   ██║   ██║██████╔╝");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("██║   ██║██║     ██╔══██║██║  ██║██║██╔══██║   ██║   ██║   ██║██╔══██╗");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("╚██████╔╝███████╗██║  ██║██████╔╝██║██║  ██║   ██║   ╚██████╔╝██║  ██║");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" ╚═════╝ ╚══════╝╚═╝  ╚═╝╚═════╝ ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝");
            positionX += 40;
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("███████╗██╗ ██████╗ ██╗  ██╗████████╗███████╗");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("██╔════╝██║██╔════╝ ██║  ██║╚══██╔══╝██╔════╝");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("█████╗  ██║██║  ███╗███████║   ██║   ███████╗");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("██╔══╝  ██║██║   ██║██╔══██║   ██║   ╚════██║");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("██║     ██║╚██████╔╝██║  ██║   ██║   ███████║");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚══════╝");
            Console.SetCursorPosition(positionX, positionY++);
            Console.SetCursorPosition(positionX, positionY++);

            Console.CursorVisible = false;

            bool isVisible = true;

            while (Console.KeyAvailable == false)
            {
                Console.SetCursorPosition(positionX, positionY);

                if (isVisible)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Нажмите любую клавишу");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Нажмите любую клавишу");
                }

                isVisible = !isVisible;
                System.Threading.Thread.Sleep(400);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;
            Console.ReadKey(true);
        }

        private void DrawAllCharacterCards()
        {
            Console.Clear();

            var fighters = _fighters.GetAllFighters();
            int cardsPerRow = 3;
            int cardWidth = 35;
            int startX = 9;
            int startY = 1;

            for (int i = 0; i < fighters.Count; i++)
            {
                int row = i / cardsPerRow;
                int col = i % cardsPerRow;
                int x = startX + col * cardWidth;
                int y = startY + row * 10;

                DrawCharacterCard(fighters[i], i + 1, x, y);
            }

            Console.WriteLine();
        }

        private void DrawCharacterCard(FighterBase fighter, int number, int x, int y)
        {
            int cardWidth = 21;
            string nameTitle = "---";
            string numberTitle = "#";
            string hpTitle = "Здоровье:";
            string armorTitle = "Броня:";
            string damageTitle = "Урон:";
            string skillTitle = "Умение:";
            string border = new string('═', cardWidth);

            Console.SetCursorPosition(x, y++);
            Console.Write(border);

            Console.SetCursorPosition(x + cardWidth / 2 - 1, y++);
            Console.Write($"{numberTitle}{number.ToString()}");

            Console.SetCursorPosition(x, y++);
            Console.Write(border);

            Console.SetCursorPosition(x, y++);
            Console.Write($"{nameTitle} {fighter.Name} {nameTitle}");

            Console.SetCursorPosition(x, y++);
            Console.Write($"{hpTitle}{fighter.Health.ToString()}");

            Console.SetCursorPosition(x, y++);
            Console.Write($"{armorTitle}{fighter.Armor.ToString()}");

            Console.SetCursorPosition(x, y++);
            Console.Write($"{damageTitle}{fighter.Damage.ToString()}");

            Console.SetCursorPosition(x, y++);
            Console.Write($"{skillTitle}{fighter.GetSpecialAbilities()}");

            Console.SetCursorPosition(x, y++);
            Console.Write(border);
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
