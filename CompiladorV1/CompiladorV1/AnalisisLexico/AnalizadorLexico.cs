using CompiladorV1.Cache;
using CompiladorV1.ManejadorErrores;
using CompiladorV1.TablaSimbolos;
using CompiladorV1.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorV1.AnalisisLexico
{
    class AnalizadorLexico
    {
        private int numeroLineaActual;
        private int puntero;
        private String caracterActual;
        private Linea lineaActual;
        private String lexema;

        public AnalizadorLexico()
        {
            CargarNuevaLinea();
            //numeroLineaActual;
        }

        private void CargarNuevaLinea()
        {
            numeroLineaActual= numeroLineaActual +1;
            lineaActual = Cache.Cache.ObtenerLinea(numeroLineaActual);

            if (lineaActual.Contenido.Equals("@EOF@"))
            {
                numeroLineaActual = lineaActual.Numero;
            }

            puntero = 0;

        }

        private void DevolverPuntero()
        {
            puntero = puntero - 1;
        }

        private void LeerSiguienteCaracter()
        {
            puntero = puntero + 1;
            if (lineaActual.Contenido.Equals("@EOF@"))
            {
                caracterActual = lineaActual.Contenido;
            }
            else if(puntero-1 >= lineaActual.Contenido.Length)
            {
                caracterActual = "@FL@";
            }
            else
            {
                caracterActual = lineaActual.Contenido.Substring(puntero-1, 1);
               // puntero = puntero + 1;
            }
            
        }

        private void concatenarLexema()
        {
            Console.WriteLine("caracter actual " + caracterActual);

            lexema = lexema + caracterActual;
            Console.WriteLine("lexema actual" + caracterActual);
        }

        private void limpiarLexema()
        {
            lexema = "";
        }

        private void DevorarEspaciosBlanco()
        {

            while (caracterActual.Equals(" "))
            {
                LeerSiguienteCaracter();
            }

        }

        public bool EsLetra(String simbolo)
        {
            return Char.IsLetter(simbolo, 0);
        }

        public bool EsDigito(String simbolo)
        {
            return Char.IsDigit(simbolo, 0);
        }

        public bool EsLetraODigito(String simbolo)
        {
            return EsLetra(simbolo) || EsDigito(simbolo);
        }

        public ComponenteLexico Analizar()
        {
            ComponenteLexico componenteLexico = new ComponenteLexico();
            limpiarLexema();
            int estadoActual = 0;
            bool continuarAnalisis = true;

            while (continuarAnalisis)
            {
                if (estadoActual == 0)
                {
                    LeerSiguienteCaracter();
                    DevorarEspaciosBlanco();

                    if (EsLetra(caracterActual) || caracterActual.Equals("$") || caracterActual.Equals("_"))
                    {
                        estadoActual = 4;
                        concatenarLexema();
                    }
                    else if (EsDigito(caracterActual))
                    {
                        estadoActual = 1;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("+"))
                    {
                        estadoActual = 5;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("-"))
                    {
                        estadoActual = 6;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("*"))
                    {
                        estadoActual = 7;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("/"))
                    {
                        estadoActual = 8;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("%"))
                    {
                        estadoActual = 9;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("("))
                    {
                        estadoActual = 10;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals(")"))
                    {
                        estadoActual = 11;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("@EOF@"))
                    {
                        estadoActual = 12;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("="))
                    {
                        estadoActual = 19;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("<"))
                    {
                        estadoActual = 20;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals(">"))
                    {
                        estadoActual = 21;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals(":"))
                    {
                        estadoActual = 22;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("!"))
                    {
                        estadoActual = 30;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("@FL@"))
                    {
                        estadoActual = 13;
                    }
                    else
                    {
                        estadoActual = 18;
                    }
                }
                else if(estadoActual==1){
                    LeerSiguienteCaracter();
                    if (EsDigito(caracterActual))
                    {
                        estadoActual = 1;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals(","))
                    {
                        estadoActual = 2;
                        concatenarLexema();
                    }
                    else
                    {
                        estadoActual = 14;
                    }
                }
                else if (estadoActual == 2)
                {
                    LeerSiguienteCaracter();

                    if (EsDigito(caracterActual))
                    {
                        estadoActual = 3;
                        concatenarLexema();
                    }
                    else
                    {
                        Console.WriteLine("error " + caracterActual);
                        concatenarLexema();
                        estadoActual = 17;
                    }
                }
                else if (estadoActual==14)
                {
                    continuarAnalisis = false;
                    DevolverPuntero();
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.ENTERO;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);

                }

                else if (estadoActual == 3)
                {
                    LeerSiguienteCaracter();
                    if (EsDigito(caracterActual))
                    {
                        concatenarLexema();
                    }
                    else
                    {
                        estadoActual = 15;
                    }
                }

                else if (estadoActual == 15)
                {
                    continuarAnalisis = false;
                    DevolverPuntero();
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.DECIMAL;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero ;
                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual==4)
                {
                    LeerSiguienteCaracter();

                    if (EsLetra(caracterActual))
                    {
                        concatenarLexema();
                    }
                    else
                    {
                        estadoActual = 16;
                    }
                }

                else if (estadoActual == 5)
                {
                    continuarAnalisis = false;
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.SUMA;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 6)
                {
                    continuarAnalisis = false;
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.RESTA;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 7)
                {
                    continuarAnalisis = false;
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.MULTIPLICACION;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 9)
                {
                    continuarAnalisis = false;
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.MODULO;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 10)
                {
                    continuarAnalisis = false;
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.PARENTESIS_ABRE;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 11)
                {
                    continuarAnalisis = false;
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.PARENTESIS_CIERRA;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }


                else if (estadoActual == 16)
                {
                    continuarAnalisis = false;
                    DevolverPuntero();
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.IDENTIFICADOR;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;
                    TablaMaestra.SincronizarSimbolo(componenteLexico);

                }

                else if (estadoActual==8)
                {
                    LeerSiguienteCaracter();
                    if (caracterActual.Equals("*")){
                        estadoActual = 34;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("/"))
                    {
                        concatenarLexema();
                        estadoActual = 36;
                    }
                    else
                    {
                        estadoActual = 33;
                    }
                }

                else if (estadoActual == 33)
                {
                    continuarAnalisis = false;
                    DevolverPuntero();
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.DIVISION;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero+1;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);


                }
                else if (estadoActual ==34)
                {
                    LeerSiguienteCaracter();
                    if (caracterActual.Equals("*"))
                    {
                        concatenarLexema();
                        estadoActual = 35;
                    }
                    else if (caracterActual.Equals("@FL@"))
                    {
                        estadoActual = 37;
                    }
                    else
                    {
                        concatenarLexema();
                    }
                    
                }
                else if (estadoActual == 35)
                {
                    LeerSiguienteCaracter();
                    if (caracterActual.Equals("*"))
                    {
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("/"))
                    {
                        concatenarLexema();
                        estadoActual = 0;
                    }
                    else
                    {
                        estadoActual = 34;
                        concatenarLexema();
                    }
                }

                else if (estadoActual == 37)
                {
                    CargarNuevaLinea();
                    estadoActual = 34;

                    //concatenarLexema();
                }

                else if (estadoActual == 36)
                {
                    LeerSiguienteCaracter();
                    if (caracterActual.Equals("@FL@"))
                    {
                        estadoActual = 13;
                        //concatenarLexema();
                    }
                    else
                    {
                        concatenarLexema();
                    }
                }

                else if (estadoActual==13)
                {
                    CargarNuevaLinea();
                    estadoActual = 0;
                }

                else if (estadoActual == 20)
                {
                    LeerSiguienteCaracter();
                    if (caracterActual.Equals(">"))
                    {
                        estadoActual = 23;
                        concatenarLexema();
                    }
                    else if (caracterActual.Equals("="))
                    {
                        concatenarLexema();
                        estadoActual = 24;
                    }
                    else
                    {
                        estadoActual = 25;
                    }
                }

                else if (estadoActual==23)
                {
                    continuarAnalisis = false;
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.DIFERENTE;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 24)
                {
                    continuarAnalisis = false;
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.MAYOR_O_IGUAL_QUE;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 25)
                {
                    continuarAnalisis = false;
                    DevolverPuntero();
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.MENOR_QUE;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual==21)
                {
                    LeerSiguienteCaracter();
                    if (caracterActual.Equals("="))
                    {
                        concatenarLexema();
                        estadoActual = 26;
                    }
                    else
                    {
                        estadoActual = 27;
                    }
                }
                else if (estadoActual==26)
                {
                    continuarAnalisis = false;
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.MAYOR_O_IGUAL_QUE;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual==27)
                {
                    continuarAnalisis = false;
                    DevolverPuntero();
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.MAYOR_QUE;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 22)
                {
                    LeerSiguienteCaracter();
                    if (caracterActual.Equals("="))
                    {
                        concatenarLexema();
                        estadoActual =28;
                    }
                    else
                    {
                        concatenarLexema();
                        estadoActual=29;
                    }

                }

                else if (estadoActual == 28)
                {
                    continuarAnalisis = false;
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.ASIGNACION;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 19)
                {
                    continuarAnalisis = false;
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.IGUAL_QUE;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 30)
                {
                    LeerSiguienteCaracter();
                    if (caracterActual.Equals("="))
                    {
                        concatenarLexema();
                        estadoActual = 31;
                    }
                    else
                    {
                        concatenarLexema();
                        estadoActual = 32;
                    }
                }

                else if (estadoActual == 31)
                {
                    continuarAnalisis = false;
                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.DIFERENTE;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;
                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 32)
                {
                    DevolverPuntero();
                    continuarAnalisis = false;

                    Error error = Error.CrearErrorLexico(lexema, Categoria.DECIMAL, numeroLineaActual,
                        puntero - lexema.Length, puntero,
                        "Caracter no valido",
                        "Leí \"" + caracterActual + "\" y esperaba un '='",
                        "Asegúrese que el caracter que se reciba despues de ! sea un =");

                    GestorErrores.Reportar(error);

                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.DECIMAL;
                    componenteLexico.Lexema = lexema + "0";
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;
                    componenteLexico.Tipo = TipoComponente.DUMMY;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 29)
                {

                    DevolverPuntero();
                    continuarAnalisis = false;
                    
                    Error error = Error.CrearErrorLexico(lexema, Categoria.CARACTER_NO_VALIDO, numeroLineaActual,
                        puntero - lexema.Length, puntero,
                        "Caracter no valido",
                        "Leí \"" + caracterActual + "\" y esperaba un '='",
                        "Asegúrese que el caracter que se reciba despues de ! sea un =");

                    GestorErrores.Reportar(error);

                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.DECIMAL;
                    componenteLexico.Lexema = lexema + "0";
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;
                    componenteLexico.Tipo = TipoComponente.DUMMY;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 17)
                {
                    DevolverPuntero();
                    continuarAnalisis = false;

                    Error error = Error.CrearErrorLexico(lexema, Categoria.DECIMAL, numeroLineaActual, 
                        puntero - lexema.Length, puntero, 
                        "Número decimal no valido", 
                        "Leí \"" + caracterActual + "\" y esperaba un digíto del 0 al 9",
                        "Asegúrese que el caracter que se reciba sea un dígito del 0 al 9");

                    GestorErrores.Reportar(error);

                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.DECIMAL;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero - lexema.Length+1;
                    componenteLexico.PosicionFinal = puntero;
                    componenteLexico.Tipo = TipoComponente.DUMMY;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

                else if (estadoActual == 18)
                {
                    Error error = Error.CrearErrorLexico(caracterActual, Categoria.CARACTER_NO_VALIDO, numeroLineaActual,
                        puntero, puntero,
                        "Caracter no reconocido por el lenguaje",
                        "Leí \"" + caracterActual + "\"",
                        "Asegúrese que el caracter que se reciba sea valido dentro del lenguaje");

                    GestorErrores.Reportar(error);


                    throw new Exception("Se ha presentado un error de tipo stopper durante" +
                        "el analisis léxico. Por favor verifique la consola de errores...");
                }

                else if (estadoActual==12)
                {
                    continuarAnalisis = false;

                    componenteLexico = new ComponenteLexico();
                    componenteLexico.Categoria = Categoria.FIN_ARCHIVO;
                    componenteLexico.Lexema = lexema;
                    componenteLexico.NumeroLinea = numeroLineaActual;
                    componenteLexico.PosicionInicial = puntero;
                    componenteLexico.PosicionFinal = puntero ;

                    TablaMaestra.SincronizarSimbolo(componenteLexico);
                }

            }

            return componenteLexico;

        }

    }
}
