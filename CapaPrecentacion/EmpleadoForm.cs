using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace CapaPrecentacion
{
    public partial class EmpleadoForm : Form
    {
        public EmpleadoForm()
        {
            InitializeComponent();
        }

        N_Bus n_Bus = new N_Bus();

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1 && Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) != 0)
            {

                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                AgregarEmpleado agregarEmpleado = new AgregarEmpleado(true,id);
                agregarEmpleado.textNombre.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                agregarEmpleado.textApe.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                agregarEmpleado.textCedula.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
 
                agregarEmpleado.Show();
                show("");
            }
            else
            {
                AgregarEmpleado agregarEmpleado = new AgregarEmpleado(false,0);
                agregarEmpleado.Show();

            }
        }

        private void show(string buscar)
        {
           dataGridView1.DataSource = n_Bus.showingDrivers(buscar);
        }

        private void EmpleadoForm_Load(object sender, EventArgs e)
        {
            show("");
            actions();
        }

        private void actions()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            show(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                E_Conductor e_Conductor = new E_Conductor();
                
                e_Conductor.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                n_Bus.deletingDriver(e_Conductor);
                MessageBox.Show("Registro eliminado correctamente");
                show("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("eRROR al eliminar" + ex);
            }
        }
    }
}
