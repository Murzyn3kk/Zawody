using System.Collections.Generic;

namespace Projekt1
{
    class Zawody
    {
        public Zawody()
        {
            listadruzyn = new List<Druzyna>();
            listasedzia = new List<Sedzia>();
            listasiatkowka = new List<Druzyna>();
            listadwaognie = new List<Druzyna>();
            listaprzeciaganieliny = new List<Druzyna>();
            final = new List<Druzyna>();
        }
        public void Zapis(string file)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(file);

            sw.WriteLine(":Druzyny:");
            foreach (Druzyna druzyna in listadruzyn)
                sw.WriteLine(druzyna);
            sw.WriteLine(":Sedzia:");
            foreach (Sedzia sedzia in listasedzia)
                sw.WriteLine(sedzia);
            sw.WriteLine(":Punkty za siatkowke:");
            foreach (Druzyna druzyna in listasiatkowka)
                sw.WriteLine(druzyna);
            sw.WriteLine(":Punkty za dwa ognie:");
            foreach (Druzyna druzyna in listadwaognie)
                sw.WriteLine(druzyna);
            sw.WriteLine(":Punkty za przeciaganie liny:");
            foreach (Druzyna druzyna in listaprzeciaganieliny)
                sw.WriteLine(druzyna);
            sw.Close();
        }
        public void Odczyt(string file)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(file);
            string line;
            int step = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (line[0] == ':') step++;
                else
                {
                    if (step == 1)
                    {
                        string[] s = line.Split(null);
                        listadruzyn.Add(new Druzyna(s[1], int.Parse(s[0])));
                    }
                    if (step == 2)
                    {
                        string[] s = line.Split(null);
                        listasedzia.Add(new Sedzia(s[0], s[1]));
                    }
                    if (step == 3)
                    {
                        string[] s = line.Split(null);
                        listasiatkowka.Add(new Druzyna(s[1], int.Parse(s[0])));
                    }
                    if (step == 4)
                    {
                        string[] s = line.Split(null);
                        listadwaognie.Add(new Druzyna(s[1], int.Parse(s[0])));
                    }
                    if (step == 5)
                    {
                        string[] s = line.Split(null);
                        listaprzeciaganieliny.Add(new Druzyna(s[1], int.Parse(s[0])));
                    }
                }

            }
            sr.Close();
        }
        public void Dodaj_Druzyne()
        {
            System.Console.WriteLine("Podaj Nazwe");
            string nazwa = System.Console.ReadLine();
            if (nazwa == null)
                return;
            nazwa = nazwa.Replace(" ", "_");
            Druzyna druzyna = Druzyna_Exists(nazwa);
            if (druzyna != null)
                return;

            listadruzyn.Add(new Druzyna(nazwa));
            listasiatkowka.Add(new Druzyna(nazwa));
            listadwaognie.Add(new Druzyna(nazwa));
            listaprzeciaganieliny.Add(new Druzyna(nazwa));
        }
        public void Usun_Druzyne()
        {
            System.Console.WriteLine("Podaj nazwe");
            string nazwa = System.Console.ReadLine();
            if (nazwa == null)
                return;
            nazwa = nazwa.Replace(" ", "_");
            Druzyna druzyna = Druzyna_Exists(nazwa);
            if (druzyna == null)
                return;
            
            listadruzyn.Remove(druzyna);
            listasiatkowka.Remove(druzyna);
            listadwaognie.Remove(druzyna);
            listaprzeciaganieliny.Remove(druzyna);
        }
        public void Przeglad_Druzyny_String()
        {
            System.Console.WriteLine("Druzyna: Punkty Nazwa");
            foreach (Druzyna druzyna in listadruzyn)
                System.Console.WriteLine("\t" + druzyna);
        }
        public List<Druzyna> Przeglad_Druzyny() { return listadruzyn; }
        public void Dodaj_Sedziego()
        {
            System.Console.WriteLine("Podaj Imie i Nazwisko");
            string nazwa = System.Console.ReadLine();
            if (nazwa == null)
                return;
            Sedzia sedzia = Sedzia_Exists(nazwa);
            if (sedzia != null)
                return;
            
            string[] s = nazwa.Split(null);
            if(s.Length == 2)
                listasedzia.Add(new Sedzia(s[0], s[1]));
        }
        public void Usun_Sedziego()
        {
            System.Console.WriteLine("Podaj Imie i Nazwisko");
            string nazwa = System.Console.ReadLine();
            if (nazwa == null)
                return;
            Sedzia sedzia = Sedzia_Exists(nazwa);
            if (sedzia == null)
                return;
            
            listasedzia.Remove(sedzia);
        }
        public void Przeglad_Sedzia_String()
        {
            System.Console.WriteLine("Sedzia: Imie Nazwisko");
            foreach (Sedzia sedzia in listasedzia)
                System.Console.WriteLine("\t" + sedzia);
        }
        public List<Sedzia> Przeglad_Sedzia() { return listasedzia; }
        public void Tabela_Siatkowka_String()
        {
            Sort(listasiatkowka);
            System.Console.WriteLine("Siatkowka: Punkty, Nazwa druzyny");
            foreach (Druzyna druzyna in listasiatkowka)
                System.Console.WriteLine("\t" + druzyna);
        }
        public List<Druzyna> Tabela_Siatkowka() { return listasiatkowka; }
        public void Tabela_Dwaognie_String()
        {
            Sort(listadwaognie);
            System.Console.WriteLine("Dwa ognie: Punkty, Nazwa druzyny");
            foreach (Druzyna druzyna in listadwaognie)
                System.Console.WriteLine("\t" + druzyna);
        }
        public List<Druzyna> Tabela_Dwaognie() { return listadwaognie; }
        public void Tabela_Przeciaganieliny_String()
        {
            Sort(listaprzeciaganieliny);
            System.Console.WriteLine("Przeciaganie liny: Punkty, Nazwa druzyny");
            foreach (Druzyna druzyna in listaprzeciaganieliny)
                System.Console.WriteLine("\t" + druzyna);
        }
        public List<Druzyna> Tabela_Przeciaganieliny() { return listaprzeciaganieliny; }

        public void Rozgrywka_Siatkowka()
        {
            Tabela_Siatkowka_String();
            System.Console.WriteLine("Wybierz pierwsza druzyne");
            Druzyna d1 = Wybierz_Druzyne();
            if (d1 == null)
                return;
            System.Console.WriteLine("Wybierz druga druzyne");
            Druzyna d2 = Wybierz_Druzyne();
            if (d2 == null || d2 == d1)
                return;

            Przeglad_Sedzia_String();
            System.Console.WriteLine("Wybierz sedziego glownego");
            Sedzia sg = Wybierz_Sedziego();
            if (sg == null)
                return;
            System.Console.WriteLine("Wybierz pierwszego sedziego pomocniczego");
            Sedzia sp1 = Wybierz_Sedziego();
            if (sp1 == null || sp1 == sg)
                return;
            System.Console.WriteLine("Wybierz drugiego sedziego pomocniczego");
            Sedzia sp2 = Wybierz_Sedziego();
            if (sp2 == null || sp2 == sp1 || sp2 == sg)
                return;

            Siatkowka siatkowka = new Siatkowka(d1, d2, sg, sp1, sp2);
            siatkowka.Rozgrywka();
            int win = siatkowka.Wpisz_Wynik();
            foreach(Druzyna druzyna in listasiatkowka)
            {
                if(win == 1 && druzyna.GetNazwa() == d1.GetNazwa())
                {
                    druzyna.DodajPunkty(1);
                }
                if(win == 0 && druzyna.GetNazwa() == d2.GetNazwa())
                {
                    druzyna.DodajPunkty(1);
                }
            }
            Sort(listadruzyn);
            Sort(listasiatkowka);
        }
        public void Rozgrywka_Dwa_Ognie()
        {
            Tabela_Dwaognie_String();
            System.Console.WriteLine("Wybierz pierwsza druzyne");
            Druzyna d1 = Wybierz_Druzyne();
            if (d1 == null)
                return;
            System.Console.WriteLine("Wybierz druga druzyne");
            Druzyna d2 = Wybierz_Druzyne();
            if (d2 == null || d2 == d1)
                return;
            Przeglad_Sedzia_String();
            System.Console.WriteLine("Wybierz sedziego");
            Sedzia se = Wybierz_Sedziego();
            if (se == null)
                return;

            Dwa_ognie dwaognie = new Dwa_ognie(d1, d2, se);
            dwaognie.Rozgrywka();
            int win = dwaognie.Wpisz_Wynik();
            foreach (Druzyna druzyna in listadwaognie)
            {
                if (win == 1 && druzyna.GetNazwa() == d1.GetNazwa())
                {
                    druzyna.DodajPunkty(1);
                }
                if (win == 0 && druzyna.GetNazwa() == d2.GetNazwa())
                {
                    druzyna.DodajPunkty(1);
                }
            }
            Sort(listadruzyn);
            Sort(listadwaognie);
        }
        public void Rozgrywka_Przeciaganie_Liny()
        {
            Tabela_Przeciaganieliny_String();
            System.Console.WriteLine("Wybierz pierwsza druzyne");
            Druzyna d1 = Wybierz_Druzyne();
            if (d1 == null)
                return;
            System.Console.WriteLine("Wybierz druga druzyne");
            Druzyna d2 = Wybierz_Druzyne();
            if (d2 == null || d2 == d1)
                return;
            Przeglad_Sedzia_String();
            System.Console.WriteLine("Wybierz sedziego");
            Sedzia se = Wybierz_Sedziego();
            if (se == null)
                return;

            Przeciaganie_liny przeciaganieliny = new Przeciaganie_liny(d1, d2, se);
            przeciaganieliny.Rozgrywka();
            int win = przeciaganieliny.Wpisz_Wynik();
            foreach (Druzyna druzyna in listaprzeciaganieliny)
            {
                if (win == 1 && druzyna.GetNazwa() == d1.GetNazwa())
                {
                    druzyna.DodajPunkty(1);
                }
                if (win == 0 && druzyna.GetNazwa() == d2.GetNazwa())
                {
                    druzyna.DodajPunkty(1);
                }
            }
            Sort(listadruzyn);
            Sort(listaprzeciaganieliny);
        }
        public void Finaly(string dyscyplina)
        {
            final = new List<Druzyna>();
            if(dyscyplina == "Siatkowka")
            {
                final.Add(listasiatkowka[0]);
                final.Add(listasiatkowka[1]);
                final.Add(listasiatkowka[2]);
                final.Add(listasiatkowka[3]);
                System.Console.WriteLine("Do finalu przechodz?? druzyny: ");
                foreach (Druzyna druzyna in final)
                {
                    System.Console.WriteLine(druzyna.GetNazwa());
                }
                Przeglad_Sedzia_String();
                System.Console.WriteLine("Wybierz sedziego glownego");
                Sedzia sg = Wybierz_Sedziego();
                if (sg == null)
                    return;
                System.Console.WriteLine("Wybierz pierwszego sedziego pomocniczego");
                Sedzia sp1 = Wybierz_Sedziego();
                if (sp1 == null || sp1 == sg)
                    return;
                System.Console.WriteLine("Wybierz drugiego sedziego pomocniczego");
                Sedzia sp2 = Wybierz_Sedziego();
                if (sp2 == null || sp2 == sp1 || sp2 == sg)
                    return;
                Siatkowka siatkowka;
                for(int i=0; i < final.Count; i++)
                {
                    for(int j=i+1; j < final.Count; j++)
                    {
                        siatkowka = new Siatkowka(final[i], final[j], sg, sp1, sp2 );
                        siatkowka.Rozgrywka();
                        int win = siatkowka.Wpisz_Wynik();
                        foreach (Druzyna druzyna in listadruzyn)
                        {
                            if (win == 1 && druzyna.GetNazwa() == final[i].GetNazwa())
                            {
                                druzyna.DodajPunkty(1);
                            }
                            if (win == 0 && druzyna.GetNazwa() == final[j].GetNazwa())
                            {
                                druzyna.DodajPunkty(1);
                            }
                        }
                    }
                }
                Sort(final);
                if (final[0] == final[1])
                {
                    siatkowka = new Siatkowka(final[0], final[1], sg, sp1, sp2);
                    siatkowka.Rozgrywka();
                    siatkowka.Wpisz_Wynik();
                    int win = siatkowka.Wpisz_Wynik();
                    foreach (Druzyna druzyna in listadruzyn)
                    {
                        if (win == 1 && druzyna.GetNazwa() == final[0].GetNazwa())
                        {
                            druzyna.DodajPunkty(1);
                        }
                        if (win == 0 && druzyna.GetNazwa() == final[1].GetNazwa())
                        {
                            druzyna.DodajPunkty(1);
                        }
                    }
                }
                System.Console.WriteLine("Final wygrala druzyna " + final[0].GetNazwa());
            }
            if (dyscyplina == "Dwa Ognie")
            {
                final.Add(listadwaognie[0]);
                final.Add(listadwaognie[1]);
                final.Add(listadwaognie[2]);
                final.Add(listadwaognie[3]);
                System.Console.WriteLine("Do finalu przechodz?? druzyny: ");
                foreach (Druzyna druzyna in final)
                {
                    System.Console.WriteLine(druzyna.GetNazwa());
                }
                Przeglad_Sedzia_String();
                System.Console.WriteLine("Wybierz sedziego");
                Sedzia sg = Wybierz_Sedziego();
                if (sg == null)
                    return;
                Dwa_ognie dwaognie;
                for (int i = 0; i < final.Count; i++)
                {
                    for (int j = i + 1; j < final.Count; j++)
                    {
                        dwaognie = new Dwa_ognie(final[i], final[j], sg);
                        dwaognie.Rozgrywka();
                        int win = dwaognie.Wpisz_Wynik();
                        foreach (Druzyna druzyna in listadruzyn)
                        {
                            if (win == 1 && druzyna.GetNazwa() == final[i].GetNazwa())
                            {
                                druzyna.DodajPunkty(1);
                            }
                            if (win == 0 && druzyna.GetNazwa() == final[j].GetNazwa())
                            {
                                druzyna.DodajPunkty(1);
                            }
                        }
                    }
                }
                Sort(final);
                if (final[0] == final[1])
                {
                    dwaognie = new Dwa_ognie(final[0], final[1], sg);
                    dwaognie.Rozgrywka();
                    int win = dwaognie.Wpisz_Wynik();
                    foreach (Druzyna druzyna in listadruzyn)
                    {
                        if (win == 1 && druzyna.GetNazwa() == final[0].GetNazwa())
                        {
                            druzyna.DodajPunkty(1);
                        }
                        if (win == 0 && druzyna.GetNazwa() == final[1].GetNazwa())
                        {
                            druzyna.DodajPunkty(1);
                        }
                    }
                }
                System.Console.WriteLine("Final wygrala druzyna " + final[0].GetNazwa());
            }
            if (dyscyplina == "Przeciaganie Liny")
            {
                final.Add(listaprzeciaganieliny[0]);
                final.Add(listaprzeciaganieliny[1]);
                final.Add(listaprzeciaganieliny[2]);
                final.Add(listaprzeciaganieliny[3]);
                System.Console.WriteLine("Do finalu przechodz?? druzyny: ");
                foreach (Druzyna druzyna in final)
                {
                    System.Console.WriteLine(druzyna.GetNazwa());
                }
                Przeglad_Sedzia_String();
                System.Console.WriteLine("Wybierz sedziego");
                Sedzia sg = Wybierz_Sedziego();
                if (sg == null)
                    return;
                Przeciaganie_liny przeciaganieliny;
                for (int i = 0; i < final.Count; i++)
                {
                    for (int j = i + 1; j < final.Count; j++)
                    {
                        przeciaganieliny = new Przeciaganie_liny(final[i], final[j], sg);
                        przeciaganieliny.Rozgrywka();
 
                        int win = przeciaganieliny.Wpisz_Wynik();
                        foreach (Druzyna druzyna in listadruzyn)
                        {
                            if (win == 1 && druzyna.GetNazwa() == final[i].GetNazwa())
                            {
                                druzyna.DodajPunkty(1);
                            }
                            if (win == 0 && druzyna.GetNazwa() == final[j].GetNazwa())
                            {
                                druzyna.DodajPunkty(1);
                            }
                        }
                    }
                }
                Sort(final);
                if (final[0] == final[1])
                {
                    przeciaganieliny = new Przeciaganie_liny(final[0], final[1], sg);
                    przeciaganieliny.Rozgrywka();
                    int win = przeciaganieliny.Wpisz_Wynik();
                    foreach (Druzyna druzyna in listadruzyn)
                    {
                        if (win == 1 && druzyna.GetNazwa() == final[0].GetNazwa())
                        {
                            druzyna.DodajPunkty(1);
                        }
                        if (win == 0 && druzyna.GetNazwa() == final[1].GetNazwa())
                        {
                            druzyna.DodajPunkty(1);
                        }
                    }
                }
                System.Console.WriteLine("Final wygrala druzyna " + final[0].GetNazwa());
            }
            Sort(listadruzyn);
            Sort(listasiatkowka);
            Sort(listadwaognie);
            Sort(listaprzeciaganieliny);
        }
        public void Kazdy_Z_Kazdym_Siatkowka()
        {
            Przeglad_Sedzia_String();
            System.Console.WriteLine("Wybierz sedziego glownego");
            Sedzia sg = Wybierz_Sedziego();
            if (sg == null)
                return;
            System.Console.WriteLine("Wybierz pierwszego sedziego pomocniczego");
            Sedzia sp1 = Wybierz_Sedziego();
            if (sp1 == null || sp1 == sg)
                return;
            System.Console.WriteLine("Wybierz drugiego sedziego pomocniczego");
            Sedzia sp2 = Wybierz_Sedziego();
            if (sp2 == null || sp2 == sp1 || sp2 == sg)
                return;
            for (int i = 0; i < listasiatkowka.Count; i++)
            {
                for (int j = i + 1; j < listasiatkowka.Count; j++)
                {
                    Siatkowka siatkowka = new Siatkowka(listasiatkowka[i], listasiatkowka[j], sg, sp1, sp2);
                    siatkowka.Rozgrywka();
                    int win = siatkowka.Wpisz_Wynik();
                    foreach (Druzyna druzyna in listadruzyn)
                    {
                        if (win == 1 && druzyna.GetNazwa() == listasiatkowka[i].GetNazwa())
                        {
                            druzyna.DodajPunkty(1);
                        }
                        if (win == 0 && druzyna.GetNazwa() == listasiatkowka[j].GetNazwa())
                        {
                            druzyna.DodajPunkty(1);
                        }
                    }
                }
            }
            Sort(listadruzyn);
            Sort(listasiatkowka);
        }
        public void Kazdy_Z_Kazdym_DwaOgnie()
        {
            Przeglad_Sedzia_String();
            System.Console.WriteLine("Wybierz sedziego ");
            Sedzia s = Wybierz_Sedziego();
            if (s == null)
                return;
            for (int i = 0; i < listasiatkowka.Count; i++)
            {
                for (int j = i + 1; j < listasiatkowka.Count; j++)
                {
                    Dwa_ognie dwaognie = new Dwa_ognie(listadwaognie[i], listadwaognie[j], s);
                    dwaognie.Rozgrywka();
                    int win = dwaognie.Wpisz_Wynik();
                    foreach (Druzyna druzyna in listadruzyn)
                    {
                        if (win == 1 && druzyna.GetNazwa() == listadwaognie[i].GetNazwa())
                        {
                            druzyna.DodajPunkty(1);
                        }
                        if (win == 0 && druzyna.GetNazwa() == listadwaognie[j].GetNazwa())
                        {
                            druzyna.DodajPunkty(1);
                        }
                    }
                }
            }
            Sort(listadruzyn);
            Sort(listadwaognie);
        }
        public void Kazdy_Z_Kazdym_PrzeciaganieLiny()
        {
            Przeglad_Sedzia_String();
            System.Console.WriteLine("Wybierz sedziego ");
            Sedzia s = Wybierz_Sedziego();
            if (s == null)
                return;
            for (int i = 0; i < listasiatkowka.Count; i++)
            {
                for (int j = i + 1; j < listasiatkowka.Count; j++)
                {
                    Przeciaganie_liny przeciaganieliny = new Przeciaganie_liny(listaprzeciaganieliny[i], listaprzeciaganieliny[j], s);
                    przeciaganieliny.Rozgrywka();
                    int win = przeciaganieliny.Wpisz_Wynik();
                    foreach (Druzyna druzyna in listadruzyn)
                    {
                        if (win == 1 && druzyna.GetNazwa() == listaprzeciaganieliny[i].GetNazwa())
                        {
                            druzyna.DodajPunkty(1);
                        }
                        if (win == 0 && druzyna.GetNazwa() == listaprzeciaganieliny[j].GetNazwa())
                        {
                            druzyna.DodajPunkty(1);
                        }
                    }
                }
            }
            Sort(listadruzyn);
            Sort(listaprzeciaganieliny);
        }
        public Druzyna Wybierz_Druzyne()
        {
            System.Console.WriteLine("Podaj nazwe");
            string nazwa = System.Console.ReadLine();
            if (nazwa == null)
                return null;
            nazwa = nazwa.Replace(" ", "_");
            Druzyna druzyna = Druzyna_Exists(nazwa);
            if(druzyna == null)
                System.Console.WriteLine("Nie ma takiej druzyny");

            return druzyna;
        }
        public Sedzia Wybierz_Sedziego()
        {
            System.Console.WriteLine("Podaj Imie i Nazwisko");
            string nazwa = System.Console.ReadLine();
            if (nazwa == null)
                return null;
            Sedzia sedzia = Sedzia_Exists(nazwa);
            if(sedzia == null)
                System.Console.WriteLine("Nie ma takiego sedziego");

            return sedzia;
        }
        private Sedzia Sedzia_Exists(string nazwa)
        {
            for (int i = 0; i < listasedzia.Count; i++)
            {
                Sedzia sedzia = listasedzia[i];
                if (nazwa == sedzia.ToString())
                    return sedzia;
            }
            return null;
        }
        private Druzyna Druzyna_Exists(string nazwa)
        {
            for (int i = 0; i < listadruzyn.Count; i++)
            {
                Druzyna druzyna = listadruzyn[i];
                if (nazwa == druzyna.GetNazwa())
                    return druzyna;
            }
            return null;
        }
        private void Sort(List<Druzyna> d)
        {
            for (int i = 0; i < d.Count; i++)
            {
                int pun = d[i].GetPunkty();
                for (int j = i; j < d.Count; j++)
                {
                    if (d[j].GetPunkty() > pun)
                    {
                        Druzyna temp = d[j];
                        d[j] = d[i];
                        d[i] = temp;
                    }
                }
            }
        }

        protected List<Druzyna>         listadruzyn;
        protected List<Druzyna>         listasiatkowka;
        protected List<Druzyna>         listadwaognie;
        protected List<Druzyna>         listaprzeciaganieliny;
        protected List<Sedzia>          listasedzia;
        protected List<Druzyna>         final;
    }
}
