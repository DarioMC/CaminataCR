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
           listViewUsuariosAdministradores.Items.Clear();
           // carga los admins otra vez (por si hay cambios)
           SesionActual.getInstance().modUsuariosAdministrador.cargarAdministradores();
            foreach (Administrador admin in SesionActual.getInstance().modUsuariosAdministrador.listaAdministradores)
            {
                ListViewItem linea = new ListViewItem(admin.primerNombre);
                linea.SubItems.Add(admin.alias);
                listViewUsuariosAdministradores.Items.Add(linea);
            }
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

        private void PanelControl_Load(object sender, EventArgs e)
        {

        }



        private void labelCloseButton_Click_1(object sender, EventArgs e)
        {
            if (Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                Environment.Exit(1);
            }
        }

        private void labelCloseButton_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void labelMinimiza_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void labelMinimiza_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void labelMinimiza_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void labelCloseButton_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void buttonAgregarAdmins_Click(object sender, EventArgs e)
        {
            this.Hide();
            UAAgregarAdmins window = new UAAgregarAdmins();
            window.ShowDialog();
            this.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditarAdmins_Click(object sender, EventArgs e)
        {

            int indexAdminListView = listViewUsuariosAdministradores.SelectedIndices[0];
            MessageBox.Show("Index: " + indexAdminListView.ToString());

            Administrador admin = SesionActual.getInstance().modUsuariosAdministrador.listaAdministradores[indexAdminListView];
            SesionActual.getInstance().modUsuariosAdministrador.listaAdministradores.RemoveAt(indexAdminListView);
            SesionActual.getInstance().modUsuariosAdministrador.borrarAdministrador(admin);
            MessageBox.Show("Usuario: " + admin.alias);


            this.Hide();
            UAAgregarAdmins window = new UAAgregarAdmins(admin);
            window.ShowDialog();
            this.Show();



            /*
                Restaurante restaurante = restauranteListas[restauranteIndexDetalles];
                labelTipo.Text = restaurante.Tipo;
                FrAdminRest.restauranteActualID = restaurante.IdRestaurante;
                //int temp = restaurante.IdRestaurante;
                MemoryStream mem = new MemoryStream(restaurante.Foto);      // carga la imagen restaurante.foto es un byte[]
                pictureBox1.Image = Image.FromStream(mem);
                */
        }

        private void buttonEliminarAdmins_Click(object sender, EventArgs e)
        {
            int indexAdminListView = listViewUsuariosAdministradores.SelectedIndices[0];

            Administrador admin = SesionActual.getInstance().modUsuariosAdministrador.listaAdministradores[indexAdminListView];
            SesionActual.getInstance().modUsuariosAdministrador.listaAdministradores.RemoveAt(indexAdminListView);
            SesionActual.getInstance().modUsuariosAdministrador.borrarAdministrador(admin);

            MessageBox.Show("Index: " + indexAdminListView.ToString() + " Usuario: " + admin.alias);
        }

        private void buttonCargaDatosUICT_Click(object sender, EventArgs e)
        {
            listViewUsuariosICT.Items.Clear();
            foreach (UsuarioICT usuario in SesionActual.getInstance().modUsuariosICT.listaUsuarios)
            {
                ListViewItem linea = new ListViewItem(usuario.alias);
                linea.SubItems.Add(usuario.primerNombre);
                listViewUsuariosICT.Items.Add(linea);
            }
        }

        private void buttonAgregarUsuariosICT_Click(object sender, EventArgs e)
        {
            this.Hide();
            UICTAgregarUsuario window = new UICTAgregarUsuario();
            window.ShowDialog();
            this.Show();
        }

        private void buttonDesactivarAdmins_Click(object sender, EventArgs e)
        {
            // esta lineas asocian el administrador en memoria con el listview
            int index = listViewUsuariosAdministradores.SelectedIndices[0];
            Administrador admin = SesionActual.getInstance().modUsuariosAdministrador.listaAdministradores[index];
            SesionActual.getInstance().modUsuariosAdministrador.listaAdministradores.RemoveAt(index);
            SesionActual.getInstance().modUsuariosAdministrador.borrarAdministrador(admin);

        }

        private void buttonEliminarUsuariosICT_Click(object sender, EventArgs e)
        {
            int index = listViewUsuariosICT.SelectedIndices[0];

            UsuarioICT usuario = SesionActual.getInstance().modUsuariosICT.listaUsuarios[index];
            SesionActual.getInstance().modUsuariosICT.listaUsuarios.RemoveAt(index);
            SesionActual.getInstance().modUsuariosICT.borrarUsuarioICT(usuario);
        }

        private void buttonCargaDatosNivelesDificultad_Click(object sender, EventArgs e)
        {

        }
    }
    
}
