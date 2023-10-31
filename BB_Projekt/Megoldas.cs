using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_Projekt
{
    public class Megoldas : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string tulajdonsagNev)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagNev));
        }
        
        public List<string> honapok = new List<string>() { "Január", "Február", "Március", "Április", "Május", "Június", "Július", "Augusztus", "Szeptember", "Október", "November", "December"};
        public List<string> rendezes = new List<string>() { "Nap", "ABC", "Ár" };
        public Megoldas()
        {
            FajlOlvas();
        }

        private List<Termek> _termekek;
        public List<Termek> termekek
        {
            get { return _termekek; }
            set { _termekek = value; OnPropertyChanged("termekek"); }
        }

        private void FajlOlvas()
        {
            termekek = new List<Termek>();
            StreamReader sr = new StreamReader("termekek.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                termekek.Add(new Termek(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}
