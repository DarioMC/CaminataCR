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
    public partial class UICTEditarUsuario : Form
    {
        UsuarioICT admin;

        public UICTEditarUsuario(UsuarioICT adminEditar)
        {
            InitializeComponent();
            admin = adminEditar; 
            this.textBoxNombre.Text = admin.primerNombre;
            this.textBoxCedula.Text = admin.cedula;
            this.textBoxPrimerApellido.Text = admin.primerApellido;
            this.textBoxUsuario.Text = admin.alias;
            this.dateTimePickerFechaNac.Value = admin.fechaNac;
        }

        private void UICTEditarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void buttonRegistrarUsuarioICT_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha = this.dateTimePickerFechaNac.Value.ToString("yyyy-MM-dd");
                admin.primerNombre = this.textBoxNombre.Text;
                admin.cedula = this.textBoxCedula.Text;
                admin.primerApellido = this.textBoxPrimerApellido.Text;
                admin.fechaNac = this.dateTimePickerFechaNac.Value;
                admin.contrasena = textBoxContrasena.Text;

                ContrasenaEncriptada contrasenaEncriptada;
                contrasenaEncriptada = new ContrasenaEncriptada(admin.contrasena);
                admin.contrasena = contrasenaEncriptada.getContrasenaEncriptadaTira();

                SesionActual.getInstance().modUsuariosICT.editarUsuarioICT(admin);
                MessageBox.Show("Usuario Editado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
