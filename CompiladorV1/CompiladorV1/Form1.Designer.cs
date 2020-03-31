namespace Compilador
{
    partial class FormCompilador
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxReader = new System.Windows.Forms.TextBox();
            this.textBoxEditor = new System.Windows.Forms.TextBox();
            this.btnCompilar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.tablaSimbolos = new System.Windows.Forms.DataGridView();
            this.tablaDummys = new System.Windows.Forms.DataGridView();
            this.tablaErrores = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaSimbolos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDummys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxReader
            // 
            this.textBoxReader.HideSelection = false;
            this.textBoxReader.Location = new System.Drawing.Point(26, 425);
            this.textBoxReader.Multiline = true;
            this.textBoxReader.Name = "textBoxReader";
            this.textBoxReader.ReadOnly = true;
            this.textBoxReader.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxReader.Size = new System.Drawing.Size(463, 330);
            this.textBoxReader.TabIndex = 0;
            this.textBoxReader.TextChanged += new System.EventHandler(this.TextBoxReader_TextChanged);
            // 
            // textBoxEditor
            // 
            this.textBoxEditor.Location = new System.Drawing.Point(26, 51);
            this.textBoxEditor.Multiline = true;
            this.textBoxEditor.Name = "textBoxEditor";
            this.textBoxEditor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEditor.Size = new System.Drawing.Size(463, 325);
            this.textBoxEditor.TabIndex = 1;
            this.textBoxEditor.TextChanged += new System.EventHandler(this.TextBoxEditor_TextChanged);
            // 
            // btnCompilar
            // 
            this.btnCompilar.Location = new System.Drawing.Point(186, 382);
            this.btnCompilar.Name = "btnCompilar";
            this.btnCompilar.Size = new System.Drawing.Size(143, 27);
            this.btnCompilar.TabIndex = 2;
            this.btnCompilar.Text = "Compilar";
            this.btnCompilar.UseVisualStyleBackColor = true;
            this.btnCompilar.Click += new System.EventHandler(this.BtnCompilar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Editor";
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.Location = new System.Drawing.Point(360, 12);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(129, 23);
            this.btnCargarArchivo.TabIndex = 4;
            this.btnCargarArchivo.Text = "Cargar Archivo";
            this.btnCargarArchivo.UseVisualStyleBackColor = true;
            this.btnCargarArchivo.Click += new System.EventHandler(this.BtnCargarArchivo_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(174, 761);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(143, 27);
            this.btnResetear.TabIndex = 8;
            this.btnResetear.Text = "Limpiar editor";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.BtnResetear_Click);
            // 
            // tablaSimbolos
            // 
            this.tablaSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaSimbolos.Location = new System.Drawing.Point(555, 26);
            this.tablaSimbolos.Name = "tablaSimbolos";
            this.tablaSimbolos.Size = new System.Drawing.Size(649, 168);
            this.tablaSimbolos.TabIndex = 9;
            this.tablaSimbolos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaSimbolos_CellContentClick);
            // 
            // tablaDummys
            // 
            this.tablaDummys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDummys.Location = new System.Drawing.Point(555, 242);
            this.tablaDummys.Name = "tablaDummys";
            this.tablaDummys.Size = new System.Drawing.Size(649, 167);
            this.tablaDummys.TabIndex = 11;
            this.tablaDummys.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaDummys_CellContentClick);
            // 
            // tablaErrores
            // 
            this.tablaErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaErrores.Location = new System.Drawing.Point(555, 444);
            this.tablaErrores.Name = "tablaErrores";
            this.tablaErrores.Size = new System.Drawing.Size(649, 167);
            this.tablaErrores.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tabla de Símbolos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(556, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tabla de Dummys";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(556, 428);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tabla de Errores";
            // 
            // FormCompilador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 749);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tablaErrores);
            this.Controls.Add(this.tablaDummys);
            this.Controls.Add(this.tablaSimbolos);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.btnCargarArchivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCompilar);
            this.Controls.Add(this.textBoxEditor);
            this.Controls.Add(this.textBoxReader);
            this.Name = "FormCompilador";
            this.Text = "Compilador";
            this.Load += new System.EventHandler(this.FormCompilador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaSimbolos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDummys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaErrores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxReader;
        private System.Windows.Forms.TextBox textBoxEditor;
        private System.Windows.Forms.Button btnCompilar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.DataGridView tablaSimbolos;
        private System.Windows.Forms.DataGridView tablaDummys;
        private System.Windows.Forms.DataGridView tablaErrores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

