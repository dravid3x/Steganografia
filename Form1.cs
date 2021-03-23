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
        Inserimento formInserimento = new Inserimento();    //Dichiaro il nuovo form per la criptazione
        Estrazione formEstrazione = new Estrazione();    //Dichiaro il nuovo form per la criptazione

        private void criptazioneButton_Click(object sender, EventArgs e)
        {
            formInserimento = new Inserimento();
            formInserimento.Show();
        }

        private void decriptazioneButton_Click(object sender, EventArgs e)
        {
            formEstrazione = new Estrazione();
            formEstrazione.Show();
        }

        public Form1()
        {
            InitializeComponent();
        }
    }
}
