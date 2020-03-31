using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiladorV1.Cache
{
    class Cache
    {
        private static List<Linea> lineas = new List<Linea>();


        public static void AgregarLinea(String contenido)
        {
            if (contenido != null)
            {
                Linea linea = new Linea();
                linea.Contenido = contenido;
                if (lineas.Count == 0) {
                    
                    linea.Numero = 1;
                    
                }
                else
                {
                    linea.Numero = lineas.Count + 1;
                }

                lineas.Add(linea);
            }
        }

        public static List<Linea> obtenerLineas()
        {
            return lineas;
        }

        public static Linea ObtenerLinea(int numero)
        {
            Linea lineaRetorno;

            if (ExisteLinea(numero))
            {
                lineaRetorno = lineas[numero - 1];
            }
            else
            {
                lineaRetorno = new Linea();
                lineaRetorno.Contenido = "@EOF@";
                lineaRetorno.Numero = lineas.Count + 1;

            }

            return lineaRetorno;
        }

        public static void limpiarLineas()
        {
            lineas.Clear();
        }

        public static bool ExisteLinea(int numero)
        {
            return (lineas.Count >= numero && numero > 0);

        }

        public static void BuildArchivo(String[] texto)
        {
            Cache.limpiarLineas();
            foreach (String contenidoLinea in texto)
            {
                Cache.AgregarLinea(contenidoLinea);
            }
        }

        public static void CargarArchivo()
        {
            OpenFileDialog openFileDialog;
            string filePath = string.Empty;
            String contenidoLinea;
            using (openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                int contador = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        while ((contenidoLinea = reader.ReadLine()) != null)
                        {
                            //lineas.Add(Linea.Crear(contador, contenidoLinea));
                            AgregarLinea(contenidoLinea);
                            contador++;
                        }
                    }
                }
            }
        }
    }
}
