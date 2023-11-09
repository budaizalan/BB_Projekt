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
            stackPanel.Children.Clear();
            listaOldalBTN.IsEnabled = true;
        }

        private void FajlIras()
        {
            try
            {
                StreamWriter sw = new StreamWriter("termekek.txt");
                sw.WriteLine("Datum;Termek;Ar(forintban)");
                foreach (var termek in megoldas.termekek)
                {
                    sw.WriteLine($"{termek.Idopont:MM-dd};{termek.Nev};{termek.Ar}");
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
            DockPanel dp2 = new DockPanel(); Label lbl2 = new Label(); ComboBox cmbbx2 = new ComboBox();
            ListBox termekekLBX = new ListBox();
            DockPanel dp3 = new DockPanel(); 
            Button torlesBTN = new Button();

        private void alapOldalBuild()
        {
            mainGrid.Children.Clear();
            stackPanel.Children.Clear();
            dp1.Children.Clear();
            dp2.Children.Clear();
            dp3.Children.Clear();
            listaOldalBTN.IsEnabled = false;
            bezarBtn.Margin = new Thickness(20);
            bezarBtn.Height = 20;
            bezarBtn.Width = 20;
            bezarBtn.Content = "x";
            bezarBtn.HorizontalAlignment = HorizontalAlignment.Right;
            bezarBtn.Click += bezarBTN_Click;            

            stackPanel.Children.Add(bezarBtn);

            lb1.Content = "Válasszon hónapot:";
            cmbbx1.ItemsSource = megoldas.honapok;
            cmbbx1.Width = 300;
            cmbbx1.SelectedIndex = 0;
            dp1.Children.Add(lb1);
            dp1.Children.Add(cmbbx1);

            stackPanel.Children.Add(dp1);

            lbl2.Content = "Rendezés szerint:";
            cmbbx2.ItemsSource = megoldas.rendezes;
            cmbbx2.Width = 200;
            cmbbx2.SelectedIndex = 0;
            dp2.Children.Add(lbl2);
            dp2.Children.Add(cmbbx2);

            stackPanel.Children.Add(dp2);


            termekekLBX.ItemsSource = megoldas.termekek;
            termekekLBX.Height = 300;
            termekekLBX.Margin = new Thickness(20);
            termekekLBX.SelectionChanged += termekekLBX_SelectionChanged;

            stackPanel.Children.Add(termekekLBX);

            torlesBTN.Height = 40;
            torlesBTN.Width = 380;
            torlesBTN.IsEnabled = false;
            torlesBTN.Content = "Tárgy törlése"; 
            dp3.Children.Add(torlesBTN); 


            stackPanel.Children.Add(dp3);
            mainGrid.Children.Add(stackPanel);
        }

        private void keszitokOldal_Build()
        {
            mainGrid.Children.Clear();
        }

        private void termekekLBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            torlesBTN.IsEnabled = true;
        }

        private void ujTargyBTN_Click(object sender, RoutedEventArgs e)
        {
            Ujablak uj = new Ujablak();
            if (uj.ShowDialog() == true)
            {
                megoldas.termekek.Add(uj.UjTermek());
                termekekLBX.Items.Refresh();
                FajlIras();
            }
            listaOldalBTN.IsEnabled = true;
            stackPanel.Children.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FajlIras();
            this.Close();
        }

        private void keszitokBTN_Click(object sender, RoutedEventArgs e)
        {
            keszitokOldal_Build();
            listaOldalBTN.IsEnabled = true;
            stackPanel.Children.Clear();
        }
    }
}
