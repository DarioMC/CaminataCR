using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionSQL;
using EntityObjects;

namespace BusinessLayer
{
    public class ModUsuariosRegulares
    {
        public List<Hiker> listaHikers = new List<Hiker>();

        public ModUsuariosRegulares()
        {
            cargaUsuarios();
        }

        public void cargaUsuarios()
        {
            listaHikers = conexionSQL.getInstance().seleccionaHikers();
        }


    }
}
