class Sedzia
{
    protected string imie, nazwisko;
    private Sedzia sedzia;

    public Sedzia(Sedzia sedzia)
    {
        this.sedzia = sedzia;
    }

    public Sedzia(string imie, string nazwisko)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
    }

    public string ToString() { return imie + " " + nazwisko; }
}
class Sedzia_pomocniczy : Sedzia
{
    public Sedzia_pomocniczy(string imie, string nazwisko) : base(imie, nazwisko)
    {
    }
}