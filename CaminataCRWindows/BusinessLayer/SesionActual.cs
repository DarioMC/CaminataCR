using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionSQL;
using EntityObjects;

namespace BusinessLayer
{
    public class SesionActual
    {

        // esta clase tiene 7 modulos
        public ModNivCalidad modNivCalidad = new ModNivCalidad();
        public ModNivDificultad modNivDificultad = new ModNivDificultad();
        public ModNivPrecio modNivPrecio = new ModNivPrecio();
        public ModTipoCaminata modTipoCaminata = new ModTipoCaminata();
        public ModUsuariosAdministrador modUsuariosAdministrador = new ModUsuariosAdministrador();
        public ModUsuariosICT modUsuariosICT = new ModUsuariosICT();
        public ModUsuariosRegulares modUsuariosRegulares = new ModUsuariosRegulares();



        //singleton
        private static SesionActual singletonInstance = null;
        private Administrador SesionAdministradorActual = null;

        protected SesionActual() { }

        /// <summary>
        /// retorna la instancia de la clase global, todo de acuerdo a el singleton
        /// </summary>
        /// <returns></returns>
        public static SesionActual getInstance()
        {
            if (singletonInstance == null)
            {
                singletonInstance = new SesionActual();
                Console.WriteLine("instancia creada");
            }
            return singletonInstance;
        }



        public void iniciarSesion(string alias, string contrasena)
        {
            SesionAdministradorActual = new Administrador();
            ContrasenaEncriptada contrasenaEncriptada;
            contrasenaEncriptada = new ContrasenaEncriptada(contrasena);
            if (conexionSQL.getInstance().loginAdministrador(alias, contrasenaEncriptada.getContrasenaEncriptadaTira()) == 0)
            {
                throw new Exception("contraseña invalida o el usuario no existe");
            }
        }

        public List<EntradaBitacora> seleccionarBitacora(DateTime fechaInicio, DateTime fechaFinal, string tipoAccion, string objeto, int horaInicial, int horaFinal)
        {
            return conexionSQL.getInstance().seleccionarBitacora(fechaInicio, fechaFinal, tipoAccion, objeto, horaInicial, horaFinal);
        }
    }
}
