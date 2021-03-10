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
            this.InserisciButton = new System.Windows.Forms.Button();
            this.fDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.testoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InserisciButton
            // 
            this.InserisciButton.Location = new System.Drawing.Point(26, 12);
            this.InserisciButton.Name = "InserisciButton";
            this.InserisciButton.Size = new System.Drawing.Size(117, 64);
            this.InserisciButton.TabIndex = 1;
            this.InserisciButton.Text = "Inserisci immagine";
            this.InserisciButton.UseVisualStyleBackColor = true;
            this.InserisciButton.Click += new System.EventHandler(this.InserisciButton_Click);
            // 
            // fDialog1
            // 
            this.fDialog1.FileName = "openFileDialog1";
            // 
            // testoTextBox
            // 
            this.testoTextBox.Location = new System.Drawing.Point(26, 120);
            this.testoTextBox.Name = "testoTextBox";
            this.testoTextBox.Size = new System.Drawing.Size(117, 20);
            this.testoTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Inserire il testo da camuffare";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 453);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testoTextBox);
            this.Controls.Add(this.InserisciButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button InserisciButton;
        private System.Windows.Forms.OpenFileDialog fDialog1;
        private System.Windows.Forms.TextBox testoTextBox;
        private System.Windows.Forms.Label label1;
    }
}

