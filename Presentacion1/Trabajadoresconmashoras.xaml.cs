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
    /// Interaction logic for Trabajadoresconmashoras.xaml
    /// </summary>
    public partial class Trabajadoresconmashoras : Window
    {
        private nControlHoras horas = new nControlHoras();
        public Trabajadoresconmashoras()
        {
            InitializeComponent();
            Mostrar();
        }
        public void Mostrar()
        {
            dgtrabajadoresmashoras.ItemsSource = horas.ListarTrabajadoresConMashorasTrabajadas();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
