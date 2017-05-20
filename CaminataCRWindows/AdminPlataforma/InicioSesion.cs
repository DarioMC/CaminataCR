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
            initFont();
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
