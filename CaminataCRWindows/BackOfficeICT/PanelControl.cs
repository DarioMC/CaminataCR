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

namespace BackOfficeICT
{
    public partial class PanelControl : Form
    {
        bool descAsc = true;
        List<CaminataLikes> listaCaminataLikes;

        public PanelControl()
        {
            InitializeComponent();
            textBoxCantidadLikesUsuariosAportes.Text = "0";
            textBoxNumeroRegistrosRemuneracion.Text = "1000";
            textBoxNumeroRutasGustos.Text = "30";
            dateTimePickerFechaInicialGustos.Value = DateTime.Today.AddYears(-100);
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

        // ------------------------------------------------------- MODULO USUARIOS POR APORTES -------------------------------------------------------
        // ------------------------------------------------------- MODULO USUARIOS POR APORTES -------------------------------------------------------

        private void buttonAgregarAdmins_Click(object sender, EventArgs e)
        {
            listViewUsuariosAportes.Items.Clear();
            // carga los admins otra vez (por si hay cambios)

            // en este caso: PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, Imagen, CuentaBancaria, 
            // Cantidad Caminatas, Puntos Geograficos, Likes
            try
            {
                List<UsuarioConsulta> listaUsuarios = conexionSQL.getInstance().consultaUsuarios(textBoxNombreUsuariosAportes.Text, textBoxApellidoUsuariosAportes.Text, int.Parse(textBoxCantidadLikesUsuariosAportes.Text));

                List<UsuarioConsulta> listaOrdenada = listaUsuarios.OrderBy(o => o.alias).ToList();
                foreach (UsuarioConsulta usuario in listaOrdenada)
                {
                    ListViewItem linea = new ListViewItem(usuario.primerNombre);
                    linea.SubItems.Add(usuario.primerApellido);
                    linea.SubItems.Add(usuario.segundoApellido);
                    linea.SubItems.Add(usuario.fechaNac.ToShortDateString());
                    linea.SubItems.Add(usuario.alias);
                    linea.SubItems.Add(usuario.cedula.ToString());
                    linea.SubItems.Add(usuario.cuentaBancaria.ToString());
                    linea.SubItems.Add(usuario.cantidadCaminatas.ToString());
                    linea.SubItems.Add(usuario.puntosGeograficos.ToString());
                    linea.SubItems.Add(usuario.cantidadLikes.ToString());
                    listViewUsuariosAportes.Items.Add(linea);
                }
            }
            catch
            {
                MessageBox.Show("Datos invalidos");
            }

        }

        private void listViewUsuariosAportes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Int32 colIndex = Convert.ToInt32(e.Column.ToString());
            string columna = listViewUsuariosAportes.Columns[colIndex].Text;
            descAsc = !descAsc;
            try
            {
                List<UsuarioConsulta> listaUsuarios = conexionSQL.getInstance().consultaUsuarios(textBoxNombreUsuariosAportes.Text, textBoxApellidoUsuariosAportes.Text, int.Parse(textBoxCantidadLikesUsuariosAportes.Text));

            }
            catch
            {
                MessageBox.Show("Datos invalidos consultaUsuarios()");
            }

            if (columna == "PrimerNombre")
            {
                listViewUsuariosAportes.Items.Clear();
                // carga los admins otra vez (por si hay cambios)

                // en este caso: PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, Imagen, CuentaBancaria, 
                // Cantidad Caminatas, Puntos Geograficos, Likes
                try
                {
                    List<UsuarioConsulta> listaUsuarios = conexionSQL.getInstance().consultaUsuarios(textBoxNombreUsuariosAportes.Text, textBoxApellidoUsuariosAportes.Text, int.Parse(textBoxCantidadLikesUsuariosAportes.Text));

                    List<UsuarioConsulta> listaOrdenada = listaUsuarios.OrderBy(o => o.primerNombre).ToList();
                    if (descAsc == true)
                    {
                        listaOrdenada = listaUsuarios.OrderBy(o => o.primerNombre).ToList();
                    }
                    else
                    {
                        listaOrdenada = listaUsuarios.OrderByDescending(o => o.primerNombre).ToList();
                    }
                    
                    foreach (UsuarioConsulta usuario in listaOrdenada)
                    {
                        ListViewItem linea = new ListViewItem(usuario.primerNombre);
                        linea.SubItems.Add(usuario.primerApellido);
                        linea.SubItems.Add(usuario.segundoApellido);
                        linea.SubItems.Add(usuario.fechaNac.ToShortDateString());
                        linea.SubItems.Add(usuario.alias);
                        linea.SubItems.Add(usuario.cedula.ToString());
                        linea.SubItems.Add(usuario.cuentaBancaria.ToString());
                        linea.SubItems.Add(usuario.cantidadCaminatas.ToString());
                        linea.SubItems.Add(usuario.puntosGeograficos.ToString());
                        linea.SubItems.Add(usuario.cantidadLikes.ToString());
                        listViewUsuariosAportes.Items.Add(linea);
                    }
                }
                catch
                {
                    MessageBox.Show("Datos invalidos");

                }
            }
            else if (columna == "PrimerApellido")
            {
                listViewUsuariosAportes.Items.Clear();
                // carga los admins otra vez (por si hay cambios)

                // en este caso: PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, Imagen, CuentaBancaria, 
                // Cantidad Caminatas, Puntos Geograficos, Likes
                try
                {
                    List<UsuarioConsulta> listaUsuarios = conexionSQL.getInstance().consultaUsuarios(textBoxNombreUsuariosAportes.Text, textBoxApellidoUsuariosAportes.Text, int.Parse(textBoxCantidadLikesUsuariosAportes.Text));

                    List<UsuarioConsulta> listaOrdenada = listaUsuarios.OrderBy(o => o.primerApellido).ToList();
                    if (descAsc == true)
                    {
                        listaOrdenada = listaUsuarios.OrderBy(o => o.primerApellido).ToList();
                    }
                    else
                    {
                        listaOrdenada = listaUsuarios.OrderByDescending(o => o.primerApellido).ToList();
                    }

                    foreach (UsuarioConsulta usuario in listaOrdenada)
                    {
                        ListViewItem linea = new ListViewItem(usuario.primerNombre);
                        linea.SubItems.Add(usuario.primerApellido);
                        linea.SubItems.Add(usuario.segundoApellido);
                        linea.SubItems.Add(usuario.fechaNac.ToShortDateString());
                        linea.SubItems.Add(usuario.alias);
                        linea.SubItems.Add(usuario.cedula.ToString());
                        linea.SubItems.Add(usuario.cuentaBancaria.ToString());
                        linea.SubItems.Add(usuario.cantidadCaminatas.ToString());
                        linea.SubItems.Add(usuario.puntosGeograficos.ToString());
                        linea.SubItems.Add(usuario.cantidadLikes.ToString());
                        listViewUsuariosAportes.Items.Add(linea);
                    }
                }
                catch
                {
                    MessageBox.Show("Datos invalidos");

                }
            }
            else if (columna == "FechaNacimiento")
            {
                listViewUsuariosAportes.Items.Clear();
                // carga los admins otra vez (por si hay cambios)

                // en este caso: PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, Imagen, CuentaBancaria, 
                // Cantidad Caminatas, Puntos Geograficos, Likes
                try
                {
                    List<UsuarioConsulta> listaUsuarios = conexionSQL.getInstance().consultaUsuarios(textBoxNombreUsuariosAportes.Text, textBoxApellidoUsuariosAportes.Text, int.Parse(textBoxCantidadLikesUsuariosAportes.Text));


                    List<UsuarioConsulta> listaOrdenada = listaUsuarios.OrderBy(o => o.fechaNac).ToList();
                    if (descAsc == true)
                    {
                        listaOrdenada = listaUsuarios.OrderBy(o => o.fechaNac).ToList();
                    }
                    else
                    {
                        listaOrdenada = listaUsuarios.OrderByDescending(o => o.fechaNac).ToList();
                    }

                    foreach (UsuarioConsulta usuario in listaOrdenada)
                    {
                        ListViewItem linea = new ListViewItem(usuario.primerNombre);
                        linea.SubItems.Add(usuario.primerApellido);
                        linea.SubItems.Add(usuario.segundoApellido);
                        linea.SubItems.Add(usuario.fechaNac.ToShortDateString());
                        linea.SubItems.Add(usuario.alias);
                        linea.SubItems.Add(usuario.cedula.ToString());
                        linea.SubItems.Add(usuario.cuentaBancaria.ToString());
                        linea.SubItems.Add(usuario.cantidadCaminatas.ToString());
                        linea.SubItems.Add(usuario.puntosGeograficos.ToString());
                        linea.SubItems.Add(usuario.cantidadLikes.ToString());
                        listViewUsuariosAportes.Items.Add(linea);
                    }
                }
                catch
                {
                    MessageBox.Show("Datos invalidos");

                }
            }
            else if (columna == "Alias")
            {
                listViewUsuariosAportes.Items.Clear();
                // carga los admins otra vez (por si hay cambios)

                // en este caso: PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, Imagen, CuentaBancaria, 
                // Cantidad Caminatas, Puntos Geograficos, Likes
                try
                {
                    List<UsuarioConsulta> listaUsuarios = conexionSQL.getInstance().consultaUsuarios(textBoxNombreUsuariosAportes.Text, textBoxApellidoUsuariosAportes.Text, int.Parse(textBoxCantidadLikesUsuariosAportes.Text));


                    List<UsuarioConsulta> listaOrdenada = listaUsuarios.OrderBy(o => o.alias).ToList();
                    if (descAsc == true)
                    {
                        listaOrdenada = listaUsuarios.OrderBy(o => o.alias).ToList();
                    }
                    else
                    {
                        listaOrdenada = listaUsuarios.OrderByDescending(o => o.alias).ToList();
                    }

                    foreach (UsuarioConsulta usuario in listaOrdenada)
                    {
                        ListViewItem linea = new ListViewItem(usuario.primerNombre);
                        linea.SubItems.Add(usuario.primerApellido);
                        linea.SubItems.Add(usuario.segundoApellido);
                        linea.SubItems.Add(usuario.fechaNac.ToShortDateString());
                        linea.SubItems.Add(usuario.alias);
                        linea.SubItems.Add(usuario.cedula.ToString());
                        linea.SubItems.Add(usuario.cuentaBancaria.ToString());
                        linea.SubItems.Add(usuario.cantidadCaminatas.ToString());
                        linea.SubItems.Add(usuario.puntosGeograficos.ToString());
                        linea.SubItems.Add(usuario.cantidadLikes.ToString());
                        listViewUsuariosAportes.Items.Add(linea);
                    }
                }
                catch
                {
                    MessageBox.Show("Datos invalidos");

                }
            }
            else if (columna == "Cedula")
            {
                listViewUsuariosAportes.Items.Clear();
                // carga los admins otra vez (por si hay cambios)

                // en este caso: PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, Imagen, CuentaBancaria, 
                // Cantidad Caminatas, Puntos Geograficos, Likes
                try
                {
                    List<UsuarioConsulta> listaUsuarios = conexionSQL.getInstance().consultaUsuarios(textBoxNombreUsuariosAportes.Text, textBoxApellidoUsuariosAportes.Text, int.Parse(textBoxCantidadLikesUsuariosAportes.Text));

                    List<UsuarioConsulta> listaOrdenada = listaUsuarios.OrderBy(o => o.cedula).ToList();
                    if (descAsc == true)
                    {
                        listaOrdenada = listaUsuarios.OrderBy(o => o.cedula).ToList();
                    }
                    else
                    {
                        listaOrdenada = listaUsuarios.OrderByDescending(o => o.cedula).ToList();
                    }

                    foreach (UsuarioConsulta usuario in listaOrdenada)
                    {
                        ListViewItem linea = new ListViewItem(usuario.primerNombre);
                        linea.SubItems.Add(usuario.primerApellido);
                        linea.SubItems.Add(usuario.segundoApellido);
                        linea.SubItems.Add(usuario.fechaNac.ToShortDateString());
                        linea.SubItems.Add(usuario.alias);
                        linea.SubItems.Add(usuario.cedula.ToString());
                        linea.SubItems.Add(usuario.cuentaBancaria.ToString());
                        linea.SubItems.Add(usuario.cantidadCaminatas.ToString());
                        linea.SubItems.Add(usuario.puntosGeograficos.ToString());
                        linea.SubItems.Add(usuario.cantidadLikes.ToString());
                        listViewUsuariosAportes.Items.Add(linea);
                    }
                }
                catch
                {
                    MessageBox.Show("Datos invalidos");

                }
            }
            else if (columna == "Imagen")
            {

            }
            else if (columna == "CuentaBancaria")
            {
                listViewUsuariosAportes.Items.Clear();
                // carga los admins otra vez (por si hay cambios)

                // en este caso: PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, Imagen, CuentaBancaria, 
                // Cantidad Caminatas, Puntos Geograficos, Likes
                try
                {
                    List<UsuarioConsulta> listaUsuarios = conexionSQL.getInstance().consultaUsuarios(textBoxNombreUsuariosAportes.Text, textBoxApellidoUsuariosAportes.Text, int.Parse(textBoxCantidadLikesUsuariosAportes.Text));


                    List<UsuarioConsulta> listaOrdenada = listaUsuarios.OrderBy(o => o.cuentaBancaria).ToList();
                    if (descAsc == true)
                    {
                        listaOrdenada = listaUsuarios.OrderBy(o => o.cuentaBancaria).ToList();
                    }
                    else
                    {
                        listaOrdenada = listaUsuarios.OrderByDescending(o => o.cuentaBancaria).ToList();
                    }

                    foreach (UsuarioConsulta usuario in listaOrdenada)
                    {
                        ListViewItem linea = new ListViewItem(usuario.primerNombre);
                        linea.SubItems.Add(usuario.primerApellido);
                        linea.SubItems.Add(usuario.segundoApellido);
                        linea.SubItems.Add(usuario.fechaNac.ToShortDateString());
                        linea.SubItems.Add(usuario.alias);
                        linea.SubItems.Add(usuario.cedula.ToString());
                        linea.SubItems.Add(usuario.cuentaBancaria.ToString());
                        linea.SubItems.Add(usuario.cantidadCaminatas.ToString());
                        linea.SubItems.Add(usuario.puntosGeograficos.ToString());
                        linea.SubItems.Add(usuario.cantidadLikes.ToString());
                        listViewUsuariosAportes.Items.Add(linea);
                    }
                }
                catch
                {
                    MessageBox.Show("Datos invalidos");

                }
            }
            else if (columna == "Cantidad Caminatas")
            {
                listViewUsuariosAportes.Items.Clear();
                // carga los admins otra vez (por si hay cambios)

                // en este caso: PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, Imagen, CuentaBancaria, 
                // Cantidad Caminatas, Puntos Geograficos, Likes
                try
                {
                    List<UsuarioConsulta> listaUsuarios = conexionSQL.getInstance().consultaUsuarios(textBoxNombreUsuariosAportes.Text, textBoxApellidoUsuariosAportes.Text, int.Parse(textBoxCantidadLikesUsuariosAportes.Text));


                    List<UsuarioConsulta> listaOrdenada = listaUsuarios.OrderBy(o => o.cantidadCaminatas).ToList();
                    if (descAsc == true)
                    {
                        listaOrdenada = listaUsuarios.OrderBy(o => o.cantidadCaminatas).ToList();
                    }
                    else
                    {
                        listaOrdenada = listaUsuarios.OrderByDescending(o => o.cantidadCaminatas).ToList();
                    }

                    foreach (UsuarioConsulta usuario in listaOrdenada)
                    {
                        ListViewItem linea = new ListViewItem(usuario.primerNombre);
                        linea.SubItems.Add(usuario.primerApellido);
                        linea.SubItems.Add(usuario.segundoApellido);
                        linea.SubItems.Add(usuario.fechaNac.ToShortDateString());
                        linea.SubItems.Add(usuario.alias);
                        linea.SubItems.Add(usuario.cedula.ToString());
                        linea.SubItems.Add(usuario.cuentaBancaria.ToString());
                        linea.SubItems.Add(usuario.cantidadCaminatas.ToString());
                        linea.SubItems.Add(usuario.puntosGeograficos.ToString());
                        linea.SubItems.Add(usuario.cantidadLikes.ToString());
                        listViewUsuariosAportes.Items.Add(linea);
                    }
                }
                catch
                {
                    MessageBox.Show("Datos invalidos");

                }
            }
            else if (columna == "Puntos Geograficos")
            {
                listViewUsuariosAportes.Items.Clear();
                // carga los admins otra vez (por si hay cambios)

                // en este caso: PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, Imagen, CuentaBancaria, 
                // Cantidad Caminatas, Puntos Geograficos, Likes
                try
                {
                    List<UsuarioConsulta> listaUsuarios = conexionSQL.getInstance().consultaUsuarios(textBoxNombreUsuariosAportes.Text, textBoxApellidoUsuariosAportes.Text, int.Parse(textBoxCantidadLikesUsuariosAportes.Text));


                    List<UsuarioConsulta> listaOrdenada = listaUsuarios.OrderBy(o => o.puntosGeograficos).ToList();
                    if (descAsc == true)
                    {
                        listaOrdenada = listaUsuarios.OrderBy(o => o.puntosGeograficos).ToList();
                    }
                    else
                    {
                        listaOrdenada = listaUsuarios.OrderByDescending(o => o.puntosGeograficos).ToList();
                    }

                    foreach (UsuarioConsulta usuario in listaOrdenada)
                    {
                        ListViewItem linea = new ListViewItem(usuario.primerNombre);
                        linea.SubItems.Add(usuario.primerApellido);
                        linea.SubItems.Add(usuario.segundoApellido);
                        linea.SubItems.Add(usuario.fechaNac.ToShortDateString());
                        linea.SubItems.Add(usuario.alias);
                        linea.SubItems.Add(usuario.cedula.ToString());
                        linea.SubItems.Add(usuario.cuentaBancaria.ToString());
                        linea.SubItems.Add(usuario.cantidadCaminatas.ToString());
                        linea.SubItems.Add(usuario.puntosGeograficos.ToString());
                        linea.SubItems.Add(usuario.cantidadLikes.ToString());
                        listViewUsuariosAportes.Items.Add(linea);
                    }
                }
                catch
                {
                    MessageBox.Show("Datos invalidos");

                }
            }
            else if (columna == "Likes")
            {
                listViewUsuariosAportes.Items.Clear();
                // carga los admins otra vez (por si hay cambios)

                // en este caso: PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, Imagen, CuentaBancaria, 
                // Cantidad Caminatas, Puntos Geograficos, Likes
                try
                {
                    List<UsuarioConsulta> listaUsuarios = conexionSQL.getInstance().consultaUsuarios(textBoxNombreUsuariosAportes.Text, textBoxApellidoUsuariosAportes.Text, int.Parse(textBoxCantidadLikesUsuariosAportes.Text));


                    List<UsuarioConsulta> listaOrdenada = listaUsuarios.OrderBy(o => o.cantidadLikes).ToList();
                    if (descAsc == true)
                    {
                        listaOrdenada = listaUsuarios.OrderBy(o => o.cantidadLikes).ToList();
                    }
                    else
                    {
                        listaOrdenada = listaUsuarios.OrderByDescending(o => o.cantidadLikes).ToList();
                    }

                    foreach (UsuarioConsulta usuario in listaOrdenada)
                    {
                        ListViewItem linea = new ListViewItem(usuario.primerNombre);
                        linea.SubItems.Add(usuario.primerApellido);
                        linea.SubItems.Add(usuario.segundoApellido);
                        linea.SubItems.Add(usuario.fechaNac.ToShortDateString());
                        linea.SubItems.Add(usuario.alias);
                        linea.SubItems.Add(usuario.cedula.ToString());
                        linea.SubItems.Add(usuario.cuentaBancaria.ToString());
                        linea.SubItems.Add(usuario.cantidadCaminatas.ToString());
                        linea.SubItems.Add(usuario.puntosGeograficos.ToString());
                        linea.SubItems.Add(usuario.cantidadLikes.ToString());
                        listViewUsuariosAportes.Items.Add(linea);
                    }
                }
                catch
                {
                    MessageBox.Show("Datos invalidos");

                }
            }
            else if (columna == "SegundoApellido")
            {
                listViewUsuariosAportes.Items.Clear();
                // carga los admins otra vez (por si hay cambios)

                // en este caso: PrimerNombre, PrimerApellido, SegundoApellido, FechaNac, Alias, Cedula, Imagen, CuentaBancaria, 
                // Cantidad Caminatas, Puntos Geograficos, Likes
                try
                {
                    List<UsuarioConsulta> listaUsuarios = conexionSQL.getInstance().consultaUsuarios(textBoxNombreUsuariosAportes.Text, textBoxApellidoUsuariosAportes.Text, int.Parse(textBoxCantidadLikesUsuariosAportes.Text));


                    List<UsuarioConsulta> listaOrdenada = listaUsuarios.OrderBy(o => o.segundoApellido).ToList();
                    if (descAsc == true)
                    {
                        listaOrdenada = listaUsuarios.OrderBy(o => o.segundoApellido).ToList();
                    }
                    else
                    {
                        listaOrdenada = listaUsuarios.OrderByDescending(o => o.segundoApellido).ToList();
                    }

                    foreach (UsuarioConsulta usuario in listaOrdenada)
                    {
                        ListViewItem linea = new ListViewItem(usuario.primerNombre);
                        linea.SubItems.Add(usuario.primerApellido);
                        linea.SubItems.Add(usuario.segundoApellido);
                        linea.SubItems.Add(usuario.fechaNac.ToShortDateString());
                        linea.SubItems.Add(usuario.alias);
                        linea.SubItems.Add(usuario.cedula.ToString());
                        linea.SubItems.Add(usuario.cuentaBancaria.ToString());
                        linea.SubItems.Add(usuario.cantidadCaminatas.ToString());
                        linea.SubItems.Add(usuario.puntosGeograficos.ToString());
                        linea.SubItems.Add(usuario.cantidadLikes.ToString());
                        listViewUsuariosAportes.Items.Add(linea);
                    }
                }
                catch
                {
                    MessageBox.Show("Datos invalidos");

                }
            }
        }

        // ------------------------------------------------------- MODULO USUARIOS POR APORTES -------------------------------------------------------
        // ------------------------------------------------------- MODULO USUARIOS POR APORTES -------------------------------------------------------
        // ------------------------------------------------------- MODULO USUARIOS POR APORTES -------------------------------------------------------


        private void buttonCargarRemuneraciones_Click(object sender, EventArgs e)
        {
            try
            {
                listViewReporteRemuneraciones.Items.Clear();
                DateTime fechaInicial = dateTimePickerFechaInicialRemuneraciones.Value;
                DateTime fechaFinal = dateTimePickerFechaFinalRemuneraciones.Value;
                List<UsuarioReporteRemuneraciones> listaUsuarios = conexionSQL.getInstance().consultaReporteRemuneraciones(int.Parse(textBoxNumeroRegistrosRemuneracion.Text), fechaInicial , fechaFinal);

                foreach (UsuarioReporteRemuneraciones usuario in listaUsuarios)
                {
                    ListViewItem linea = new ListViewItem(usuario.primerNombre);
                    linea.SubItems.Add(usuario.primerApellido);
                    linea.SubItems.Add(usuario.segundoApellido);
                    linea.SubItems.Add(usuario.alias);
                    linea.SubItems.Add(usuario.montoTotal.ToString());
                    listViewReporteRemuneraciones.Items.Add(linea);
                }
            }
            catch
            {
                MessageBox.Show("Datos invalidos");
            }
        }

        private void listViewReporteRemuneraciones_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Int32 colIndex = Convert.ToInt32(e.Column.ToString());
            string columna = listViewReporteRemuneraciones.Columns[colIndex].Text;

            descAsc = !descAsc;

            if(columna == "PrimerNombre")
            {

            }
            else if (columna == "PrimerApellido")
            {

            }
            else if (columna == "SegundoApellido")
            {

            }
        }

        private void buttonCargarGustosRutas_Click(object sender, EventArgs e)
        {
            try
            {
                listViewCaminataLikesGustos.Items.Clear();
                DateTime fechaInicial = dateTimePickerFechaInicialGustos.Value;
                DateTime fechaFinal = dateTimePickerFechaFinalGustos.Value;

                listaCaminataLikes = conexionSQL.getInstance().consultaRutasLikes(int.Parse(textBoxNumeroRutasGustos.Text), checkBoxOrden.Checked, 
                    fechaInicial, fechaFinal);

                //List<CaminataLikes> listaOrdenada = listaUsuarios.OrderBy(o => o.alias).ToList();
                foreach (CaminataLikes caminata in listaCaminataLikes)
                {
                    ListViewItem linea = new ListViewItem(caminata.idCaminata.ToString());
                    linea.SubItems.Add(caminata.nombre);
                    linea.SubItems.Add(caminata.likes.ToString());

                    listViewCaminataLikesGustos.Items.Add(linea);
                }
            }
            catch
            {
                MessageBox.Show("Datos invalidos");
            }
        }

        private void listViewCaminataLikesGustos_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewPuntosGustos.Items.Clear();

            int indexCaminataLikesListview = listViewCaminataLikesGustos.SelectedIndices[0];
            MessageBox.Show("Index: " + indexCaminataLikesListview.ToString());

            CaminataLikes caminata = listaCaminataLikes[indexCaminataLikesListview];
            MessageBox.Show("Usuario: " + caminata.nombre);

            List<Puntos> listaPuntos = conexionSQL.getInstance().consultaRutasCaminata(caminata.idCaminata);
            foreach (Puntos punto in listaPuntos)
            {
                ListViewItem linea = new ListViewItem(punto.puntoReportado.ToString());
                linea.SubItems.Add(punto.latitud.ToString());
                linea.SubItems.Add(punto.longitud.ToString());
                linea.SubItems.Add(punto.comentario);

                listViewPuntosGustos.Items.Add(linea);
            }
        }

        private void PanelControl_Load(object sender, EventArgs e)
        {

        }
    }
}
