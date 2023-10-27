using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;
using Datos;
namespace Presentacion1
{
    public partial class RegistrarControlHoras1 : Form
    {
        private nTrabajador gtrabajador = new nTrabajador();
        private nControlHoras gControlHoras = new nControlHoras();
        private nAusencias gAusencias = new nAusencias();
        eTrabajador trabajador = null;
        public RegistrarControlHoras1()
        {
            InitializeComponent();
            mostrartrabajador();
        }
        public void mostrartrabajador()
        {
            cbidTrabajador.DataSource = gtrabajador.listarTrabajadores();
            cbidTrabajador.DisplayMember = "Nombre_Completo";
        }
        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (cbidTrabajador.SelectedIndex != -1 && dateTimePicker1.Text != "" && dateTimePicker2.Text != "" && dateTimePicker3.Text != "" && checkBox1.Checked != true)
            {
                MessageBox.Show(gControlHoras.InsertarControlhoras(trabajador.Id_Trabajador, Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text), Convert.ToDateTime(dateTimePicker3.Text)));
                cbidTrabajador.SelectedIndex = -1;
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
        }

        private void cbidTrabajador_SelectedIndexChanged(object sender, EventArgs e)
        {
            trabajador = cbidTrabajador.SelectedItem as eTrabajador;
        }

        private void RegistrarControlHoras1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else if (checkBox1.Checked == false)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }

        private void btnregistrarAusencia_Click(object sender, EventArgs e)
        {
            if (cbidTrabajador.SelectedIndex != -1 && dateTimePicker3.Text != "" && checkBox1.Checked == true)
            {
                MessageBox.Show(gAusencias.Registrarausencia(Convert.ToDateTime(dateTimePicker3.Text), trabajador.Id_Trabajador));
                cbidTrabajador.SelectedIndex = -1;
            }
            else
                MessageBox.Show("Por favor debe completar todos los datos");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
