using System;
using System.Collections.Generic;
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
        }

        private void alapOldalBTN_Click(object sender, RoutedEventArgs e)
        {
            alapOldalBuild();
        }

        private void bezarBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void alapOldalBuild()
        {
            mainGrid.Children.Clear();
            StackPanel stackPanel = new StackPanel();
            Button bezarBtn = new Button(); bezarBtn.Margin = new Thickness(20); bezarBtn.Height = 20; bezarBtn.Width = 20; bezarBtn.Content = "x"; bezarBtn.HorizontalAlignment = HorizontalAlignment.Right; bezarBtn.Click += bezarBTN_Click; stackPanel.Children.Add(bezarBtn);
            DockPanel dp1 = new DockPanel(); Label lb1 = new Label(); lb1.Content = "Válasszon hónapot"; ComboBox cmbbx1 = new ComboBox(); cmbbx1.Width = 300; dp1.Children.Add(lb1); dp1.Children.Add(cmbbx1); stackPanel.Children.Add(dp1);
            DockPanel dp2 = new DockPanel(); Label lbl2 = new Label(); lbl2.Content = "Rendezés szerint:"; ComboBox cmbbx2 = new ComboBox(); cmbbx2.Width = 200; Button btn2 = new Button(); btn2.Width = 20; btn2.Content = "ˇ^"; dp2.Children.Add(lbl2); dp2.Children.Add(cmbbx2); dp2.Children.Add(btn2); stackPanel.Children.Add(dp2);
            ListBox lbx = new ListBox(); lbx.ItemsSource = "{Binding termekek}"; lbx.Height = 300; lbx.Margin = new Thickness(20); stackPanel.Children.Add(lbx);
            DockPanel dp3 = new DockPanel(); Button btn31 = new Button(); Button btn32 = new Button(); btn32.Height = btn31.Height = 40; btn31.IsEnabled = btn32.IsEnabled = false; btn31.Content = "Tárgy módosítása"; btn32.Content = "Tárgy törlése"; dp3.Children.Add(btn31); dp3.Children.Add(btn32); stackPanel.Children.Add(dp3);
            mainGrid.Children.Add(stackPanel);
        }
    }
}
