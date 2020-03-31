using CompiladorV1.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorV1.TablaSimbolos
{
    public class TablaSimbolos
    {
        private static Dictionary<String, List<ComponenteLexico>> simbolos
            = new Dictionary<string, List<ComponenteLexico>>();


        private TablaSimbolos()
        {
        }

        private static List<ComponenteLexico> ObtenerSimbolos(string clave)
        {
            if (!simbolos.ContainsKey(clave))
           {
                simbolos.Add(clave, new List<ComponenteLexico>());
           }
          
            return simbolos[clave];
        }

        public static void Agregar(ComponenteLexico componente)
        {
           if(componente != null && !componente.Lexema.Equals("") && componente.Tipo.Equals(TipoComponente.SIMBOLO))
            {
                ObtenerSimbolos(componente.Lexema).Add(componente);
            }
        }

        public static List<ComponenteLexico> ObtenerTodosSimbolos()
        {
            return simbolos.Values.SelectMany(componente => componente).ToList();
        }

        public static void Limpiar()
        {
            simbolos.Clear();
        }

    }
}
