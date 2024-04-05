namespace AppAct3
{
    partial class Form1
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
            this.btnConvertJSON = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnConvertXML = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnConvertCSV = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConvertJSON
            // 
            this.btnConvertJSON.Location = new System.Drawing.Point(45, 131);
            this.btnConvertJSON.Name = "btnConvertJSON";
            this.btnConvertJSON.Size = new System.Drawing.Size(180, 26);
            this.btnConvertJSON.TabIndex = 0;
            this.btnConvertJSON.Text = "CONVERT JSON";
            this.btnConvertJSON.UseVisualStyleBackColor = true;
            this.btnConvertJSON.Click += new System.EventHandler(this.btnConvertJSON_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(279, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(834, 540);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnConvertXML
            // 
            this.btnConvertXML.Location = new System.Drawing.Point(45, 180);
            this.btnConvertXML.Name = "btnConvertXML";
            this.btnConvertXML.Size = new System.Drawing.Size(180, 26);
            this.btnConvertXML.TabIndex = 2;
            this.btnConvertXML.Text = "CONVERT XML";
            this.btnConvertXML.UseVisualStyleBackColor = true;
            this.btnConvertXML.Click += new System.EventHandler(this.btnConvertXML_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(79, 35);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(122, 23);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "OPEN";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnConvertCSV
            // 
            this.btnConvertCSV.Location = new System.Drawing.Point(45, 85);
            this.btnConvertCSV.Name = "btnConvertCSV";
            this.btnConvertCSV.Size = new System.Drawing.Size(180, 27);
            this.btnConvertCSV.TabIndex = 4;
            this.btnConvertCSV.Text = "CONVERT CSV";
            this.btnConvertCSV.UseVisualStyleBackColor = true;
            this.btnConvertCSV.Click += new System.EventHandler(this.btnConvertCSV_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1175, 35);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(520, 540);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1722, 718);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnConvertCSV);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnConvertXML);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnConvertJSON);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConvertJSON;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnConvertXML;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnConvertCSV;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

