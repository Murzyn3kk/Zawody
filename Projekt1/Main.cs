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
            System.Console.WriteLine("[R] - Menu Rozgrywek");
            System.Console.WriteLine("[ESC] - Wyjscie z programu");
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
                case System.ConsoleKey.R:
                    System.Console.WriteLine("[S] - Mecz w siatkowke");
                    System.Console.WriteLine("[D] - Mecz w dwa ognie");
                    System.Console.WriteLine("[P] - Mecz w przeciaganie liny");
                    switch (System.Console.ReadKey().Key)
                    {
                        case System.ConsoleKey.S:
                            zawody.Rozgrywka_Siatkowka();
                            break;
                        case System.ConsoleKey.D:
                            zawody.Rozgrywka_Dwa_Ognie();
                            break;
                        case System.ConsoleKey.P:
                            zawody.Rozgrywka_Przeciaganie_Liny();
                            break;
                    }
                    break;
            }
        }
        zawody.Zapis("Test.txt");
    }
}