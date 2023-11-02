using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BB_Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Megoldas megoldas = new Megoldas();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = megoldas;
            //alapOldalBuild();
        }

        private void alapOldalBTN_Click(object sender, RoutedEventArgs e)
        {
            alapOldalBuild();
        }

        private void bezarBTN_Click(object sender, RoutedEventArgs e)
        {
            FajlIras();
            Close();
        }

        private void FajlIras()
        {
            try
            {
                StreamWriter sw = new StreamWriter("termekek.txt");
                sw.WriteLine("Datum;Termek;Ar(forintban)");
                foreach (var termek in megoldas.termekek)
                {
                    sw.WriteLine($"{termek.Idopont};{termek.Nev};{termek.Ar}");
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fájl írás sikertelen! {ex}", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        StackPanel stackPanel = new StackPanel();
            Button bezarBtn = new Button();
            DockPanel dp1 = new DockPanel(); Label lb1 = new Label(); ComboBox cmbbx1 = new ComboBox();
            DockPanel dp2 = new DockPanel(); Label lbl2 = new Label(); ComboBox cmbbx2 = new ComboBox(); Button felLeBTN = new Button();
            ListBox termekekLBX = new ListBox();
            DockPanel dp3 = new DockPanel(); Button modositBTN = new Button(); Button torlesBTN = new Button();

        private void alapOldalBuild()
        {
            mainGrid.Children.Clear();
            listaOldalBTN.IsEnabled = false;
            bezarBtn.Margin = new Thickness(20); bezarBtn.Height = 20; bezarBtn.Width = 20; bezarBtn.Content = "x"; bezarBtn.HorizontalAlignment = HorizontalAlignment.Right; bezarBtn.Click += bezarBTN_Click;
                stackPanel.Children.Add(bezarBtn);
            lb1.Content = "Válasszon hónapot:";
                 cmbbx1.ItemsSource = megoldas.honapok; cmbbx1.Width = 300; cmbbx1.SelectedIndex = 0;
                 dp1.Children.Add(lb1); dp1.Children.Add(cmbbx1); stackPanel.Children.Add(dp1);
            lbl2.Content = "Rendezés szerint:";
                cmbbx2.ItemsSource = megoldas.rendezes; cmbbx2.Width = 200; cmbbx2.SelectedIndex = 0;
                felLeBTN.Width = 20; felLeBTN.Content = "ˇ";
                dp2.Children.Add(lbl2); dp2.Children.Add(cmbbx2); dp2.Children.Add(felLeBTN); stackPanel.Children.Add(dp2);
            termekekLBX.ItemsSource = megoldas.termekek; termekekLBX.Height = 300; termekekLBX.Margin = new Thickness(20); termekekLBX.SelectionChanged += termekekLBX_SelectionChanged;
                stackPanel.Children.Add(termekekLBX);
            torlesBTN.Height = modositBTN.Height = 40; modositBTN.IsEnabled = torlesBTN.IsEnabled = false; modositBTN.Content = "Tárgy módosítása"; torlesBTN.Content = "Tárgy törlése";
                dp3.Children.Add(modositBTN); dp3.Children.Add(torlesBTN); stackPanel.Children.Add(dp3);
            mainGrid.Children.Add(stackPanel);
        }

        private void termekekLBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            torlesBTN.IsEnabled = modositBTN.IsEnabled = true;
        }

        private void ujTargyBTN_Click(object sender, RoutedEventArgs e)
        {
            Ujablak uj = new Ujablak();
            uj.ShowDialog();
        }
    }
}
