using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorV1.Transversal
{
    public class ComponenteLexico
    {
        public Categoria Categoria { get; internal set; }
        public String Lexema { get; set; }
        public Categoria categoria { get; set; }
        public int NumeroLinea { get; set; }
        public int PosicionInicial { get; set; }
        public int PosicionFinal { get; set; }

        public TipoComponente Tipo { get; set; }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("Tipo Componente: " + Tipo.ToString() + "\n");
            retorno.Append("Categoría: " + Categoria + "\n");
            retorno.Append("Lexema: " + Lexema +"\n");
            retorno.Append("Numero linea: " + NumeroLinea + "\n");
            retorno.Append("Posición inicial: " + PosicionInicial + "\n");
            retorno.Append("Posición final: " + PosicionFinal + "\n");

            return base.ToString();
        }


    }
}
