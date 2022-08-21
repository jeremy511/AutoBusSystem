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
    public partial class AgregarEmpleado : Form
    {

        bool editar = false;
        int id;
        public AgregarEmpleado(bool editar, int id)
        {
            InitializeComponent();
            this.editar = editar;
            this.id = id;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            E_Conductor e_Conductor = new E_Conductor();
            N_Bus n_Bus = new N_Bus();

            if (editar == true)
            {
                try
                {
                    e_Conductor.Id = id;
                    e_Conductor.Nombre = textNombre.Text;
                    e_Conductor.Apellido = textApe.Text;
                    e_Conductor.Cedula = textCedula.Text;
                    e_Conductor.Fecha = bunifuDatepicker1.Value;

                    n_Bus.updatingDriver(e_Conductor);
                    MessageBox.Show("Datos Editados correctamente!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar los datos" + ex);
                }
            }
            else
            {
                try
                {
                  

                    e_Conductor.Nombre = textNombre.Text.Trim();
                    e_Conductor.Apellido = textApe.Text.Trim();
                    e_Conductor.Cedula = textCedula.Text.Trim();
                    e_Conductor.Fecha = bunifuDatepicker1.Value;
                    e_Conductor.IdRuta1 = 0;
                    e_Conductor.IdBus = 0;

                    n_Bus.insertingDrivers(e_Conductor);
                    MessageBox.Show("Datos guardados correctamente!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar los datos" + ex);
                }
            }
        }

        private void AgregarEmpleado_Load(object sender, EventArgs e)
        {
            
        }
    }
}
