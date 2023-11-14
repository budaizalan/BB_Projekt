using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for Keszitok.xaml
    /// </summary>
    public partial class Keszitok : Window
    {
        public Keszitok()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void miklosBtn_Click(object sender, RoutedEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://github.com/FeketeMiklosBenjamin",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void marciBtn_Click(object sender, RoutedEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://github.com/kissmarcell132",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void zalanBtn_Click(object sender, RoutedEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://github.com/budaizalan",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void miklosInstaBtn_Click(object sender, RoutedEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://www.instagram.com/fekete.miklos.b/",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void marciInstaBtn_Click(object sender, RoutedEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://www.instagram.com/marcivok14/",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void zalanInstaBtn_Click(object sender, RoutedEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://www.instagram.com/budai_zalan/",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void miklosContriBtn_Click(object sender, RoutedEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://github.com/budaizalan/BB_Projekt/activity?ref=main&actor=FeketeMiklosBenjamin",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void marciContriBtn_Click(object sender, RoutedEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://github.com/budaizalan/BB_Projekt/activity?ref=main&actor=kissmarcell132",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void zalanContriBtn_Click(object sender, RoutedEventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://github.com/budaizalan/BB_Projekt/activity?ref=main&actor=budaizalan",
                UseShellExecute = true
            };
            Process.Start(psi);
        }
    }
}
