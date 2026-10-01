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
            btnAgregarFinal = new Button();
            btnUpNext = new Button();
            btnAvanzar = new Button();
            btnInvertir = new Button();
            btnOrdenarBpm = new Button();
            btnDepurar = new Button();
            btnLimpiar = new Button();
            dgvCola = new DataGridView();
            numBpm = new NumericUpDown();
            txtArtista = new TextBox();
            txtTitulo = new TextBox();
            numDuracion = new NumericUpDown();
            groupBox1 = new GroupBox();
            rbList = new RadioButton();
            rbLinkedList = new RadioButton();
            rbPropia = new RadioButton();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            lblResumen = new Label();
            lblReproduciendo = new Label();
            groupBox4 = new GroupBox();
            btnCargarAudio = new Button();
            lblResultLinkedList = new Label();
            lblResultList = new Label();
            lblResultPropia = new Label();
            btnBenchmark = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCola).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBpm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // btnAgregarFinal
            // 
            btnAgregarFinal.Location = new Point(6, 70);
            btnAgregarFinal.Name = "btnAgregarFinal";
            btnAgregarFinal.Size = new Size(208, 40);
            btnAgregarFinal.TabIndex = 4;
            btnAgregarFinal.Text = "Agregar al final";
            btnAgregarFinal.UseVisualStyleBackColor = true;
            btnAgregarFinal.Click += btnAgregarFinal_Click;
            // 
            // btnUpNext
            // 
            btnUpNext.Location = new Point(239, 70);
            btnUpNext.Name = "btnUpNext";
            btnUpNext.Size = new Size(208, 40);
            btnUpNext.TabIndex = 5;
            btnUpNext.Text = "Siguiente";
            btnUpNext.UseVisualStyleBackColor = true;
            btnUpNext.Click += btnUpNext_Click;
            // 
            // btnAvanzar
            // 
            btnAvanzar.Location = new Point(6, 132);
            btnAvanzar.Name = "btnAvanzar";
            btnAvanzar.Size = new Size(208, 40);
            btnAvanzar.TabIndex = 6;
            btnAvanzar.Text = "Avanzar pista";
            btnAvanzar.UseVisualStyleBackColor = true;
            btnAvanzar.Click += btnAvanzar_Click;
            // 
            // btnInvertir
            // 
            btnInvertir.Location = new Point(239, 132);
            btnInvertir.Name = "btnInvertir";
            btnInvertir.Size = new Size(208, 40);
            btnInvertir.TabIndex = 7;
            btnInvertir.Text = "Invertir cola";
            btnInvertir.UseVisualStyleBackColor = true;
            btnInvertir.Click += btnInvertir_Click;
            // 
            // btnOrdenarBpm
            // 
            btnOrdenarBpm.Location = new Point(6, 198);
            btnOrdenarBpm.Name = "btnOrdenarBpm";
            btnOrdenarBpm.Size = new Size(208, 40);
            btnOrdenarBpm.TabIndex = 8;
            btnOrdenarBpm.Text = "Ordenar por BPM";
            btnOrdenarBpm.UseVisualStyleBackColor = true;
            btnOrdenarBpm.Click += btnOrdenarBpm_Click;
            // 
            // btnDepurar
            // 
            btnDepurar.Location = new Point(239, 198);
            btnDepurar.Name = "btnDepurar";
            btnDepurar.Size = new Size(208, 40);
            btnDepurar.TabIndex = 9;
            btnDepurar.Text = "Depurar duplicados";
            btnDepurar.UseVisualStyleBackColor = true;
            btnDepurar.Click += btnDepurar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(130, 269);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(208, 40);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "Limpiar Cola";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvCola
            // 
            dgvCola.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCola.Location = new Point(25, 95);
            dgvCola.Name = "dgvCola";
            dgvCola.RowHeadersWidth = 72;
            dgvCola.Size = new Size(1064, 285);
            dgvCola.TabIndex = 11;
            // 
            // numBpm
            // 
            numBpm.Location = new Point(504, 110);
            numBpm.Name = "numBpm";
            numBpm.Size = new Size(210, 35);
            numBpm.TabIndex = 2;
            // 
            // txtArtista
            // 
            txtArtista.Location = new Point(272, 109);
            txtArtista.Name = "txtArtista";
            txtArtista.Size = new Size(175, 35);
            txtArtista.TabIndex = 1;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(42, 109);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(175, 35);
            txtTitulo.TabIndex = 0;
            // 
            // numDuracion
            // 
            numDuracion.Location = new Point(770, 110);
            numDuracion.Name = "numDuracion";
            numDuracion.Size = new Size(210, 35);
            numDuracion.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbList);
            groupBox1.Controls.Add(rbLinkedList);
            groupBox1.Controls.Add(rbPropia);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtTitulo);
            groupBox1.Controls.Add(txtArtista);
            groupBox1.Controls.Add(numBpm);
            groupBox1.Controls.Add(numDuracion);
            groupBox1.Location = new Point(27, 19);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1631, 230);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "REGISTRO DE PISTA";
            // 
            // rbList
            // 
            rbList.AutoSize = true;
            rbList.Location = new Point(634, 163);
            rbList.Name = "rbList";
            rbList.Size = new Size(118, 34);
            rbList.TabIndex = 10;
            rbList.TabStop = true;
            rbList.Text = ".NET List";
            rbList.UseVisualStyleBackColor = true;
            // 
            // rbLinkedList
            // 
            rbLinkedList.AutoSize = true;
            rbLinkedList.Location = new Point(382, 163);
            rbLinkedList.Name = "rbLinkedList";
            rbLinkedList.Size = new Size(178, 34);
            rbLinkedList.TabIndex = 9;
            rbLinkedList.TabStop = true;
            rbLinkedList.Text = ".NET LinkedList";
            rbLinkedList.UseVisualStyleBackColor = true;
            // 
            // rbPropia
            // 
            rbPropia.AutoSize = true;
            rbPropia.Location = new Point(33, 163);
            rbPropia.Name = "rbPropia";
            rbPropia.Size = new Size(292, 34);
            rbPropia.TabIndex = 8;
            rbPropia.TabStop = true;
            rbPropia.Text = "Lista Simple Propia (Nodos)";
            rbPropia.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(770, 60);
            label4.Name = "label4";
            label4.Size = new Size(118, 30);
            label4.TabIndex = 7;
            label4.Text = "Duración(s)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(504, 60);
            label3.Name = "label3";
            label3.Size = new Size(56, 30);
            label3.TabIndex = 6;
            label3.Text = "BPM";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(270, 60);
            label2.Name = "label2";
            label2.Size = new Size(73, 30);
            label2.TabIndex = 5;
            label2.Text = "Artista";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 60);
            label1.Name = "label1";
            label1.Size = new Size(65, 30);
            label1.TabIndex = 4;
            label1.Text = "Título";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAvanzar);
            groupBox2.Controls.Add(btnAgregarFinal);
            groupBox2.Controls.Add(btnUpNext);
            groupBox2.Controls.Add(btnLimpiar);
            groupBox2.Controls.Add(btnInvertir);
            groupBox2.Controls.Add(btnDepurar);
            groupBox2.Controls.Add(btnOrdenarBpm);
            groupBox2.Location = new Point(27, 263);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(467, 398);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "ACCIONES DE COLA";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblResumen);
            groupBox3.Controls.Add(lblReproduciendo);
            groupBox3.Controls.Add(dgvCola);
            groupBox3.Location = new Point(548, 271);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1110, 429);
            groupBox3.TabIndex = 14;
            groupBox3.TabStop = false;
            groupBox3.Text = "PLAYLIST VISUAL / COLA EN VIVO";
            // 
            // lblResumen
            // 
            lblResumen.AutoSize = true;
            lblResumen.Location = new Point(25, 392);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(486, 30);
            lblResumen.TabIndex = 13;
            lblResumen.Text = "Total en cola: 0 pistas | Duración acumulada: 0m 0s";
            // 
            // lblReproduciendo
            // 
            lblReproduciendo.AutoSize = true;
            lblReproduciendo.Location = new Point(25, 47);
            lblReproduciendo.Name = "lblReproduciendo";
            lblReproduciendo.Size = new Size(406, 30);
            lblReproduciendo.TabIndex = 12;
            lblReproduciendo.Text = "Estado Actual: ► Reproduciendo: Ninguna";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnCargarAudio);
            groupBox4.Controls.Add(lblResultLinkedList);
            groupBox4.Controls.Add(lblResultList);
            groupBox4.Controls.Add(lblResultPropia);
            groupBox4.Controls.Add(btnBenchmark);
            groupBox4.Location = new Point(27, 706);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1631, 249);
            groupBox4.TabIndex = 15;
            groupBox4.TabStop = false;
            groupBox4.Text = "BENCHMARK Y TELEMETRÍA";
            // 
            // btnCargarAudio
            // 
            btnCargarAudio.Location = new Point(498, 52);
            btnCargarAudio.Name = "btnCargarAudio";
            btnCargarAudio.Size = new Size(254, 40);
            btnCargarAudio.TabIndex = 6;
            btnCargarAudio.Text = "Cargar Audio (BPM)";
            btnCargarAudio.UseVisualStyleBackColor = true;
            btnCargarAudio.Click += btnCargarAudio_Click;
            // 
            // lblResultLinkedList
            // 
            lblResultLinkedList.AutoSize = true;
            lblResultLinkedList.Location = new Point(16, 159);
            lblResultLinkedList.Name = "lblResultLinkedList";
            lblResultLinkedList.Size = new Size(227, 30);
            lblResultLinkedList.TabIndex = 5;
            lblResultLinkedList.Text = "- .NET LinkedList: -- ms";
            lblResultLinkedList.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblResultList
            // 
            lblResultList.AutoSize = true;
            lblResultList.Location = new Point(16, 206);
            lblResultList.Name = "lblResultList";
            lblResultList.Size = new Size(167, 30);
            lblResultList.TabIndex = 4;
            lblResultList.Text = "- .NET List: -- ms";
            // 
            // lblResultPropia
            // 
            lblResultPropia.AutoSize = true;
            lblResultPropia.Location = new Point(16, 110);
            lblResultPropia.Name = "lblResultPropia";
            lblResultPropia.Size = new Size(273, 30);
            lblResultPropia.TabIndex = 3;
            lblResultPropia.Text = "- Lista Propia (Nodos): -- ms";
            // 
            // btnBenchmark
            // 
            btnBenchmark.Location = new Point(16, 52);
            btnBenchmark.Name = "btnBenchmark";
            btnBenchmark.Size = new Size(398, 40);
            btnBenchmark.TabIndex = 2;
            btnBenchmark.Text = "🚀 Iniciar Prueba de Rendimiento";
            btnBenchmark.UseVisualStyleBackColor = true;
            btnBenchmark.Click += btnBenchmark_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1889, 1011);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "Form1SoundCore Engine v2.0 - DJ Set Controller [TecNM Monclova]";
            ((System.ComponentModel.ISupportInitialize)dgvCola).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBpm).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuracion).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAgregarFinal;
        private Button btnUpNext;
        private Button btnAvanzar;
        private Button btnInvertir;
        private Button btnOrdenarBpm;
        private Button btnDepurar;
        private Button btnLimpiar;
        private DataGridView dgvCola;
        private NumericUpDown numBpm;
        private TextBox txtArtista;
        private TextBox txtTitulo;
        private NumericUpDown numDuracion;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private GroupBox groupBox4;
        private Label label4;
        private Label label3;
        private Label label2;
        private RadioButton rbList;
        private RadioButton rbLinkedList;
        private RadioButton rbPropia;
        private Label lblReproduciendo;
        private Label lblResumen;
        private Button btnBenchmark;
        private Label lblResultLinkedList;
        private Label lblResultList;
        private Label lblResultPropia;
        private Button btnCargarAudio;
    }
}
