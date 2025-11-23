using GladiatorFights.Game;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;

namespace GladiatorFights.UI
{
    internal class Menu
    {
        private FighterList _fighters;
        private BattleEngine _arena;
        private int _indexFighter;
        private int _windowSizeX = 110;
        private int _windowSizeY = 270;

        public Menu()
        {
            Console.SetWindowSize(_windowSizeX, _windowSizeY);
            _fighters = new FighterList();
            ShowSplashScreen();
            Console.Clear();
            DrawAllCharacterCards();
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

        private void ShowAllFighters()
        {
            Console.Clear();

            int index = 0;

            foreach (var fighter in _fighters.GetAllFighters())
            {
                Console.WriteLine($"{index + 1}\n" +
                    $"{fighter.Name}:\n" +
                    $"Здоровье:{fighter.Health}\n" +
                    $"Броня:{fighter.Armor}\n" +
                    $"Урон:{fighter.Damage}\n" +
                    $"Особое умение - {fighter.GetSpecialAbilities()}");
                Console.WriteLine();

                index++;
            }
        }

        private void DrawAllCharacterCards()
        {
            var fighters = _fighters.GetAllFighters();
            int cardsPerRow = 3; // Количество карточек в ряду
            int cardWidth = 35; // Ширина одной карточки
            int startX = 2;
            int startY = 2;

            for (int i = 0; i < fighters.Count; i++)
            {
                int row = i / cardsPerRow;
                int col = i % cardsPerRow;
                int x = startX + col * cardWidth;
                int y = startY + row * 10; // 8 строк на карточку

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
            
            Console.SetCursorPosition(x + cardWidth/2 - 1, y++);
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
    }
}
