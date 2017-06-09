using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using EntityObjects;

namespace ConexionSQL
{

    public class conexionSQL
    {
        // crear un singleton
        private static conexionSQL singletonInstance = null;

        private static SqlConnection conexion = new SqlConnection("Server=186.15.10.94,1433; Database=Caminata; User Id=Emma; password= 0000");
        private static SqlCommand comandosql;
        private static SqlDataReader lectorsql;

        /// <summary>
        /// se blockea la creacion de la instancia
        /// </summary>
        protected conexionSQL() { }

        /// <summary>
        /// retorna la instancia de la clase global, todo de acuerdo a el singleton
        /// </summary>
        /// <returns></returns>
        public static conexionSQL getInstance()
        {
            if (singletonInstance == null)
            {
                singletonInstance = new conexionSQL();
                Console.WriteLine("instancia creada");
            }
            return singletonInstance;
        }

        private void abrirConexionSP(string tiraSP)
        {
            // abrir la conexion al servidor
            conexion.Open();

            // tira con el nombre del procedimiento
            comandosql = new SqlCommand(tiraSP, conexion);
            comandosql.CommandType = CommandType.StoredProcedure;
        }

        private void terminaConexionSO()
        {
            // cerrar el reader
            if (lectorsql != null)
            {
                lectorsql.Close();
            }

            // cerrar conexion
            if (conexion != null)
            {
                conexion.Close();
            }
        }

        public void procedimientoEjemplo2(string alias)
        {
            try
            {
                this.abrirConexionSP("SPS_SeleccionarAmigos");

                //agregar parametros
                comandosql.Parameters.Add("@alias", SqlDbType.VarChar).Value = alias;

                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");

                // se lee cada tupla de la tabla retornada una por una, .Read() retorna true cada tupla retornada y false si ya termino
                while (lectorsql.Read())
                {
                    //Mesas mesa = new Mesas();
                    //mesa.idMesa = int.Parse(sql.Lectorsql[0].ToString());

                    // se puede castear los parametros con el nombre de la columna
                    string columna = (string)lectorsql["columna"];

                    //lista.Add(mesa); // se agregar elemento a la lista que se retornara
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }

        public int existeAlias(string alias)
        {
            try
            {
                this.abrirConexionSP("SPS_ExisteAlias");

                //agregar parametros
                comandosql.Parameters.Add("@alias", SqlDbType.VarChar).Value = alias;

                // asocia el parametro de regreso
                var returnParameter = comandosql.Parameters.Add("@existe", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");
                var val = returnParameter.Value;
                return (int)val;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.ExisteAlias()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }

        // ------------------------------------------------------- MODULO ADMINISTRADOR -------------------------------------------------------
        // ------------------------------------------------------- MODULO ADMINISTRADOR -------------------------------------------------------
        // ------------------------------------------------------- MODULO ADMINISTRADOR -------------------------------------------------------
        // ------------------------------------------------------- MODULO ADMINISTRADOR -------------------------------------------------------
        // ------------------------------------------------------- MODULO ADMINISTRADOR -------------------------------------------------------


        public void agregarAdministrador(string alias, string contrasena, string primerNombre, string primerApellido, string segundoApellido, string fechaNac, string cedula)
        {
            try
            {
                this.abrirConexionSP("SPS_AgregarAdministrador");

                //agregar parametros
                comandosql.Parameters.Add("@alias", SqlDbType.VarChar).Value = alias;
                comandosql.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = contrasena;
                comandosql.Parameters.Add("@primerNombre", SqlDbType.VarChar).Value = primerNombre;
                comandosql.Parameters.Add("@primerApellido", SqlDbType.VarChar).Value = primerApellido;
                comandosql.Parameters.Add("@segundoApellido", SqlDbType.VarChar).Value = segundoApellido;
                comandosql.Parameters.Add("@cedula", SqlDbType.VarChar).Value = cedula;
                comandosql.Parameters.Add("@fechaNac", SqlDbType.Date).Value = fechaNac;

                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.agregaAdministrador()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }

        public void editarAdministrador(Administrador admin)
        {
            try
            {
                this.abrirConexionSP("SPS_EditarAdministrador");

                //agregar parametros
                comandosql.Parameters.Add("@alias", SqlDbType.VarChar).Value = admin.alias;
                comandosql.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = admin.contrasena;
                comandosql.Parameters.Add("@primerNombre", SqlDbType.VarChar).Value = admin.primerNombre;
                comandosql.Parameters.Add("@primerApellido", SqlDbType.VarChar).Value = admin.primerApellido;
                comandosql.Parameters.Add("@segundoApellido", SqlDbType.VarChar).Value = admin.segundoApellido;
                comandosql.Parameters.Add("@cedula", SqlDbType.VarChar).Value = admin.cedula;
                comandosql.Parameters.Add("@fechaNac", SqlDbType.Date).Value = admin.fechaNac;

                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.agregaAdministrador()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }

        public int loginAdministrador(string alias, string contrasena)
        {
            try
            {
                this.abrirConexionSP("SPS_LoginAdministrador");

                //agregar parametros
                comandosql.Parameters.Add("@alias", SqlDbType.VarChar).Value = alias;
                comandosql.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = contrasena;

                // asocia el parametro de regreso
                var returnParameter = comandosql.Parameters.Add("@conectado", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");
                var val = returnParameter.Value;
                return (int)val;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.loginAdministrador()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }

        public void borrarAdministrador(Administrador admin)
        {
            try
            {
                this.abrirConexionSP("SPS_BorrarAdministrador");

                //agregar parametros
                comandosql.Parameters.Add("@alias", SqlDbType.VarChar).Value = admin.alias;

                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.borrarAdministrador()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }

        public List<Administrador> SeleccionaAdministradores()
        {
            try
            {
                this.abrirConexionSP("SPS_SeleccionarAdministradores");
                
                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");

                List<Administrador> listaAdministradores = new List<Administrador>();

                // se lee cada tupla de la tabla retornada una por una, .Read() retorna true cada tupla retornada y false si ya termino
                while (lectorsql.Read())
                {
                    Administrador admin = new Administrador();

                    //Alias, P.PrimerNombre, P.PrimerApellido, P.SegundoApellido, FechaNac, Cedula, IdPersona
                    admin.alias = (string)lectorsql["Alias"];
                    admin.primerNombre = (string)lectorsql["PrimerNombre"];
                    admin.segundoApellido = (string)lectorsql["SegundoApellido"];
                    admin.fechaNac = (DateTime)lectorsql["FechaNac"];
                    admin.cedula = (string)lectorsql["Cedula"];
                    admin.IdPersona = (int)lectorsql["IdPersona"];

                    listaAdministradores.Add(admin);
                    //lista.Add(mesa); // se agregar elemento a la lista que se retornara
                }
                return listaAdministradores;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.SeleccionaAdministradores()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }


        // ------------------------------------------------------- MODULO USUARIO ICT -------------------------------------------------------
        // ------------------------------------------------------- MODULO USUARIO ICT -------------------------------------------------------
        // ------------------------------------------------------- MODULO USUARIO ICT -------------------------------------------------------
        // ------------------------------------------------------- MODULO USUARIO ICT -------------------------------------------------------
        // ------------------------------------------------------- MODULO USUARIO ICT -------------------------------------------------------


        public void agregarUsuarioICT(string alias, string contrasena, string primerNombre, string primerApellido, string segundoApellido, string fechaNac, string cedula)
        {
            try
            {
                this.abrirConexionSP("SPS_AgregarUsuarioICT");

                //agregar parametros
                comandosql.Parameters.Add("@alias", SqlDbType.VarChar).Value = alias;
                comandosql.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = contrasena;
                comandosql.Parameters.Add("@primerNombre", SqlDbType.VarChar).Value = primerNombre;
                comandosql.Parameters.Add("@primerApellido", SqlDbType.VarChar).Value = primerApellido;
                comandosql.Parameters.Add("@segundoApellido", SqlDbType.VarChar).Value = segundoApellido;
                comandosql.Parameters.Add("@cedula", SqlDbType.VarChar).Value = cedula;
                comandosql.Parameters.Add("@fechaNac", SqlDbType.Date).Value = fechaNac;

                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.agregarUsuarioICT()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }

        public void editarUsuarioICT(UsuarioICT admin)
        {
            try
            {
                this.abrirConexionSP("SPS_EditarUsuarioICT");
                
                //agregar parametros
                comandosql.Parameters.Add("@alias", SqlDbType.VarChar).Value = admin.alias;
                comandosql.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = admin.contrasena;
                comandosql.Parameters.Add("@primerNombre", SqlDbType.VarChar).Value = admin.primerNombre;
                comandosql.Parameters.Add("@primerApellido", SqlDbType.VarChar).Value = admin.primerApellido;
                comandosql.Parameters.Add("@segundoApellido", SqlDbType.VarChar).Value = admin.segundoApellido;
                comandosql.Parameters.Add("@cedula", SqlDbType.VarChar).Value = admin.cedula;
                comandosql.Parameters.Add("@fechaNac", SqlDbType.Date).Value = admin.fechaNac;

                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.editarUsuarioICT()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }

        public void borrarUsuarioICT(UsuarioICT usuario)
        {
            try
            {
                this.abrirConexionSP("SPS_BorrarUsuarioICT");

                //agregar parametros
                comandosql.Parameters.Add("@alias", SqlDbType.VarChar).Value = usuario.alias;

                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.borrarUsuarioICT()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }

        public List<UsuarioICT> seleccionaUsuariosICT()
        {
            try
            {
                this.abrirConexionSP("SPS_SeleccionarUsuariosICT");

                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");

                List<UsuarioICT> listaAdministradores = new List<UsuarioICT>();

                // se lee cada tupla de la tabla retornada una por una, .Read() retorna true cada tupla retornada y false si ya termino
                while (lectorsql.Read())
                {
                    UsuarioICT admin = new UsuarioICT();

                    //Alias, P.PrimerNombre, P.PrimerApellido, P.SegundoApellido, FechaNac, Cedula, IdPersona
                    admin.alias = (string)lectorsql["Alias"];
                    admin.primerNombre = (string)lectorsql["PrimerNombre"];
                    admin.segundoApellido = (string)lectorsql["SegundoApellido"];
                    admin.fechaNac = (DateTime)lectorsql["FechaNac"];
                    admin.cedula = (string)lectorsql["Cedula"];
                    admin.IdPersona = (int)lectorsql["IdPersona"];

                    listaAdministradores.Add(admin);
                    //lista.Add(mesa); // se agregar elemento a la lista que se retornara
                }
                return listaAdministradores;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.SeleccionaUsuariosICT()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }

        // ------------------------------------------------------- MODULO HIKERS -------------------------------------------------------
        // ------------------------------------------------------- MODULO HIKERS -------------------------------------------------------
        // ------------------------------------------------------- MODULO HIKERS -------------------------------------------------------

        public List<Hiker> seleccionaHikers()
        {
            try
            {
                this.abrirConexionSP("SPS_SeleccionarHikers");

                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");

                List<Hiker> listaHikers = new List<Hiker>();

                // se lee cada tupla de la tabla retornada una por una, .Read() retorna true cada tupla retornada y false si ya termino
                while (lectorsql.Read())
                {
                    Hiker hiker = new Hiker();

                    //Alias, P.PrimerNombre, P.PrimerApellido, P.SegundoApellido, FechaNac, Cedula, IdPersona
                    hiker.alias = (string)lectorsql["Alias"];
                    hiker.primerNombre = (string)lectorsql["PrimerNombre"];
                    hiker.segundoApellido = (string)lectorsql["SegundoApellido"];
                    hiker.fechaNac = (DateTime)lectorsql["FechaNac"];
                    hiker.cedula = (string)lectorsql["Cedula"];
                    hiker.IdPersona = (int)lectorsql["IdPersona"];
                    hiker.cuentaBancaria = (int)lectorsql["CuentaBancaria"];

                    listaHikers.Add(hiker);
                    //lista.Add(mesa); // se agregar elemento a la lista que se retornara
                }
                return listaHikers;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.seleccionaHikers()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }

        // ------------------------------------------------------- MODULO NIVELES DIFICULTAD -------------------------------------------------------
        // ------------------------------------------------------- MODULO NIVELES DIFICULTAD -------------------------------------------------------
        // ------------------------------------------------------- MODULO NIVELES DIFICULTAD -------------------------------------------------------

        public List<Dificultad> seleccionaNivelesDificultad()
        {
            try
            {
                this.abrirConexionSP("SPS_SeleccionarNivelesDificultad");

                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");

                List<Dificultad> listaDificultades = new List<Dificultad>();

                // se lee cada tupla de la tabla retornada una por una, .Read() retorna true cada tupla retornada y false si ya termino
                while (lectorsql.Read())
                {
                    Dificultad dificultad = new Dificultad();

                    dificultad.idNivel = (int)lectorsql["Nivel"];
                    dificultad.descripcion = (string)lectorsql["Descripcion"];

                    //agregar habilitado

                    listaDificultades.Add(dificultad);
                    //lista.Add(mesa); // se agregar elemento a la lista que se retornara
                }
                return listaDificultades;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.seleccionaDificultades()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }

        public void editarNivelDificultad(Dificultad dificultad)
        {
            try
            {
                this.abrirConexionSP("SPS_EditarNivelDificultad");

                //agregar parametros
                comandosql.Parameters.Add("@idPk", SqlDbType.Int).Value = dificultad.idNivel;
                comandosql.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = dificultad.descripcion;

                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.editarNivelDificultad()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }
        public void agregarNivelDificultad(Dificultad dificultad)
        {
            try
            {
                this.abrirConexionSP("SPS_AgregarNivelDificultad");

                //agregar parametros
                comandosql.Parameters.Add("@comentario", SqlDbType.VarChar).Value = dificultad.descripcion;

                // ejecuta el query y lo guarda en un objeto SqlDataReader llamado lectorsql
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
                MessageBox.Show("Error: " + e);
                throw new Exception("Ocurrio un error conexion.SQL.AgregarNivelDificultad()");
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }

        /*
        public void procedimientoEjemplo()
        {
            try
            {
                // abrir la conexion al servidor
                conexion.Open();

                // tira con el nombre del procedimiento
                String procedureName = "SPS_SeleccionarAmigos";
                comandosql = new SqlCommand(procedureName, conexion);
                comandosql.CommandType = CommandType.StoredProcedure;

                //agregar parametros
                comandosql.Parameters.Add("@alias", SqlDbType.VarChar).Value = alias;

                // ejecuta el query y lo guarda en un objeto SqlDataReader
                lectorsql = comandosql.ExecuteReader();
                Console.WriteLine("Ejecutado Correctamente");

                // se lee cada tupla de la tabla retornada una por una, .Read() retorna true cada tupla retornada y false si ya termino
                while (lectorsql.Read())
                {
                    Mesas mesa = new Mesas();
                    mesa.idMesa = int.Parse(sql.Lectorsql[0].ToString());

                    // se puede castear los parametros con el nombre de la columna
                    string columna = (string)lectorsql["columna"];

                    lista.Add(mesa); // se agregar elemento a la lista que se retornara
                }


            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                // cerrar el reader
                if (lectorsql != null)
                {
                    lectorsql.Close();
                }

                // cerrar conexion
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }
        */


    }
}
