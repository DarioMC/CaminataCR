using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionSQL;
using EntityObjects;


namespace BusinessLayer
{
    public class ModUsuariosICT
    {
        public List<UsuarioICT> listaUsuarios = new List<UsuarioICT>();

        public ModUsuariosICT()
        {
            cargaUsuarios();
        }

        /// <summary>
        /// carga los usuarios de la base de datos a memoria
        /// </summary>
        public void cargaUsuarios()
        {
            listaUsuarios = conexionSQL.getInstance().SeleccionaUsuariosICT();
        }

        public void agregarUsuarioICT(string alias, string contrasena, string primerNombre, string primerApellido, string segundoApellido, string fechaNac, string cedula)
        {

            if (conexionSQL.getInstance().existeAlias(alias) == 0)
            {
                ContrasenaEncriptada contrasenaEncriptada;
                contrasenaEncriptada = new ContrasenaEncriptada(contrasena);
                conexionSQL.getInstance().agregarUsuarioICT(alias, contrasenaEncriptada.getContrasenaEncriptadaTira(), primerNombre, primerApellido, segundoApellido, fechaNac, cedula);
            }
            else
            {
                throw new Exception("El usuario ya existe");
            }
        }

        public void borrarUsuarioICT(UsuarioICT usuario)
        {
            conexionSQL.getInstance().borrarUsuarioICT(usuario);
        }
    }
}
