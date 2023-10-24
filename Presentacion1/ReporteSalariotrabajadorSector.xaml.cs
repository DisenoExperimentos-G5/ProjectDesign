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
using Datos;
namespace Presentacion1
{
    /// <summary>
    /// Interaction logic for ReporteSalariotrabajadorSector.xaml
    /// </summary>
    public partial class ReporteSalariotrabajadorSector : Window
    {
        private nSector gsector = new nSector();
        private nTrabajador gtrabajador = new nTrabajador();
        eSector sector = null;
        public ReporteSalariotrabajadorSector()
        {
            InitializeComponent();
            Mostrarid();
        }
        public void Mostrarid()
        {
            cbidsector.ItemsSource = gsector.listarsectores();
        }
        public void MostrarSalarios()
        {
            dgSalario.ItemsSource = gtrabajador.Listar_salario_sector_trabajador(sector.Id_Sector);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbidsector.SelectedIndex != -1)
            {
                MostrarSalarios();
            }
            else MessageBox.Show("Sellecione ID");
        }

        private void cbidsector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sector = cbidsector.SelectedItem as eSector;
        }

        private void dgSalario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
