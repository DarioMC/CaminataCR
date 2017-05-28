using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackOfficeICT
{
    public partial class PanelControl : Form
    {
        public PanelControl()
        {
            InitializeComponent();
        }

        private void buttonTabUsuariosAportes_Click(object sender, EventArgs e)
        {
            tabControlPaginas.SelectTab(0);
        }

        private void buttonTabGustosRutas_Click(object sender, EventArgs e)
        {
            tabControlPaginas.SelectTab(1);
        }

        private void buttonTabClasfRutas_Click(object sender, EventArgs e)
        {
            tabControlPaginas.SelectTab(2);
        }

        private void buttonTabReportRemuneraciones_Click(object sender, EventArgs e)
        {
            tabControlPaginas.SelectTab(3);
        }

        private void buttonAgregarAdmins_Click(object sender, EventArgs e)
        {

        }
    }
}
