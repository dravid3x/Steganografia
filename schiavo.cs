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

        public schiavo(string testo)
        {
            testoDaProcessare = testo;
        }

    }

    class schiavoMaster : BackgroundWorker
    {
        public string testoFinito = "", testoDaProcessare = "";
        public bool finito = false;
        public schiavoMaster(string testo)
        {
            testoDaProcessare = testo;
        }
    }
}
