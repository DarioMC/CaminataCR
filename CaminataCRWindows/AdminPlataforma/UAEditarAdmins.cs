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
    public partial class UAEditarAdmins : Form
    {
        Administrador admin;

        public UAEditarAdmins(Administrador adminEditar)
        {
            InitializeComponent();
            admin = adminEditar;
            this.textBoxNombre.Text = admin.primerNombre;
            this.textBoxCedula.Text = admin.cedula;
            this.textBoxPrimerApellido.Text = admin.primerApellido;
            this.textBoxUsuario.Text = admin.alias;
            this.dateTimePickerFechaNac.Value = admin.fechaNac;
        }

        private void buttonRegistrarEditar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = this.dateTimePickerFechaNac.Value;

                admin.contrasena = this.textBoxContrasena.Text;
                admin.primerApellido = this.textBoxPrimerApellido.Text;
                admin.segundoApellido = this.textBoxSegundoApellido.Text;
                admin.primerNombre = this.textBoxNombre.Text;
                admin.fechaNac = fecha;
                admin.cedula = this.textBoxCedula.Text;


                ContrasenaEncriptada contrasenaEncriptada;
                contrasenaEncriptada = new ContrasenaEncriptada(admin.contrasena);
                admin.contrasena = contrasenaEncriptada.getContrasenaEncriptadaTira();

                SesionActual.getInstance().modUsuariosAdministrador.editarAdministrador(admin);
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
