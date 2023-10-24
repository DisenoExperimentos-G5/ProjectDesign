using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentacion1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btIniciar_Click(object sender, RoutedEventArgs e)
        {
            if (usernametext.Text == "admin" && passwordtext.Text == "admin")
            {
                RegistrosyReportes ryp = new RegistrosyReportes();
                ryp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ingrese los datos correctamente");
            }
        }

        private void passwordtext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
