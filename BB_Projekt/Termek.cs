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
            public string Ev { get; set; }
            public DateTime Idopont { get; set; }
            public string Nev { get; set; }
            public int Ar { get; set; }

            public Termek()
            {

            }
            public Termek(string sor)
            {
                string[] adatok = sor.Split(';');
                Ev = adatok[0];
                Idopont = DateTime.ParseExact(adatok[1], "MM-dd", CultureInfo.InvariantCulture);
                Nev = adatok[2];
                Ar = int.Parse(adatok[3]);
            }

            public override string ToString()
            {
                return $"{Ev}-{Idopont:MM-dd} - {Nev} - {Ar}Ft";
            }

    }
}
