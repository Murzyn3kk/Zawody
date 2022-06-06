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
            System.Console.WriteLine("Siatkowka: Punkty, Nazwa druzyny");
            foreach (Druzyna druzyna in listasiatkowka)
                System.Console.WriteLine("\t" + druzyna);
        }
        public List<Druzyna> Tabela_Siatkowka() { return listasiatkowka; }
        public void Tabela_Dwaognie_String()
        {
            System.Console.WriteLine("Dwa ognie: Punkty, Nazwa druzyny");
            foreach (Druzyna druzyna in listadwaognie)
                System.Console.WriteLine("\t" + druzyna);
        }
        public List<Druzyna> Tabela_Dwaognie() { return listadwaognie; }
        public void Tabela_Przeciaganieliny_String()
        {
            System.Console.WriteLine("Przeciaganie liny: Punkty, Nazwa druzyny");
            foreach (Druzyna druzyna in listaprzeciaganieliny)
                System.Console.WriteLine("\t" + druzyna);
        }
        public List<Druzyna> Tabela_Przeciaganieliny() { return listaprzeciaganieliny; }

        public void Rozgrywka_Siatkowka()
        {
            Przeglad_Druzyny_String();
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
            Sedzia_pomocniczy sp1 = (Sedzia_pomocniczy)Wybierz_Sedziego();
            if (sp1 == null || sp1 == sg)
                return;
            System.Console.WriteLine("Wybierz drugiego sedziego pomocniczego");
            Sedzia_pomocniczy sp2 = (Sedzia_pomocniczy)Wybierz_Sedziego();
            if (sp2 == null || sp2 == sp1 || sp2 == sg)
                return;

            Siatkowka siatkowka = new Siatkowka(d1, d2, sg, sp1, sp2);
            siatkowka.Rozgrywka();
            siatkowka.Wpisz_Wynik();
            Sort(listadruzyn);
        }
        public void Rozgrywka_Dwa_Ognie()
        {
            Przeglad_Druzyny_String();
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
            dwaognie.Wpisz_Wynik();
            Sort(listadruzyn);
        }
        public void Rozgrywka_Przeciaganie_Liny()
        {
            Przeglad_Druzyny_String();
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
            przeciaganieliny.Wpisz_Wynik();
            Sort(listadruzyn);
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
    }
}
