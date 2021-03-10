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
        const int dimByte = 8, offSetLabel = 15;
        bool visualizzaSoloMex = false, inserimentoDaFile = false;
        PictureBox immagineOriginale = new PictureBox();
        PictureBox nuovaImmagine = new PictureBox();    //Dichiaro la nuova picturebox per l'immagine modificata
        OpenFileDialog fDialog1 = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void InserisciButton_Click(object sender, EventArgs e)
        {
            string Testo = testoTextBox.Text;
            //Controllo la lunghezza del testo inserito, ovvero se l'utente ha inserito del testo
            if (Testo.Length == 0)
            {
                if (!inserimentoDaFile)
                {
                    MessageBox.Show("Inserire prima il testo da camuffare");
                    return;
                }
                inserimentoDaFile = false;
                OpenFileDialog fileTestoDialog = new OpenFileDialog();
                DialogResult risFileTesto = fileTestoDialog.ShowDialog();
                if(risFileTesto == DialogResult.OK)
                {
                    if (File.Exists(fileTestoDialog.FileName)){
                        Testo = File.ReadAllText(fileTestoDialog.FileName);
                    }
                }
            }
            int offSetPic = 20;
            DialogResult result = fDialog1.ShowDialog();
            immagineOriginale.Location = new Point((InserisciButton.Location.X * 2) + InserisciButton.Size.Width, InserisciButton.Location.Y);       //Imposto la posizione della prima picturebox
            if (result == DialogResult.OK)  //Controllo se è stato selezionato un file adatto
            {
                immagineOriginale.Load(fDialog1.FileName);  //Carico l'immagine originale nella prima picturebox
                //Controllo se le dimensioni sono valide per contenere il testo
                ulong spaziDisponibili = (ulong)(immagineOriginale.Image.Size.Width * immagineOriginale.Image.Size.Height * 3);
                if ((ulong)Testo.Length > spaziDisponibili)
                {
                    MessageBox.Show("Lunghezza del testo eccessiva per l'immagine selezionata");
                    return;
                }
                immagineOriginale.Size = new Size(immagineOriginale.Image.Width, immagineOriginale.Image.Height);   //Imposto la size della prima picturebox in base alle dimensioni dell'imamgine
                this.Controls.Add(immagineOriginale);   //Aggiungo la prima picturebox all'interno del form
                nuovaImmagine.Location = new Point(immagineOriginale.Location.X + immagineOriginale.Size.Width + offSetPic, immagineOriginale.Location.Y);  //Imposto la posizione in base alla prima picturebox + un offset
                nuovaImmagine.Size = immagineOriginale.Size;    //Copio la dimensione della prima picturebox
                Image immagineFinale = Stg(immagineOriginale.Image, Testo);     //Salvo l'immagine che verrà modificata nell'immagine finale
                FolderBrowserDialog fBDialog = new FolderBrowserDialog();   //Creo una FolderBrowserDialog per selezionare la cartella di destinazione dell'immagine modificata
                fBDialog.Description = "Scegliere dove salvare l'immagine modificata";
                DialogResult resultSalvataggio = fBDialog.ShowDialog();     //Mostro il dialogo
                if (resultSalvataggio == DialogResult.OK)    //Controllo l'integrità della scelta
                {
                    //Salvo l'immagine modificata nella cartella scelta con estensione bmp e nome originale + "_Convertito"
                    try
                    {
                        immagineFinale.Save(fBDialog.SelectedPath + "\\" + fDialog1.SafeFileName.Substring(0, fDialog1.SafeFileName.LastIndexOf('.')) + "_Convertito" + ".bmp");
                    }
                    catch (Exception errore)
                    {
                        MessageBox.Show("Qualcosa è andato storto\n" + errore.Message);
                    }
                }
                nuovaImmagine.Image = immagineFinale;   //Metto l'immagine modificata nel 
                this.Controls.Add(nuovaImmagine);       //Aggiungo la seconda picturebox all'interno del form
                //Inseriscod dei label per distinguere l'immagine originale dalla modificata. Se eseguo più volte la conversione i label si overlappano
                Label primaImmagineLabel = new Label();
                primaImmagineLabel = new Label();
                primaImmagineLabel.Text = "Originale";
                primaImmagineLabel.Location = new Point(immagineOriginale.Location.X, immagineOriginale.Location.Y - offSetLabel);
                Controls.Add(primaImmagineLabel);
                Label seondaImmagineLabel = new Label();
                seondaImmagineLabel = new Label();
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
            int indice = 0;//Indice per la posizione nella stringa binaria
            string carattereFine = "00000100";    //carattere identificativo della fine del testo
            testo = ConvertiInBinario(testo);
            testo += carattereFine;
            //Console.WriteLine(testo);
            int y = 0;
            bool finitoTesto = false;
            while (y < immagine.Height)
            {
                int x = 0;
                while (x < immagine.Width)
                {
                    Color coloreCorrente = (immagine as Bitmap).GetPixel(x, y);
                    Color nuovoColore;
                    int R = coloreCorrente.R, G = coloreCorrente.G, B = coloreCorrente.B;
                    if (!finitoTesto)
                    {
                        /*In questi controlli verifico se ho terminato di "criptare" tutto il testo inserito, se no converto il valore del colore R o G o B (1 per volta) in binario all'interno di una stringa
                         *Successivamente converto la stringa in array di tipo char per poter manipolare i singoli caratteri, ovvero i singoli bit del valore, imposterò poi l'ultimo bit del valore attuale a 0 o 1
                         *Passo al valore successivo sia nella sequenza RGB sia nella posizione all'interno del testo in binario. Quando terminerò il testo o copierò i pixel così come sono o non li copierò affatto in base a visualizzaSoloMex
                         */
                        if (indice < testo.Length)
                        {
                            string temp = Convert.ToString(coloreCorrente.R, 2);
                            char[] char_temp = temp.ToCharArray();
                            char_temp[char_temp.Length - 1] = (testo[indice++] == '0') ? '0' : '1';
                            temp = new string(char_temp);
                            R = Convert.ToInt32(temp, 2);
                        }
                        else finitoTesto = true;
                        if (indice < testo.Length)
                        {
                            string temp = Convert.ToString(coloreCorrente.G, 2);
                            char[] char_temp = temp.ToCharArray();
                            char_temp[char_temp.Length - 1] = (testo[indice++] == '0') ? '0' : '1';
                            temp = new string(char_temp);
                            G = Convert.ToInt32(temp, 2);
                        }
                        else finitoTesto = true;
                        if (indice < testo.Length)
                        {
                            string temp = Convert.ToString(coloreCorrente.B, 2);
                            char[] char_temp = temp.ToCharArray();
                            char_temp[char_temp.Length - 1] = (testo[indice++] == '0') ? '0' : '1';
                            temp = new string(char_temp);
                            B = Convert.ToInt32(temp, 2);
                        }
                        else finitoTesto = true;
                        nuovoColore = Color.FromArgb(coloreCorrente.A, R, G, B);
                    }
                    else nuovoColore = coloreCorrente;
                    //Opzione per mostrare solo i pixel del testo o tutta l'immagine converita.
                    if (visualizzaSoloMex)
                    {
                        if (!finitoTesto) outputBitmap.SetPixel(x, y, nuovoColore); //Imposto il pixel della nuova immagine in base ai valori calcolati
                    }
                    else outputBitmap.SetPixel(x, y, nuovoColore);  //Imposto il pixel della nuova immagine in base ai valori calcolati
                    x++;
                }
                y++;
            }
            return outputBitmap;    //Restituisco l'immagine modificata
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
            textBox1.ScrollBars = ScrollBars.Vertical;
            DialogResult result = fDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Dichiaro e aggiungo una picturebox contenente l'immagine selezionata
                PictureBox immagineOriginale = new PictureBox();
                immagineOriginale.Location = new Point((InserisciButton.Location.X * 2) + InserisciButton.Size.Width, InserisciButton.Location.Y);
                immagineOriginale.Load(fDialog1.FileName);  //Carico l'immagine originale nella prima picturebox
                immagineOriginale.Size = new Size(immagineOriginale.Image.Width, immagineOriginale.Image.Height);   //Imposto la size della prima picturebox in base alle dimensioni dell'
                string testoRicavato = Desteganografatore(immagineOriginale.Image);     //Richiamo la funzione di decodifica, potevo chiamarlo decodifica ma non puù dire che Desteganografatore non è fantastico come nome
                //Console.WriteLine(testoRicavato);
                textBox1.Text = testoRicavato;
            }
            else MessageBox.Show("Selezionato file invalido");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            testoTextBox.ScrollBars = ScrollBars.Vertical;  //Aggiungo la scrollbar verticale
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inserimentoDaFile = true;
            InserisciButton_Click(sender, e);
        }

        private void modalitàDiSalvataggioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizzaSoloMex = !visualizzaSoloMex; //Abilito o disabilito la modalità solo mex
            MessageBox.Show("Ora verranno salvati " + ((visualizzaSoloMex) ? "solamente i pixel del messaggio." : "tutti i pixel dell'immagine"));
        }

        private string Desteganografatore(Image immagine)
        {
            int dim = immagine.Width * immagine.Height, x = 0, y = 0, posColore = 0;
            string carattereFine = "00000100";
            bool tailDetected = false;
            string testoFinale = "";
            while (!tailDetected)
            {
                int pos = 0;
                string carattereAttuale = "";
                while (pos < dimByte)
                {
                    Color colore = (immagine as Bitmap).GetPixel(x, y);
                    //Switch ce esegue la conversione e salvataggio del char trovato in base al turno R, G o B
                    switch (posColore)
                    {
                        case 0:
                            {
                                //Converto in binario, poi in array di char e prendo il LSB
                                string temp = Convert.ToString(colore.R, 2);
                                char[] char_temp = temp.ToCharArray();
                                carattereAttuale += (char_temp[char_temp.Length - 1] == '0') ? "0" : "1";
                            }
                            break;
                        case 1:
                            {
                                //Converto in binario, poi in array di char e prendo il LSB
                                string temp = Convert.ToString(colore.G, 2);
                                char[] char_temp = temp.ToCharArray();
                                carattereAttuale += (char_temp[char_temp.Length - 1] == '0') ? "0" : "1";
                            }
                            break;
                        case 2:
                            {
                                //Converto in binario, poi in array di char e prendo il LSB
                                string temp = Convert.ToString(colore.B, 2);
                                char[] char_temp = temp.ToCharArray();
                                carattereAttuale += (char_temp[char_temp.Length - 1] == '0') ? "0" : "1";
                            }
                            break;
                    }
                    //Controllo per ricominciare da R se arrivo a B, con annesso controllo della x per passare al pixel successivo senza sbordare, se sbordo aumento la y e resetto la x
                    if (posColore == 2)
                    {
                        posColore = 0;
                        if (x + 1 < immagine.Width) x++;
                        else
                        {
                            x = 0;
                            y++;
                        }
                    }
                    else posColore++;
                    pos++;
                }
                char carattereFinale = (char)Convert.ToInt32(carattereAttuale, 2);
                if (carattereFinale == (char)Convert.ToInt32(carattereFine, 2)) tailDetected = true;    //Controllo per identificare la tail che indica la fine del messaggio
                else testoFinale += carattereFinale;
            }
            return testoFinale;
        }

        private string TestoDaFile(string dir)
        {
            return "ads";
        }
    }
}
