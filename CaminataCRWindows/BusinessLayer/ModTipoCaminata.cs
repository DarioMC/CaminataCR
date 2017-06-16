using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityObjects;
using ConexionSQL;

namespace BusinessLayer
{
    public class ModTipoCaminata
    {
        public List<TipoCaminata> listaTiposCaminata = new List<TipoCaminata>();

        public ModTipoCaminata()
        {
            cargaTipoCaminatas();
        }

        public void cargaTipoCaminatas()
        {
            listaTiposCaminata = conexionSQL.getInstance().seleccionaTiposCaminata();
        }

        public void editarTipo(TipoCaminata tipo)
        {
            conexionSQL.getInstance().editarTipoCaminata(tipo);
        }

        public void agregarTipo(TipoCaminata tipo)
        {
            conexionSQL.getInstance().agregarTipoCaminata(tipo);
        }
    }
}
