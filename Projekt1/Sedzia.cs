class Sedzia
{
    protected string imie, nazwisko;

    public Sedzia(string imie, string nazwisko)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
    }

    public override string ToString() { return imie + " " + nazwisko; } 

}