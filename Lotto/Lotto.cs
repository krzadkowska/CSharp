using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Menu
{
    class Program
    {
        private static string[] line = new string[] { "1.Wystąpienie każdej z liczb",
                                                        "2.Która liczba została wylosowana najwięcej razy?",
                                                        "3.Która liczba została wylosowana najmniej razy?",
                                                        "4.Czy kiedykolwiek nastąpiło powtórzenie?",
                                                        "5.Jakie wyniki wylosowano danego dnia?",
                                                        "6.Jakie wyniki wylosowano w danym roku?",
                                                        "7.Jakie wyniki wylosowano w danym miesiącu?"
                                                    };
        private static int x0 = (Console.WindowWidth / 2) ;
        private static int y0 = (Console.WindowHeight / 2);
        private static int pozycja = 0;

        private static string liniaLiczby, liniaDaty;
        private static List<string> lista = new List<string>();
        private static List<string> listaDat = new List<string>();

        public static bool Sprawdz(int liczba, string linia) //sprawdza czy dana liczba znajduje sie w danej linii
        {
            bool pom = false;
            string s;
            int rob;
            for (int i = 0; i < 5; i++)
            {
                s = linia.Substring(0, linia.IndexOf(","));
                linia = linia.Substring(linia.IndexOf(",") + 1, linia.Length - linia.IndexOf(",") - 1);
                rob = int.Parse(s);

                if (rob == liczba)
                {
                    pom = true;
                }
            }
            rob = int.Parse(linia);

            if (rob == liczba)
            {
                pom = true;
            }

            return pom;
        }

        public static int LiczbaWystapien(int liczba)
        {
            int licznik = 0;

            for (int i = 0; i < lista.Count - 1; i++)
            {
                if (Sprawdz(liczba, lista[i]))
                {
                    licznik++;
                }
            }
            return licznik;
        }

        public static void PokazLiczbeWystapien()
        {
            int ileWystapien;

            for (int i = 1; i <= 49; i++)
            {
                ileWystapien = LiczbaWystapien(i);
                Console.WriteLine("liczba " + i + " występuje " + ileWystapien + " razy");
            }
        }

        public static bool Powtorzenie()
        {
            bool pom = false;
            for (int i = 0; i < lista.Count - 2; i++)
            {
                for (int j = i + 1; j < lista.Count - 1; j++)
                {
                    if (lista[i] == lista[j])
                    {
                        pom = true;
                    }
                }
            }

            return pom;
        }

        public static void NajmniejWystapien()
        {
            int minLiczbaWystapien = LiczbaWystapien(1);
            int numerMin = 1;
            int ileWystapien;
            //Console.WriteLine("liczba 1 występuje " + LiczbaWystapien(1) + " razy");
            for (int i = 2; i <= 49; i++)
            {
                ileWystapien = LiczbaWystapien(i);
                //Console.WriteLine("liczba " + i + " występuje " + ileWystapien + " razy");
                if (ileWystapien < minLiczbaWystapien)
                {
                    minLiczbaWystapien = ileWystapien;
                    numerMin = i;
                }
            }
            Console.WriteLine("Najmniej wystąpień ma liczba " + numerMin);
        }

        public static void NajwiecejWystapien()
        {
            int maxLiczbaWystapien = LiczbaWystapien(1);
            int numerMax = 1;
            int ileWystapien;

            for (int i = 2; i <= 49; i++)
            {
                ileWystapien = LiczbaWystapien(i);

                if (ileWystapien > maxLiczbaWystapien)
                {
                    maxLiczbaWystapien = ileWystapien;
                    numerMax = i;
                }
            }
            Console.WriteLine("Najwięcej wystąpień ma liczba " + numerMax);
        }

        public static void WczytajLiczby()
        {
            int licznik = 0;
            StreamReader file = new StreamReader("dl.txt");

            while ((liniaLiczby = file.ReadLine()) != null)
            {
                liniaLiczby = liniaLiczby.Substring(liniaLiczby.IndexOf(" ") + 1, liniaLiczby.Length - liniaLiczby.IndexOf(" ") - 1);
                liniaLiczby = liniaLiczby.Substring(liniaLiczby.IndexOf(" ") + 1, liniaLiczby.Length - liniaLiczby.IndexOf(" ") - 1);
                lista.Add(liniaLiczby);
                licznik++;
            }
        }

        public static void WczytajDaty()
        {
           int licznik = 0;
           StreamReader plikDaty = new StreamReader("dl.txt");

           while ((liniaDaty = plikDaty.ReadLine()) != null)
           {
                liniaDaty = liniaDaty.Substring(liniaDaty.IndexOf(" ") + 1, liniaDaty.Length - liniaDaty.IndexOf(" ") - 1);
                liniaDaty = liniaDaty.Substring(0, liniaDaty.IndexOf(" "));
                listaDat.Add(liniaDaty);
                licznik++;
           }
        }

        public static string WczytajDate()
        {
            string dd, mm, rrrr;
            string data;
            Console.WriteLine("Podaj dzień: ");
            dd = Console.ReadLine();
            Console.WriteLine("Podaj miesiąc: ");
            mm = Console.ReadLine();
            Console.WriteLine("Podaj rok: ");
            rrrr = Console.ReadLine();

            data = dd + "." + mm + "." + rrrr;

            return data;
        }

        public static void WynikiDanegoDnia()
        {
            string data = WczytajDate();
            Console.WriteLine("Data:" + data);
            int pozycja = -1;
            for(int i = 0; i<listaDat.Count-1; i++)
            {
                if(data == listaDat[i])
                {
                    pozycja = i;
                    break;
                }
                
            }
            if (pozycja >= 0)
            {
                Console.WriteLine(lista[pozycja]);
            }
            else
            {
                Console.WriteLine("Danego dnia nie było losowania.");
            }
        }

        public static string WytnijRok(string data)
        {
            string rob="";
            rob = data.Substring(6, 4);
            return rob;
        }

        public static void WynikiZDanegoRoku()
        {
            string podanyRok;
            Console.WriteLine("Podaj rok:");
            podanyRok = Console.ReadLine();
            for(int i = 0; i < listaDat.Count-1; i++)
            {
                liniaDaty = listaDat[i];
                liniaDaty = WytnijRok(liniaDaty);
                if(liniaDaty == podanyRok)
                {
                    Console.WriteLine("Dnia " + listaDat[i] + " wylosowano liczby: " + lista[i]);
                }
            }
        }

        public static string WytnijMiesiac(string data)
        {
            string rob = "";
            rob = data.Substring(3, 2);
            return rob;
        }

        public static void WynikiZDanegoMiesiaca()
        {
            string podanyMiesiac;
            int licznik = 0;
            Console.WriteLine("Podaj miesiac: ");
            podanyMiesiac = Console.ReadLine();
            for(int i = 0; i < listaDat.Count-1; i++)
            {
                liniaDaty = listaDat[i];
                liniaDaty = WytnijMiesiac(liniaDaty);
                if(liniaDaty == podanyMiesiac)
                {
                    licznik++;
                    Console.WriteLine("Dnia " + listaDat[i] + " wylosowano liczby: " + lista[i]);
                    if(licznik == 100)
                    {
                        Console.Write("Naciśnij...");
                        Console.ReadKey();
                        licznik = 0;
                    }
                }
            }
        }

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

            WczytajDaty();
            WczytajLiczby();

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
                    case ConsoleKey.Enter:
                        if(pozycja == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.WriteLine("Odpowiedź na pierwsze pytanie");
                            PokazLiczbeWystapien();
                            Console.WriteLine("\nNacisnij dowolny przycisk aby powrócić do menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (pozycja == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.WriteLine("Odpowiedź na drugie pytanie");
                            NajwiecejWystapien();
                            Console.WriteLine("\nNacisnij dowolny przycisk aby powrócić do menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (pozycja == 2)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.WriteLine("Odpowiedź na trzecie pytanie");
                            NajmniejWystapien();
                            Console.WriteLine("\nNacisnij dowolny przycisk aby powrócić do menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (pozycja == 3)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.WriteLine("Odpowiedź na czwarte pytanie");
                            Console.WriteLine("Czy kiedykolwiek nastąpiło powtórzebue: " + Powtorzenie());
                            Console.WriteLine("\nNacisnij dowolny przycisk aby powrócić do menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (pozycja == 4)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.WriteLine("Odpowiedź na piąte pytanie");
                            Console.WriteLine("Wynik losowania danego dnia: ");
                            WynikiDanegoDnia();
                            Console.WriteLine("\nNacisnij dowolny przycisk aby powrócić do menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (pozycja == 5)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.WriteLine("Odpowiedź na szóste pytanie");
                            Console.WriteLine("Wynik losowania z danego roku: ");
                            WynikiZDanegoRoku();
                            Console.WriteLine("\nNacisnij dowolny przycisk aby powrócić do menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (pozycja == 6)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.WriteLine("Odpowiedź na siódme pytanie");
                            Console.WriteLine("Wynik losowania z danego miesiaca: ");
                            WynikiZDanegoMiesiaca();
                            Console.WriteLine("\nNacisnij dowolny przycisk aby powrócić do menu...");
                            Console.ReadKey();
                            Console.Clear();
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
                //rysujRamke();
                wyswietl();
                klawisz = Console.ReadKey(true);


            }
        }
    }
}
