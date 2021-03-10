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

namespace Steganografia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InserisciButton_Click(object sender, EventArgs e)
        {

            DialogResult result = fDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox1.Load(fDialog1.FileName);
                pictureBox1.Size = new Size(pictureBox1.Image.Width, pictureBox1.Image.Height);
            }
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if(testoTextBox.Text.Length != 0)
            {
                Console.WriteLine(testoTextBox.Text);
                stg(pictureBox1.Image, testoTextBox.Text);
            }
        }

        private Image stg(Image immagine, String testo)
        {
            Bitmap outputBitmap = new Bitmap(immagine.Width, immagine.Height);

            Color coloreCorrente = (immagine as Bitmap).GetPixel(0, 0);

            outputBitmap.SetPixel(0, 0, coloreCorrente);

            Console.WriteLine("R: " + coloreCorrente.R.ToString() + "\nG: " + coloreCorrente.G.ToString() + "\nB: " + coloreCorrente.B.ToString());

            return outputBitmap;
        }
    }
}
