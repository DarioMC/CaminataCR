using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace AdminPlataforma
{
    public partial class UAAgregarAdmins : Form
    {
        public UAAgregarAdmins()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonInicioSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha = this.dateTimePickerFechaNac.Value.ToString("yyyy-MM-dd");
                Procedimientos.getInstance().AgregarAdministrador(
                    this.textBoxUsuario.Text, this.textBoxContrasena.Text,
                    this.textBoxNombre.Text, this.textBoxPrimerApellido.Text,
                    this.textBoxSegundoApellido.Text, fecha,
                    this.textBoxCedula.Text);
                MessageBox.Show("Usuario Creado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
