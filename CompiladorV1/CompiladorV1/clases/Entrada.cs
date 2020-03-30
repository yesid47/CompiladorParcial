using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorV1.clases
{
    sealed class Entrada
    {
        private String tipo;
        private List<Linea2> lineas= new List<Linea2>();
        private readonly static Entrada _instance= new Entrada();

        private Entrada()
        {

        }
        public static Entrada Instance
        {
            get
            {
                return _instance;
            }
        }


        public void agregarLinea(Linea2 linea)
        {
            if (linea != null)
            {
                lineas.Add(linea);
            }
        }

        public Linea2 obtenerLinea(int numero)
        {
            Linea2 resultado = null;
            foreach(Linea2 linea in lineas)
            {
                if (linea.Numero == numero)
                {
                    resultado = linea;
                }
            }
            return resultado;
        }

        public void reiniciarEntrada()
        {
            if(lineas.Count != 0)
            {
                lineas.Clear();
            }
        }

        public List<Linea2> obtenerLineas()
        {
            /*List<Linea> listaLineas=null;

            foreach(int numline in lineasEntrada)
            {
                listaLineas.Add(obtenerLinea(numline));
            }*/


            return lineas;
        }
    }
}
