using System.Collections.Generic;

namespace Projekt1
{
    class Zawody
    {
        public bool Zapis(string file) { return true; }
        public bool Odczyt(string file) { return true; }
        public void Dodaj_Sedziego(Sedzia sedzia) { }
        public void Usun_Sedziego(Sedzia sedzia) { }
        public List<Sedzia> Przeglad_Sedzia() { return listasedzia; }
        public void Dodaj_Druzyne(Druzyna druzyna) { }
        public void Usun_Druzyne(Druzyna druzyna) { }
        public List<Druzyna> Przeglad_Druzyny() { return listadruzyn; }
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
