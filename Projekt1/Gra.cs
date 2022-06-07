using System;

internal class Gra
{
    protected Druzyna pierwsza_druzyna, druga_druzyna;
    protected Sedzia pierwszy_sedzia;
    protected bool kto_wygral;
    public Gra(Druzyna pierwsza_druzyna, Druzyna druga_druzyna, Sedzia pierwszy_sedzia)
    {
        this.pierwszy_sedzia = pierwszy_sedzia;
        this.druga_druzyna = druga_druzyna;
        this.pierwsza_druzyna = pierwsza_druzyna;
    }
    public void Rozgrywka()
    {
        int punkty1, punkty2;
        Random r = new Random();
        punkty1 = r.Next(100);
        punkty2 = r.Next(100);
        if (punkty1 > punkty2)
        {
            kto_wygral = false;
            System.Console.WriteLine("Wygrala druzyna " + druga_druzyna.GetNazwa());
        }
        else if (punkty2 > punkty1)
        {
            kto_wygral = true;
            System.Console.WriteLine("Wygrala druzyna " + pierwsza_druzyna.GetNazwa());
        }
        else
        {
            if (r.Next(2) == 0) { kto_wygral = false; System.Console.WriteLine("Wygrala druzyna " + druga_druzyna.GetNazwa()); }
            else { kto_wygral = true; System.Console.WriteLine("Wygrala druzyna " + pierwsza_druzyna.GetNazwa()); }
        }
    }
    public int Wpisz_Wynik()
    {
        if (kto_wygral)
        {
            pierwsza_druzyna.DodajPunkty(1);
            return 1;
        }
        else
        {
            druga_druzyna.DodajPunkty(1);
            return 0;
        }
    }
}

