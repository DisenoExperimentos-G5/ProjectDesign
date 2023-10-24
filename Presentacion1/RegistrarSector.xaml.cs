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
using Negocio;
namespace Presentacion1
{
    /// <summary>
    /// Interaction logic for RegistrarSector.xaml
    /// </summary>
    public partial class RegistrarSector : Window
    {
        private nSector _sector = new nSector();
        public RegistrarSector()
        {
            InitializeComponent();
        }

        private void btregistrarsector_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreSector.Text != "" && txtUbicacionPlanta.Text != "")
            {
                MessageBox.Show(_sector.RegistraSector(txtNombreSector.Text, txtUbicacionPlanta.Text));
                txtNombreSector.Clear();
                txtUbicacionPlanta.Clear();
            }
            else MessageBox.Show("Por favor complete los datos");
            txtNombreSector.Focus();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
