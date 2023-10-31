using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_Projekt
{
    class Termek
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
            Idopont = DateTime.Parse(adatok[0]);
            Nev = adatok[1];
            Ar = int.Parse(adatok[2]);
        }

        public override string ToString()
        {
            return $"{Idopont} - {Nev} - {Ar}Ft";
        }

    }
}
