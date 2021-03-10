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
            int offSetPic = 20;
            DialogResult result = fDialog1.ShowDialog();
            PictureBox immagineOriginale = new PictureBox();
            immagineOriginale.Location = new Point(159, 12);
            if (result == DialogResult.OK)
            {
                immagineOriginale.Load(fDialog1.FileName);
                immagineOriginale.Size = new Size(immagineOriginale.Image.Width, immagineOriginale.Image.Height);
            }
            this.Controls.Add(immagineOriginale);
            if(testoTextBox.Text.Length != 0)
            {
                Console.WriteLine(testoTextBox.Text);
                PictureBox nuovaImmagine = new PictureBox();
                nuovaImmagine.Location = new Point(immagineOriginale.Location.X + immagineOriginale.Size.Width + offSetPic, immagineOriginale.Location.Y);
                nuovaImmagine.Size = immagineOriginale.Size;
                Image immagineFinale = stg(immagineOriginale.Image, testoTextBox.Text);
                nuovaImmagine.Image = immagineFinale;
                this.Controls.Add(nuovaImmagine);
            }
        }

        private Image stg(Image immagine, String testo)
        {
            Bitmap outputBitmap = new Bitmap(immagine.Width, immagine.Height);

            for(int y = 0; y < immagine.Height; y++)
            {
                for(int x = 0; x < immagine.Width; x++)
                {
                    Color coloreCorrente = (immagine as Bitmap).GetPixel(x, y);
                    outputBitmap.SetPixel(x, y, coloreCorrente);
                }
            }
            //Color coloreCorrente = (immagine as Bitmap).GetPixel(0, 0);

            //outputBitmap.SetPixel(0, 0, coloreCorrente);

            //Console.WriteLine("R: " + coloreCorrente.R.ToString() + "\nG: " + coloreCorrente.G.ToString() + "\nB: " + coloreCorrente.B.ToString());

            return outputBitmap;
        }
    }
}
