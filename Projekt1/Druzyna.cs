class Druzyna
{
    protected string nazwa_druzyny;
    protected int ilosc_punktow_druzyny;
    public Druzyna(string nazwa_druzyny)
    {
        this.nazwa_druzyny = nazwa_druzyny;
        ilosc_punktow_druzyny = 0;
    }
}
class Sedzia
{
    protected string imie, nazwisko;
    public Sedzia(string imie, string nazwisko)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
    }
}
class Sedzia_pomocniczy : Sedzia
{
    public Sedzia_pomocniczy(string imie, string nazwisko) : base(imie, nazwisko)
    {
    }
}
