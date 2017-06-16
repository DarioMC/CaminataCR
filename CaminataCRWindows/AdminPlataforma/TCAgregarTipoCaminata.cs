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
    public partial class TCAgregarTipoCaminata : Form
    {
        public TCAgregarTipoCaminata()
        {
            InitializeComponent();
        }

        private void buttonAceptarEditarTipoCaminata_Click(object sender, EventArgs e)
        {
            try
            {
                TipoCaminata tipo = new TipoCaminata();
                tipo.descripcion = textBoxDescripcion.Text;
                SesionActual.getInstance().modTipoCaminata.agregarTipo(tipo);
                MessageBox.Show("Dificultad Agregada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
