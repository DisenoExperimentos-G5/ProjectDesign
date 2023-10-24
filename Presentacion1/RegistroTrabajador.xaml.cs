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
    /// Interaction logic for RegistroTrabajador.xaml
    /// </summary>
    public partial class RegistroTrabajador : Window
    {
        private nCargo gcargo = new nCargo();
        private nSector gsector = new nSector();
        private nTrabajador gtrabajador = new nTrabajador();
        eCargo cargo = null;
        eSector sector = null;
        eTrabajador trabajador = null;

        int idTrabajador;

        public RegistroTrabajador()
        {
            InitializeComponent();
            MostrarSectore();
            MostrarCargos();
            MostrarTrabajador();
        }
        private void MostrarTrabajador()
        {
            dgTrabajadores.ItemsSource = gtrabajador.listarTrabajadores();
        }
        private void MostrarSectore()
        {
            cbSector.ItemsSource = gsector.listarsectores();
            cbSector.Text = "Nombre_sector";
        }
        private void MostrarCargos()
        {
            cbCargo.ItemsSource = gcargo.listarCargos();
        }
    
        public void limpiar()
        {

            txtNombreTrabajador.Clear();
            txtAP.Clear();
            txtAM.Clear();
            txtDni.Clear();
            txtSalario.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtAñosEmpres.Clear();
            cbCargo.SelectedIndex = -1;
            cbSector.SelectedIndex = -1;

        }
        private void btnRegistrarTrabajador_Click(object sender, RoutedEventArgs e)
        {
            if(txtNombreTrabajador.Text != "" && txtAP.Text != "" && txtAM.Text != "" && txtDni.Text != "" && dtpFechaNacimiento.Text != "" && 
                txtSalario.Text != "" && txtTelefono.Text != "" && txtDireccion.Text !="" && txtAñosEmpres.Text !="" && cbCargo.SelectedIndex != -1 && cbSector.SelectedIndex != -1)
            {
                MessageBox.Show(gtrabajador.RegistrarTrabajador(txtNombreTrabajador.Text, txtAP.Text, txtAM.Text,Convert.ToInt32(txtDni.Text), Convert.ToDateTime(dtpFechaNacimiento.Text), Convert.ToInt32(txtSalario.Text)
                , Convert.ToInt32(txtTelefono.Text),txtDireccion.Text, Convert.ToInt32(txtAñosEmpres.Text),cargo.Id_Cargo,sector.Id_Sector));
                limpiar();

            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
            txtNombreTrabajador.Focus();
        }

        private void cbCargo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cargo = cbCargo.SelectedItem as eCargo;
        }
        
        private void cbSector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sector = cbSector.SelectedItem as eSector;
        }


   
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (trabajador != null)
            {
                MessageBox.Show(gtrabajador.EliminarTrabajador(trabajador.Id_Trabajador));
                MostrarTrabajador();
            }
            else
                MessageBox.Show("Por favor debe seleccionar un trabajador de la lista");
            txtNombreTrabajador.Focus();
        }

        private void dgTrabajadores_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            trabajador = dgTrabajadores.SelectedItem as eTrabajador;

            if (trabajador != null)
            {
                idTrabajador = trabajador.Id_Trabajador;
                txtNombreTrabajador.Text = trabajador.Nombres;
                txtAP.Text = trabajador.Apellido_Paterno;
                txtAM.Text = trabajador.Apellido_Materno;
                txtDni.Text = trabajador.DNI.ToString();
                txtSalario.Text = trabajador.Salario.ToString();
                txtTelefono.Text = trabajador.Telefono.ToString();
                txtDireccion.Text = trabajador.Direccion;
                txtAñosEmpres.Text = trabajador.AnhoIngreso.ToString();

            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
