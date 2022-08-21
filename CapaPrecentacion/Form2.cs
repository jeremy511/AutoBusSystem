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
    public partial class Form2 : Form
    {
        public Form2()
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
            if (dataGridView1.SelectedRows.Count == 1 && Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) != 0)
            {

                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                AgregarBus bus = new AgregarBus(true,id);
                bus.textMarca.Text= Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
                bus.textModelo.Text=  Convert.ToString(dataGridView1.SelectedRows[0].Cells[2].Value);
                bus.textPlaca.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[3].Value);
                bus.textColor.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[4].Value);
                bus.textAño.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[5].Value);
                bus.Show();
                show("");
            }
            else
            {
                AgregarBus bus = new AgregarBus(false, 0);
                bus.Show();
            }
        }

        private void show(string buscar)
        {
            
            dataGridView1.DataSource = n_Bus.showingBus(buscar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            show(textBox1.Text);
        }

        private void accions()
        {
            dataGridView1.Columns[0].Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            show("");
            accions();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               E_Bus bus = new E_Bus();

                bus.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                n_Bus.deletingBus(bus);
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
