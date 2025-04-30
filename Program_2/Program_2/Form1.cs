using System;
using System.Drawing;
using System.Windows.Forms;

namespace Program_2
{
    public partial class Form1 : Form
    {
        private Bitmap? originalImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Çîáðàæåííÿ (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openDialog.FileName); 
                pictureBox1.Image = originalImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return; 

            Bitmap grayImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color pixel = originalImage.GetPixel(x, y); 
                    int gray = (int)(0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B); 
                    grayImage.SetPixel(x, y, Color.FromArgb(gray, gray, gray)); 
                }
            }

            pictureBox1.Image = grayImage; 
            originalImage = grayImage;  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;  

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG çîáðàæåííÿ|*.png"; 

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                originalImage.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);  
            }
        }

        // Îáðîáíèê äëÿ êë³êó ïî PictureBox (ÿêùî ïîòð³áíî)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Òóò í³÷îãî íå ïîòð³áíî, ÿêùî ò³ëüêè íå õî÷åòå äîäàòè ÿêóñü äîäàòêîâó ëîã³êó
        }
    }
}
