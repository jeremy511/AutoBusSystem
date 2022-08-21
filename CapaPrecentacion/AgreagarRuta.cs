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
    public partial class AgreagarRuta : Form
    {
        public bool editar = false;
        public int id;
        public AgreagarRuta(bool editar,int id)
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
            
            
            N_Bus n_Bus = new N_Bus();
            E_Ruta e_Ruta = new E_Ruta();


          if (editar == true)
            {
                try
                {
                    e_Ruta.Ruta = textRuta.Text.Trim();
                    e_Ruta.Id = id;
                    n_Bus.updatingRoute(e_Ruta);
                    MessageBox.Show("Datos editados correctamente");
                    this.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al editar registro" + ex);
                }
            }
          else
            {
                try
                {
                    e_Ruta.Ruta = textRuta.Text.Trim();
                    n_Bus.insertingRoutes(e_Ruta);
                    MessageBox.Show("Datos guardados correctamente");
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar los datos" + ex);
                }
            }
        }
    }
}
