using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _rutaDeArchivo;

        /// <summary>
        /// Constructor de la clase Texto.
        /// Inicializa el atributo _rutaDeArchivo con el ruta del archivo de texto.
        /// </summary>
        /// <param name="archivo">Direccion del archivo, del cual se va a leer y guardar los datos del historial.</param>
        public Texto(string archivo)
        {
            this._rutaDeArchivo = archivo;
        }

        /// <summary>
        /// Retorna true si guarda datos en un archivo de texto, si falla la escritura lanza una excepcion.
        /// </summary>
        /// <param name="datos">String donde se guarda la informacion del archivo.</param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(this._rutaDeArchivo, true))
                {
                    escritor.WriteLine(datos);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Retorna true si lee datos en un archivo de texto, si falla la lectura lanza una excepcion.
        /// </summary>
        /// <param name="datos">Lista donde se lee la informacion del archivo.</param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            datos = new List<string>();

            try
            {
                using (StreamReader lector = new StreamReader(this._rutaDeArchivo))
                {
                    while (!lector.EndOfStream)
                    {
                        datos.Add(lector.ReadLine());
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
