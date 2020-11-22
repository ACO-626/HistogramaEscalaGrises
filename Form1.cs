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
                
            }else
            {
                MessageBox.Show("Debe importar una imagen");
            }
        }
    }
}
