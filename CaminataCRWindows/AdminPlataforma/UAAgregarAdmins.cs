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
using EntityObjects;

namespace AdminPlataforma
{
    public partial class UAAgregarAdmins : Form
    {
        public UAAgregarAdmins()
        {
            InitializeComponent();
        }

        public UAAgregarAdmins(Administrador admin)
        {
            InitializeComponent();
            this.textBoxNombre.Text = admin.primerNombre;
            this.textBoxCedula.Text = admin.cedula;
            this.textBoxPrimerApellido.Text = admin.primerApellido;
            this.textBoxUsuario.Text = admin.alias;
            this.dateTimePickerFechaNac.Value = admin.fechaNac;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonRegistrarAdminClick(object sender, EventArgs e)
        {
            try
            {
                string fecha = this.dateTimePickerFechaNac.Value.ToString("yyyy-MM-dd");

                SesionActual.getInstance().modUsuariosAdministrador.agregarAdministrador(
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
