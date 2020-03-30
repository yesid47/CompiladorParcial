using CompiladorV1.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorV1.ManejadorErrores
{
    public class Error: ComponenteLexico
    {
        public String Falla { get; set; }
        public String Causa { get; set; }
        public String Solucion { get; set; }
        public int NumeroLinea { get; }
        public int PosicionInicial { get; }
        public int PosicionFinal { get; }
        public TipoError Tipo { get; set; }


       

        public Error (String lexema, Categoria categoria, int numeroLinea, int posicionInicial, int posicionFinal, string falla, string causa, string solucion, TipoError tipoError)
        {
            Lexema = lexema;
            Categoria = categoria;
            NumeroLinea = numeroLinea;
            PosicionFinal = posicionFinal;
            PosicionInicial = posicionInicial;
            Falla = falla;
            Causa = causa;
            Solucion = solucion;
            Tipo = tipoError;

        }

        public static Error CrearErrorLexico(String lexema, Categoria categoria, int numeroLinea, int posicionInicial, int posicionFinal, string falla, string causa, string solucion)
        {
            return new Error(lexema, categoria, numeroLinea, posicionInicial, posicionFinal, falla, causa, solucion, TipoError.LEXICO);

        }

        public static Error CrearErrorSemantico(String lexema, Categoria categoria, int numeroLinea, int posicionInicial, int posicionFinal, string falla, string causa, string solucion, TipoError tipoError)
        {
            return new Error(lexema, categoria, numeroLinea, posicionInicial, posicionFinal, falla, causa, solucion, TipoError.SEMANTICO);

        }

        public static Error CrearErrorSintactico(String lexema, Categoria categoria, int numeroLinea, int posicionInicial, int posicionFinal, string falla, string causa, string solucion, TipoError tipoError)
        {
            return new Error(lexema, categoria, numeroLinea, posicionInicial, posicionFinal, falla, causa, solucion, TipoError.SINTACTICO);

        }
    }
}
