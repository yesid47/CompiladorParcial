using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorV1.Cache
{
    class Linea
    {
        public int Numero { get; set; }
        public String Contenido { get; set; }

        private Linea(int numero, string contenido)
        {
            this.Numero = numero;
            this.Contenido = contenido;
        }

        public Linea()
        {
        }
    }
}
