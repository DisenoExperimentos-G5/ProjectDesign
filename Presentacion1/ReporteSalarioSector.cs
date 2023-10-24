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
    public partial class ReporteSalarioSector : Form
    {
        private nSector gsector = new nSector();
        private nTrabajador gtrabajador = new nTrabajador();
        eSector sector = null;
        public ReporteSalarioSector()
        {
            InitializeComponent();
            mostrar();
        }
        public void mostrar()
        {
            comboBox1.DataSource = gsector.listarsectores();
            comboBox1.DisplayMember = "Nombre_Sector";
        }
        private void ReporteSalarioSector_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                //dataGridView1.DataSource = gtrabajador.Listar_salario_sector_trabajador(Convert.ToInt32(comboBox1.Text));
                //listBox1.DataSource = gtrabajador.Listar_salario_sector_trabajador(Int32.Parse(comboBox1.Text));
            }
            else MessageBox.Show("Por favor debe completar todos los datos");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sector = comboBox1.SelectedItem as eSector;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
