namespace Steganografia
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.criptazioneButton = new System.Windows.Forms.Button();
            this.decriptazioneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // criptazioneButton
            // 
            this.criptazioneButton.Location = new System.Drawing.Point(192, 142);
            this.criptazioneButton.Name = "criptazioneButton";
            this.criptazioneButton.Size = new System.Drawing.Size(149, 70);
            this.criptazioneButton.TabIndex = 0;
            this.criptazioneButton.Text = "Criptazione";
            this.criptazioneButton.UseVisualStyleBackColor = true;
            this.criptazioneButton.Click += new System.EventHandler(this.criptazioneButton_Click);
            // 
            // decriptazioneButton
            // 
            this.decriptazioneButton.Location = new System.Drawing.Point(420, 142);
            this.decriptazioneButton.Name = "decriptazioneButton";
            this.decriptazioneButton.Size = new System.Drawing.Size(149, 70);
            this.decriptazioneButton.TabIndex = 1;
            this.decriptazioneButton.Text = "Decriptazione";
            this.decriptazioneButton.UseVisualStyleBackColor = true;
            this.decriptazioneButton.Click += new System.EventHandler(this.decriptazioneButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(783, 360);
            this.Controls.Add(this.decriptazioneButton);
            this.Controls.Add(this.criptazioneButton);
            this.Name = "Form1";
            this.Text = "Menu Steganografia";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button criptazioneButton;
        private System.Windows.Forms.Button decriptazioneButton;
    }
}

