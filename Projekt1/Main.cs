using Projekt1;
using System.Collections.Generic;

class Projekt
{
    static void Main(string[] args)
    {
        bool running = true;
        Zawody zawody = new Zawody();
        zawody.Odczyt("Test.txt");
        while (running)
        {
            System.Console.WriteLine("[S] - Menu Sedzia");
            System.Console.WriteLine("[D] - Menu Druzyny");
            switch (System.Console.ReadKey().Key)
            {
                case System.ConsoleKey.Escape:
                    running = false; break;
                case System.ConsoleKey.S:
                    System.Console.WriteLine("[D] - Dodaj");
                    System.Console.WriteLine("[U] - Usun");
                    System.Console.WriteLine("[P] - Przejrzyj");
                    switch (System.Console.ReadKey().Key)
                    {
                        case System.ConsoleKey.D:
                            zawody.Dodaj_Sedziego();
                            break;
                        case System.ConsoleKey.U:
                            zawody.Usun_Sedziego();
                            break;
                        case System.ConsoleKey.P:
                            zawody.Przeglad_Sedzia_String();
                            break;
                    }
                    break;
                case System.ConsoleKey.D:
                    System.Console.WriteLine("[D] - Dodaj");
                    System.Console.WriteLine("[U] - Usun");
                    System.Console.WriteLine("[P] - Przejrzyj");
                    switch (System.Console.ReadKey().Key)
                    {
                        case System.ConsoleKey.D:
                            zawody.Dodaj_Druzyne();
                            break;
                        case System.ConsoleKey.U:
                            zawody.Usun_Druzyne();
                            break;
                        case System.ConsoleKey.P:
                            zawody.Przeglad_Druzyny_String();
                            break;
                    } 
                    break;
            }
        }
        zawody.Zapis("Test.txt");
    }
}