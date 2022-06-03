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

            sw.WriteLine("Sedzia:");
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
                        listadruzyn.Add(new Druzyna(s[0], int.Parse(s[1])));
                    }
                }
                else if (step == 1){
                    string[] s = line.Split(null);
                    listasedzia.Add(new Sedzia(s[0], s[1]));
                }
            }
            sr.Close();
        }
        public void Dodaj_Druzyne(Druzyna druzyna) { listadruzyn.Add(druzyna); }
        public void Usun_Druzyne(Druzyna druzyna) { listadruzyn.Remove(druzyna); }
        public List<Druzyna> Przeglad_Druzyny() { return listadruzyn; }
        public void Dodaj_Sedziego(Sedzia sedzia) { listasedzia.Add(sedzia); }
        public void Usun_Sedziego(Sedzia sedzia) { listasedzia.Remove(sedzia); }
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
