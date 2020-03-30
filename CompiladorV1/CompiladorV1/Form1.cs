
using CompiladorV1.AnalisisLexico;
using CompiladorV1.Cache;
using CompiladorV1.ManejadorErrores;
using CompiladorV1.TablaSimbolos;
using CompiladorV1.Transversal;
using System;
using System.Windows.Forms;

namespace Compilador
{
    public partial class FormCompilador : Form
    {
        //private Cache archivo;
        public FormCompilador()
        {
            InitializeComponent();
            //archivo = Cache.ObtenerInstancia();
        }

        private void BtnCargarArchivo_Click(object sender, EventArgs e)
        {

            if (Cache.obtenerLineas().Count != 0)
            {
                if (MessageBox.Show("Se cargara un nuevo archivo y el anterior se eliminara\n¿Deseas cargar el nuevo archivo?",
                    "Cargar Archivo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                { 
                    Cache.limpiarLineas();
                    Cache.CargarArchivo();
                    textBoxEditor.Clear();
                    LlenarTextBoxEditor();
                }
            }
            else
            {
                Cache.CargarArchivo();
                textBoxEditor.Clear();
            }
            LlenarTextBoxEditor();
        }

        private void BtnCompilar_Click(object sender, EventArgs e)
        {
            //TablaSimbolos.ObtenerTablaSimbolos();
            //TablaSimbolos.Limpiar();
            //TablaDummy.ObtenerTodosSimbolos();
            //TablaDummy.Limpiar();
            //TablaDummys.ObtenerTablaDummys().Limpiar();
            //TablaLiterales.ObtenerTablaLiterales().Limpiar();
            //GestorErrores.ObtenerTodosErrores();

            textBoxReader.Clear();
            LlenarTextBoxReader();

            AnalizadorLexico analizador = new AnalizadorLexico();
            ComponenteLexico componente = new ComponenteLexico();

            while (analizador.Analizar().Lexema != "@EOF@") {
            }

                //componente.ToString();

            //text

                tablaSimbolos.DataSource = TablaSimbolos.ObtenerTodosSimbolos();
                
                //tablaLiterales.DataSource = TablaLiterales.ObtenerTablaLiterales().ObtenerLiterales();
                tablaDummys.DataSource = TablaDummy.ObtenerTodosSimbolos();
                //tablaErrores.DataSource = GestorErrores.ObtenerTodosErrores();*
            

        }

        private void BtnResetear_Click(object sender, EventArgs e)
        {

            /*Cache.LimpiarLineas();
            textBoxReader.Clear();

            TablaSimbolos.ObtenerTablaSimbolos().Limpiar();
            TablaDummys.ObtenerTablaDummys().Limpiar();
            TablaLiterales.ObtenerTablaLiterales().Limpiar();
            ManejadorErrores.ObtenerManejadorErrores().Limpiar();

            tablaSimbolos.DataSource = TablaSimbolos.ObtenerTablaSimbolos().ObtenerSimbolos();
            tablaLiterales.DataSource = TablaLiterales.ObtenerTablaLiterales().ObtenerLiterales();
            tablaDummys.DataSource = TablaDummys.ObtenerTablaDummys().ObtenerDummys();
            tablaErrores.DataSource = ManejadorErrores.ObtenerManejadorErrores().ObtenerErrores();*/

        }   
        private void LlenarTextBoxReader()
        {
            Cache.BuildArchivo(textBoxEditor.Lines);
            textBoxReader.Clear();

            if (Cache.obtenerLineas().Count != 0)
            {
                foreach (Linea linea in Cache.obtenerLineas())
                {
                    textBoxReader.AppendText(linea.Numero + "- > "+ linea.Contenido + Environment.NewLine);
                }
            }
        }
        private void LlenarTextBoxEditor()
        {
            textBoxEditor.Clear();
            if (Cache.obtenerLineas().Count != 0)
            {
                foreach (Linea linea in Cache.obtenerLineas())
                {
                    textBoxEditor.AppendText(linea.Contenido + Environment.NewLine);
                }
            }
        }

        private void FormCompilador_Load(object sender, EventArgs e)
        {

        }

        private void TextBoxEditor_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxReader_TextChanged(object sender, EventArgs e)
        {

        }

        private void tablaSimbolos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tablaLiterales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tablaDummys_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
