using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPrecentacion
{
    public partial class trip : Form
    {

        public trip()
        {
            InitializeComponent();
        }

        N_Bus n_Bus = new N_Bus();
        private void trip_Load(object sender, EventArgs e)
        {
            show("");
            combos();
            table();

        }

        public void show(string buscar)
        {
            dataGridView1.DataSource = n_Bus.showingTrip(buscar);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void combos()
        {

            comboBox2.DataSource = n_Bus.comboBus();
            comboBox2.DisplayMember = "Marca";
            comboBox2.ValueMember = "idBus";


            comboBox3.DataSource = n_Bus.comboRuta();
            comboBox3.DisplayMember = "Ruta";
            comboBox3.ValueMember = "idRuta";

        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            E_Conductor e_Conductor = new E_Conductor();
            e_Conductor.IdBus = comboBox2.SelectedIndex;
            e_Conductor.IdRuta1 = comboBox3.SelectedIndex;
            e_Conductor.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            comboBox3.Items.RemoveAt(comboBox3.SelectedIndex);
            MessageBox.Show(comboBox3.SelectedIndex.ToString());




            n_Bus.updatingTrip(e_Conductor);
            show("");

        }

        private void comboEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void table()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9 ].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            E_Conductor e_Conductor = new E_Conductor();
            e_Conductor.IdBus = comboBox2.SelectedIndex;
            e_Conductor.IdRuta1 = comboBox3.SelectedIndex;
            e_Conductor.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (comboBox3.SelectedIndex != 0)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value) == Convert.ToInt32(comboBox3.SelectedIndex))
                    {
                        MessageBox.Show("Esta ruta no esta disponible, ya ha sido asignada ");
                        break;
                    }
                    else
                    {
                        n_Bus.updatingTrip(e_Conductor);
                        show("");
                    }
                }
                else
                {
                    e_Conductor.IdRuta1 = 0;
                    n_Bus.updatingTrip(e_Conductor);
                    show("");
                }

            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (comboBox2.SelectedIndex != 0)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value) == Convert.ToInt32(comboBox2.SelectedIndex))
                    {
                        MessageBox.Show("Bus no disponible, ya ha sido asignado ");
                        break;
                    }
                    else
                    {
                        n_Bus.updatingTrip(e_Conductor);
                        show("");
                    }
                }
                else
                {
                    e_Conductor.IdBus = 0;
                    n_Bus.updatingTrip(e_Conductor);
                    show("");
                }

            }



        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
