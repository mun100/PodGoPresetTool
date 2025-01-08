namespace PodGoPresetTool
{
    partial class Form1
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
        private void InitializeComponent() {
            btn_AbrirPreset = new Button();
            lbl_PresetAbierto = new Label();
            btn_Guardar = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            lbl_PedalVol = new Label();
            lbl_PedalWah = new Label();
            lbl_Amp = new Label();
            lbl_Eq = new Label();
            lbl_Cab = new Label();
            btn_PedalVol = new Button();
            btn_PedalWah = new Button();
            btn_Amp = new Button();
            btn_Cab = new Button();
            btn_Eq = new Button();
            btn_FxLoop = new Button();
            lbl_FxLoop = new Label();
            SuspendLayout();
            // 
            // btn_AbrirPreset
            // 
            btn_AbrirPreset.Location = new Point(12, 12);
            btn_AbrirPreset.Name = "btn_AbrirPreset";
            btn_AbrirPreset.Size = new Size(90, 23);
            btn_AbrirPreset.TabIndex = 0;
            btn_AbrirPreset.Text = "Abrir preset";
            btn_AbrirPreset.UseVisualStyleBackColor = true;
            btn_AbrirPreset.Click += btn_AbrirPreset_Click;
            // 
            // lbl_PresetAbierto
            // 
            lbl_PresetAbierto.AutoSize = true;
            lbl_PresetAbierto.Location = new Point(12, 48);
            lbl_PresetAbierto.Name = "lbl_PresetAbierto";
            lbl_PresetAbierto.Size = new Size(157, 15);
            lbl_PresetAbierto.TabIndex = 1;
            lbl_PresetAbierto.Text = "Ningún preset seleccionado.";
            // 
            // btn_Guardar
            // 
            btn_Guardar.Location = new Point(259, 12);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(90, 23);
            btn_Guardar.TabIndex = 5;
            btn_Guardar.Text = "Guardar preset";
            btn_Guardar.UseVisualStyleBackColor = true;
            btn_Guardar.Click += btn_Guardar_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbl_PedalVol
            // 
            lbl_PedalVol.AutoSize = true;
            lbl_PedalVol.Location = new Point(108, 75);
            lbl_PedalVol.Name = "lbl_PedalVol";
            lbl_PedalVol.Size = new Size(131, 15);
            lbl_PedalVol.TabIndex = 14;
            lbl_PedalVol.Text = "Pedal Vol. no detectado";
            // 
            // lbl_PedalWah
            // 
            lbl_PedalWah.AutoSize = true;
            lbl_PedalWah.Location = new Point(108, 104);
            lbl_PedalWah.Name = "lbl_PedalWah";
            lbl_PedalWah.Size = new Size(136, 15);
            lbl_PedalWah.TabIndex = 15;
            lbl_PedalWah.Text = "Pedal Wah no detectado";
            // 
            // lbl_Amp
            // 
            lbl_Amp.AutoSize = true;
            lbl_Amp.Location = new Point(108, 162);
            lbl_Amp.Name = "lbl_Amp";
            lbl_Amp.Size = new Size(106, 15);
            lbl_Amp.TabIndex = 16;
            lbl_Amp.Text = "Amp no detectado";
            // 
            // lbl_Eq
            // 
            lbl_Eq.AutoSize = true;
            lbl_Eq.Location = new Point(108, 220);
            lbl_Eq.Name = "lbl_Eq";
            lbl_Eq.Size = new Size(93, 15);
            lbl_Eq.TabIndex = 17;
            lbl_Eq.Text = "Eq no detectado";
            // 
            // lbl_Cab
            // 
            lbl_Cab.AutoSize = true;
            lbl_Cab.Location = new Point(108, 191);
            lbl_Cab.Name = "lbl_Cab";
            lbl_Cab.Size = new Size(101, 15);
            lbl_Cab.TabIndex = 18;
            lbl_Cab.Text = "Cab no detectado";
            // 
            // btn_PedalVol
            // 
            btn_PedalVol.Location = new Point(12, 71);
            btn_PedalVol.Name = "btn_PedalVol";
            btn_PedalVol.Size = new Size(90, 23);
            btn_PedalVol.TabIndex = 19;
            btn_PedalVol.Text = "Eliminar";
            btn_PedalVol.UseVisualStyleBackColor = true;
            btn_PedalVol.Click += btn_PedalVol_Click;
            // 
            // btn_PedalWah
            // 
            btn_PedalWah.Location = new Point(12, 100);
            btn_PedalWah.Name = "btn_PedalWah";
            btn_PedalWah.Size = new Size(90, 23);
            btn_PedalWah.TabIndex = 20;
            btn_PedalWah.Text = "Eliminar";
            btn_PedalWah.UseVisualStyleBackColor = true;
            btn_PedalWah.Click += btn_PedalWah_Click;
            // 
            // btn_Amp
            // 
            btn_Amp.Location = new Point(12, 158);
            btn_Amp.Name = "btn_Amp";
            btn_Amp.Size = new Size(90, 23);
            btn_Amp.TabIndex = 21;
            btn_Amp.Text = "Eliminar";
            btn_Amp.UseVisualStyleBackColor = true;
            btn_Amp.Click += btn_Amp_Click;
            // 
            // btn_Cab
            // 
            btn_Cab.Location = new Point(12, 187);
            btn_Cab.Name = "btn_Cab";
            btn_Cab.Size = new Size(90, 23);
            btn_Cab.TabIndex = 22;
            btn_Cab.Text = "Eliminar";
            btn_Cab.UseVisualStyleBackColor = true;
            btn_Cab.Click += btn_Cab_Click;
            // 
            // btn_Eq
            // 
            btn_Eq.Location = new Point(12, 216);
            btn_Eq.Name = "btn_Eq";
            btn_Eq.Size = new Size(90, 23);
            btn_Eq.TabIndex = 23;
            btn_Eq.Text = "Eliminar";
            btn_Eq.UseVisualStyleBackColor = true;
            btn_Eq.Click += btn_Eq_Click;
            // 
            // btn_FxLoop
            // 
            btn_FxLoop.Location = new Point(12, 129);
            btn_FxLoop.Name = "btn_FxLoop";
            btn_FxLoop.Size = new Size(90, 23);
            btn_FxLoop.TabIndex = 25;
            btn_FxLoop.Text = "Eliminar";
            btn_FxLoop.UseVisualStyleBackColor = true;
            btn_FxLoop.Click += btn_FxLoop_Click;
            // 
            // lbl_FxLoop
            // 
            lbl_FxLoop.AutoSize = true;
            lbl_FxLoop.Location = new Point(108, 133);
            lbl_FxLoop.Name = "lbl_FxLoop";
            lbl_FxLoop.Size = new Size(118, 15);
            lbl_FxLoop.TabIndex = 24;
            lbl_FxLoop.Text = "FxLoop no detectado";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 255);
            Controls.Add(btn_FxLoop);
            Controls.Add(lbl_FxLoop);
            Controls.Add(btn_Eq);
            Controls.Add(btn_Cab);
            Controls.Add(btn_Amp);
            Controls.Add(btn_PedalWah);
            Controls.Add(btn_PedalVol);
            Controls.Add(lbl_Cab);
            Controls.Add(lbl_Eq);
            Controls.Add(lbl_Amp);
            Controls.Add(lbl_PedalWah);
            Controls.Add(lbl_PedalVol);
            Controls.Add(btn_Guardar);
            Controls.Add(lbl_PresetAbierto);
            Controls.Add(btn_AbrirPreset);
            MaximumSize = new Size(377, 294);
            MinimumSize = new Size(377, 294);
            Name = "Form1";
            Text = "Pod Go preset tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_AbrirPreset;
        private Label lbl_PresetAbierto;
        private Button btn_Guardar;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Label lbl_PedalVol;
        private Label lbl_PedalWah;
        private Label lbl_Amp;
        private Label lbl_Eq;
        private Label lbl_Cab;
        private Button btn_PedalVol;
        private Button btn_PedalWah;
        private Button btn_Amp;
        private Button btn_Cab;
        private Button btn_Eq;
        private Button btn_FxLoop;
        private Label lbl_FxLoop;
    }
}
