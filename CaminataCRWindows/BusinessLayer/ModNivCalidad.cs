using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityObjects;
using ConexionSQL;

namespace BusinessLayer
{
    public class ModNivCalidad
    {
        public List<NivelCalidad> listaNivelCalidad = new List<NivelCalidad>();


        public ModNivCalidad()
        {
            cargaNiveles();
        }

        public void cargaNiveles()
        {
            listaNivelCalidad = conexionSQL.getInstance().seleccionaNivelCalidad();
        }
        
        public void agregaNivelCalidad(NivelCalidad nivel)
        {
            conexionSQL.getInstance().agregarNivelCalidad(nivel);
        }

        public void editarNivelCalidad(NivelCalidad nivel)
        {
            conexionSQL.getInstance().editarNivelCalidad(nivel);
        }
    }
}
