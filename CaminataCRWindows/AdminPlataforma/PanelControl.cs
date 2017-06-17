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



        // ------------------------------------------------------- MODULO ADMINISTRADOR -------------------------------------------------------
        // ------------------------------------------------------- MODULO ADMINISTRADOR -------------------------------------------------------
        // ------------------------------------------------------- MODULO ADMINISTRADOR -------------------------------------------------------
        // ------------------------------------------------------- MODULO ADMINISTRADOR -------------------------------------------------------
        // ------------------------------------------------------- MODULO ADMINISTRADOR -------------------------------------------------------

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

        private void buttonAgregarAdmins_Click(object sender, EventArgs e)
        {
            this.Hide();
            UAAgregarAdmins window = new UAAgregarAdmins();
            window.ShowDialog();
            this.Show();
        }

        private void buttonEditarAdmins_Click(object sender, EventArgs e)
        {

            int indexAdminListView = listViewUsuariosAdministradores.SelectedIndices[0];
            //MessageBox.Show("Index: " + indexAdminListView.ToString());

            Administrador admin = SesionActual.getInstance().modUsuariosAdministrador.listaAdministradores[indexAdminListView];
            //MessageBox.Show("Usuario: " + admin.alias);


            this.Hide();
            UAEditarAdmins window = new UAEditarAdmins(admin);
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

            //MessageBox.Show("Index: " + indexAdminListView.ToString() + " Usuario: " + admin.alias);
        }


        private void buttonDesactivarAdmins_Click(object sender, EventArgs e)
        {
            /*
            // esta lineas asocian el administrador en memoria con el listview
            int index = listViewUsuariosAdministradores.SelectedIndices[0];
            Administrador admin = SesionActual.getInstance().modUsuariosAdministrador.listaAdministradores[index];
            SesionActual.getInstance().modUsuariosAdministrador.listaAdministradores.RemoveAt(index);
            SesionActual.getInstance().modUsuariosAdministrador.borrarAdministrador(admin);
            */
        }



        // ------------------------------------------------------- MODULO USUARIO ICT -------------------------------------------------------
        // ------------------------------------------------------- MODULO USUARIO ICT -------------------------------------------------------
        // ------------------------------------------------------- MODULO USUARIO ICT -------------------------------------------------------
        // ------------------------------------------------------- MODULO USUARIO ICT -------------------------------------------------------
        // ------------------------------------------------------- MODULO USUARIO ICT -------------------------------------------------------

        private void buttonCargaDatosUICT_Click(object sender, EventArgs e)
        {
            listViewUsuariosICT.Items.Clear();
            // cargar otra vez los nuevos datos
            SesionActual.getInstance().modUsuariosICT.cargaUsuarios();

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

        private void buttonEliminarUsuariosICT_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listViewUsuariosICT.SelectedIndices[0];

                UsuarioICT usuario = SesionActual.getInstance().modUsuariosICT.listaUsuarios[index];
                SesionActual.getInstance().modUsuariosICT.listaUsuarios.RemoveAt(index);
                SesionActual.getInstance().modUsuariosICT.borrarUsuarioICT(usuario);
                MessageBox.Show("Usuario Borrado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se borro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }



        private void buttonEditarUICT_Click(object sender, EventArgs e)
        {
            int indexAdminListView = listViewUsuariosICT.SelectedIndices[0];
            //MessageBox.Show("Index: " + indexAdminListView.ToString());

            UsuarioICT user = SesionActual.getInstance().modUsuariosICT.listaUsuarios[indexAdminListView];
            //MessageBox.Show("Usuario: " + user.alias);


            this.Hide();
            UICTEditarUsuario window = new UICTEditarUsuario(user);
            window.ShowDialog();
            this.Show();
        }



        // ----------------------------------------------------- MODULO NIVELES DIFICULTAD -----------------------------------------------------
        // ----------------------------------------------------- MODULO NIVELES DIFICULTAD -----------------------------------------------------
        // ----------------------------------------------------- MODULO NIVELES DIFICULTAD -----------------------------------------------------
        // ----------------------------------------------------- MODULO NIVELES DIFICULTAD -----------------------------------------------------



        private void buttonCargaDatosNivelesDificultad_Click(object sender, EventArgs e)
        {
            listViewNivelesDificultad.Items.Clear();
            SesionActual.getInstance().modNivDificultad.cargaNiveles();
            foreach (Dificultad dificultad in SesionActual.getInstance().modNivDificultad.listaDificultades)
            {
                ListViewItem linea = new ListViewItem(dificultad.idNivel.ToString());
                linea.SubItems.Add(dificultad.descripcion);
                linea.SubItems.Add(dificultad.habilitado.ToString());
                listViewNivelesDificultad.Items.Add(linea);
            }
        }

        private void buttonEditarNivelesDificultad_Click(object sender, EventArgs e)
        {

            int indexNivelDificultadListView = listViewNivelesDificultad.SelectedIndices[0];

            Dificultad dificultad = SesionActual.getInstance().modNivDificultad.listaDificultades[indexNivelDificultadListView];

            // codigo template

            this.Hide();
            NDEditarNivelDificultad window = new NDEditarNivelDificultad(dificultad);
            window.ShowDialog();
            this.Show();
        }

        private void buttonAgregarNivelesDificultad_Click(object sender, EventArgs e)
        {
            this.Hide();
            NDAgregarNivelDificultad window = new NDAgregarNivelDificultad();
            window.ShowDialog();
            this.Show();
        }

        private void buttonEliminarNivelDificultad_Click(object sender, EventArgs e)
        {

        }

        private void buttonDesactivarNivelDificultad_Click(object sender, EventArgs e)
        {
            int indexNivelDificultadListView = listViewNivelesDificultad.SelectedIndices[0];

            Dificultad dificultad = SesionActual.getInstance().modNivDificultad.listaDificultades[indexNivelDificultadListView];


            try
            {
                SesionActual.getInstance().modNivDificultad.inactivarDificultad(dificultad);

                MessageBox.Show("Nivel Desactivado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "No se desactivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        // ----------------------------------------------------- MODULO USUARIOS REGULARES -----------------------------------------------------
        // ----------------------------------------------------- MODULO USUARIOS REGULARES -----------------------------------------------------
        // ----------------------------------------------------- MODULO USUARIOS REGULARES -----------------------------------------------------


        private void buttonCargaDatosUsuariosRegulares_Click(object sender, EventArgs e)
        {
            listViewUsuariosRegulares.Items.Clear();
            // carga los DatosNiveles otra vez (por si hay cambios)
            SesionActual.getInstance().modUsuariosRegulares.cargaUsuarios();
            foreach (Hiker user in SesionActual.getInstance().modUsuariosRegulares.listaHikers)
            {
                ListViewItem linea = new ListViewItem(user.primerNombre);
                linea.SubItems.Add(user.alias);
                linea.SubItems.Add(user.habilitado.ToString());
                listViewUsuariosRegulares.Items.Add(linea);
            }
        }

        private void buttonDesactivarUsuarioRegular_Click(object sender, EventArgs e)
        {
            int indexAdminListView = listViewUsuariosRegulares.SelectedIndices[0];
            //MessageBox.Show("Index: " + indexAdminListView.ToString());

            Hiker user = SesionActual.getInstance().modUsuariosRegulares.listaHikers[indexAdminListView];
            //MessageBox.Show("Usuario: " + user.alias);


            try
            {
                SesionActual.getInstance().modUsuariosRegulares.inactivarHiker(user);
                MessageBox.Show("Usuario Desactivado!");

            }
            catch
            {

            }


        }


        // ----------------------------------------------------- MODULO TIPO CAMINATA -----------------------------------------------------
        // ----------------------------------------------------- MODULO TIPO CAMINATA -----------------------------------------------------
        // ----------------------------------------------------- MODULO TIPO CAMINATA -----------------------------------------------------


        private void buttonCargaDatosTipoCaminata_Click(object sender, EventArgs e)
        {
            listViewTipoCaminata.Items.Clear();
            // carga los DatosNiveles otra vez (por si hay cambios)
            SesionActual.getInstance().modTipoCaminata.cargaTipoCaminatas();
            foreach (TipoCaminata tipo in SesionActual.getInstance().modTipoCaminata.listaTiposCaminata)
            {
                ListViewItem linea = new ListViewItem(tipo.idTipo.ToString());
                linea.SubItems.Add(tipo.descripcion);
                listViewTipoCaminata.Items.Add(linea);
            }
        }

        private void buttonEditarTipoCaminata_Click(object sender, EventArgs e)
        {
            int indexTipoCaminataListView = listViewTipoCaminata.SelectedIndices[0];
            //MessageBox.Show("Index: " + indexTipoCaminataListView.ToString());

            TipoCaminata tipo = SesionActual.getInstance().modTipoCaminata.listaTiposCaminata[indexTipoCaminataListView];
            //MessageBox.Show("Usuario: " + tipo.descripcion);

            // codigo template

            this.Hide();
            TCEditarTipo window = new TCEditarTipo(tipo);
            window.ShowDialog();
            this.Show();
        }

        private void buttonAgregarTipoCaminata_Click(object sender, EventArgs e)
        {
            this.Hide();
            NDAgregarNivelDificultad window = new NDAgregarNivelDificultad();
            window.ShowDialog();
            this.Show();
        }

        private void buttonDesactivarTipoCaminata_Click(object sender, EventArgs e)
        {
            int indexTipoCaminataListView = listViewTipoCaminata.SelectedIndices[0];

            TipoCaminata tipo = SesionActual.getInstance().modTipoCaminata.listaTiposCaminata[indexTipoCaminataListView];

            try
            {
                SesionActual.getInstance().modTipoCaminata.desactivarTipo(tipo);

                MessageBox.Show("Tipo Desactivado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "No se desactivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ----------------------------------------------------- MODULO NIVELES PRECIO -----------------------------------------------------
        // ----------------------------------------------------- MODULO NIVELES PRECIO -----------------------------------------------------
        // ----------------------------------------------------- MODULO NIVELES PRECIO -----------------------------------------------------

        private void buttonCargaDatosNivelesPrecio_Click(object sender, EventArgs e)
        {
            listViewNivelesPrecio.Items.Clear();
            // carga los DatosNiveles otra vez (por si hay cambios)
            SesionActual.getInstance().modNivPrecio.cargaNiveles();
            foreach (NivelPrecio nivel in SesionActual.getInstance().modNivPrecio.listaNivelPrecio)
            {
                ListViewItem linea = new ListViewItem(nivel.idNivelPrecio.ToString());
                linea.SubItems.Add(nivel.descripcion);
                linea.SubItems.Add(nivel.habilitado.ToString());
                listViewNivelesPrecio.Items.Add(linea);
            }
        }

        private void buttonAgregaNivelesPrecio_Click(object sender, EventArgs e)
        {
            this.Hide();
            NPAgregarNivelPrecio window = new NPAgregarNivelPrecio();
            window.ShowDialog();
            this.Show();
        }

        private void buttonEditaNivelesPrecio_Click(object sender, EventArgs e)
        {
            int indexNivelPrecioListView = listViewNivelesPrecio.SelectedIndices[0];
            //MessageBox.Show("Index: " + indexNivelPrecioListView.ToString());

            NivelPrecio tipo = SesionActual.getInstance().modNivPrecio.listaNivelPrecio[indexNivelPrecioListView];
            //MessageBox.Show("Nivel: " + tipo.idNivelPrecio);

            // codigo template

            this.Hide();
            NPEditarNivelPrecio window = new NPEditarNivelPrecio(tipo);
            window.ShowDialog();
            this.Show();
        }

        private void buttonDesactivarNivelesPrecio_Click(object sender, EventArgs e)
        {
            int indexNivelPrecioListView = listViewNivelesPrecio.SelectedIndices[0];

            NivelPrecio tipo = SesionActual.getInstance().modNivPrecio.listaNivelPrecio[indexNivelPrecioListView];

            try
            {
                SesionActual.getInstance().modNivPrecio.inactivarNivelPrecio(tipo);

                MessageBox.Show("Nivel Desactivado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "No se desactivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------------------- MODULO NIVELES CALIDAD -----------------------------------------------------
        // ----------------------------------------------------- MODULO NIVELES CALIDAD -----------------------------------------------------
        // ----------------------------------------------------- MODULO NIVELES CALIDAD -----------------------------------------------------


        private void buttonCargaDatosNivelesCalidad_Click(object sender, EventArgs e)
        {
            listViewNivelesCalidad.Items.Clear();
            // carga los DatosNiveles otra vez (por si hay cambios)
            SesionActual.getInstance().modNivCalidad.cargaNiveles();
            foreach (NivelCalidad nivel in SesionActual.getInstance().modNivCalidad.listaNivelCalidad)
            {
                ListViewItem linea = new ListViewItem(nivel.idNivelCalidad.ToString());
                linea.SubItems.Add(nivel.descripcion);
                linea.SubItems.Add(nivel.habilitado.ToString());
                listViewNivelesCalidad.Items.Add(linea);
            }
        }

        private void buttonbuttonAgregarNivelesCalidad_Click(object sender, EventArgs e)
        {
            this.Hide();
            NCAgregarNivelCalidad window = new NCAgregarNivelCalidad();
            window.ShowDialog();
            this.Show();
        }

        private void buttonEditarNivelesCalidad_Click(object sender, EventArgs e)
        {
            int indexNivelCalidadListView = listViewNivelesCalidad.SelectedIndices[0];
            //MessageBox.Show("Index: " + listViewNivelesCalidad.ToString());

            NivelCalidad tipo = SesionActual.getInstance().modNivCalidad.listaNivelCalidad[indexNivelCalidadListView];
            //MessageBox.Show("Nivel: " + tipo.idNivelCalidad);

            // codigo template

            this.Hide();
            NCEditarNivelCalidad window = new NCEditarNivelCalidad(tipo);
            window.ShowDialog();
            this.Show();
        }

        private void buttonDesactivarNivelesCalidad_Click(object sender, EventArgs e)
        {
            int indexNivelCalidadListView = listViewNivelesCalidad.SelectedIndices[0];
            //MessageBox.Show("Index: " + listViewNivelesCalidad.ToString());

            NivelCalidad tipo = SesionActual.getInstance().modNivCalidad.listaNivelCalidad[indexNivelCalidadListView];
            //MessageBox.Show("Nivel: " + tipo.idNivelCalidad);


            try
            {
                SesionActual.getInstance().modNivCalidad.inactivarNivelCalidad(tipo);

                MessageBox.Show("Nivel Desactivado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "No se desactivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBitacora_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bitacora window = new Bitacora();
            window.ShowDialog();
            this.Show();
        }
    }
    
}
