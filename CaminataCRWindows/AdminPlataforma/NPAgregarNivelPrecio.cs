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
    public partial class NPAgregarNivelPrecio : Form
    {

        NivelPrecio nivel = new NivelPrecio();

        
        public NPAgregarNivelPrecio()
        {
            InitializeComponent();
        }

        private void buttonAceptarEditarDificultad_Click(object sender, EventArgs e)
        {
            try
            {
                nivel.descripcion = textBoxDescripcion.Text;
                SesionActual.getInstance().modNivPrecio.agregaNivelPrecio(nivel);
                MessageBox.Show("Nivel Precio Agregado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
