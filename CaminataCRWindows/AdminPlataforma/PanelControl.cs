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
    public partial class PanelControl : Form
    {
        public PanelControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControlPaginas.SelectTab(2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControlPaginas.SelectTab(2);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tabControlPaginas.SelectTab(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControlPaginas.SelectTab(1);
        }

        private void buttonTab3_Click(object sender, EventArgs e)
        {
            tabControlPaginas.SelectTab(3);
        }

        private void buttonTab4_Click(object sender, EventArgs e)
        {
            tabControlPaginas.SelectTab(4);
        }

        private void buttonTab5_Click(object sender, EventArgs e)
        {
            tabControlPaginas.SelectTab(5);
        }

        private void buttonTab6_Click(object sender, EventArgs e)
        {
            tabControlPaginas.SelectTab(6);
        }

        private void buttonCargaDatos_Click(object sender, EventArgs e)
        {

            ListViewItem linea = new ListViewItem("Emmanuel Perez");
            linea.SubItems.Add("H4Xor");
            listViewUsuariosAdministradores.Items.Add(linea);
            /*
            foreach (PlatilloCuenta platilloCuenta in FrVerMenuOrdenar.cuenta)
            {
                ListViewItem linea = new ListViewItem(platilloCuenta.platoNombre);
                linea.SubItems.Add(platilloCuenta.usuario);
                linea.SubItems.Add(platilloCuenta.precio.ToString());
                listViewReporteCliente.Items.Add(linea);
            }
            */
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
