using System.Diagnostics;
using System.Drawing.Imaging;

namespace ImageDownsizer
{
    public partial class ImageDownsizerWinForm : Form
    {
        Downsizer? downsizer;

        public ImageDownsizerWinForm()
        {
            InitializeComponent();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    downsizer = new(new Bitmap(openFileDialog.FileName));

                    Image image = Image.FromFile(openFileDialog.FileName);
                    pictureBox1.Image = image;
                    MessageBox.Show("The Image is loaded!");

                    imageLbl.Text = openFileDialog.SafeFileName;
                    downsizeFactorUpDown.Enabled = true;

                }
                else
                {
                    MessageBox.Show("The Image file is not found!");
                }
            }

        }

        private void DownsizeImage(bool parallel)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Restart();

            var downsizedImage = downsizer!.SequentialResizeImage((int)downsizeFactorUpDown.Value, parallel);

            stopwatch.Stop();

            timeLbl.Text = stopwatch.ElapsedMilliseconds.ToString() + " miliseconds";


            saveFile(downsizedImage);
        }

        private void saveFile(Bitmap newImage)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {

                ImageFormat format = downsizer!.Format;


                saveFileDialog.Filter = "JPEG Image|*.jpg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    newImage.Save(saveFileDialog.FileName, format);

                }

                MessageBox.Show("The Image is saved successfully!");

            }
        }
        private void downsizeFactor_Change(object sender, EventArgs e)
        {
            sequentialButton.Enabled = true;
            parallelButton.Enabled = true;
        }

        private void sequentialButton_Click(object sender, EventArgs e)
        {
            DownsizeImage(false);
        }


        private void parallelButton_Click(object sender, EventArgs e)
        {
            DownsizeImage(true);
        }

        private void downsizeFactorUpDown_KeyDown(object sender, KeyEventArgs e)
        {
            sequentialButton.Enabled = true;
            parallelButton.Enabled = true;
        }
    }
}