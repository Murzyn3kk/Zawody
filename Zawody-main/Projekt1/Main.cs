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
                            zawody.Przeglad_Druzyny_String();
                            System.Console.WriteLine("Wybierz pierwsza druzyne");
                            Druzyna d1 = zawody.Wybierz_Druzyne();
                            System.Console.WriteLine("Wybierz druga druzyne");
                            Druzyna d2 = zawody.Wybierz_Druzyne();
                            while(d2 == d1)
                            {
                                System.Console.WriteLine("Ta sama druzyna. Wybierz inną");
                                d2 = zawody.Wybierz_Druzyne();
                            }
                            zawody.Przeglad_Sedzia_String();
                            System.Console.WriteLine("Wybierz sedziego glownego");
                            Sedzia sg = zawody.Wybierz_Sedziego();
                            System.Console.WriteLine("Wybierz pierwszego sedziego pomocniczego");
                            Sedzia_pomocniczy sp1 = (Sedzia_pomocniczy)zawody.Wybierz_Sedziego();
                            System.Console.WriteLine("Wybierz drugiego sedziego pomocniczego");
                            Sedzia_pomocniczy sp2 = (Sedzia_pomocniczy)zawody.Wybierz_Sedziego();
                            zawody.Rozgrywka_Siatkowka(d1, d2, sg, sp1, sp2);
                            break;
                        case System.ConsoleKey.D:
                            zawody.Przeglad_Druzyny_String();
                            System.Console.WriteLine("Wybierz pierwsza druzyne");
                            d1 = zawody.Wybierz_Druzyne();
                            System.Console.WriteLine("Wybierz druga druzyne");
                            d2 = zawody.Wybierz_Druzyne();
                            while (d2 == d1)
                            {
                                System.Console.WriteLine("Ta sama druzyna. Wybierz inną");
                                d2 = zawody.Wybierz_Druzyne();
                            }
                            zawody.Przeglad_Sedzia_String();
                            System.Console.WriteLine("Wybierz sedziego");
                            Sedzia se = zawody.Wybierz_Sedziego();
                            zawody.Rozgrywka_Dwa_Ognie(d1, d2, se);
                            break;
                        case System.ConsoleKey.P:
                            zawody.Przeglad_Druzyny_String();
                            System.Console.WriteLine("Wybierz pierwsza druzyne");
                            d1 = zawody.Wybierz_Druzyne();
                            System.Console.WriteLine("Wybierz druga druzyne");
                            d2 = zawody.Wybierz_Druzyne();
                            while (d2 == d1)
                            {
                                System.Console.WriteLine("Ta sama druzyna. Wybierz inną");
                                d2 = zawody.Wybierz_Druzyne();
                            }
                            zawody.Przeglad_Sedzia_String();
                            System.Console.WriteLine("Wybierz sedziego");
                            se = zawody.Wybierz_Sedziego();
                            zawody.Rozgrywka_Przeciaganie_Liny(d1, d2, se);
                            break;
                    }
                    break;
            }
        }
        zawody.Zapis("Test.txt");
    }
}