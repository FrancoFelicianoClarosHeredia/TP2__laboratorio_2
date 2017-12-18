using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
        public static class Calculadora
        {
            /// <summary>
            /// recibe 2 numeros y un operador, si el operador es valido
            /// se pisa a si mismo y le asigna el valor validado, si este 
            /// no es un operador con un caracter valido, este se 
            /// convertira en un signo + y se pisa a si mismo,
            /// entra a un switch, realizando la operacion necesaria
            /// dependiendo de su operador y la asigna a una variable 
            /// de retorno(valida division por 0)
            /// </summary>
            /// <param name="numero1"></param>
            /// <param name="numero2"></param>
            /// <param name="operador"></param>
            /// <returns></returns>
            public static double Operar(Numero numero1, Numero numero2, string operador)
            {
                double retorno;

                operador = validarOperador(operador);

                switch (operador)
                {
                    case "/":
                        if (numero2.NumeroD == 0)
                            retorno = 0;
                        else
                            retorno = numero1.NumeroD / numero2.NumeroD;
                        break;

                    case "*":
                        retorno = numero1.NumeroD * numero2.NumeroD;
                        break;

                    case "-":
                        retorno = numero1.NumeroD - numero2.NumeroD;
                        break;

                    default:
                        retorno = numero1.NumeroD + numero2.NumeroD;
                        break;
                }
                return retorno;
            }

            /// <summary>
            /// valida el operador que recibe por parametro,si no es "/","*","-"
            /// retorna +
            /// </summary>
            /// <param name="operador"></param>
            /// <returns></returns>
            public static string validarOperador(string operador)
            {
                if (operador == "/" || operador == "*" || operador == "-")
                    return operador;
                return "+";

        }
    }
}
