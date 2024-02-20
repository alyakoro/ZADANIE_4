using System;

namespace ZADANIE_4
{
    class Program
    {
        static void Main()
        {
            bool exit = false;
            while (exit != true)
            {
                VvodCoordinat();

                Console.Write(Environment.NewLine +
                    "Введите 'exit' для выхода: " +
                    Environment.NewLine);
                string exitword = Console.ReadLine();
                if (exitword == "exit")
                    exit = true;
            }
        }


        // Функция рисование шахматной доски.
        static void DrawChessboard(int KX, int KY,
            int FX, int FY)
        {
            Console.WriteLine("  a b c d e f g h");
            for (int i = 8; i >= 1; i--)
            {
                Console.Write((i) + " ");
                for (int j = 1; j <= 8; j++)
                {
                    if (j == KX && i == KY)
                        Console.Write("K ");
                    else if (j == FX && i == FY)
                        Console.Write("F ");
                    else
                        Console.Write("- ");
                }
                Console.WriteLine();
            }
        }

        // Функция ввода и проверки данных.
        static void VvodCoordinat()
        {
            bool vvod_reght = false;
            do
            {
                Console.Write("Введите координаты короля(K) " +
                    "и фигуры(F) (например, a1 b3): ");
                string coordinat_fig = Console.ReadLine();

                string[] coordinat = coordinat_fig.Split(' ');

                if ((coordinat.Length == 2) &&
                    (coordinat[0] != coordinat[1]))
                {
                    string korolPosition = coordinat[0];
                    string figurePosition = coordinat[1];

                    if (CorrectPosition(korolPosition) &&
                        CorrectPosition(figurePosition))
                    {
                        vvod_reght = true;
                        SravnrniePossision(korolPosition,
                            figurePosition);
                    }
                }

            } while (vvod_reght != true);
        }

        // Функция сравнения координаты слона и фигуры.
        static void SravnrniePossision(string korol,
            string figure)
        {
            // Нахождение координат слона и фигуры.
            int korolX = korol[0] - 'a' + 1;
            int korolY = korol[1] - '0';
            int figureX = figure[0] - 'a' + 1;
            int figureY = figure[1] - '0';

            DrawChessboard(korolX, korolY, figureX, figureY);

            KorlAttacking(korolX, korolY, figureX, figureY);
        }

        // Функция проверки на правильность ввода:
        // 1. Количество символов.
        // 2. Пределы (a-h) и (1 - 8).
        static bool CorrectPosition(string position)
        {
            if (position.Length != 2)
                return false;

            char bokva = position[0];
            char numer = position[1];

            return bokva >= 'a' && bokva <= 'h'
                && numer >= '1' && numer <= '8';
        }

        // 1 Функция определения, "нападает" ли ферзь (true/false).
        static void KorlAttacking(int KX, int KY,
            int FX, int FY)
        {
            for (int X = KX - 1; X <= KX + 1; X++)
            {
                for (int Y = KX + 1; Y >= KY - 1; Y--)
                {
                    if ((FX == X) && (FY == Y))
                    {
                        Console.WriteLine("Король сможет побить фигуру");
                        return;
                    }
                }
            }
            Console.WriteLine("Король не сможет побить фигуру");
        }
    }
}
