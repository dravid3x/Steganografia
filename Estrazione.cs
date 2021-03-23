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
    public partial class Estrazione : Form
    {
        private const int dimByte = 8;
        private Bitmap immagineCaricata;
        private readonly Bitmap immagineVuota;
        private worker estrazioneWorker = new worker();
        private string testoOttenuto = "";

        public Estrazione()
        {
            InitializeComponent();
        }

        private void Estrazione_Load(object sender, EventArgs e)
        {
            immagineCaricataPic.SizeMode = PictureBoxSizeMode.StretchImage; //Strecho l'immagine per farcela stare
            textDecriptato.ScrollBars = ScrollBars.Both;    //Imposto la barra per scorrere la textbox
            estrazioneWorker.WorkerReportsProgress = true;   //Abilito il report dello stato del worker
            estrazioneWorker.WorkerSupportsCancellation = true;  //Abilito la possibilità di cancellare la task del thread
            estrazioneWorker.RunWorkerCompleted += estrazioneWorker_LavoroCompletato;     //Associo la funzione di LavoroCompletato
            estrazioneWorker.ProgressChanged += estrazioneWorker_ProgressChanged;     //Associo la funzione di quando il worker progredisce
            estrazioneWorker.DoWork += estrazioneWorker_Lavora;       //Associo la funzione di Lavoro
            progressoLabel.Text = "Stato conversione: In Attesa";
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
            fDialog.Filter = "Immagine Bitmap|*.BMP";
            DialogResult result = fDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Dichiaro e aggiungo una picturebox contenente l'immagine selezionata
                try
                {
                    immagineCaricata = new Bitmap(fDialog.FileName);      //Carico l'immagine originale nella variabile globale
                    if (checkAnteprima.Checked == true) immagineCaricataPic.Image = immagineCaricata;
                }
                catch (Exception eccezione)
                {
                    MessageBox.Show("Errore:\n" + eccezione.Message);
                    return;
                }
            }
        }

        private void decriptaButton_Click(object sender, EventArgs e)
        {
            //Controllo se è stata caricata un immagine, confrontando l'immagineCaricata con un'immagineVuota
            if (immagineCaricata == immagineVuota)
            {
                textDecriptato.Clear();
                textDecriptato.Text = "Nessuna immagine caricata...";
            }
            else
            {
                if (estrazioneWorker.IsBusy != true)
                {
                    //Inizio il lavoro di estrazione, imposto il valore attuale e massimo della progressBar
                    progressBar1.Maximum = immagineCaricata.Width * immagineCaricata.Height;    //Imposto il valore massimo della progressBar
                    progressBar1.Value = 0;     //Imposto a 0 il valore della progressBar
                    progressBar1.Step = 1;      //Imposto a 1 il valore che verrà aggiunto ad ogni "passo avanti" della progressBar (ovvero ogni volta che avanzo di 1 pixel"
                    textDecriptato.Clear();     //Ripulisco la textBox del testoDecriptato
                    progressoLabel.Text = "Stato Conversione: In Corso";
                    nPixelLabel.Text = progressBar1.Maximum.ToString() + " Pixel Totali";
                    estrazioneWorker.RunWorkerAsync();       //Do il via alla conversione
                }
                else
                {
                    MessageBox.Show("Vi è un processo già in corso.\nCancellarlo per poter procedere ad una nuova decriptazione o attendere che finisca.");
                }
            }
        }

        private void estrazioneWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.PerformStep();  //Riporto la percentuale di progresso tramite la progressBar. So che non utilizzo il valore progress del worker ma dettagli. Volevo utilizzare la PerformStep perchè si
        }

        private void estrazioneWorker_LavoroCompletato(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                //Identifico che il lavoro è stato cancellato
                label2.Text = "Cancellato!";
            }
            else if (e.Error != null)
            {
                //Identifico che il worker ha avuto un problema
                label2.Text = "Errore: " + e.Error.Message;
            }
            else
            {
                //Identifico che il worker ha terminato il suo compito correttamente
                progressoLabel.Text = "Stato Conversione: Completata!";
                testoOttenuto = estrazioneWorker.testoProcessato;
                textDecriptato.Text = testoOttenuto;
            }
        }

        private void estrazioneWorker_Lavora(object sender, DoWorkEventArgs e)
        {
            worker worker = sender as worker;
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
                    //Controllo se vi è una richiesta di interruzione del lavoro
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
                //Controllo se l'utente ha richiesto la cancellazione del thread, questo controllo serve a impedire conversioni che potrebbero causare problemi
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
            if (estrazioneWorker.WorkerSupportsCancellation == true)
            {
                estrazioneWorker.CancelAsync();  //Cancello il lavoro in corso
            }
        }

        private void salvaButton_Click(object sender, EventArgs e)
        {
            //Richiamo la funzione per salvare una stringa in un file
            SalvaTestoInFile(testoOttenuto);
        }

        private void SalvaTestoInFile(string testo)
        {
            //Parte per il salvataggio di testo in un file
            SaveFileDialog testoSalvare = new SaveFileDialog();
            testoSalvare.Title = "Dove desidera salvare il file contenente il testo decifrato?";
            testoSalvare.DefaultExt = "txt";
            testoSalvare.Filter = "File txt|*.txt|All files (*.*)|*.*";
            testoSalvare.ShowDialog();
            string posFile = testoSalvare.FileName;
            //Controllo che rileva eventuali errori nella scrittura del file.
            try
            {
                File.WriteAllText(posFile, testo);      //Scrivo il file di testo nella posizione scelta
            }
            catch (Exception) { /*MessageBox.Show(ecc.Message);*/ }
        }

    }
}