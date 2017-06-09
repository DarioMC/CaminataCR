using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionSQL;
using EntityObjects;

namespace BusinessLayer
{
    public class ModNivDificultad
    {
        public List<Dificultad> listaDificultades = new List<Dificultad>();

        public ModNivDificultad()
        {
            cargaNiveles();
        }

        public void cargaNiveles()
        {
            listaDificultades = conexionSQL.getInstance().seleccionaNivelesDificultad();
        }

        public void editarNivel(Dificultad nivel)
        {
            conexionSQL.getInstance().editarNivelDificultad(nivel);
        }

        public void agregarNivel(Dificultad nivel)
        {
            conexionSQL.getInstance().agregarNivelDificultad(nivel);
        }
    }
}
