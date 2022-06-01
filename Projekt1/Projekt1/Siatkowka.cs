class Siatkowka : Gra
{
    protected Sedzia_pomocniczy sedzia_pomocniczy1, sedzia_pomocniczy2;
    public Siatkowka(Druzyna pierwsza_druzyna, Druzyna druga_druzyna, Sedzia sedzia_glowny, Sedzia_pomocniczy sedzia_pomocniczy1, Sedzia_pomocniczy sedzia_pomocniczy2) :base(pierwsza_druzyna, druga_druzyna, sedzia_glowny)
    {
        this.sedzia_pomocniczy1 = sedzia_pomocniczy1;
        this.sedzia_pomocniczy2 = sedzia_pomocniczy2;
    }
}

