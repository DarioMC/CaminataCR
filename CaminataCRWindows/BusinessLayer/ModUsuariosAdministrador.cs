using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionSQL;
using EntityObjects;

namespace BusinessLayer
{
    public class ModUsuariosAdministrador
    {

        // administradores
        public List<Administrador> listaAdministradores = new List<Administrador>();

        public ModUsuariosAdministrador()
        {
            cargarAdministradores();
        }

        /// <summary>
        /// Agrega administradores a la base de datos, utilizando DAL
        /// </summary>
        /// <param name="alias"></param>
        /// <param name="contrasena"></param>
        /// <param name="primerNombre"></param>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <param name="fechaNac"></param>
        /// <param name="cedula"></param>
        public void agregarAdministrador(string alias, string contrasena, string primerNombre, string primerApellido, string segundoApellido, string fechaNac, string cedula)
        {
            
            if (conexionSQL.getInstance().existeAlias(alias) == 0)
            {
                ContrasenaEncriptada contrasenaEncriptada;
                contrasenaEncriptada = new ContrasenaEncriptada(contrasena);
                conexionSQL.getInstance().agregarAdministrador(alias, contrasenaEncriptada.getContrasenaEncriptadaTira(), primerNombre, primerApellido, segundoApellido, fechaNac, cedula);
            }
            else
            {
                throw new Exception("El usuario ya existe");
            }
        }

        /// <summary>
        /// Carga los administradores de la base de datos a memoria
        /// </summary>
        public void cargarAdministradores()
        {
             listaAdministradores = conexionSQL.getInstance().SeleccionaAdministradores();
        }

        public void borrarAdministrador(Administrador admin)
        {
            conexionSQL.getInstance().borrarAdministrador(admin);
        }

        public void editarAdministrador(Administrador admin)
        {
            ContrasenaEncriptada contrasenaEncriptada;
            contrasenaEncriptada = new ContrasenaEncriptada(admin.contrasena);
            admin.contrasena = contrasenaEncriptada.getContrasenaEncriptadaTira();
            conexionSQL.getInstance().editarAdministrador(admin);
        }
    }
}
