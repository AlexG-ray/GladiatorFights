using System;
using System.Collections.Generic;

namespace GladiatorFights.UI
{
    internal class ObjectPainter
    {
        private Action<int, int>[] _nameDrawers;
        private int _windowSizeX = 110;
        private int _windowsSizeY = 270;
        private int _positionCursoreX;
        private int _positionCursoreY;
        private int _offsetCursoreX;
        private int _offsetCursoreY;

        public ObjectPainter()
        {
            Console.SetWindowSize(_windowSizeX, _windowsSizeY);
        }

        public void DrawFighterNameByIndex(int fighterIndex, ref int positionX, ref int positionY)
        {
            if (_nameDrawers == null)
            {
                _nameDrawers = new Action<int, int>[]
                {
                    DrawNameBarbarian,
                    DrawNameFireKnight,
                    DrawNameGladiator,
                    DrawNameMonk,
                    DrawNamePaladin,
                    DrawNameRogue,
                };
            }

            if (fighterIndex >= 0 && fighterIndex < _nameDrawers.Length)
            {
                int startY = positionY;
                _nameDrawers[fighterIndex](positionX, positionY);
                _offsetCursoreY = 5;
                positionY = startY + _offsetCursoreY;
            }
        }

        public void DrawSplashScreen(int positionX, int positionY)
        {
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
            _offsetCursoreX = 40;
            positionX += _offsetCursoreX;
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
        }

        public void DrawPressAnyKey(string text, int positionX, int positionY, bool isVisible)
        {
            Console.SetCursorPosition(positionX, positionY);

            if (isVisible)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.Write(text);
        }

        public void DrawCharacterCardTable(List<FighterBase> fighters)
        {
            Console.Clear();

            int cardsPerRow = 3;
            int cardWidth = 35;
            int startX = 9;
            int startY = 1;

            for (int i = 0; i < fighters.Count; i++)
            {
                int row = i / cardsPerRow;
                int col = i % cardsPerRow;
                int x = startX + (col * cardWidth);
                int lineCountInCard = 10;
                int y = startY + (row * lineCountInCard);

                DrawCharacterCard(fighters[i], i + 1, x, y);
            }

            Console.WriteLine();
        }

        public void DrawCharacterCard(FighterBase fighter, int number, int x, int y)
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

            Console.SetCursorPosition(x + (cardWidth / 2) - 1, y++);
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

        public void DrawWinnerScreen(int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(":::       ::: ::::::::::: ::::    ::: ::::    ::: :::::::::: :::::::::  ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(":+:       :+:     :+:     :+:+:   :+: :+:+:   :+: :+:        :+:    :+: ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("+:+       +:+     +:+     :+:+:+  +:+ :+:+:+  +:+ +:+        +:+    +:+ ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("+#+  +:+  +#+     +#+     +#+ +:+ +#+ +#+ +:+ +#+ +#++:++#   +#++:++#:  ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("+#+ +#+#+ +#+     +#+     +#+  +#+#+# +#+  +#+#+# +#+        +#+    +#+ ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" #+#+# #+#+#      #+#     #+#   #+#+# #+#   #+#+# #+#        #+#    #+# ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("  ###   ###   ########### ###    #### ###    #### ########## ###    ### ");
        }

        public void DrawWinnerScreen(ref int positionX, ref int positionY)
        {
            int startY = positionY;
            DrawWinnerScreen(positionX, positionY);
            _offsetCursoreY = 7;
            positionY = startY + _offsetCursoreY;
        }

        public void DrawNameBarbarian(int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("    _   __                          __");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("   / | / /___  ____ ___  ____ _____/ /");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("  /  |/ / __ \\/ __ `__ \\/ __ `/ __  / ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" / /|  / /_/ / / / / / / /_/ / /_/ /  ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("/_/ |_/\\____/_/ /_/ /_/\\__,_/\\__,_/   ");
        }

        public void DrawNameBarbarian(ref int positionX, ref int positionY)
        {
            int startY = positionY;
            DrawNameBarbarian(positionX, positionY);
            _offsetCursoreX = 5;
            positionY = startY + _offsetCursoreX;
        }

        public void DrawNameFireKnight(int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" _       __           __               __");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("| |     / /___ ______/ /___  _________/ /");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("| | /| / / __ `/ ___/ / __ \\/ ___/ __  / ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("| |/ |/ / /_/ / /  / / /_/ / /  / /_/ /  ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("|__/|__/\\__,_/_/  /_/\\____/_/   \\__,_/   ");
        }

        public void DrawNameFireKnight(ref int positionX, ref int positionY)
        {
            int startY = positionY;
            DrawNameFireKnight(positionX, positionY);
            _offsetCursoreY = 5;
            positionY = startY + _offsetCursoreY;
        }

        public void DrawNameGladiator(int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("   ________          __          ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("  / ____/ /___ _____/ /_  _______");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" / / __/ / __ `/ __  / / / / ___/");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("/ /_/ / / /_/ / /_/ / /_/ (__  ) ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("\\____/_/\\__,_/\\__,_/\\__,_/____/  ");
        }

        public void DrawNameGladiator(ref int positionX, ref int positionY)
        {
            int startY = positionY;
            DrawNameGladiator(positionX, positionY);
            _offsetCursoreY = 5;
            positionY = startY + _offsetCursoreY;
        }

        public void DrawNameMonk(int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("    __  __                    _ __ ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("   / / / /__  _________ ___  (_) /_");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("  / /_/ / _ \\/ ___/ __ `__ \\/ / __/");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" / __  /  __/ /  / / / / / / / /_  ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("/_/ /_/\\___/_/  /_/ /_/ /_/_/\\__/  ");
        }

        public void DrawNameMonk(ref int positionX, ref int positionY)
        {
            int startY = positionY;
            DrawNameMonk(positionX, positionY);
            _offsetCursoreY = 5;
            positionY = startY + _offsetCursoreY;
        }

        public void DrawNameRogue(int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("    ____                  ___ __ ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("   / __ )____ _____  ____/ (_) /_");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("  / __  / __ `/ __ \\/ __  / / __/");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" / /_/ / /_/ / / / / /_/ / / /_  ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("/_____/\\__,_/_/ /_/\\__,_/_/\\__/  ");
        }

        public void DrawNameRogue(ref int positionX, ref int positionY)
        {
            int startY = positionY;
            DrawNameRogue(positionX, positionY);
            _offsetCursoreY = 5;
            positionY = startY + _offsetCursoreY;
        }

        public void DrawNamePaladin(int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("    ______                          __    ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("   / ____/______  ___________ _____/ /__  ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("  / /   / ___/ / / / ___/ __ `/ __  / _ \\ ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" / /___/ /  / /_/ (__  ) /_/ / /_/ /  __/ ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" \\____/_/   \\__,_/____/\\__,_/\\__,_/\\___/  ");
        }

        public void DrawNamePaladin(ref int positionX, ref int positionY)
        {
            int startY = positionY;
            DrawNamePaladin(positionX, positionY);
            _offsetCursoreY = 5;
            positionY = startY + _offsetCursoreY;
        }

        public void DrawTextVersus(int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" _    _______");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("| |  / / ___/");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("| | / /\\__ \\ ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("| |/ /___/ / ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("|___//____/  ");
        }

        public void DrawTextVersus(ref int positionX, ref int positionY)
        {
            int startY = positionY;
            DrawTextVersus(positionX, positionY);
            _offsetCursoreY = 5;
            positionY = startY + _offsetCursoreY;
        }

        public void DrawTextFight(int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" ███████████ █████   █████████  █████   █████ ███████████");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("░░███░░░░░░█░░███   ███░░░░░███░░███   ░░███ ░█░░░███░░░█");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" ░███   █ ░  ░███  ███     ░░░  ░███    ░███ ░   ░███  ░ ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" ░███████    ░███ ░███          ░███████████     ░███    ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" ░███░░░█    ░███ ░███    █████ ░███░░░░░███     ░███    ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" ░███  ░     ░███ ░░███  ░░███  ░███    ░███     ░███    ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine(" █████       █████ ░░█████████  █████   █████    █████   ");
            Console.SetCursorPosition(positionX, positionY++);
            Console.WriteLine("░░░░░       ░░░░░   ░░░░░░░░░  ░░░░░   ░░░░░    ░░░░░    ");
        }

        public void DrawTextFight(ref int positionX, ref int positionY)
        {
            int startY = positionY;
            DrawTextFight(positionX, positionY);
            _offsetCursoreY = 8;
            positionY = startY + _offsetCursoreY;
        }
    }
}
