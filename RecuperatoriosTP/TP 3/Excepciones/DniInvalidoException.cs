using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string _mensajeBase;

        public DniInvalidoException() : base()
        {
            this._mensajeBase = "Dni invalido";
        }

        public DniInvalidoException(Exception e) : base("Dni invalido", e) { }

        public DniInvalidoException(string message) : base(message)
        {
            this._mensajeBase = "Dni invalido";
        }

        public DniInvalidoException(string message, Exception e) : base(message, e)
        {
            this._mensajeBase = "Dni invalido";
        }
    }
}
