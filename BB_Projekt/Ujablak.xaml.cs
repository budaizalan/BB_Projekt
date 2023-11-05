using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BB_Projekt
{
    /// <summary>
    /// Interaction logic for Ujablak.xaml
    /// </summary>
    public partial class Ujablak : Window
    {
        public Megoldas megoldas;

        private List<int> napok;

        public ObservableCollection<string> ujtermekseged = new ObservableCollection<string>();

        private Termek termek;
        public Termek Termek
        {
            get
            {
                return termek;
            }
            set
            {
                termek = value;
            }
        }
        public Ujablak()
        {
            InitializeComponent();
            napok_Feltolt();
            termek = new Termek();
            megoldas = new Megoldas();
            this.DataContext = megoldas;
        }

        private void ujMegseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void ujFelvetelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(ujTermekTxtbx.Text) && int.TryParse(ujArTxtbx.Text, out int ar) && NapEllenorzo(ujHonapCbbx.SelectedItem.ToString(), int.Parse(ujNapCbbx.SelectedItem.ToString())))
            {
                MessageBoxResult result = MessageBox.Show("Biztos fel akarja venni a listába az új terméket?", "Mentés", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.DialogResult = true;
                    this.Close();
                }
            }
            //if (!string.isnullorempty(ujtermektxtbx.text))
            //{
            //    if (int.tryparse(ujartxtbx.text, out int ar))
            //    {
            //        if (napellenorzo(ujhonapcbbx.selecteditem.tostring(), int.parse(ujnapcbbx.selecteditem.tostring())))
            //        {
            //            messageboxresult result = messagebox.show("biztos fel akarja venni a listába az új terméket?", "mentés", messageboxbutton.yesno, messageboximage.question);
            //            if (result == messageboxresult.yes)
            //            {
            //                this.dialogresult = true;
            //                this.close();
            //            }
            //        }
            //    }
            //}
            else
            {
                MessageBox.Show("Hibás adatatot adott meg az egyik bekérésnél", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void napok_Feltolt()
        {
            napok = new List<int>();
            for (int i = 1; i <= 31; i++)
            {
                napok.Add(i);
            }
            ujNapCbbx.ItemsSource = napok;
        }

        private bool NapEllenorzo(string honap, int nap)
        {
            if ((honap == "Április" || honap == "Június" || honap == "Szeptember" || honap == "November") && nap > 30)
            {
                return false;
            }
            if (honap == "Február" && nap > 28)
            {
                return false;
            }
            return true;
        }

        public Termek UjTermek()
        {
            ujtermekseged = megoldas.ujtermekek;
            ujtermekseged[0] = (int.Parse(ujtermekseged[0]) + 1).ToString();
            string segedSor = $"{((int.Parse(ujtermekseged[0]) <= 9) ? "0" : "")}{ujtermekseged[0]}-{((int.Parse(ujtermekseged[1]) <= 9) ? "0" : "")}{ujtermekseged[1]};{ujtermekseged[2]};{ujtermekseged[3]}";
            return new Termek(segedSor);
        }
    }
}
