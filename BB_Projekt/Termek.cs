using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_Projekt
{
    public class Termek
    {
            public DateTime Idopont { get; set; }
            public string Nev { get; set; }
            public int Ar { get; set; }

            public Termek()
            {

            }
            public Termek(string sor)
            {
                string[] adatok = sor.Split(';');
                Idopont = DateTime.ParseExact(adatok[0], "MM-dd", CultureInfo.InvariantCulture);
                Nev = adatok[1];
                Ar = int.Parse(adatok[2]);
            }

            public override string ToString()
            {
                return $"{Idopont:MM-dd} - {Nev} - {Ar}Ft";
            }

    }
}
