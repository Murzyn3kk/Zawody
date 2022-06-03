using Projekt1;
using System.Collections.Generic;

class Projekt
{
    static void Main(string[] args)
    {
        Zawody zawody = new Zawody();
        zawody.Odczyt("../../../Test.txt");
        foreach (Sedzia sedzia in zawody.Przeglad_Sedzia())
            System.Console.WriteLine(sedzia.GetString());
        foreach (Druzyna druzyna in zawody.Przeglad_Druzyny())
            System.Console.WriteLine(druzyna.GetString());
    }
}