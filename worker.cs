using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Steganografia
{
    class worker : BackgroundWorker
    {
        //BackgroundWorker worker = new BackgroundWorker();
        public string testoDaProcessare = "", testoProcessato = "";
        public bool finito = false;
        public worker()
        {
            //Non inserisco il testo da processare come parametro per poter riutilizzare questo schiavo anche nella decriptazione
        }

    }

    class gestoreConvertitori : BackgroundWorker
    {
        public string testoProcessato = "", testoDaProcessare = "";
        public bool finito = false;
        private int NConvertitori = -1;
        public List<worker> convertitori = new List<worker>();
        public List<string> pezzi = new List<string>();

        public gestoreConvertitori()
        {

        }

        public void GeneraSchiavi(int nSchiavi)
        {
            NConvertitori = nSchiavi;
            //Dichiaro e assegno ad ogni thread un pezzo di testo da processare
            for (int i = 0; i < nSchiavi; i++)
            {
                worker worker = new worker();
                worker.testoDaProcessare = pezzi[i];
                worker.WorkerReportsProgress = true;
                worker.WorkerSupportsCancellation = true;
                worker.DoWork += schiavoWorker_Lavoro;
                worker.RunWorkerCompleted += schiavoWorker_LavoroCompletato;
                //worker.ProgressChanged += schiavoWorker_ProgressChanged;
                convertitori.Add(worker);
                convertitori[convertitori.Count - 1].RunWorkerAsync();
            }
        }

        public int ContaFiniti()
        {
            //Funzione che conta il numero di thread completati e in caso salva il testo finale
            int nFiniti = 0;
            foreach (worker sc in convertitori) if(sc.finito) nFiniti++;
            if (nFiniti == NConvertitori)
            {
                foreach (worker sc in convertitori) testoProcessato += sc.testoProcessato;
                finito = true;
            }
            return nFiniti;
        }

        private void schiavoWorker_Lavoro(object sender, DoWorkEventArgs e)
        {
            worker worker = sender as worker;
            foreach (char c in worker.testoDaProcessare) worker.testoProcessato += (Convert.ToString(c, 2).PadLeft(8, '0'));
        }

        private void schiavoWorker_LavoroCompletato(object sender, RunWorkerCompletedEventArgs e)
        {
            worker worker = sender as worker;
            worker.finito = true;
        }

        public int nSchiavi { get { return NConvertitori; } }
    }
}
