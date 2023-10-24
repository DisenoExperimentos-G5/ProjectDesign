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
using System.Windows.Shapes;
using Entidades;
using Datos;
using Negocio;
namespace Presentacion1
{
    /// <summary>
    /// Interaction logic for RegistroCargo.xaml
    /// </summary>
    public partial class RegistroCargo : Window
    {
        private nCargo _cargo = new nCargo();
        public RegistroCargo()
        {
            InitializeComponent();
        }

        private void btnRegistrarCargo_Click(object sender, RoutedEventArgs e)
        {
            if (txtCargo.Text != "")
            {
                MessageBox.Show(_cargo.RegistrarCargo(txtCargo.Text));
                txtCargo.Clear();
            }
            else MessageBox.Show("Por favor complete los datos");
        }

        private void txtCargo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
