using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_Class
{
    public class Numero
    {
        private double _numero;

        /// <summary>
        /// Metodo publico que devuelve el valor del atributo _numero 
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        {
            return this._numero;
        }

        /// <summary>
        /// Constructor por defecto que inicializa el valor del atributo _numero en 0
        /// </summary>
        public Numero()
        {
            _numero = 0;
        }

        /// <summary>
        /// Constructor que recibe un double y asigna su valor al atributo _numero
        /// </summary>
        /// <param name="numero">Valor double utilizado para asignarlo al atributo _numero</param>
        public Numero(double numero)
        {
            _numero = numero;
        }

        /// <summary>
        /// Constructor que recibe un string, el cual se valida y luego lo asigna al atributo _numero 
        /// </summary>
        /// <param name="numero">String a validar antes de asignar</param>
        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        /// <summary>
        /// Metodo que recibe un string, el cual convertira a double para luego validar si el mismo es mayor a cero; en caso de error retorna cero
        /// </summary>
        /// <param name="numeroString">String con el numero a validar</param>
        /// <returns>Retorna el valor numero convertido a double; de lo contratio retorna cero</returns>
        private static double validarNumero(string numeroString)
        {
            double retorno = 0;
            double doble;

            if (double.TryParse(numeroString, out doble))
            {
                if (doble > 0)
                {
                    retorno = doble;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Le asigna al atributo _numero, el valor ya validado
        /// </summary>
        /// <param name="numero">String que contiene el numero ingresado</param>
        private void setNumero(string numero) //Este será el único lugar donde se podrá utilizar el método validarNumero.
        {
            if(validarNumero(numero) != 0)
            {
                double convertir;
                if (double.TryParse(numero, out convertir))
                {
                    _numero = convertir;
                }
            }
        }
    }
}
