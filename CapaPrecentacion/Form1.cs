using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPrecentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            EmpleadoForm empleado = new EmpleadoForm();
            empleado.Show();
        }

        private void Transporte_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void ruta_Click(object sender, EventArgs e)
        {
            rutasForm rutas = new rutasForm();
            rutas.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            trip tr = new trip();
            tr.Show();
        }
    }
}
