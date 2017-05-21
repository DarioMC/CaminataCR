using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConexionSQL
{

    public class conexionSQL
    {
        private static SqlConnection conexion = new SqlConnection("Server=186.15.160.14,1433; Database=Monchemos; User Id=Emma; password= 0000");
        private static SqlCommand comandosql;
        private static SqlDataReader lectorsql;

        public conexionSQL()
        {

        }

        public void procedimientoEjemplo()
        {
            String procedureName = "SPS_SeleccionarAmigos";
            comandosql = new SqlCommand(procedureName, conexion);
            comandosql.CommandType = CommandType.StoredProcedure;
            comandosql.Parameters.Add("@alias", SqlDbType.VarChar).Value = alias;
            ConectarDb();
        }
    }
}
