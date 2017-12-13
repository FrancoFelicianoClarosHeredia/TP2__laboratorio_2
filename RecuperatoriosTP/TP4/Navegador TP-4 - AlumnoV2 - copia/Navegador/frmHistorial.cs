using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        /// <summary>
        /// Inicializa los componentes del formulario.
        /// </summary>
        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se le agrega al historial todas las paginas buscadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
                Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

                List<string> historial = new List<string>();

                archivos.leer(out historial);

                foreach (string direccion in historial)
                {
                    if (direccion != null)
                    {
                        this.lstHistorial.Items.Add(direccion);
                    }
                }
        }

    }
}
