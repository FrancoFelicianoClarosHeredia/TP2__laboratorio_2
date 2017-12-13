using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculadora_Class;

namespace Prueba_Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Numero num1 = new Numero("12");
            Numero num2 = new Numero("0");
            double resultado = Calculadora.operar(num1, num2, "/");

            Console.WriteLine("La operacion es igual a " + resultado);
            Console.Read();
        }
    }
}
