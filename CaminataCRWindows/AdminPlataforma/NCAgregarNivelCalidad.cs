using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityObjects;
using BusinessLayer;

namespace AdminPlataforma
{
    public partial class NCAgregarNivelCalidad : Form
    {
        NivelCalidad nivel = new NivelCalidad();

        public NCAgregarNivelCalidad()
        {
            InitializeComponent();
        }

        private void buttonAceptarEditarNivelCalidad_Click(object sender, EventArgs e)
        {
            try
            {
                nivel.descripcion = textBoxDescripcion.Text;
                SesionActual.getInstance().modNivCalidad.agregaNivelCalidad(nivel);
                MessageBox.Show("Nivel Calidad Agregado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "Some title", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }
    }
}
