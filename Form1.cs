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
        Criptazione formCriptazione = new Criptazione();    //Dichiaro il nuovo form per la criptazione
        Decriptazione formDecriptazione = new Decriptazione();    //Dichiaro il nuovo form per la criptazione
        const int dimByte = 8, offSetLabel = 15, lunghezzaBlocchiThread = 1000;
        string nomeFileOutput = "testoDecifrato", estensioneFileOutput = ".txt";   //Cambiare questo per cambiare il nome del file in output
        bool visualizzaSoloMex = false, inserimentoDaFile = false;
        PictureBox immagineOriginale = new PictureBox();

        private void criptazioneButton_Click(object sender, EventArgs e)
        {
            formCriptazione = new Criptazione();
            formCriptazione.Show();
        }

        private void decriptazioneButton_Click(object sender, EventArgs e)
        {
            formDecriptazione = new Decriptazione();
            formDecriptazione.Show();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
