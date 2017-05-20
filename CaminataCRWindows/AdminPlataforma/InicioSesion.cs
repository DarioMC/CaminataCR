using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminPlataforma
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonInicioSesion_Click(object sender, EventArgs e)
        {
            //if (a == 1)
            //{
                //usuario = this.textBoxUsuario.Text;
                //MessageBox.Show("Exito", "Some title", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Hide();
                PanelControl window = new PanelControl();
                window.ShowDialog();
                this.Close();
            //}
            //else if (a == 0)
            //{
               // MessageBox.Show("No corresponde a ningun usuario o contrasena", "Some title", MessageBoxButtons.OK, MessageBoxIcon.Error);
           // }
        }
    }
}
