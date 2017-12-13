using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciable
{
    public class Jornada
    {
        #region Atributos

        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #endregion

        #region Constructores

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura para atributo _alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
            set
            {
                this._alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para atributo _clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this._clase;
            }
            set
            {
                this._clase = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para atributo _instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this._instructor;
            }
            set
            {
                this._instructor = value;
            }
        }

        #endregion

        #region "Sobrecargas"

        /// <summary>
        /// recorre la lista de alumnos en la jornada y los compara con el que es pasado por parametro
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Devuelve true si dicho alumno esta en la lista</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// recorre la lista de alumnos en la jornada y los compara con el que es pasado por parametro
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Devuelve exactamente lo contrario al ==</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada solo si no estaba
        /// </summary>
        /// <param name="a">Jornada</param>
        /// <param name="b">Alumno</param>
        /// <returns>Devuelve la jornada coon el nuevo alumno si es que no estaba</returns>
        public static Jornada operator +(Jornada a, Alumno b)
        {
            if (!(a == b))
            {
                a.Alumnos.Add(b);
            }
            return a;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Hace publicos los datos de la jornada
        /// </summary>
        /// <returns>Retorna string con los datos de todos los alumnos y profesores de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASE DE " + this._clase.ToString() + " POR " + this._instructor.ToString());

            foreach (Alumno item in this._alumnos)
            {
                sb.Append(item.ToString());
            }
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }

        /// <summary>
        /// Guarda en un archivo de texto los datos de la jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\jornada.txt";
            Texto text = new Texto();

            if (text.guardar(ruta, jornada.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Lee de un archivo de texto los datos de la jornada
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public static bool Leer(out string datos)
        {
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Jornada.txt";
            Texto text = new Texto();

            if (text.leer(ruta, out datos))
            {
                return true;
            }

            return false;
        }

        #endregion

    }
}
