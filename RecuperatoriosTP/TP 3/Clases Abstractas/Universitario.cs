using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        protected int _legajo;
        #endregion

        #region Constructores
        public Universitario() : base() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }
        #endregion

        #region Sobrecarga de Operadores

        /// <summary>
        /// Compara a dos Universitarios. Serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="a">Universitario uno</param>
        /// <param name="b">Universitario dos</param>
        /// <returns>Retorna booleano</returns>
        public static bool operator ==(Universitario a, Universitario b)
        {

            return ((a is Universitario && b is Universitario) && ((a._legajo == b._legajo) || (a.DNI == b.DNI)));
        }

        /// <summary>
        /// Compara a dos Universitarios. Serán distintos si y sólo si no son del mismo Tipo y su Legajo o DNI no son iguales.
        /// </summary>
        /// <param name="a">Universitario uno</param>
        /// <param name="b">Universitario dos</param>
        /// <returns>Retorna booleano</returns>

        public static bool operator !=(Universitario a, Universitario b)
        {
            return !(a == b);
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Compara cualquier tipo de objeto con el de referencia
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>Retorna booleano</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj is Universitario)
            {
                retorno = (this == (Universitario)obj);
            }
            return retorno;
        }

        /// <summary>
        /// Metodo abstracto que muestra a que clases participa el alumno
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Muestra los datos de la Persona y del Universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NUMERO: " + this._legajo);

            return sb.ToString();
        }
        #endregion
    }
}
