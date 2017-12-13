using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;


namespace Clases_Instanciable
{
    public sealed class Alumno : Universitario
    {
        #region Enumerador

        public enum EEstadoCuenta { Becado, AlDia, Deudor }

        #endregion

        #region Atributos

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #endregion

        #region Constructores
        public Alumno() : base() { }

        public Alumno(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(legajo, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region "Sobrecargas"

        /// <summary>
        /// Compara Alumno con clase
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si cursa la clase y no tiene deuda, caso contrario, false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Compara Alumno con clase
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Devuelve exactamente lo contrario al ==</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo sobreescrito. Retorna las clases qut toma el alumno
        /// </summary>
        /// <returns>Retorna string con la clase que cursa</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma;
        }

        /// <summary>
        /// Metodo sobreescrito. Muestra los datos del alumno, de universitario y de persona.
        /// </summary>
        /// <returns>Retorna un string con los datos completos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ALUMNOS: ");
            sb.AppendLine(base.MostrarDatos());
            if (this._estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine("ESTADO DE CUENTA: " + "Cuota al día");
            }
            else
            {
                sb.AppendLine("ESTADO DE CUENTA " + this._estadoCuenta);
            }
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Hace publicos los datos del metodo MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

    }
}
