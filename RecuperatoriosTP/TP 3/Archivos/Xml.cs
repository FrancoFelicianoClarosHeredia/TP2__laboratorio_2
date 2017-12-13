using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        #region Metodos

        /// <summary>
        /// Abre el archivo para escritura, de no encontrarlo, lo crea
        /// Guarda los datos en el archivo y lo cierra.
        /// En caso de haber error, lanza excepcion
        /// </summary>
        /// <param name="archivo">Nombre y direccion del archivo</param>
        /// <param name="datos">Datos a guardar de tipo Generico</param>
        /// <returns>Retorna true si no hubo errores</returns>
        public bool guardar(string archivo, T datos)
        {
            bool flag = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    XmlSerializer serializar = new XmlSerializer(typeof(T));
                    serializar.Serialize(sw, datos);
                    flag = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return flag;
        }

        /// <summary>
        /// Abre el archivo en modo lectura.
        /// En caso de error lanza excepcion
        /// </summary>
        /// <param name="archivo">Nombre y direccion del archivo</param>
        /// <param name="datos">Aux de salida de tipo generico para guardar los datos leidos</param>
        /// <returns>Retorna true si no hubo errores</returns>
        public bool leer(string archivo, out T datos)
        {
            bool flag = false;
            try
            {
                using (XmlTextReader xArchivo = new XmlTextReader(archivo))
                {
                    XmlSerializer deserializar = new XmlSerializer(typeof(T));
                    datos = (T)deserializar.Deserialize(xArchivo);
                    flag = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return flag;
        }
        #endregion
    }
}
