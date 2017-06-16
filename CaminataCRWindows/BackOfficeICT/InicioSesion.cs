using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConexionSQL;
using EntityObjects;
using BusinessLayer;

namespace BackOfficeICT
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void buttonInicioSesion_Click(object sender, EventArgs e)
        {

            //SesionAdministradorActual = new Administrador();
            ContrasenaEncriptada contrasenaEncriptada;
            contrasenaEncriptada = new ContrasenaEncriptada(textBoxContrasena.Text);
            if (conexionSQL.getInstance().loginICT(textBoxUsuario.Text, contrasenaEncriptada.getContrasenaEncriptadaTira()) == 0)
            {
                throw new Exception("contraseña invalida o el usuario no existe");
            }
            else
            {
                this.Hide();
                PanelControl window = new PanelControl();
                window.ShowDialog();
                this.Close();
            }

        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {
            textBoxUsuario.Text = "Dende";
            textBoxContrasena.Text = "123";
        }
    }
}
