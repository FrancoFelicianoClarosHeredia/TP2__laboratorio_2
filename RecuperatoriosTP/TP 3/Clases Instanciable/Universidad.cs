using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciable
{
    public class Universidad
    {
        #region Enumerados

        public enum EClases { Programacion, Legislacion, Laboratorio, SPD }

        #endregion

        #region Atributos

        private List<Alumno> _alumnos;
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto. Inicializa las listas
        /// </summary>
        public Universidad()
        {
            this._jornada = new List<Jornada>();
            this._profesores = new List<Profesor>();
            this._alumnos = new List<Alumno>();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura para atributo alumnos
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
        /// Propiedad de lectura y escritura para atributo alumnos
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this._profesores;
            }
            set
            {
                this._profesores = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para atributo alumnos
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this._jornada;
            }
            set
            {
                this._jornada = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la jornada en el indice deseado
        /// </summary>
        /// <param name="i">Recibe el indice de la jornada a utilizar</param>
        /// <returns>Retorna la jornada del indice pedido</returns>
        public Jornada this[int i]
        {
            get
            {
                return this._jornada[i];
            }
            set
            {
                this._jornada[i] = value;
            }
        }

        #endregion

        #region "Sobrecargas"

        /// <summary>
        /// recorre la lista de alumnos en la Universidad y los compara con el que es pasado por parametro
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Devuelve true si dicho alumno esta en la lista</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in g._alumnos)
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
        /// recorre la lista de alumnos en la Universidad y los compara con el que es pasado por parametro
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Devuelve exactamente lo contrario al ==</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// recorre la lista de Profesores en la Universidad y los compara con el que es pasado por parametro
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>Devuelve true si dicho Profesor esta en la lista</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor item in g._profesores)
            {
                if (item == i)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// recorre la lista de Profesores en la Universidad y los compara con el que es pasado por parametro
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>Devuelve exactamente lo contrario al ==</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Compara universidad con clase y busca al profesor que pueda darla
        /// En caso de no encontrarlo arroja excepcion
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna al primer profesor que pueda dar la clase</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor item in g._profesores)
            {
                if (item == clase)
                {
                    if (!(object.Equals(item, null)))
                    {
                        return item;
                    }
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Compara universidad con clase y busca al profesor que no de dicha case
        /// En caso de no encontrar profesor que no de dicha clase arroja excepcion
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna al primer profesor que no pueda dar la clase</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor item in g._profesores)
            {
                if (item != clase)
                {
                        return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Si el alumno no esta en la Universidad, lo agrega.
        /// Si ya se encuentra en la Universidad, arroja excepcion
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Retorna la universidad con o sin alumno</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g._alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return g;
        }

        /// <summary>
        /// Si el profesor no esta en la Universidad, lo agrega.
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>Retorna la Universidad, con o sin el nuevo profesor</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g._profesores.Add(i);
            }
            return g;
        }

        /// <summary>
        /// Busca un profesor de la Universidad que pueda dar la clase.
        /// Si lo encuentra crea la jornada, 
        /// y agrega a los alumnos que la puedan cursar
        /// </summary>
        /// <param name="g">Universiadad a utilizar</param>
        /// <param name="clase">Clase a agregar</param>
        /// <returns>Retorna la universidad, con o sin la nueva jornada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada aux = new Jornada(clase, (g == clase));
            foreach (Alumno item in g._alumnos)
            {
                if (item == clase)
                {
                    aux.Alumnos.Add(item);
                }
            }
            g.Jornadas.Add(aux);

            return g;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Crea un string con los datos de todas las jornadas de la universidad
        /// </summary>
        /// <param name="gim">Universidad a utilizar</param>
        /// <returns>Retorna string con los datos</returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            foreach (Jornada item in gim._jornada)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Hace publico el metodo MostrarDatos
        /// </summary>
        /// <returns>Retorna string con los datos de la universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Guarda los datos de la universidad en un archivo XML
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            bool flag = false;

            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Universidad.xml";
            Xml<Universidad> xml = new Xml<Universidad>();
            try
            {
                xml.guardar(ruta, gim);
                flag = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return flag;
        }

        /// <summary>
        /// Lee los datos de una universidad desde un archivo XML
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Leer(out Universidad gim)
        {
            bool flag = false;
            Xml<Universidad> xml = new Xml<Universidad>();

            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Universidad.xml";
                xml.leer(ruta, out gim);
                flag = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return flag;
        }

        #endregion

    }
}
