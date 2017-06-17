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
    public partial class UICTAgregarUsuario : Form
    {
        public UICTAgregarUsuario()
        {
            InitializeComponent();
        }

        private void buttonRegistrarUsuarioICT_Click(object sender, EventArgs e)
        {
            try
            {
                int ced = int.Parse(textBoxCedula.Text);
                string fecha = this.dateTimePickerFechaNac.Value.ToString("yyyy-MM-dd");
                SesionActual.getInstance().modUsuariosICT.agregarUsuarioICT(
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
