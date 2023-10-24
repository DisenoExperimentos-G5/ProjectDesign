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
    /// Interaction logic for RegistrarContolHoras.xaml
    /// </summary>
    public partial class RegistrarContolHoras : Window
    {
        private nTrabajador gtrabajador = new nTrabajador();
        private nControlHoras gControlHoras = new nControlHoras();
        eTrabajador trabajador = null;
        public RegistrarContolHoras()
        {
            InitializeComponent();
            mostrartrabajador();
        }
        public void mostrartrabajador()
        {
            cbIdTrabajador.ItemsSource = gtrabajador.listarTrabajadores();
        }
        private void btnRegistrarControlHoras_Click(object sender, RoutedEventArgs e)
        {
            if(cbIdTrabajador.SelectedIndex != -1 && dpHoraIngreso.Text != "" && dpHoraSalida.Text != "" && dpHoraRegistro.Text != "" && chbAusencia.IsChecked != true)
            {
                MessageBox.Show(gControlHoras.InsertarControlhoras(trabajador.Id_Trabajador, Convert.ToDateTime(dpHoraIngreso.Text), Convert.ToDateTime(dpHoraSalida.Text), Convert.ToDateTime(dpHoraRegistro.Text)));
                cbIdTrabajador.SelectedIndex = -1;
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
        }

        private void cbIdTrabajador_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            trabajador = cbIdTrabajador.SelectedItem as eTrabajador;
        }
    }
}
