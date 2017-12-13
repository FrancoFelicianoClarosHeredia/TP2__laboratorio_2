using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region "Enumerados"
        public enum ENacionalidad { Argentino, Extranjero }
        #endregion

        #region "Atributos"
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;
        #endregion

        #region "Propiedades"
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = Persona.ValidarNombreApellido(value);
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = Persona.ValidarNombreApellido(value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }


        public string StringToDNI
        {
            set
            {
                this._dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region "Constructores"

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Valida que el nombre y el apellido este compuesto solo letras
        /// </summary>
        /// <param name="dato">Recibe el nombre y el apellido a validar</param>
        /// <returns>Retorna el nombre o el apellido en caso de estar bien, sino retorna un string vacio</returns>
        private static string ValidarNombreApellido(string dato)
        {
            string retorno = null;
            if (dato != null)
            {
                foreach (char letra in dato)
                {
                    if (!char.IsLetter(letra))
                    {
                        retorno = "";
                        break;
                    }
                    else
                    {
                        retorno = dato;
                    }
                }
            }
            else
            {
                retorno = "";
            }

            return retorno;
        }

        /// <summary>
        /// Valida que el DNI este dentro del rango numerico permitido segun la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad del dni</param>
        /// <param name="dato">DNI, valor numerico a validar</param>
        /// <returns>DNI validado si todo esta correcto, o 0(cero) en caso de error</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if ((dato < 1 || dato > 89999999))
                    {
                        throw new DniInvalidoException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if ((dato < 90000000))
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                default:
                    break;
            }
            return dato;
        }

        /// <summary>
        /// Convierte un string a int, de ser posible, llama a su sobrecarga
        /// </summary>
        /// <param name="nacionalidad">recibe la nacionalidad a comparar</param>
        /// <param name="dni">recibe el dni a convertir</param>
        /// <returns>Retorna el dni, en caso de error, retorna 0</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dni)
        {
            int retorno = 0;

            if (int.TryParse(dni, out retorno))
            {
                retorno = ValidarDni(nacionalidad, retorno);
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del metodo ToString, que muestra unicamente los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.Append("NACIONALIDAD: " + this.Nacionalidad.ToString());
            return sb.ToString();
        }

        #endregion
    }
}
