using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciable
{
    public sealed class Profesor : Universitario
    {
        #region Atributos

        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #endregion

        #region Constructores
        static Profesor()
        {
            Profesor._random = new Random();
        }

        public Profesor() : base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
        }


        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
        }
        #endregion

        #region "Sobrecargas"

        /// <summary>
        /// Compara un profesor con una clase
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna true si el profesor da esa clase</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compara un profesor con una clase
        /// </summary>
        /// <param name="a">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Devuelve exactamente lo contrario al ==</returns>
        public static bool operator !=(Profesor a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Genera una clase random utilizando cualquiera de las iteraciones posibles
        /// </summary>
        private void _randomClase()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 3));
            this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 3));
        }

        /// <summary>
        /// Metodo sobreescrito
        /// </summary>
        /// <returns>Retorna string con las clases en las que es profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                retorno.AppendLine(item.ToString());
            }

            return retorno.ToString();
        }

        /// <summary>
        /// Metodo sobreescrito con los datos del Profesor
        /// </summary>
        /// <returns>Retorna string con los datos completos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append(base.MostrarDatos());
            retorno.Append(this.ParticiparEnClase());

            return retorno.ToString();
        }

        /// <summary>
        /// Hace publico el metodo MostrarDatos
        /// </summary>
        /// <returns>Retorna string</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
