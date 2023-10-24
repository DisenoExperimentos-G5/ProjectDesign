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

namespace Presentacion1
{
    /// <summary>
    /// Interaction logic for RegistrosyReportes.xaml
    /// </summary>
    public partial class RegistrosyReportes : Window
    {
        public RegistrosyReportes()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrarSector rS = new RegistrarSector();
            rS.ShowDialog();
        }

        private void btnRegistroCargo_Click(object sender, RoutedEventArgs e)
        {
            RegistroCargo cargo = new RegistroCargo();
            cargo.ShowDialog();
        }

        private void btnRegistroTrabajador_Click(object sender, RoutedEventArgs e)
        {
            RegistroTrabajador registroTrabajador = new RegistroTrabajador();
            registroTrabajador.ShowDialog();
        }

        private void btnRegistroControlhoras_Click(object sender, RoutedEventArgs e)
        {
            RegistrarControlHoras1 registrarControlHoras1 = new RegistrarControlHoras1();
            registrarControlHoras1.ShowDialog();
        }

        private void btnsalarioxsector_Click(object sender, RoutedEventArgs e)
        {
            ReporteSalariotrabajadorSector sector = new ReporteSalariotrabajadorSector();
            sector.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ReporteSector_mayor_ausencias reporteSector_Mayor_Ausencias = new ReporteSector_mayor_ausencias();
            reporteSector_Mayor_Ausencias.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TrabajadoresConMasAusencias trabajadores = new TrabajadoresConMasAusencias();
            trabajadores.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Trabajadoresconmashoras trabajadores1 = new Trabajadoresconmashoras();
            trabajadores1.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            trabajadoresconmenoshorastrabajadas tr = new trabajadoresconmenoshorastrabajadas(); 
            tr.ShowDialog();
        }
    }
}
