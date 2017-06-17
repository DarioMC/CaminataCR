using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityObjects;
using BusinessLayer;

namespace AdminPlataforma
{
    public partial class Bitacora : Form
    {
        public Bitacora()
        {
            InitializeComponent();
            this.comboBoxObjeto.Items.Add("NivelCalidad");
            this.comboBoxObjeto.Items.Add("Administrador");
            this.comboBoxObjeto.Items.Add("NivelPrecio");
            this.comboBoxObjeto.Items.Add("TipoCaminata");
            this.comboBoxObjeto.Items.Add("NivelDificultad"); 
            this.comboBoxObjeto.Items.Add("UsuarioICT");


            this.comboBoxTipoCambio.Items.Add("Borrado");
            this.comboBoxTipoCambio.Items.Add("Registro");
            this.comboBoxTipoCambio.Items.Add("Actualizacion");


            dateTimePickerFechaInicial.Value = DateTime.Today.AddYears(-100);
            this.textBoxHoraInicial.Text = "0";
            this.textBoxHoraFinal.Text = "23";
        }


        private void buttonCargaDatosUICT_Click(object sender, EventArgs e)
        {
            //DateTime fechaInicio, DateTime fechaFinal, string tipoAccion, string objeto, int horaInicial, int horaFinal
            try
            {
                listViewBitacora.Items.Clear();
                DateTime fechaInicio = dateTimePickerFechaInicial.Value;
                DateTime fechaFinal = dateTimePickerFechaFinal.Value;
                string tipoAccion = comboBoxTipoCambio.Text;
                string objeto = comboBoxObjeto.Text;
                int horaInicial = int.Parse(textBoxHoraInicial.Text);
                int horaFinal = int.Parse(textBoxHoraFinal.Text);
                List<EntradaBitacora> entradas = SesionActual.getInstance().seleccionarBitacora(fechaInicio, fechaFinal, tipoAccion, objeto, horaInicial, horaFinal);
                foreach (EntradaBitacora entrada in entradas)
                {
                    ListViewItem linea = new ListViewItem(entrada.descripcion);
                    linea.SubItems.Add(entrada.objeto);
                    linea.SubItems.Add(entrada.tipoAccion);
                    linea.SubItems.Add(entrada.fecha.ToString());
                    listViewBitacora.Items.Add(linea);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Datos ingresados son invalidos");
                MessageBox.Show(ex.ToString());
            }


        }

        private void Bitacora_Load(object sender, EventArgs e)
        {

        }
    }
}
