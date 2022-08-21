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
    public partial class AgregarBus : Form
    {
        bool editar = false;
        int id;
        public AgregarBus(bool editar,int id)
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
            E_Bus bus = new E_Bus();
            N_Bus n_Bus = new N_Bus();

            if (editar == true)
            {
                try
                {
                    bus.Id = id;
                    bus.Marca = textMarca.Text;
                    bus.Modelo = textModelo.Text;
                    bus.Placa = textPlaca.Text;
                    bus.Color = textColor.Text;
                    bus.Año = textAño.Text;

                    n_Bus.updatingBus(bus);
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

                    bus.Id = id;
                    bus.Marca = textMarca.Text;
                    bus.Modelo = textModelo.Text;
                    bus.Placa = textPlaca.Text;
                    bus.Color = textColor.Text;
                    bus.Año = textAño.Text;

                    n_Bus.insertingBus(bus);
                    MessageBox.Show("Datos guardados correctamente!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar los datos" + ex);
                }
            }
        }
    }
}
