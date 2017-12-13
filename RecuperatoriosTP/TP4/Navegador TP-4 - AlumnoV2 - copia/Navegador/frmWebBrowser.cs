using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;

        /// <summary>
        /// Inicializa los componentes del formulario.
        /// </summary>
        public frmWebBrowser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Configuramos el formato de texto del textBox donde ingresamos el url.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        /// <summary>
        /// Borra el texto por defecto que aparece en el textbox, y le asigna el color negro al buscador del navegador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Escribe un mensaje por defecto en el caso que no se haya escrito nada en el textBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        /// <summary>
        /// Selecciona todo la url que escribimos en el textBox cuando se hace click sobre la misma.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);
        /// <summary>
        /// Metodo que se encarga de ir actualizando la barra de progreso hasta que termina.
        /// </summary>
        /// <param name="progreso"></param>
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }

        delegate void FinDescargaCallback(string html);
        /// <summary>
        /// Metodo que se encarga de cargar el url en el ritchTextBox cuando la descarga finaliza.
        /// </summary>
        /// <param name="html"></param>
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        /// <summary>
        /// Descarga como texto la url ingresada y guarda la direccion en un archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIr_Click(object sender, EventArgs e)
        {
            try
            {
                this.archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

                this.txtUrl.Text = this.txtUrl.Text.ToLower();

                if (!(this.txtUrl.Text.StartsWith("http://")))
                {
                    this.txtUrl.Text = "http://" + this.txtUrl.Text;
                }

                Uri uri = new Uri(this.txtUrl.Text);
                Descargador descargador = new Descargador(uri);
                descargador.EventoEnProgreso += new DescargaEnProgreso(this.ProgresoDescarga);
                descargador.EventohtmlFinalizado += new DescargaCompleta(this.FinDescarga);

                Thread hilo = new Thread(descargador.IniciarDescarga);
                hilo.Start();

                this.archivos.guardar(this.txtUrl.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra el historial de paginas web ingresadas en una nueva ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial historial = new frmHistorial();

            historial.ShowDialog();
        }
    }
}
