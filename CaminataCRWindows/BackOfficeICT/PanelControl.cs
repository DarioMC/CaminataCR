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
        public PanelControl()
        {
            InitializeComponent();
            textBoxCantidadLikesUsuariosAportes.Text = "0";
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

        private void listViewUsuariosAportes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewUsuariosAportes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Int32 colIndex = Convert.ToInt32(e.Column.ToString());
            string columna = listViewUsuariosAportes.Columns[colIndex].Text;

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
    }
}
