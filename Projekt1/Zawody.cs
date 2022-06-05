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
            listadruzyn.Add(new Druzyna(nazwa));
        }
        public void Usun_Druzyne()
        {
            System.Console.WriteLine("Podaj nazwe");
            string nazwa = System.Console.ReadLine();
            if (nazwa == null)
                return;
            nazwa = nazwa.Replace(" ", "_");
            for (int i = 0; i < listadruzyn.Count; i++)
            {
                Druzyna druzyna = listadruzyn[i];
                if (nazwa == druzyna.GetNazwa())
                {
                    listadruzyn.Remove(druzyna);
                    i--;
                }
            }
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
            for (int i = 0; i < listasedzia.Count; i++)
            {
                Sedzia sedzia = listasedzia[i];
                if (nazwa == sedzia.GetString())
                {
                    listasedzia.Remove(sedzia);
                    i--;
                }
            }
        }
        public void Przeglad_Sedzia_String()
        {
            System.Console.WriteLine("Sedzia: Imie Nazwisko");
            foreach (Sedzia sedzia in listasedzia)
                System.Console.WriteLine("\t" + sedzia.GetString());
        }
        public List<Sedzia> Przeglad_Sedzia() { return listasedzia; }

        public List<Druzyna> Tabela_Siatkowka() { return listasiatkowka; }
        public List<Druzyna> Tabela_Dwaognie() { return listadwaognie; }
        public List<Druzyna> Tabela_Przeciaganieliny() { return listaprzeciaganieliny; }

        protected Siatkowka           siatkowka;
        protected Dwa_ognie           dwaognie;
        protected Przeciaganie_liny   przeciaganieliny;
        protected List<Druzyna>       listadruzyn;
        protected List<Druzyna>       listasiatkowka;
        protected List<Druzyna>       listadwaognie;
        protected List<Druzyna>       listaprzeciaganieliny;
        protected List<Sedzia>        listasedzia;
    }
}
