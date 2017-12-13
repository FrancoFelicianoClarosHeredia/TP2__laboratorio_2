using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Hilo
{
    #region Delegados
    public delegate void DescargaEnProgreso(int enProgreso);
    public delegate void DescargaCompleta(string html);
    #endregion

    public class Descargador
    {
        #region Atributos
        private string html;
        private Uri direccion;
        #endregion

        #region Eventos
        public event DescargaEnProgreso EventoEnProgreso;
        public event DescargaCompleta EventohtmlFinalizado;
        #endregion

        /// <summary>
        /// Constructor de la clase Descargador
        /// </summary>
        /// <param name="direccion">Direccion de la pagina web que se quiere descargar.</param>
        public Descargador(Uri direccion)
        {
            this.html = direccion.AbsolutePath;
            this.direccion = direccion;
        }

        /// <summary>
        /// Se inicia la descarga del codigo fuente de la url ingresada.
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClientDownloadProgressChanged);
                cliente.DownloadStringCompleted += new DownloadStringCompletedEventHandler(WebClientDownloadCompleted);

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        /// <summary>
        /// Lanza un evento que actualiza el progreso de la descarga.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.EventoEnProgreso(e.ProgressPercentage);
        }

        /// <summary>
        /// Lanza un evento que se ejecuta cuando la pagina a descargar está completa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.EventohtmlFinalizado(e.Result);
        }
    }
}
