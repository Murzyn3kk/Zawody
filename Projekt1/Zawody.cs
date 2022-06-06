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

            foreach(Druzyna druzyna in listadruzyn)
                sw.WriteLine(druzyna.GetString());

            sw.WriteLine(":Sedzia:");
            foreach (Sedzia sedzia in listasedzia)
                sw.WriteLine(sedzia.GetString());

            sw.Close();
        }
        public void Odczyt(string file)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(file);
            string line;
            int step = 0;
            while((line = sr.ReadLine()) != null)
            {
                if (step == 0){
                    if (line == ":Sedzia:")
                        step++;
                    else
                    {
                        string[] s = line.Split(null);
                        listadruzyn.Add(new Druzyna(s[1], int.Parse(s[0])));
                    }
                }
                else if (step == 1){
                    string[] s = line.Split(null);
                    listasedzia.Add(new Sedzia(s[0], s[1]));
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
                System.Console.WriteLine("\t" + druzyna.GetString());
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
                System.Console.WriteLine("\t" + sedzia.GetString());
        }
        public List<Sedzia> Przeglad_Sedzia() { return listasedzia; }
        public void Tabela_Siatkowka_String()
        {
            System.Console.WriteLine("Siatkowka: Punkty, Nazwa druzyny");
            listasiatkowka.Sort();
            foreach (Druzyna druzyna in listasiatkowka)
                System.Console.WriteLine("\t" + druzyna.GetString());
        }
        public List<Druzyna> Tabela_Siatkowka() { return listasiatkowka; }
        public void Tabela_Dwaognie_String()
        {
            System.Console.WriteLine("Dwa ognie: Punkty, Nazwa druzyny");
            listadwaognie.Sort();
            foreach (Druzyna druzyna in listadwaognie)
                System.Console.WriteLine("\t" + druzyna.GetString());
        }
        public List<Druzyna> Tabela_Dwaognie() { return listadwaognie; }
        public void Tabela_Przeciaganieliny_String()
        {
            System.Console.WriteLine("Przeciaganie liny: Punkty, Nazwa druzyny");
            listaprzeciaganieliny.Sort();
            foreach (Druzyna druzyna in listaprzeciaganieliny)
                System.Console.WriteLine("\t" + druzyna.GetString());
        }
        public List<Druzyna> Tabela_Przeciaganieliny() { return listaprzeciaganieliny; }

        public void Rozgrywka_Siatkowka()
        {
            System.Console.WriteLine("Podaj nazwe pierwszej druzyny:");
            string druzyna1str = System.Console.ReadLine();
            if (druzyna1str == null)
                return;
            druzyna1str = druzyna1str.Replace(" ", "_");
            Druzyna druzyna1 = Druzyna_Exists(druzyna1str);
            if (druzyna1 == null)
                return;

            System.Console.WriteLine("Podaj nazwe drugiej druzyny:");
            string druzyna2str = System.Console.ReadLine();
            if (druzyna2str == null || druzyna1str == druzyna2str)
                return;
            Druzyna druzyna2 = Druzyna_Exists(druzyna1str);
            if (druzyna2 == null)
                return;

            System.Console.WriteLine("Podaj nazwe sedziego glownego:");
            string sedziaglstr = System.Console.ReadLine();
            if (sedziaglstr == null)
                return;
            Sedzia sedziagl = Sedzia_Exists(sedziaglstr);
            if (sedziagl == null)
                return;

            System.Console.WriteLine("Podaj nazwe sedziego pomocniczego:");
            string sedziapom1str = System.Console.ReadLine();
            if (sedziapom1str == null || sedziapom1str == sedziaglstr)
                return;
            Sedzia sedziapom1 = Sedzia_Exists(sedziapom1str);
            if (sedziapom1 == null)
                return;

            System.Console.WriteLine("Podaj nazwe drugiego sedziego pomocniczego:");
            string sedziapom2str = System.Console.ReadLine();
            if (sedziapom2str == null || sedziapom2str == sedziaglstr || sedziapom2str == sedziapom1str)
                return;
            Sedzia sedziapom2 = Sedzia_Exists(sedziapom2str);
            if (sedziapom2 == null)
                return;

            Siatkowka siatkowka = new Siatkowka(druzyna1, druzyna2, sedziagl, (Sedzia_pomocniczy)sedziapom1, (Sedzia_pomocniczy)sedziapom2);
            siatkowka.Rozgrywka();
        }
        public void Rozgrywka_Dwaognie()
        {
            System.Console.WriteLine("Podaj nazwe pierwszej druzyny:");
            string druzyna1str = System.Console.ReadLine();
            if (druzyna1str == null)
                return;
            druzyna1str = druzyna1str.Replace(" ", "_");
            Druzyna druzyna1 = Druzyna_Exists(druzyna1str);
            if (druzyna1 == null)
                return;

            System.Console.WriteLine("Podaj nazwe drugiej druzyny:");
            string druzyna2str = System.Console.ReadLine();
            if (druzyna2str == null || druzyna1str == druzyna2str)
                return;
            Druzyna druzyna2 = Druzyna_Exists(druzyna1str);
            if (druzyna2 == null)
                return;

            System.Console.WriteLine("Podaj nazwe sedziego glownego:");
            string sedziaglstr = System.Console.ReadLine();
            if (sedziaglstr == null)
                return;
            Sedzia sedziagl = Sedzia_Exists(sedziaglstr);
            if (sedziagl == null)
                return;

            Dwa_ognie dwaognie = new Dwa_ognie(druzyna1, druzyna2, sedziagl);
            dwaognie.Rozgrywka();
        }
        public void Rozgrywka_Przeciaganieliny()
        {
            System.Console.WriteLine("Podaj nazwe pierwszej druzyny:");
            string druzyna1str = System.Console.ReadLine();
            if (druzyna1str == null)
                return;
            druzyna1str = druzyna1str.Replace(" ", "_");
            Druzyna druzyna1 = Druzyna_Exists(druzyna1str);
            if (druzyna1 == null)
                return;

            System.Console.WriteLine("Podaj nazwe drugiej druzyny:");
            string druzyna2str = System.Console.ReadLine();
            if (druzyna2str == null || druzyna1str == druzyna2str)
                return;
            Druzyna druzyna2 = Druzyna_Exists(druzyna1str);
            if (druzyna2 == null)
                return;

            System.Console.WriteLine("Podaj nazwe sedziego glownego:");
            string sedziaglstr = System.Console.ReadLine();
            if (sedziaglstr == null)
                return;
            Sedzia sedziagl = Sedzia_Exists(sedziaglstr);
            if (sedziagl == null)
                return;

            Przeciaganie_liny przeciaganieliny = new Przeciaganie_liny(druzyna1, druzyna2, sedziagl);
            przeciaganieliny.Rozgrywka();
        }

        private Sedzia Sedzia_Exists(string nazwa)
        {
            for (int i = 0; i < listasedzia.Count; i++)
            {
                Sedzia sedzia = listasedzia[i];
                if (nazwa == sedzia.GetString())
                    return sedzia;
            }
            return null;
        }
        private Druzyna Druzyna_Exists(string nazwa)
        {
            for (int i = 0; i < listadruzyn.Count; i++)
            {
                Druzyna druzyna = listadruzyn[i];
                if (nazwa == druzyna.GetString())
                    return druzyna;
            }
            return null;
        }

        protected List<Druzyna>         listadruzyn;
        protected List<Druzyna>         listasiatkowka;
        protected List<Druzyna>         listadwaognie;
        protected List<Druzyna>         listaprzeciaganieliny;
        protected List<Sedzia>          listasedzia;
    }
}
