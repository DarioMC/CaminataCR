namespace AdminPlataforma
{
    partial class NCEditarNivelCalidad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.buttonAceptarEditarNivelCalidad = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(246)))), ((int)(((byte)(235)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.57225F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.28902F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.13873F));
            this.tableLayoutPanel1.Controls.Add(this.labelDescripcion, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDescripcion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonAceptarEditarNivelCalidad, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.47969F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.671179F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.671179F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.671179F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(375, 242);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescripcion.Location = new System.Drawing.Point(16, 66);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(108, 21);
            this.labelDescripcion.TabIndex = 2;
            this.labelDescripcion.Text = "Descripcion: ";
            this.labelDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(185)))), ((int)(((byte)(181)))));
            this.textBoxDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDescripcion.Location = new System.Drawing.Point(144, 66);
            this.textBoxDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescripcion.MinimumSize = new System.Drawing.Size(3, 3);
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(180, 20);
            this.textBoxDescripcion.TabIndex = 1;
            // 
            // buttonAceptarEditarNivelCalidad
            // 
            this.buttonAceptarEditarNivelCalidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAceptarEditarNivelCalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(91)))), ((int)(((byte)(86)))));
            this.buttonAceptarEditarNivelCalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAceptarEditarNivelCalidad.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAceptarEditarNivelCalidad.Location = new System.Drawing.Point(150, 128);
            this.buttonAceptarEditarNivelCalidad.Name = "buttonAceptarEditarNivelCalidad";
            this.buttonAceptarEditarNivelCalidad.Size = new System.Drawing.Size(168, 27);
            this.buttonAceptarEditarNivelCalidad.TabIndex = 8;
            this.buttonAceptarEditarNivelCalidad.Text = "Aceptar";
            this.buttonAceptarEditarNivelCalidad.UseVisualStyleBackColor = false;
            this.buttonAceptarEditarNivelCalidad.Click += new System.EventHandler(this.buttonAceptarEditarNivelCalidad_Click);
            // 
            // NCEditarNivelCalidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 266);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NCEditarNivelCalidad";
            this.Text = "NCEditarNivelCalidad";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Button buttonAceptarEditarNivelCalidad;
    }
}