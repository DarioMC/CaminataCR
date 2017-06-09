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
    public partial class NDAgregarNivelDificultad : Form
    {
        Dificultad dificultad = new Dificultad();

        public NDAgregarNivelDificultad()
        {
            InitializeComponent();
        }

        private void buttonAceptarEditarDificultad_Click(object sender, EventArgs e)
        {
            try
            {
                dificultad.descripcion = textBoxDescripcion.Text;
                SesionActual.getInstance().modNivDificultad.agregarNivel(dificultad);
                MessageBox.Show("Dificultad Editada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
