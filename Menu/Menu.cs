using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Menu
{
    class Program
    {
        private static string[] line = new string[] { "opcja 1", "2 opcja 2", "opcja 3 a tutaj opcja 3",
                                                        "tylko 4", "a teraz 5 co dalej" };
        private static int x0 = (Console.WindowWidth / 2) ;
        private static int y0 = (Console.WindowHeight / 2);
        private static int pozycja = 0;

        public static int najdluzszyString(string[] l)
        {
            int max = l[0].Length;

            for (int i = 0; i < l.Length; i++)
            {
                if (l[i].Length > max)
                {
                    max = l[i].Length;
                }
            }
            return max;
        }

        public static void rysujRamke()
        {
            x0 = (Console.WindowWidth / 2);
            y0 = (Console.WindowHeight / 2);

            int liczbaStringow = line.Length, maksDlugosc = najdluzszyString(line);
            int x1 = x0 - (maksDlugosc/2) - 2;
            int y1 = y0 - liczbaStringow/2 - 1;
            int x2 = x0 + (maksDlugosc / 2) + 2;
            int y2 = y0 + liczbaStringow / 2 + 1;

            Console.SetCursorPosition(x1, y1);
            Console.Write("\u250C");
            for (int i = x1+1; i <= x2-1; i++)
            {
                Console.Write('\u2500');
            }
            Console.Write('\u2510');
            Console.SetCursorPosition(x1, y1+1);

            for (int i = y1+1; i < y2; i++)
            {
                Console.SetCursorPosition(x1, i);
                Console.Write("\u2502");
                Console.SetCursorPosition(x2, i);
                Console.Write("\u2502");
            }
            Console.SetCursorPosition(x1, y2);
            Console.Write("\u2514");
            for (int i = x1 + 1; i <= x2 - 1; i++)
            {
                Console.Write('\u2500');
            }
            Console.Write("\u2518");
        }

        public static void wyswietl()
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (i == pozycja)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(x0 - line[i].Length / 2, y0 - line.Length / 2 + i);
                    Console.WriteLine(line[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.SetCursorPosition(x0 - line[i].Length / 2, y0 - line.Length / 2 + i);
                    Console.WriteLine(line[i]);
                }
                
            }
        }


        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            rysujRamke();
            wyswietl();
            
            var klawisz = Console.ReadKey();

            while (klawisz.Key != ConsoleKey.Escape)
            {
                switch (klawisz.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (pozycja > 0)
                        {
                            Console.CursorTop -= 1;
                            pozycja -= 1;

                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (pozycja < line.Length - 1)
                        {
                            Console.CursorTop += 1;
                            pozycja += 1;
                        }
                        break;

                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Clear();

                        Console.SetCursorPosition(Console.WindowWidth/2 - 8, Console.WindowHeight/2);
                        Console.Beep();
                        Console.Write("Niepoprawny klawisz");
                        Thread.Sleep(110);

                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Clear();
                        Console.SetCursorPosition(Console.WindowWidth/2 - 8, Console.WindowHeight/2);
                        Console.Write("Niepoprawny klawisz");
                        Thread.Sleep(110);

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Clear();
                        Thread.Sleep(110);

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Thread.Sleep(100);

                        rysujRamke();

                        break;

                }
                wyswietl();
                klawisz = Console.ReadKey(true);


            }
        }
    }
}
