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
    /// Interaction logic for ReporteSector_mayor_ausencias.xaml
    /// </summary>
    public partial class ReporteSector_mayor_ausencias : Window
    {
        private nSector g_sector = new nSector();
        public ReporteSector_mayor_ausencias()
        {
            InitializeComponent();
            mostrarSectores_Mayores_Ausencias();
        }
        public void mostrarSectores_Mayores_Ausencias()
        {
            dgausencias.ItemsSource = g_sector.listarsectormayoresausencias();
        }
        private void dgausencias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
