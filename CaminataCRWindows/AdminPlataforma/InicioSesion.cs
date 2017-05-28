using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace AdminPlataforma
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
            initFont();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void initFont()
        {
            //Create your private font collection object.
            PrivateFontCollection pfc = new PrivateFontCollection();

            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            int fontLength = Properties.Resources.HelveticaLTStd_Light.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.HelveticaLTStd_Light;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

            // free up the unsafe memory
            Marshal.FreeCoTaskMem(data);
        }

        private void textBoxContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonInicioSesion_Click(object sender, EventArgs e)
        {
            try
            {
                SesionActual.getInstance().iniciarSesion(this.textBoxUsuario.Text, this.textBoxContrasena.Text);
                this.Hide();
                PanelControl window = new PanelControl();
                window.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void linkLabelRegistrarNuevoUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            UAAgregarAdmins window = new UAAgregarAdmins();
            window.ShowDialog();
            this.Show();
        }

        private void buttonProbar_Click(object sender, EventArgs e)
        {
            ContrasenaEncriptada contrasenaEncriptada;
            contrasenaEncriptada = new ContrasenaEncriptada("123");//ContrasenaEncriptada contrasena = new Cons
            MessageBox.Show(contrasenaEncriptada.getContrasenaEncriptadaTira());
        }
    }
}
