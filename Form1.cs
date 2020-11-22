using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;


namespace HistogramaEscalaGrises
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> MyImage;
        Image<Gray, byte> GrayImage;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Para importar la imagen
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                MyImage = new Image<Bgr, byte>(ofd.FileName);
                
                //Usando un imageBox no necesitamos transformar a bitmap
                imageBox1.Image = MyImage;

                //Permite guardar hacer zoom con la imagen
                imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Everything;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MyImage!=null)
            {
                GrayImage = MyImage.Convert<Gray, byte>();
                imageBox2.Image = GrayImage;
            }else
            {
                MessageBox.Show("Debe importar una imagen");
            }
        }

        //Botón de histograma color
        private void button3_Click(object sender, EventArgs e)
        {
            if (MyImage != null)
            {
                //Hace que no se juntenn los histogramas de diferentes imagenes
                colorHistrogram.ClearHistogram();
                //Crea un rango de histograma
                DenseHistogram hist = new DenseHistogram(256, new RangeF(0, 255));
                hist.Calculate(new Image<Gray, byte>[] { MyImage[0] }, false, null);
                Mat m = new Mat();
                hist.CopyTo(m);
                colorHistrogram.AddHistogram("Canal azul de histograma", Color.Blue, m, 256, new float[] { 0, 256 });
                colorHistrogram.Refresh();
            }
            else
            {
                MessageBox.Show("Debe importar una imagen");
            }
        }

        //Botón de histograma gris
        private void button4_Click(object sender, EventArgs e)
        {
            if (GrayImage != null)
            {
                //Hace que no se juntenn los histogramas de diferentes imagenes
                grayHistograma.ClearHistogram();
                DenseHistogram hist = new DenseHistogram(256, new RangeF(0, 255));
                hist.Calculate(new Image<Gray, byte>[] { GrayImage }, false, null);
                Mat m = new Mat();
                hist.CopyTo(m);
                grayHistograma.AddHistogram("Canal gris de histograma", Color.Blue, m, 256, new float[] { 0, 256 });
                grayHistograma.Refresh();
            }
            else
            {
                MessageBox.Show("Debe transformar a escala de grises");
            }
        }
    }
}
