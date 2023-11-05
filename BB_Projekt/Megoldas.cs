﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public List<string> rendezes = new List<string>() { "Nap", "ABC", "Ár" };
        public Megoldas()
        {
            FajlOlvas();
            honapok = new ObservableCollection<string>() { "Január", "Február", "Március", "Április", "Május", "Június", "Július", "Augusztus", "Szeptember", "Október", "November", "December" };
            ujtermekek = new ObservableCollection<string>() { "0", "1", "", ""};
        }

        private List<Termek> _termekek;
        public List<Termek> termekek
        {
            get { return _termekek; }
            set { _termekek = value; OnPropertyChanged("termekek"); }
        }

        private ObservableCollection<string> _honapok;
        public ObservableCollection<string> honapok
        {
            get { return _honapok; }
            set { _honapok = value; OnPropertyChanged("honapok"); }
        }

        private ObservableCollection<string> _ujtermekek;
        public ObservableCollection<string> ujtermekek
        {
            get { return _ujtermekek; }
            set { _ujtermekek = value; OnPropertyChanged("ujtermekek"); }
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
