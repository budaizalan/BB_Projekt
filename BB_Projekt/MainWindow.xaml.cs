using System;
using System.CodeDom;
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

        List<Termek> kivalasztottTermek = new List<Termek>();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = megoldas;
            bezarBtn.Click += bezarBTN_Click;
            torlesBTN.Click += torlesBTN_Click;
            //alapOldalBuild();
        }

        private void alapOldalBTN_Click(object sender, RoutedEventArgs e)
        {
            alapOldalBuild();
            statisztikaBTN.IsEnabled = keszitokBTN.IsEnabled = true;
        }

        private void bezarBTN_Click(object sender, RoutedEventArgs e)
        {
            FajlIras();
            stackPanel.Children.Clear();
            listaOldalBTN.IsEnabled = statisztikaBTN.IsEnabled = true;
        }

        private void ujTargyBTN_Click(object sender, RoutedEventArgs e)
        {
            Ujablak uj = new Ujablak();
            if (uj.ShowDialog() == true)
            {
                megoldas.termekek.Add(uj.UjTermek());
                termekekLBX.Items.Refresh();
                megoldas.evek = megoldas.termekek.Select(x => x.Ev).Distinct().ToList();
                FajlIras();
                listaOldalBTN.IsEnabled = statisztikaBTN.IsEnabled = keszitokBTN.IsEnabled = true;
                stackPanel.Children.Clear();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FajlIras();
            this.Close();
        }

        private void torlesBTN_Click(object sender, RoutedEventArgs e)
        {
            Termek torles = termekekLBX.SelectedItem as Termek;
            MessageBoxResult result = MessageBox.Show("Biztos törölni szeretné a listában a kiválasztott terméket?", "Törlés", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                megoldas.termekek.Remove(torles);
                termekekLBX.Items.Refresh();
                FajlIras();
            }
        }

        private void keszitokBTN_Click(object sender, RoutedEventArgs e)
        {
            keszitokOldal_Build();
            stackPanel.Children.Clear();
            statisztikaBTN.IsEnabled = listaOldalBTN.IsEnabled = true;
        }

        private void statisztikaBTN_Click(object sender, RoutedEventArgs e)
        {
            statisztikaOldalBuild();
            listaOldalBTN.IsEnabled = keszitokBTN.IsEnabled = true;
        }

        private void FajlIras()
        {
            try
            {
                StreamWriter sw = new StreamWriter("termekek.txt");
                sw.WriteLine("Ev;Datum;Termek;Ar(forintban)");
                foreach (var termek in megoldas.termekek)
                {
                    sw.WriteLine($"{termek.Ev};{termek.Idopont:MM-dd};{termek.Nev};{termek.Ar}");
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

            ComboBox cmbbxStat1 = new ComboBox(); ComboBox cmbbxStat2 = new ComboBox();
            Label lbl3 = new Label(); Label lbl4 = new Label(); Label lbl5 = new Label();
            CheckBox ckbx1 = new CheckBox(); CheckBox ckbx2 = new CheckBox();


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

            stackPanel.Children.Add(bezarBtn);

            lb1.Content = "Válasszon évet:";
            cmbbx1.ItemsSource = megoldas.evek;
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
            dp2.Margin = new Thickness(0, 10, 0, 0);

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

        private void statisztikaOldalBuild()
        {
            mainGrid.Children.Clear();
            stackPanel.Children.Clear();
            dp1.Children.Clear();
            dp2.Children.Clear();
            dp3.Children.Clear();
            statisztikaBTN.IsEnabled = false;
            bezarBtn.Margin = new Thickness(20);
            bezarBtn.Height = 20;
            bezarBtn.Width = 20;
            bezarBtn.Content = "x";
            bezarBtn.HorizontalAlignment = HorizontalAlignment.Right;

            stackPanel.Children.Add(bezarBtn);

            lb1.Content = "Válasszon évet:";
            lb1.Width = 200;
            cmbbxStat1.HorizontalAlignment = HorizontalAlignment.Left;
            cmbbxStat1.ItemsSource = megoldas.evek;
            cmbbxStat1.Width = 150;
            cmbbxStat1.SelectedIndex = 0;
            cmbbxStat1.IsEnabled = false;
            cmbbxStat1.SelectionChanged += cmbbxStat1_SelectionChanged;
            ckbx1.IsChecked = false;
            ckbx1.Checked += checkBox1_Checked;
            ckbx1.Unchecked += checkBox1_Unchecked;
            dp1.Children.Add(lb1);
            dp1.Children.Add(cmbbxStat1);
            dp1.Children.Add(ckbx1);

            stackPanel.Children.Add(dp1);

            lbl2.Content = "Válasszon honapot:";
            lbl2.Width = 200;
            cmbbxStat2.HorizontalAlignment = HorizontalAlignment.Left;
            cmbbxStat2.ItemsSource = megoldas.honapok;
            cmbbxStat2.Width = 150;
            cmbbxStat2.SelectedIndex = 0;
            cmbbxStat2.IsEnabled = false;
            cmbbxStat2.SelectionChanged += cmbbxStat2_SelectionChanged;
            ckbx2.Checked += checkBox2_Checked;
            ckbx2.Unchecked += checkBox2_Unchecked;
            ckbx2.IsChecked = false;
            dp2.Children.Add(lbl2);
            dp2.Children.Add(cmbbxStat2);
            dp2.Children.Add(ckbx2);
            dp2.Margin = new Thickness(0, 10, 0, 0);

            stackPanel.Children.Add(dp2);

            termekekLBX.ItemsSource = megoldas.termekek;
            termekekLBX.Height = 200;
            termekekLBX.Margin = new Thickness(20);

            stackPanel.Children.Add(termekekLBX);

            lbl3.Content = "A költekezés mértéke(Ft): 0";
            lbl3.Width = 500;
            lbl3.HorizontalAlignment = HorizontalAlignment.Left;
            stackPanel.Children.Add(lbl3);
            lbl4.Content = "Vásárolt termékek mennyisége: 0";
            lbl4.Width = 400;
            lbl4.HorizontalAlignment = HorizontalAlignment.Left;
            lbl4.Margin = new Thickness(0, 10, 0, 0);
            stackPanel.Children.Add(lbl4);
            lbl5.Content = "Átlag költekezés(Ft): NaN";
            lbl5.Width = 500;
            lbl5.HorizontalAlignment = HorizontalAlignment.Left;
            lbl5.Margin = new Thickness(0, 10, 0, 0);
            stackPanel.Children.Add(lbl5);

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

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            kivalasztottTermek.Clear();
            cmbbxStat1.IsEnabled = true;
            if (ckbx2.IsChecked == false)
            {
                evKivalasztottTermekFeltolt();
            }
            else
            {
                osszesKivalasztottTermekFeltolt();
            }
            StatisztikaMegjelenítése();
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            kivalasztottTermek.Clear();
            cmbbxStat2.IsEnabled = true;
            if (ckbx1.IsChecked == false)
            {
                honapKivalasztottTermekFeltolt();
            }
            else
            {
                osszesKivalasztottTermekFeltolt();
            }
            StatisztikaMegjelenítése();
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            kivalasztottTermek.Clear();
            cmbbxStat1.IsEnabled = false;
            if (ckbx2.IsChecked == true)
            {
                honapKivalasztottTermekFeltolt();
            }
            StatisztikaMegjelenítése();
        }

        private void checkBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            kivalasztottTermek.Clear();
            cmbbxStat2.IsEnabled = false;
            if (ckbx1.IsChecked == true)
            {
                evKivalasztottTermekFeltolt();
            }
            StatisztikaMegjelenítése();
        }

        private void cmbbxStat1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kivalasztottTermek.Clear();
            if (cmbbxStat2.IsEnabled == false)
            {
                evKivalasztottTermekFeltolt();
            }
            else
            {
                osszesKivalasztottTermekFeltolt();
            }
            StatisztikaMegjelenítése();
        }

        private void cmbbxStat2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kivalasztottTermek.Clear();
            if (cmbbxStat1.IsEnabled == false)
            {
                honapKivalasztottTermekFeltolt();
            }
            else
            {
                osszesKivalasztottTermekFeltolt();
            }
            StatisztikaMegjelenítése();
        }

        private void evKivalasztottTermekFeltolt()
        {
            string selected = cmbbxStat1.SelectedItem.ToString();
            foreach (var termek in megoldas.termekek)
            {
                if (termek.Ev == selected)
                {
                    kivalasztottTermek.Add(termek);
                }
            }
        }

        private void honapKivalasztottTermekFeltolt()
        {
            int selected = cmbbxStat2.SelectedIndex + 1;
            foreach (var termek in megoldas.termekek)
            {
                if (termek.Idopont.Month == selected)
                {
                    kivalasztottTermek.Add(termek);
                }
            }
        }

        private void osszesKivalasztottTermekFeltolt()
        {
            string selectedEv = cmbbxStat1.SelectedItem.ToString();
            int selectedMonth = cmbbxStat2.SelectedIndex + 1;
            foreach (var termek in megoldas.termekek)
            {
                if (termek.Ev == selectedEv && termek.Idopont.Month == selectedMonth)
                {
                    kivalasztottTermek.Add(termek);
                }
            }
        }

        private void StatisztikaMegjelenítése()
        {
            termekekLBX.ItemsSource = kivalasztottTermek;
            int koltekezes = 0;
            foreach (var termek in kivalasztottTermek)
            {
                koltekezes += termek.Ar;
            }

            lbl3.Content = $"A költekezés mértéke(Ft): {koltekezes}";
            lbl4.Content = $"Vásárolt termékek mennyisége: {kivalasztottTermek.Count()}";
            lbl5.Content = $"Átlag költekezés(Ft): {((kivalasztottTermek.Count() == 0) ? "NaN" : koltekezes / kivalasztottTermek.Count())}";
            termekekLBX.Items.Refresh();
        }
    }
}
