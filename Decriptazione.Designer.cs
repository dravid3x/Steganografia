
namespace Steganografia
{
    partial class Decriptazione
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
            this.caricaImgButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.immagineCaricataPic = new System.Windows.Forms.PictureBox();
            this.checkAnteprima = new System.Windows.Forms.CheckBox();
            this.textDecriptato = new System.Windows.Forms.TextBox();
            this.decriptaButton = new System.Windows.Forms.Button();
            this.cancellaDecButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.salvaButton = new System.Windows.Forms.Button();
            this.progressoLabel = new System.Windows.Forms.Label();
            this.nPixelLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.immagineCaricataPic)).BeginInit();
            this.SuspendLayout();
            // 
            // caricaImgButton
            // 
            this.caricaImgButton.Location = new System.Drawing.Point(53, 53);
            this.caricaImgButton.Name = "caricaImgButton";
            this.caricaImgButton.Size = new System.Drawing.Size(114, 60);
            this.caricaImgButton.TabIndex = 0;
            this.caricaImgButton.Text = "Carica Immagine";
            this.caricaImgButton.UseVisualStyleBackColor = true;
            this.caricaImgButton.Click += new System.EventHandler(this.caricaImgButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Caricare l\'immagine da decriptare";
            // 
            // immagineCaricataPic
            // 
            this.immagineCaricataPic.Location = new System.Drawing.Point(33, 197);
            this.immagineCaricataPic.Name = "immagineCaricataPic";
            this.immagineCaricataPic.Size = new System.Drawing.Size(163, 197);
            this.immagineCaricataPic.TabIndex = 2;
            this.immagineCaricataPic.TabStop = false;
            // 
            // checkAnteprima
            // 
            this.checkAnteprima.AutoSize = true;
            this.checkAnteprima.Checked = true;
            this.checkAnteprima.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAnteprima.Location = new System.Drawing.Point(33, 145);
            this.checkAnteprima.Name = "checkAnteprima";
            this.checkAnteprima.Size = new System.Drawing.Size(163, 17);
            this.checkAnteprima.TabIndex = 3;
            this.checkAnteprima.Text = "Anteprima Immagine Caricata";
            this.checkAnteprima.UseVisualStyleBackColor = true;
            this.checkAnteprima.CheckedChanged += new System.EventHandler(this.checkAnteprima_CheckedChanged);
            // 
            // textDecriptato
            // 
            this.textDecriptato.Location = new System.Drawing.Point(277, 197);
            this.textDecriptato.Multiline = true;
            this.textDecriptato.Name = "textDecriptato";
            this.textDecriptato.ReadOnly = true;
            this.textDecriptato.Size = new System.Drawing.Size(375, 197);
            this.textDecriptato.TabIndex = 4;
            // 
            // decriptaButton
            // 
            this.decriptaButton.Location = new System.Drawing.Point(277, 53);
            this.decriptaButton.Name = "decriptaButton";
            this.decriptaButton.Size = new System.Drawing.Size(114, 60);
            this.decriptaButton.TabIndex = 5;
            this.decriptaButton.Text = "Avvia Decriptazione";
            this.decriptaButton.UseVisualStyleBackColor = true;
            this.decriptaButton.Click += new System.EventHandler(this.decriptaButton_Click);
            // 
            // cancellaDecButton
            // 
            this.cancellaDecButton.Location = new System.Drawing.Point(408, 53);
            this.cancellaDecButton.Name = "cancellaDecButton";
            this.cancellaDecButton.Size = new System.Drawing.Size(114, 60);
            this.cancellaDecButton.TabIndex = 6;
            this.cancellaDecButton.Text = "Cancella Decriptazione";
            this.cancellaDecButton.UseVisualStyleBackColor = true;
            this.cancellaDecButton.Click += new System.EventHandler(this.cancellaDecButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(277, 145);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(375, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // salvaButton
            // 
            this.salvaButton.Location = new System.Drawing.Point(538, 53);
            this.salvaButton.Name = "salvaButton";
            this.salvaButton.Size = new System.Drawing.Size(114, 60);
            this.salvaButton.TabIndex = 8;
            this.salvaButton.Text = "Salva in file";
            this.salvaButton.UseVisualStyleBackColor = true;
            this.salvaButton.Click += new System.EventHandler(this.salvaButton_Click);
            // 
            // progressoLabel
            // 
            this.progressoLabel.Location = new System.Drawing.Point(370, 129);
            this.progressoLabel.Name = "progressoLabel";
            this.progressoLabel.Size = new System.Drawing.Size(204, 13);
            this.progressoLabel.TabIndex = 9;
            this.progressoLabel.Text = "Posizione/Progresso nell\'immagine in pixel";
            this.progressoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nPixelLabel
            // 
            this.nPixelLabel.Location = new System.Drawing.Point(593, 175);
            this.nPixelLabel.Name = "nPixelLabel";
            this.nPixelLabel.Size = new System.Drawing.Size(97, 13);
            this.nPixelLabel.TabIndex = 10;
            this.nPixelLabel.Text = "Pixel Totali";
            this.nPixelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Decriptazione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 433);
            this.Controls.Add(this.nPixelLabel);
            this.Controls.Add(this.progressoLabel);
            this.Controls.Add(this.salvaButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cancellaDecButton);
            this.Controls.Add(this.decriptaButton);
            this.Controls.Add(this.textDecriptato);
            this.Controls.Add(this.checkAnteprima);
            this.Controls.Add(this.immagineCaricataPic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.caricaImgButton);
            this.Name = "Decriptazione";
            this.Text = "Decriptazione";
            this.Load += new System.EventHandler(this.Decriptazione_Load);
            ((System.ComponentModel.ISupportInitialize)(this.immagineCaricataPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button caricaImgButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox immagineCaricataPic;
        private System.Windows.Forms.CheckBox checkAnteprima;
        private System.Windows.Forms.TextBox textDecriptato;
        private System.Windows.Forms.Button decriptaButton;
        private System.Windows.Forms.Button cancellaDecButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button salvaButton;
        private System.Windows.Forms.Label progressoLabel;
        private System.Windows.Forms.Label nPixelLabel;
    }
}