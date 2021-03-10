using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Steganografia
{
    public partial class Form1 : Form
    {
        const int dimByte = 8;
        public Form1()
        {
            InitializeComponent();
        }

        private void InserisciButton_Click(object sender, EventArgs e)
        {
            int offSetPic = 20, offSetLabel = 15;
            Point posIniziale = new Point(159, 26);
            DialogResult result = fDialog1.ShowDialog();
            PictureBox immagineOriginale = new PictureBox();
            PictureBox nuovaImmagine = new PictureBox();    //Dichiaro la nuova picturebox per l'immagine modificata
            immagineOriginale.Location = posIniziale;       //Imposto la posizione della prima picturebox
            if (result == DialogResult.OK)  //Controllo se è stato selezionato un file adatto
            {
                immagineOriginale.Load(fDialog1.FileName);  //Carico l'immagine originale nella prima picturebox
                immagineOriginale.Size = new Size(immagineOriginale.Image.Width, immagineOriginale.Image.Height);   //Imposto la size della prima picturebox in base alle dimensioni dell'imamgine
                this.Controls.Add(immagineOriginale);   //Aggiungo la prima picturebox all'interno del form
                if (testoTextBox.Text.Length != 0)   //Controllo se il testo inserito è maggiore di nulla
                {
                    Console.WriteLine(testoTextBox.Text);
                    Console.WriteLine(ConvertiInBinario(testoTextBox.Text));
                    nuovaImmagine.Location = new Point(immagineOriginale.Location.X + immagineOriginale.Size.Width + offSetPic, immagineOriginale.Location.Y);  //Imposto la posizione in base alla prima picturebox + un offset
                    nuovaImmagine.Size = immagineOriginale.Size;    //Copio la dimensione della prima picturebox
                    Image immagineFinale = Stg(immagineOriginale.Image, testoTextBox.Text);     //Salvo l'immagine che verrà modificata nell'immagine finale
                    FolderBrowserDialog fBDialog = new FolderBrowserDialog();   //Creo una FolderBrowserDialog per selezionare la cartella di destinazione dell'immagine modificata
                    fBDialog.Description = "Scegliere dove salvare l'immagine modificata";
                    DialogResult resultSalvataggio = fBDialog.ShowDialog();     //Mostro il dialogo
                    if (resultSalvataggio == DialogResult.OK)    //Controllo l'integrità della scelta
                    {
                        //Salvo l'immagine modificata nella cartella scelta con estensione bmp e nome originale + "_Convertito"
                        immagineFinale.Save(fBDialog.SelectedPath + "\\" + fDialog1.SafeFileName.Substring(0, fDialog1.SafeFileName.LastIndexOf('.')) + "_Convertito" + ".bmp");
                    }
                    nuovaImmagine.Image = immagineFinale;   //Metto l'immagine modificata nel 
                    this.Controls.Add(nuovaImmagine);       //Aggiungo la seconda picturebox all'interno del form
                }

                //Inseriscod dei laber per distinguere l'immagine originale dalla modificata
                Label primaImmagineLabel = new Label();
                primaImmagineLabel.Text = "Originale";
                primaImmagineLabel.Location = new Point(immagineOriginale.Location.X, immagineOriginale.Location.Y - offSetLabel);
                Controls.Add(primaImmagineLabel);
                Label seondaImmagineLabel = new Label();
                seondaImmagineLabel.Text = "Modificata";
                seondaImmagineLabel.Location = new Point(nuovaImmagine.Location.X, nuovaImmagine.Location.Y - offSetLabel);
                Controls.Add(seondaImmagineLabel);
            }
            else MessageBox.Show("Selezionato file invalido");

        }

        private Image Stg(Image immagine, String testo)
        {
            Bitmap outputBitmap = new Bitmap(immagine.Width, immagine.Height);

            //Cicli per copiare i pixel dell'immagine, per aggiungere il messaggio segreto bisognerà modificare la copia del colore corrente
            int indice = 0, carattereFine = 00000011;   //Indice per la posizione nella stringa binaria e carattere identificativo della fine
            testo = ConvertiInBinario(testo) + carattereFine;
            for (int y = 0; y < immagine.Height; y++)
            {
                for (int x = 0; x < immagine.Width; x++)
                {
                    Color coloreCorrente = (immagine as Bitmap).GetPixel(x, y);
                    Color nuovoColore = Color.FromArgb(coloreCorrente.A, (indice < testo.Length) ? ((testo[indice++] == 0) ? coloreCorrente.R & 0 : coloreCorrente.R | 1) : coloreCorrente.R, (indice < testo.Length) ? ((testo[indice++] == 0) ? coloreCorrente.G & 0 : coloreCorrente.G | 1) : coloreCorrente.G, (indice < testo.Length) ? ((testo[indice++] == 0) ? coloreCorrente.B & 0 : coloreCorrente.B | 1) : coloreCorrente.B);  //Nuovo colore con i valori modificati
                    outputBitmap.SetPixel(x, y, nuovoColore);
                }
            }

            //Console.WriteLine("R: " + coloreCorrente.R.ToString() + "\nG: " + coloreCorrente.G.ToString() + "\nB: " + coloreCorrente.B.ToString());

            return outputBitmap;
        }

        private string ConvertiInBinario(string parola)
        {
            string convertita = "";     //Dichiaro la stringa vuota
            for (int i = 0; i < parola.Length; i++)      //Scorro tutta la stringa
            {
                string binario = Convert.ToString(parola[i], 2);    //Converto il carattere in binario
                if (binario.Length < 8)  //Se c'erano zeri di fronte devo rimetterli
                {
                    string nuovoBinario = "";
                    int nBitMancanti = dimByte - binario.Length;    //Calcolo quanti 0 mancano
                    for (int k = 0; k < nBitMancanti; k++) nuovoBinario += "0";     //Inserisco gli 0 mancanti
                    nuovoBinario += binario;    //Aggiungo la parte già ottenuta
                    binario = nuovoBinario;
                }
                convertita += binario;  //Sommo tutte le conversioni
            }
            return convertita;
        }

        private void DecodificaButton_Click(object sender, EventArgs e)
        {
            DialogResult result = fDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

            }
            else MessageBox.Show("Selezionato file invalido");
        }
    }
}


//Color primoColore = (immagineOriginale.Image as Bitmap).GetPixel(0, 0);
//Color secondoColore = (nuovaImmagine.Image as Bitmap).GetPixel(0, 0);
//Console.WriteLine("R: " + primoColore.R.ToString() + "\nG: " + primoColore.G.ToString() + "\nB: " + primoColore.B.ToString());
//Console.WriteLine("R: " + secondoColore.R.ToString() + "\nG: " + secondoColore.G.ToString() + "\nB: " + secondoColore.B.ToString());