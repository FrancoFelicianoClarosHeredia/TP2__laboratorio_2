    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Numero
    {
        /// <summary>
        /// atributo privado double
        /// </summary>
        private double _numero;

        /// <summary>
        /// constructor que setea en 0 cuando no tiene parametros
        /// </summary>
        public Numero() : this(0)
        {
        }

        /// <summary>
        /// constructor que setea el numero que entra como parametro al atributo privado
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this._numero = numero;
        }

        /// <summary>
        /// constructor que recibe un string y llama a la propiedad setnumero
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this.SetNumero= numero;
        }

        /// <summary>
        /// propiedad llama a la funcion validar numero
        /// </summary>
        private string SetNumero
        {
            set { this._numero = ValidarNumero(value); }
        }

        /// <summary>
        /// propiedad que devuelve el atributo actual double
        /// </summary>
        public double NumeroD
        {
            get { return this._numero; }
        }


        /// <summary>
        /// funcion de clase que recibe un string, realiza validaciones y siendo correcto el numero lo convierte en decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {

            if(binario == "Valor inválido")
            {
                return "Valor inválido";
            }

            int exponente = binario.Length - 1;
            int num_decimal = 0;

            for (int i = 0; i < binario.Length; i++)
            {
                if (int.Parse(binario.Substring(i, 1)) == 1)
                {
                    num_decimal = num_decimal + int.Parse(System.Math.Pow(2, double.Parse(exponente.ToString())).ToString());
                }
                exponente--;
            }
            return num_decimal.ToString();
        }

        /// <summary>
        /// funcion que recibe un string y valida que sea posible pasarla a double, caso contrario devuelve mensaje de error
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            double v;
            if (double.TryParse(numero, out v))
            {
                if(v<0)
                {
                    return "Valor inválido";
                }
                return DecimalBinario(v);
            }
            else
            {
                return "Valor inválido";
            }
        }

        /// <summary>
        /// funcion de clase que recibe un double y siendo correcto el numero devuelve el valor en binario
        /// </summary>
        /// <param name="Binario"></param>
        /// <returns></returns>
        public static string DecimalBinario(double Binario)
        {
            string num = "";
            if (Binario > 0)
            {
                while (Binario > 0)
                {
                    if (Binario % 2 == 0)
                    {
                        num = "0" + num;
                    }
                    else
                    {
                        num = "1" + num;
                    }

                    Binario = (int)Binario / 2;
                }
            }
            else if (Binario == 0)
            {
                num = "0";
            }
            else
            {
                num = "Valor inválido";
            }
            return num;
        }

        /// <summary>
        /// funcion que recibe un string y valida que se pueda pasar a double
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double numero;
            if (double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// operador +
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1._numero + n2._numero;
        }

        /// <summary>
        /// operador -
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }

        /// <summary>
        /// operador *
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }

        /// <summary>
        /// operador /
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2._numero == 0)
            {
                throw new DivideByZeroException();
            }
            else
            {
                return n1._numero / n2._numero;
            }
        }

    }
}
