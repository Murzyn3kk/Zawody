class Sedzia
{
    protected string imie, nazwisko;
    public Sedzia(string imie, string nazwisko)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
    }

    public string GetString() { return imie + " " + nazwisko; }
}
class Sedzia_pomocniczy : Sedzia
{
    public Sedzia_pomocniczy(string imie, string nazwisko) : base(imie, nazwisko)
    {
    }
}