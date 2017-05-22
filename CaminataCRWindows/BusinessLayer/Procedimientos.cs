using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionSQL;

namespace BusinessLayer
{
    public class Procedimientos
    {
        //singleton
        private static Procedimientos singletonInstance = null;

        protected Procedimientos() { }

        /// <summary>
        /// retorna la instancia de la clase global, todo de acuerdo a el singleton
        /// </summary>
        /// <returns></returns>
        public static Procedimientos getInstance()
        {
            if (singletonInstance == null)
            {
                singletonInstance = new Procedimientos();
                Console.WriteLine("instancia creada");
            }
            return singletonInstance;
        }



        public void AgregarAdministrador(string alias, string contrasena, string primerNombre, string primerApellido, string segundoApellido, string fechaNac, string cedula)
        {
            if(conexionSQL.getInstance().ExisteAlias(alias) == 0)
            {
                ContrasenaEncriptada contrasenaEncriptada;
                contrasenaEncriptada = new ContrasenaEncriptada(contrasena);
                conexionSQL.getInstance().AgregarAdministrador(alias, contrasenaEncriptada.getContrasenaEncriptadaTira(), primerNombre, primerApellido, segundoApellido, fechaNac, cedula);
            }
            else
            {
                throw new Exception("El usuario ya existe");
            }
        }
    }
}
