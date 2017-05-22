using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ConexionSQL
{

    public class conexionSQL
    {
        // crear un singleton
        private static conexionSQL singletonInstance = null;

        private static SqlConnection conexion = new SqlConnection("Server=186.15.160.14,1433; Database=Caminata; User Id=Emma; password= 0000");
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

        public void AgregarAdministrador(string alias, string contrasena, string primerNombre, string primerApellido, string segundoApellido, string fechaNac, string cedula)
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
            catch(Exception e)
            {
                MessageBox.Show("Error: " + e);
            }
            // terminar la conexion despues de manejar los datos de la tabla
            finally
            {
                this.terminaConexionSO();
            }
        }


        public int ExisteAlias(string alias)
        {
            try
            {
                this.abrirConexionSP("SPS_ExisteAlias");

                //agregar parametros
                comandosql.Parameters.Add("@alias", SqlDbType.VarChar).Value = alias;

                // asocia el parametro de regreso
                var returnParameter = comandosql.Parameters.Add("@idOrden", SqlDbType.Int);
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
