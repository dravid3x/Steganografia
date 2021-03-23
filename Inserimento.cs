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
    public partial class Inserimento : Form
    {
        private const int lunghezzaBlocchiThreadDefault = 1000, dimByte = 8;
        private int lunghezzaBlocchiThread = 1000;
        private Bitmap immagineCaricata, immagineGenerata;
        private readonly Bitmap immagineVuota;
        private string testoDaCodificare = "", testoInBinario = "";
        private gestoreConvertitori GestoreConvertitori = new gestoreConvertitori();
        private BackgroundWorker GestoreGenerale = new BackgroundWorker();
        private BackgroundWorker InserimentoInImmagine_Worker = new BackgroundWorker();

        public Inserimento()
        {
            InitializeComponent();
        }

        private void gestoreConvertitori_Lavoro(object sender, DoWorkEventArgs e)
        {
            gestoreConvertitori gestoreConvertitori = sender as gestoreConvertitori;
            List<worker> schiavi = new List<worker>();
            string testo = gestoreConvertitori.testoDaProcessare;
            int nSchiavi = (testo.Length + lunghezzaBlocchiThread - 1) / lunghezzaBlocchiThread;
            List<string> pezzi = new List<string>();
            //Spezzettamento del testo in blocchi di lunghezza lunghezzaBlocchiThread
            for (int i = 0; i < nSchiavi; i++)
            {
                string pezzo = "";
                blocco(ref testo, ref pezzo, i);
                pezzi.Add(pezzo);
            }
            gestoreConvertitori.pezzi = pezzi;  //Passo la lista di pezzi al gestoreConvertitori
            gestoreConvertitori.GeneraSchiavi((testoDaCodificare.Length + lunghezzaBlocchiThread - 1) / lunghezzaBlocchiThread);
        }

        private void gestoreConvertitori_LavoroCompletato(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void blocco(ref string testoOriginale, ref string bloccoDiTesto, int nSchiavo)
        {
            if (testoOriginale.Length >= lunghezzaBlocchiThread)   //Parti normali da lunghezzaBlocchi
            {
                bloccoDiTesto = testoOriginale.Substring(0, lunghezzaBlocchiThread);
                testoOriginale = testoOriginale.Remove(0, lunghezzaBlocchiThread);
            }
            else    //Ultimo blocco minore di lunghezzaBlocchi
            {
                bloccoDiTesto = testoOriginale.Substring(0, testoOriginale.Length);
                testoOriginale = testoOriginale.Remove(0, testoOriginale.Length);
            }
        }

        private int AzzeraLSBit(int val)
        {
            //In teoria mi basta aggiugnere o togliere il valore 1 all'intero per settarlo a 0. Ma prima devo identifico se è pari o dispari per vedere l'ultimo bit
            if (val % 2 != 0) return val - 1;
            else return val;
        }

        private void ConvertiInBinario(string parola)
        {
            if (parola.Length < lunghezzaBlocchiThread)
            {
                string res = "";
                foreach (char c in parola) res += (Convert.ToString(c, 2).PadLeft(8, '0'));
                testoInBinario = res;
            }
            else
            {
                GestoreConvertitori.testoDaProcessare = parola;
                GestoreConvertitori.DoWork += gestoreConvertitori_Lavoro;
                GestoreConvertitori.RunWorkerCompleted += gestoreConvertitori_LavoroCompletato;
                GestoreConvertitori.RunWorkerAsync();
                //while (!GestoreConvertitori.finito) ;
                testoInBinario = GestoreConvertitori.testoProcessato;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lunghezzaBlocchiThread = trackBar1.Value;
            nBlocchiThreadLabel.Text = trackBar1.Value.ToString();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trackBar1.Value = lunghezzaBlocchiThreadDefault;
        }

        private void checkAnteprimaCaricata_CheckedChanged(object sender, EventArgs e)
        {
            immagineCaricataPic.Visible = !immagineCaricataPic.Visible;
            if (checkAnteprimaCaricata.Checked) immagineCaricataPic.Image = immagineCaricata;   //Carico l'immagine salvata in precedenza
            else immagineCaricataPic.Image = immagineVuota;     //Svuoto il campo Image della picturebox
        }

        private void checkAnteprimaGenerata_CheckedChanged(object sender, EventArgs e)
        {
            immagineGenerataPic.Visible = !immagineGenerataPic.Visible;
            if (checkAnteprimaGenerata.Checked) immagineGenerataPic.Image = immagineGenerata;   //Carico l'immagine salvata in precedenza
            else immagineGenerataPic.Image = immagineVuota;     //Svuoto il campo Image della picturebox
        }

        private void inserisciTextBoxButton_Click(object sender, EventArgs e)
        {
            testoDaCodificare = textConvertireBox.Text;     //Salvo il testo inserito nella textBox
        }

        private void inserisciFileButton_Click(object sender, EventArgs e)
        {
            //Funzione per l'inserimento del testo da parte da file, il quale viene caricato nella textBox
            OpenFileDialog fileTestoDialog = new OpenFileDialog();
            DialogResult risFileTesto = fileTestoDialog.ShowDialog();
            if (risFileTesto == DialogResult.OK)
            {
                if (File.Exists(fileTestoDialog.FileName))
                {
                    testoDaCodificare = File.ReadAllText(fileTestoDialog.FileName);
                    textConvertireBox.Text = testoDaCodificare;
                }
            }
        }

        private void caricaImgButton_Click(object sender, EventArgs e)
        {
            //Funzione per il caricamento e salvataggio dell'immagine da utilizzare
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "Immagine|*.BMP;*.JPEG;*.JPG;*.PNG";
            fDialog.Title = "Selezionare l'immagine da utilizzare";
            DialogResult result = fDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                immagineCaricata = new Bitmap(fDialog.FileName);
                if (checkAnteprimaCaricata.Checked == true) immagineCaricataPic.Image = immagineCaricata;
            }
        }

        private void iniziaButton_Click(object sender, EventArgs e)
        {
            //Funzione che, se possibile, fa partire la criptazione
            if (testoDaCodificare.Length == 0)
            {
                MessageBox.Show("Inserire prima del testo da criptare.");
            }
            //Controllo se è stata caricata un'immagine
            else if (immagineCaricata == immagineVuota)
            {
                MessageBox.Show("Caricare prima un immagine.");
            }
            //Controllo se le dimensioni sono valide per contenere il testo
            else if (((testoDaCodificare.Length * 8) + dimByte) > (immagineCaricata.Size.Width * immagineCaricata.Size.Height * 3))
            {
                MessageBox.Show("Lunghezza del testo eccessiva per l'immagine selezionata");
            }
            else
            {
                trackBar1.Enabled = false;
                //Avvio la criptazione, inizializzo il sindaco
                GestoreGenerale = new BackgroundWorker();
                binarioBar.Value = 0;
                binarioBar.Maximum = (testoDaCodificare.Length + lunghezzaBlocchiThread - 1) / lunghezzaBlocchiThread;
                GestoreGenerale.WorkerReportsProgress = true;
                GestoreGenerale.WorkerSupportsCancellation = true;
                GestoreGenerale.DoWork += GestoreGenerale_Lavoro;
                GestoreGenerale.RunWorkerCompleted += GestoreGenerale_LavoroCompletato;
                GestoreGenerale.ProgressChanged += GestoreGenerale_ProgressChanged;
                GestoreGenerale.RunWorkerAsync();
            }
        }

        private void GestoreGenerale_Lavoro(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (!e.Cancel)
            {
                //sindacoStatusLabel.Text = "Status: Conversione Binaria";
                ConvertiInBinario(testoDaCodificare);
                //sindacoStatusLabel.Text = "Status: Conclusa Conversione Binaria";
                worker.ReportProgress(50);
            }
        }

        private void GestoreGenerale_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statoGeneraleBar.Value = e.ProgressPercentage;    //Incremento il valore della progressBar
        }

        private void GestoreGenerale_LavoroCompletato(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                generaleStatusLabel.Text = "Status: Cancellato";
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Errore nel processo in immagine");
            }
            else
            {
                generaleStatusLabel.Text = "Status: Avviata conversione in binario";
            }
        }

        private void binarioUpdateButton_Click(object sender, EventArgs e)
        {
            if(testoDaCodificare.Length < lunghezzaBlocchiThread)
            {
                IniziaConversioneImmagine();
            }
            else
            {
                int nFiniti = GestoreConvertitori.ContaFiniti();
                binarioBar.Value = nFiniti;
                if (GestoreConvertitori.finito)
                {
                    testoInBinario = GestoreConvertitori.testoProcessato;
                    nThreadTotaliLabel.Text = "N. Thread Totali: " + GestoreConvertitori.nSchiavi.ToString();
                    generaleStatusLabel.Text = "Status: Inizio inserimento in immagine";
                    IniziaConversioneImmagine();
                }
            }

        }

        private void salvaButton_Click(object sender, EventArgs e)
        {
            //Parte per il salvataggio dell'immagine
            SaveFileDialog immagineSalvare = new SaveFileDialog();
            immagineSalvare.Title = "Dove desidera salvare l'immagine generata?";
            immagineSalvare.DefaultExt = "bmp";
            immagineSalvare.Filter = "Immagine BMP|*.BMP";
            immagineSalvare.ShowDialog();
            string posFile = immagineSalvare.FileName;
            //Controllo che rileva eventuali errori nella scrittura del file.
            try
            {
                immagineGenerata.Save(posFile);
            }
            catch (Exception) { /*MessageBox.Show(ecc.Message);*/ }
        }

        private void InserimentoInImmagine_Lavoro(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Image immagine = immagineCaricata; string testo = testoInBinario;
            Bitmap outputBitmap = new Bitmap(immagine.Width, immagine.Height);
            //Cicli per copiare i pixel dell'immagine, per aggiungere il messaggio segreto bisognerà modificare la copia del colore corrente
            //Indice per la posizione nella stringa binaria
            int indice = 0, posTotaleStatus = 0;
            string carattereFine = "00000100";    //carattere identificativo della fine del testo
            testo = testoInBinario;
            testo += carattereFine;
            //Console.WriteLine(testo);
            int y = 0;
            while (y < immagine.Height && !e.Cancel)
            {
                int x = 0;
                while (x < immagine.Width && !e.Cancel)
                {
                    Color coloreCorrente = (immagine as Bitmap).GetPixel(x, y);
                    Color nuovoColore;
                    int R = coloreCorrente.R, G = coloreCorrente.G, B = coloreCorrente.B, dimTesto = testo.Length;
                    /*Traduzione della riga a venire
                     * Prima controllo se l'indice ha raggiunto la dim del testo, se si il nuovo colore sarà uguale al vecchio, altrimenti diventerà un colore nuovo il quale sarà composto dalla Alpha precedente (non la utilizziamo anche se fornirebbe un bit aggiuntivo allungando lo spazio disponibile)
                     * La R G e B sono calcolate nel medesimo modo, viene controllato l'indice, se esso è arrivato a fine testo inserirò il valore senza modificarlo, altrimenti controllerò se esso risulta uno 0 o un 1, se 0 imposterò come valore quello restituito da AzzeraLSBit, la quale toglierà 1 al valore passatogli
                     * In modo da mettere l'ultimo bit a 0, altrimenti se la cella ha valore 1 verrà inserito come valore quello precedente | 1, ovvero verrà impostato l'ultimo bit a 1.
                     * (Evito il controllo dell'indice per la R avendolo appena fatto per entrare nell'if precedente*/
                    nuovoColore = (indice < dimTesto) ? Color.FromArgb(coloreCorrente.A, ((testo[indice++] == '0') ? AzzeraLSBit(R) : R | 1), ((indice < dimTesto) ? ((testo[indice++] == '0') ? AzzeraLSBit(G) : G | 1) : G), ((indice < dimTesto) ? ((testo[indice++] == '0') ? AzzeraLSBit(B) : B | 1) : B)) : coloreCorrente;
                    outputBitmap.SetPixel(x, y, nuovoColore);  //Imposto il pixel della nuova immagine in base ai valori calcolati
                    x++;
                    posTotaleStatus++;
                    worker.ReportProgress(posTotaleStatus);
                    if (worker.CancellationPending == true) e.Cancel = true;
                }
                y++;
            }
            if(!e.Cancel) immagineGenerata = outputBitmap;    //Salvo l'immagine modificata
        }

        private void cancellaButton_Click(object sender, EventArgs e)
        {
            if(InserimentoInImmagine_Worker.WorkerSupportsCancellation == true)
            {
                InserimentoInImmagine_Worker.CancelAsync();
            }
        }

        private void Inserimento_Load(object sender, EventArgs e)
        {
            immagineCaricataPic.SizeMode = PictureBoxSizeMode.StretchImage;
            immagineGenerataPic.SizeMode = PictureBoxSizeMode.StretchImage;
            textConvertireBox.ScrollBars = ScrollBars.Both;
        }

        private void InserimentoInImmagine_Fine(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                generaleStatusLabel.Text = "Status: Cancellato";
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Errore nell'inserimento in immagine");
            }
            else
            {
                //Mostro l'immagine generata se richiesto
                if (immagineGenerataPic.Visible) immagineGenerataPic.Image = immagineGenerata;
                statoGeneraleBar.Value = statoGeneraleBar.Maximum;
                generaleStatusLabel.Text = "Status: Concluso inserimento in immagine";
                trackBar1.Enabled = true;
            }
        }

        private void InserimentoInImmagine_Progresso(object sender, ProgressChangedEventArgs e)
        {
            inserimentoinImmagineBar.Value = e.ProgressPercentage;    //Aggiorno il valore della progressBar della conversione in immagine
        }

        private void IniziaConversioneImmagine()
        {
            //Inizializzo il InserimentoInImmagine_Worker
            inserimentoinImmagineBar.Maximum = immagineCaricata.Width * immagineCaricata.Height;
            InserimentoInImmagine_Worker = new BackgroundWorker();
            InserimentoInImmagine_Worker.WorkerReportsProgress = true;
            InserimentoInImmagine_Worker.WorkerSupportsCancellation = true;
            InserimentoInImmagine_Worker.DoWork += InserimentoInImmagine_Lavoro;
            InserimentoInImmagine_Worker.RunWorkerCompleted += InserimentoInImmagine_Fine;
            InserimentoInImmagine_Worker.ProgressChanged += InserimentoInImmagine_Progresso;
            InserimentoInImmagine_Worker.RunWorkerAsync();
        }
    }
}