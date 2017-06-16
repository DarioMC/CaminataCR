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
    public partial class TCEditarTipo : Form
    {
        TipoCaminata actual;
        public TCEditarTipo(TipoCaminata tipo)
        {
            actual = tipo;
            InitializeComponent();
            textBoxDescripcion.Text = tipo.descripcion;
        }

        private void buttonAceptarEditarTipoCaminata_Click(object sender, EventArgs e)
        {
            try
            {
                actual.descripcion = textBoxDescripcion.Text;
                SesionActual.getInstance().modTipoCaminata.editarTipo(actual);

                MessageBox.Show("Tipo Editado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
