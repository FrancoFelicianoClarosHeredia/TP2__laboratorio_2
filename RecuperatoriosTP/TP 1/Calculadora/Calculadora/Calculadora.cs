using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_Class
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operacion elegida entre dos numeros
        /// </summary>
        /// <param name="numero1">Primer operando</param>
        /// <param name="numero2">Segundo operando</param>
        /// <param name="operador">Operacion matematica</param>
        /// <returns></returns>
        public static double operar(Numero numero1, Numero numero2, string operador) //Si no puede operar (división por 0), retornará 0.
        {
            double resultado = 0;

            switch (operador)
            {
                case "+":
                    
                    resultado = numero1.getNumero() + numero2.getNumero();
                    break;

                case "-":

                    resultado = numero1.getNumero() - numero2.getNumero();
                    break;

                case "*":

                    resultado = numero1.getNumero() * numero2.getNumero();
                    break;

                case "/":

                    if (numero2.getNumero() != 0)
                    {
                        resultado = numero1.getNumero() / numero2.getNumero();
                    }
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida que la operacion matematica sea correcta devolviendolo, en caso contrario, retorna la operacion suma
        /// </summary>
        /// <param name="operador">String que contiene la operacion elegida</param>
        /// <returns></returns>
        public static string validarOperador(string operador) // Validará que el operador sea un caracter válido, caso contrario retornará “+”.
        {
            if(operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                return operador = "+";
            }

            return operador;
        }
    }
}
