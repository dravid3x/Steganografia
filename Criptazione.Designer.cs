
namespace Steganografia
{
    partial class Criptazione
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
            this.components = new System.ComponentModel.Container();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inserisciFileButton = new System.Windows.Forms.Button();
            this.inserisciTextBoxButton = new System.Windows.Forms.Button();
            this.textConvertireBox = new System.Windows.Forms.TextBox();
            this.checkAnteprimaCaricata = new System.Windows.Forms.CheckBox();
            this.immagineCaricataPic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.caricaImgButton = new System.Windows.Forms.Button();
            this.checkAnteprimaGenerata = new System.Windows.Forms.CheckBox();
            this.immagineGenerataPic = new System.Windows.Forms.PictureBox();
            this.iniziaButton = new System.Windows.Forms.Button();
            this.cancellaButton = new System.Windows.Forms.Button();
            this.salvaButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nBlocchiThreadLabel = new System.Windows.Forms.Label();
            this.sindacoBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.nThreadTotaliLabel = new System.Windows.Forms.Label();
            this.binarioBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sindacoStatusLabel = new System.Windows.Forms.Label();
            this.pittoreBar = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.binarioUpdateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.immagineCaricataPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.immagineGenerataPic)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.ContextMenuStrip = this.contextMenuStrip1;
            this.trackBar1.Location = new System.Drawing.Point(43, 411);
            this.trackBar1.Maximum = 10000;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(184, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 500;
            this.trackBar1.Value = 1000;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(103, 26);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // inserisciFileButton
            // 
            this.inserisciFileButton.Location = new System.Drawing.Point(152, 51);
            this.inserisciFileButton.Name = "inserisciFileButton";
            this.inserisciFileButton.Size = new System.Drawing.Size(96, 40);
            this.inserisciFileButton.TabIndex = 3;
            this.inserisciFileButton.Text = "Carica testo via file";
            this.inserisciFileButton.UseVisualStyleBackColor = true;
            this.inserisciFileButton.Click += new System.EventHandler(this.inserisciFileButton_Click);
            // 
            // inserisciTextBoxButton
            // 
            this.inserisciTextBoxButton.Location = new System.Drawing.Point(26, 51);
            this.inserisciTextBoxButton.Name = "inserisciTextBoxButton";
            this.inserisciTextBoxButton.Size = new System.Drawing.Size(96, 40);
            this.inserisciTextBoxButton.TabIndex = 2;
            this.inserisciTextBoxButton.Text = "Carica testo tramite TextBox";
            this.inserisciTextBoxButton.UseVisualStyleBackColor = true;
            this.inserisciTextBoxButton.Click += new System.EventHandler(this.inserisciTextBoxButton_Click);
            // 
            // textConvertireBox
            // 
            this.textConvertireBox.Location = new System.Drawing.Point(26, 106);
            this.textConvertireBox.Multiline = true;
            this.textConvertireBox.Name = "textConvertireBox";
            this.textConvertireBox.Size = new System.Drawing.Size(222, 267);
            this.textConvertireBox.TabIndex = 4;
            // 
            // checkAnteprimaCaricata
            // 
            this.checkAnteprimaCaricata.AutoSize = true;
            this.checkAnteprimaCaricata.Location = new System.Drawing.Point(332, 144);
            this.checkAnteprimaCaricata.Name = "checkAnteprimaCaricata";
            this.checkAnteprimaCaricata.Size = new System.Drawing.Size(163, 17);
            this.checkAnteprimaCaricata.TabIndex = 8;
            this.checkAnteprimaCaricata.Text = "Anteprima Immagine Caricata";
            this.checkAnteprimaCaricata.UseVisualStyleBackColor = true;
            this.checkAnteprimaCaricata.CheckedChanged += new System.EventHandler(this.checkAnteprimaCaricata_CheckedChanged);
            // 
            // immagineCaricataPic
            // 
            this.immagineCaricataPic.Location = new System.Drawing.Point(332, 197);
            this.immagineCaricataPic.Name = "immagineCaricataPic";
            this.immagineCaricataPic.Size = new System.Drawing.Size(163, 167);
            this.immagineCaricataPic.TabIndex = 7;
            this.immagineCaricataPic.TabStop = false;
            this.immagineCaricataPic.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Caricare l\'immagine da decriptare";
            // 
            // caricaImgButton
            // 
            this.caricaImgButton.Location = new System.Drawing.Point(352, 51);
            this.caricaImgButton.Name = "caricaImgButton";
            this.caricaImgButton.Size = new System.Drawing.Size(114, 60);
            this.caricaImgButton.TabIndex = 5;
            this.caricaImgButton.Text = "Carica Immagine";
            this.caricaImgButton.UseVisualStyleBackColor = true;
            this.caricaImgButton.Click += new System.EventHandler(this.caricaImgButton_Click);
            // 
            // checkAnteprimaGenerata
            // 
            this.checkAnteprimaGenerata.AutoSize = true;
            this.checkAnteprimaGenerata.Location = new System.Drawing.Point(604, 144);
            this.checkAnteprimaGenerata.Name = "checkAnteprimaGenerata";
            this.checkAnteprimaGenerata.Size = new System.Drawing.Size(168, 17);
            this.checkAnteprimaGenerata.TabIndex = 10;
            this.checkAnteprimaGenerata.Text = "Anteprima Immagine Generata";
            this.checkAnteprimaGenerata.UseVisualStyleBackColor = true;
            this.checkAnteprimaGenerata.CheckedChanged += new System.EventHandler(this.checkAnteprimaGenerata_CheckedChanged);
            // 
            // immagineGenerataPic
            // 
            this.immagineGenerataPic.Location = new System.Drawing.Point(604, 197);
            this.immagineGenerataPic.Name = "immagineGenerataPic";
            this.immagineGenerataPic.Size = new System.Drawing.Size(163, 167);
            this.immagineGenerataPic.TabIndex = 9;
            this.immagineGenerataPic.TabStop = false;
            this.immagineGenerataPic.Visible = false;
            // 
            // iniziaButton
            // 
            this.iniziaButton.Location = new System.Drawing.Point(551, 51);
            this.iniziaButton.Name = "iniziaButton";
            this.iniziaButton.Size = new System.Drawing.Size(82, 60);
            this.iniziaButton.TabIndex = 11;
            this.iniziaButton.Text = "Inizia Criptazione";
            this.iniziaButton.UseVisualStyleBackColor = true;
            this.iniziaButton.Click += new System.EventHandler(this.iniziaButton_Click);
            // 
            // cancellaButton
            // 
            this.cancellaButton.Location = new System.Drawing.Point(639, 51);
            this.cancellaButton.Name = "cancellaButton";
            this.cancellaButton.Size = new System.Drawing.Size(82, 60);
            this.cancellaButton.TabIndex = 12;
            this.cancellaButton.Text = "Cancella Criptazione";
            this.cancellaButton.UseVisualStyleBackColor = true;
            this.cancellaButton.Click += new System.EventHandler(this.cancellaButton_Click);
            // 
            // salvaButton
            // 
            this.salvaButton.Location = new System.Drawing.Point(727, 51);
            this.salvaButton.Name = "salvaButton";
            this.salvaButton.Size = new System.Drawing.Size(82, 60);
            this.salvaButton.TabIndex = 13;
            this.salvaButton.Text = "Salva Immagine";
            this.salvaButton.UseVisualStyleBackColor = true;
            this.salvaButton.Click += new System.EventHandler(this.salvaButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Caratteri x Thread";
            // 
            // nBlocchiThreadLabel
            // 
            this.nBlocchiThreadLabel.AutoSize = true;
            this.nBlocchiThreadLabel.Location = new System.Drawing.Point(120, 459);
            this.nBlocchiThreadLabel.Name = "nBlocchiThreadLabel";
            this.nBlocchiThreadLabel.Size = new System.Drawing.Size(31, 13);
            this.nBlocchiThreadLabel.TabIndex = 15;
            this.nBlocchiThreadLabel.Text = "1000";
            // 
            // sindacoBar
            // 
            this.sindacoBar.Location = new System.Drawing.Point(332, 423);
            this.sindacoBar.Name = "sindacoBar";
            this.sindacoBar.Size = new System.Drawing.Size(440, 23);
            this.sindacoBar.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 559);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "0";
            // 
            // nThreadTotaliLabel
            // 
            this.nThreadTotaliLabel.Location = new System.Drawing.Point(436, 554);
            this.nThreadTotaliLabel.Name = "nThreadTotaliLabel";
            this.nThreadTotaliLabel.Size = new System.Drawing.Size(136, 23);
            this.nThreadTotaliLabel.TabIndex = 19;
            this.nThreadTotaliLabel.Text = "N. Thread Totali: 5238";
            this.nThreadTotaliLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // binarioBar
            // 
            this.binarioBar.Location = new System.Drawing.Point(332, 515);
            this.binarioBar.Name = "binarioBar";
            this.binarioBar.Size = new System.Drawing.Size(177, 23);
            this.binarioBar.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(365, 497);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Conversione In Binario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(620, 499);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Inserimento nell\'Immagine";
            // 
            // sindacoStatusLabel
            // 
            this.sindacoStatusLabel.Location = new System.Drawing.Point(436, 390);
            this.sindacoStatusLabel.Name = "sindacoStatusLabel";
            this.sindacoStatusLabel.Size = new System.Drawing.Size(225, 23);
            this.sindacoStatusLabel.TabIndex = 23;
            this.sindacoStatusLabel.Text = "Stato: In Attesa";
            this.sindacoStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pittoreBar
            // 
            this.pittoreBar.Location = new System.Drawing.Point(595, 515);
            this.pittoreBar.Name = "pittoreBar";
            this.pittoreBar.Size = new System.Drawing.Size(177, 23);
            this.pittoreBar.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(636, 541);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "N. Pixel Processati";
            // 
            // binarioUpdateButton
            // 
            this.binarioUpdateButton.Location = new System.Drawing.Point(196, 536);
            this.binarioUpdateButton.Name = "binarioUpdateButton";
            this.binarioUpdateButton.Size = new System.Drawing.Size(101, 23);
            this.binarioUpdateButton.TabIndex = 26;
            this.binarioUpdateButton.Text = "AggiornaBinario";
            this.binarioUpdateButton.UseVisualStyleBackColor = true;
            this.binarioUpdateButton.Click += new System.EventHandler(this.binarioUpdateButton_Click);
            // 
            // Criptazione
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 586);
            this.Controls.Add(this.binarioUpdateButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pittoreBar);
            this.Controls.Add(this.sindacoStatusLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.binarioBar);
            this.Controls.Add(this.nThreadTotaliLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sindacoBar);
            this.Controls.Add(this.nBlocchiThreadLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.salvaButton);
            this.Controls.Add(this.cancellaButton);
            this.Controls.Add(this.iniziaButton);
            this.Controls.Add(this.checkAnteprimaGenerata);
            this.Controls.Add(this.immagineGenerataPic);
            this.Controls.Add(this.checkAnteprimaCaricata);
            this.Controls.Add(this.immagineCaricataPic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.caricaImgButton);
            this.Controls.Add(this.textConvertireBox);
            this.Controls.Add(this.inserisciTextBoxButton);
            this.Controls.Add(this.inserisciFileButton);
            this.Controls.Add(this.trackBar1);
            this.Name = "Criptazione";
            this.Text = "Criptazione";
            this.Load += new System.EventHandler(this.Criptazione_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.immagineCaricataPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.immagineGenerataPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.Button inserisciFileButton;
        private System.Windows.Forms.Button inserisciTextBoxButton;
        private System.Windows.Forms.TextBox textConvertireBox;
        private System.Windows.Forms.CheckBox checkAnteprimaCaricata;
        private System.Windows.Forms.PictureBox immagineCaricataPic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button caricaImgButton;
        private System.Windows.Forms.CheckBox checkAnteprimaGenerata;
        private System.Windows.Forms.PictureBox immagineGenerataPic;
        private System.Windows.Forms.Button iniziaButton;
        private System.Windows.Forms.Button cancellaButton;
        private System.Windows.Forms.Button salvaButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nBlocchiThreadLabel;
        private System.Windows.Forms.ProgressBar sindacoBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label nThreadTotaliLabel;
        private System.Windows.Forms.ProgressBar binarioBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label sindacoStatusLabel;
        private System.Windows.Forms.ProgressBar pittoreBar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button binarioUpdateButton;
    }
}