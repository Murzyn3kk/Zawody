using System;

class Gra
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
            kto_wygral = false;
        else if (punkty2 > punkty1)
            kto_wygral = true;
        else
        {
            if (r.Next(2) == 0) kto_wygral = false;
            else kto_wygral = true;
        }
    }
    public void Wpisz_Wynik(Druzyna druzyna)
    {
        if (kto_wygral)
            pierwsza_druzyna.DodajPunkty(1);
        else druga_druzyna.DodajPunkty(1);
    }
    }

