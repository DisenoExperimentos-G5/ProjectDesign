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
    /// Interaction logic for trabajadoresconmenoshorastrabajadas.xaml
    /// </summary>
    public partial class trabajadoresconmenoshorastrabajadas : Window
    {
        private nControlHoras gcontrolhoras = new nControlHoras();
        public trabajadoresconmenoshorastrabajadas()
        {
            InitializeComponent();
            Mostrar();
        }
        public void Mostrar()
        {
            dbMenoshoras.ItemsSource = gcontrolhoras.ListarTrabajadoresConMenoshorasTrabajadas();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
