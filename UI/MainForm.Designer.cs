namespace SoundCoreEngine
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitulo = new TextBox();
            txtArtista = new TextBox();
            numBpm = new NumericUpDown();
            numDuracion = new NumericUpDown();
            btnAgregarFinal = new Button();
            btnUpNext = new Button();
            btnAvanzar = new Button();
            btnInvertir = new Button();
            btnOrdenarBpm = new Button();
            btnDepurar = new Button();
            btnLimpiar = new Button();
            dgvCola = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)numBpm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCola).BeginInit();
            SuspendLayout();
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(87, 72);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(175, 35);
            txtTitulo.TabIndex = 0;
            // 
            // txtArtista
            // 
            txtArtista.Location = new Point(337, 67);
            txtArtista.Name = "txtArtista";
            txtArtista.Size = new Size(175, 35);
            txtArtista.TabIndex = 1;
            // 
            // numBpm
            // 
            numBpm.Location = new Point(609, 68);
            numBpm.Name = "numBpm";
            numBpm.Size = new Size(210, 35);
            numBpm.TabIndex = 2;
            // 
            // numDuracion
            // 
            numDuracion.Location = new Point(877, 74);
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(210, 35);
            numDuracion.TabIndex = 3;
            // 
            // btnAgregarFinal
            // 
            btnAgregarFinal.Location = new Point(72, 204);
            btnAgregarFinal.Name = "btnAgregarFinal";
            btnAgregarFinal.Size = new Size(208, 40);
            btnAgregarFinal.TabIndex = 4;
            btnAgregarFinal.Text = "Agregar al final";
            btnAgregarFinal.UseVisualStyleBackColor = true;
            // 
            // btnUpNext
            // 
            btnUpNext.Location = new Point(72, 250);
            btnUpNext.Name = "btnUpNext";
            btnUpNext.Size = new Size(208, 40);
            btnUpNext.TabIndex = 5;
            btnUpNext.Text = "Siguiente";
            btnUpNext.UseVisualStyleBackColor = true;
            // 
            // btnAvanzar
            // 
            btnAvanzar.Location = new Point(72, 296);
            btnAvanzar.Name = "btnAvanzar";
            btnAvanzar.Size = new Size(208, 40);
            btnAvanzar.TabIndex = 6;
            btnAvanzar.Text = "Avanzar pista";
            btnAvanzar.UseVisualStyleBackColor = true;
            // 
            // btnInvertir
            // 
            btnInvertir.Location = new Point(72, 342);
            btnInvertir.Name = "btnInvertir";
            btnInvertir.Size = new Size(208, 40);
            btnInvertir.TabIndex = 7;
            btnInvertir.Text = "Invertir cola";
            btnInvertir.UseVisualStyleBackColor = true;
            // 
            // btnOrdenarBpm
            // 
            btnOrdenarBpm.Location = new Point(72, 388);
            btnOrdenarBpm.Name = "btnOrdenarBpm";
            btnOrdenarBpm.Size = new Size(208, 40);
            btnOrdenarBpm.TabIndex = 8;
            btnOrdenarBpm.Text = "Ordenar por BPM";
            btnOrdenarBpm.UseVisualStyleBackColor = true;
            // 
            // btnDepurar
            // 
            btnDepurar.Location = new Point(72, 434);
            btnDepurar.Name = "btnDepurar";
            btnDepurar.Size = new Size(208, 40);
            btnDepurar.TabIndex = 9;
            btnDepurar.Text = "Depurar duplicados";
            btnDepurar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(72, 480);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(208, 40);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "Limpiar Cola";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // dgvCola
            // 
            dgvCola.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCola.Location = new Point(438, 204);
            dgvCola.Name = "dgvCola";
            dgvCola.RowHeadersWidth = 72;
            dgvCola.Size = new Size(1213, 316);
            dgvCola.TabIndex = 11;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1889, 1011);
            Controls.Add(dgvCola);
            Controls.Add(btnLimpiar);
            Controls.Add(btnDepurar);
            Controls.Add(btnOrdenarBpm);
            Controls.Add(btnInvertir);
            Controls.Add(btnAvanzar);
            Controls.Add(btnUpNext);
            Controls.Add(btnAgregarFinal);
            Controls.Add(numDuracion);
            Controls.Add(numBpm);
            Controls.Add(txtArtista);
            Controls.Add(txtTitulo);
            Name = "MainForm";
            Text = "Form1SoundCore Engine v2.0 - DJ Set Controller [TecNM Monclova]";
            ((System.ComponentModel.ISupportInitialize)numBpm).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCola).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitulo;
        private TextBox txtArtista;
        private NumericUpDown numBpm;
        private NumericUpDown numDuracion;
        private Button btnAgregarFinal;
        private Button btnUpNext;
        private Button btnAvanzar;
        private Button btnInvertir;
        private Button btnOrdenarBpm;
        private Button btnDepurar;
        private Button btnLimpiar;
        private DataGridView dgvCola;
    }
}
