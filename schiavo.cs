using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Steganografia
{
    class schiavo : BackgroundWorker
    {
        //BackgroundWorker worker = new BackgroundWorker();
        public string testoDaProcessare = "", testoProcessato = "";
        public bool finito = false;
        public schiavo()
        {
            //Non inserisco il testo da processare come parametro per poter riutilizzare questo schiavo anche nella decriptazione
        }

    }

    class mastino : BackgroundWorker
    {
        public string testoProcessato = "", testoDaProcessare = "";
        public bool finito = false;
        private int NSchiavi = -1;
        public List<schiavo> schiavi = new List<schiavo>();
        public List<string> pezzi = new List<string>();

        public mastino()
        {

        }

        public void GeneraSchiavi(int nSchiavi)
        {
            NSchiavi = nSchiavi;
            //Dichiaro e assegno ad ogni thread un pezzo di testo da processare
            for (int i = 0; i < nSchiavi; i++)
            {
                schiavo worker = new schiavo();
                worker.testoDaProcessare = pezzi[i];
                worker.WorkerReportsProgress = true;
                worker.WorkerSupportsCancellation = true;
                worker.DoWork += schiavoWorker_Lavoro;
                worker.RunWorkerCompleted += schiavoWorker_LavoroCompletato;
                //worker.ProgressChanged += schiavoWorker_ProgressChanged;
                schiavi.Add(worker);
                schiavi[schiavi.Count - 1].RunWorkerAsync();
            }
        }

        public int ContaFiniti()
        {
            //Funzione che conta il numero di thread completati e in caso salva il testo finale
            int nFiniti = 0;
            foreach (schiavo sc in schiavi) if(sc.finito) nFiniti++;
            if (nFiniti == NSchiavi)
            {
                foreach (schiavo sc in schiavi) testoProcessato += sc.testoProcessato;
                finito = true;
            }
            return nFiniti;
        }

        private void schiavoWorker_Lavoro(object sender, DoWorkEventArgs e)
        {
            schiavo worker = sender as schiavo;
            foreach (char c in worker.testoDaProcessare) worker.testoProcessato += (Convert.ToString(c, 2).PadLeft(8, '0'));
        }

        private void schiavoWorker_LavoroCompletato(object sender, RunWorkerCompletedEventArgs e)
        {
            schiavo worker = sender as schiavo;
            worker.finito = true;
        }

        public int nSchiavi { get { return NSchiavi; } }
    }
}
