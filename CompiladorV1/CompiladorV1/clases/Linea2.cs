using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorV1.clases
{
    class Linea2
    {
        private int numero;
        private string contenido;

        public Linea2(int numero, string contenido)
        {
            this.Numero = numero;
            this.contenido = contenido;
        }

        public Linea2()
        {

        }

        public int Numero { get => numero; set => numero = value; }
        public string Contenido { get => contenido; set => contenido = value; }
    }
}
