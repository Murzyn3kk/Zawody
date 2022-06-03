class Druzyna
{
    protected string nazwa_druzyny;
    protected int ilosc_punktow_druzyny;
    public Druzyna(string nazwa_druzyny)
    {
        this.nazwa_druzyny = nazwa_druzyny;
        ilosc_punktow_druzyny = 0;
    }
    public Druzyna(string nazwa, int punkty)
    {
        nazwa_druzyny = nazwa;
        ilosc_punktow_druzyny = punkty;
    }
    public void DodajPunkty(int value)
    {
        ilosc_punktow_druzyny += value;
    }
    public string GetString() { return nazwa_druzyny + " " + ilosc_punktow_druzyny; }
}

