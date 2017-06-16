using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityObjects;
using ConexionSQL;

namespace BusinessLayer
{
    public class ModNivPrecio
    {
        public List<NivelPrecio> listaNivelPrecio = new List<NivelPrecio>();

        public ModNivPrecio()
        {
            cargaNiveles();
        }

        public void cargaNiveles()
        {
            listaNivelPrecio = conexionSQL.getInstance().seleccionaNivelPrecio();
        }

        public void agregaNivelPrecio(NivelPrecio nivel)
        {
            conexionSQL.getInstance().agregarNivelPrecio(nivel);
        }

        public void editarNivelPrecio(NivelPrecio nivel)
        {
            conexionSQL.getInstance().editarNivelPrecio(nivel);
        }
    }
}
