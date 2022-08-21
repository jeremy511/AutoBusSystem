using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPrecentacion
{
    public partial class rutasForm : Form
    {
        public rutasForm()
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
           // AgreagarRuta ruta = new AgreagarRuta(false,0);
            //ruta.Show();
        }

        private void rutasForm_Load(object sender, EventArgs e)
        {
            show("");
            accions();
        }

        private void accions()
        {
            dataGridView2.Columns[0].Visible = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            show(textBox1.Text);
        }
        private void show(string buscar)
        {
            dataGridView2.DataSource = n_Bus.showingRoutes(buscar);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count == 1 && Convert.ToInt32( dataGridView2.SelectedRows[0].Cells[0].Value) != 0)
            {

                int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
                AgreagarRuta agreagarRuta = new AgreagarRuta(true, id);
                agreagarRuta.Show();
                show("");
            }
            else
            {
                AgreagarRuta ruta = new AgreagarRuta(false,0);
                ruta.Show();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            E_Ruta e_Ruta = new E_Ruta();

           try
            {
                e_Ruta.Id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);

                n_Bus.deletingRoutes(e_Ruta);
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
