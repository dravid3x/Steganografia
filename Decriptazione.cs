using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganografia
{
    public partial class Decriptazione : Form
    {
        const int dimByte = 8;
        Bitmap immagineCaricata, immagineVuota;
        schiavo decriptazioneWorker = new schiavo();
        string testoOttenuto = "";

        public Decriptazione()
        {
            InitializeComponent();
        }

        private void Decriptazione_Load(object sender, EventArgs e)
        {
            immagineCaricataPic.SizeMode = PictureBoxSizeMode.StretchImage; //Strecho l'immagine per farcela stare
            textDecriptato.ScrollBars = ScrollBars.Vertical;
            decriptazioneWorker.WorkerReportsProgress = true;
            decriptazioneWorker.WorkerSupportsCancellation = true;
            decriptazioneWorker.RunWorkerCompleted += decriptazioneWorker_LavoroCompletato;
            decriptazioneWorker.ProgressChanged += decriptazioneWorker_ProgressChanged;
            decriptazioneWorker.DoWork += decriptazioneWorker_Lavora;
        }

        private void checkAnteprima_CheckedChanged(object sender, EventArgs e)
        {
            immagineCaricataPic.Visible = !immagineCaricataPic.Visible;     //Rendo la picturebox visibile o non visibile
            if (checkAnteprima.Checked) immagineCaricataPic.Image = immagineCaricata;   //Carico l'immagine salvata in precedenza
            else immagineCaricataPic.Image = immagineVuota;     //Svuoto il campo Image della picturebox
        }

        private void caricaImgButton_Click(object sender, EventArgs e)
        {
            CaricaImmagine();   //Richiamo la funzione di caricamento dell'immagine
        }

        private void CaricaImmagine()
        {
            //Funzione che permette il caricamento di un immagine
            OpenFileDialog fDialog = new OpenFileDialog();
            DialogResult result = fDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Dichiaro e aggiungo una picturebox contenente l'immagine selezionata
                try
                {
                    immagineCaricata = new Bitmap(fDialog.FileName);      //Carico l'immagine originale nella variabile globale
                    if (checkAnteprima.Checked == true) immagineCaricataPic.Image = immagineCaricata;
                }
                catch (Exception eccezzione)
                {
                    MessageBox.Show("Errore:\n" + eccezzione.Message);
                    return;
                }
            }
            else MessageBox.Show("Selezionato file invalido");
        }

        private void decriptaButton_Click(object sender, EventArgs e)
        {
            if (decriptazioneWorker.IsBusy != true)
            {
                //Inizio il lavoro di decriptazione, imposto il valore attuale e massimo della progressBar
                progressBar1.Maximum = immagineCaricata.Width * immagineCaricata.Height;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                textDecriptato.Clear();
                progressoLabel.Text = "Posizione/Progresso nell'immagine in pixel";
                nPixelLabel.Text = progressBar1.Maximum.ToString() + " Pixel Totali";
                decriptazioneWorker.RunWorkerAsync();
            }
            else
            {
                //Se il worker è impegnato cancello la richiesta e inizio la nuova
                decriptazioneWorker.CancelAsync();
                progressBar1.Value = 0;
                decriptazioneWorker.RunWorkerAsync();
            }
        }

        private void decriptazioneWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.PerformStep();  //Riporto la percentuale di progresso tramite la progressBar. So che non utilizzo il valore progress del worker ma dettagli. Volevo utilizzare la PerformStep perchè si
        }

        private void decriptazioneWorker_LavoroCompletato(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                progressoLabel.Text = "Cancellato!";
            }
            else if (e.Error != null)
            {
                progressoLabel.Text = "Errore: " + e.Error.Message;
            }
            else
            {
                progressoLabel.Text = "Completato!";
                testoOttenuto = decriptazioneWorker.testoProcessato;
                textDecriptato.Text = testoOttenuto;
            }
        }

        private void decriptazioneWorker_Lavora(object sender, DoWorkEventArgs e)
        {
            schiavo worker = sender as schiavo;
            int x = 0, y = 0, posColore = 0, progresso = 0;
            string carattereFine = "00000100";
            bool tailDetected = false;
            string testoFinale = "";
            while (!tailDetected)
            {
                int pos = 0;
                string carattereAttuale = "";
                while (pos < dimByte)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        tailDetected = true;
                        break;
                    }
                    Color colore = (immagineCaricata as Bitmap).GetPixel(x, y);
                    //Switch ce esegue la conversione e salvataggio del char trovato in base al turno R, G o B
                    switch (posColore)
                    {
                        case 0:
                            carattereAttuale += (colore.R % 2 == 0) ? "0" : "1";
                            break;
                        case 1:
                            carattereAttuale += (colore.G % 2 == 0) ? "0" : "1";
                            break;
                        case 2:
                            carattereAttuale += (colore.B % 2 == 0) ? "0" : "1";
                            break;
                    }
                    //Controllo per ricominciare da R se arrivo a B, con annesso controllo della x per passare al pixel successivo senza sbordare, se sbordo aumento la y e resetto la x
                    if (posColore == 2)
                    {
                        posColore = 0;
                        if (x + 1 < immagineCaricata.Width) x++;
                        else
                        {
                            x = 0;
                            y++;
                        }
                    }
                    else posColore++;
                    pos++;
                }
                //Controllo se l'utente ha richiesto la cancellazione del thread
                if (!e.Cancel)
                {
                    char carattereFinale = (char)Convert.ToInt32(carattereAttuale, 2);
                    if (carattereFinale == (char)Convert.ToInt32(carattereFine, 2)) tailDetected = true;    //Controllo per identificare la tail che indica la fine del messaggio
                    else testoFinale += carattereFinale;
                    progresso++;
                    worker.ReportProgress(progresso);       //Dico al worker di riferire il progresso fatto, ovvero a che pixel siamo
                }
            }
            worker.testoProcessato = testoFinale;   //Salvo il testo ottenuto
        }

        private void cancellaDecButton_Click(object sender, EventArgs e)
        {
            //Controllo inutile ma sempre meglio inserirlo
            if (decriptazioneWorker.WorkerSupportsCancellation == true)
            {
                decriptazioneWorker.CancelAsync();  //Cancella il lavoro in corso
            }
        }

        private void salvaButton_Click(object sender, EventArgs e)
        {
            //Salvataggio in file
            DialogResult salvareFile = MessageBox.Show("Desidera salvare il risultato in un file di testo?", "Salvare in un file?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (salvareFile == DialogResult.Yes)
            {
                DialogResult ritentare = DialogResult.Yes;
                while (!SalvaOutputFile(testoOttenuto))
                {
                    ritentare = MessageBox.Show("Qualcosa è andato storto nel salvataggio\nRitentare?", "Errore salvataggio", MessageBoxButtons.YesNo);
                    if (ritentare == DialogResult.No) break;
                }
                if (ritentare != DialogResult.No)
                {
                    MessageBox.Show("File salvato correttamente", "Salvataggio riuscito");
                }
            }
        }

        private bool SalvaOutputFile(string testo)
        {
            //Parte per il salvataggio dell'output in file
            SaveFileDialog testoSalvare = new SaveFileDialog();
            testoSalvare.Title = "Dove desidera salvare il file contenente il testo decifrato?";
            testoSalvare.DefaultExt = "txt";
            testoSalvare.ShowDialog();
            string posFile = testoSalvare.FileName;     //Compongo la pos di destinazione aggiungendo il nome scelto per il file                                                                                           //Controllo che rileva eventuali errori nella scrittura del file, come errori di permessi ecc.
            try
            {
                File.WriteAllText(posFile, testo);      //Scrivo il file di testo nella posizione scelta
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
