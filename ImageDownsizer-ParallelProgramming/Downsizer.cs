using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageDownsizer
{
    public class Downsizer
    {
        private readonly Bitmap original;
        public ImageFormat Format { get; }

        public Downsizer(Bitmap bitmap) 
        {
            original = bitmap;
            Format = original.RawFormat;
        }


        public Bitmap SequentialResizeImage(int percentage, bool parallel)
        {

            BitmapData originalData = original.LockBits(new Rectangle(Point.Empty, original.Size),
               ImageLockMode.ReadOnly, original.PixelFormat);

            int newWidth = (int)(originalData.Width * percentage / 100.0);
            int newHeight = (int)(originalData.Height * percentage / 100.0);

            Bitmap downsizedImage = new Bitmap(newWidth, newHeight);

            BitmapData downsizedImageData = downsizedImage.LockBits(new Rectangle(0, 0, newWidth, newHeight),
            ImageLockMode.WriteOnly, originalData.PixelFormat);

            var pixelSize = originalData.PixelFormat == PixelFormat.Format32bppArgb ? 4 : 3;

            byte[] originalBytes = new byte[originalData.Height * originalData.Stride];

            Marshal.Copy(originalData.Scan0, originalBytes, 0, originalBytes.Length);

            byte[] downsizedImageBytes = new byte[downsizedImageData.Stride * downsizedImageData.Height];

            double ratio = (double)original.Width / newWidth;

            if (parallel)
            {
                ParallelResizeImage(originalData, newWidth, newHeight, downsizedImageData, pixelSize, originalBytes, downsizedImageBytes, ratio);
            }
            else
            {
                NearestNeighborTypeInterpolation(originalData, newWidth, newHeight, downsizedImageData, pixelSize, originalBytes, downsizedImageBytes, ratio);
            }

            Marshal.Copy(downsizedImageBytes, 0, downsizedImageData.Scan0, downsizedImageBytes.Length);

            original.UnlockBits(originalData);
            downsizedImage.UnlockBits(downsizedImageData);

            return downsizedImage;
        }

        private void ParallelResizeImage(BitmapData originalData, int newWidth, int newHeight, BitmapData downsizedImageData, int pixelSize, byte[] originalBytes, byte[] downsizedImageBytes, double ratio)
        {
            int numberThreads = 8;

            int chunkHeight = newHeight / numberThreads;

            Thread[] threads = new Thread[numberThreads];

            for (int i = 0; i < numberThreads; i++)
            {
                int startY = i * chunkHeight;
                int endY = (i == numberThreads - 1) ? newHeight : (i + 1) * chunkHeight;

                threads[i] = new Thread(() => NearestNeighborTypeInterpolation(originalData, newWidth, newHeight, downsizedImageData, pixelSize, originalBytes, downsizedImageBytes, ratio, startY, endY));
                threads[i].Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }

        private void NearestNeighborTypeInterpolation(BitmapData originalData, int newWidth, int newHeight, BitmapData newImageData, int pixelSize, byte[] originalBytes, byte[] downsizedImageBytes, double ratio, int startY = 0, int endY = -1)
        {
            if (endY == -1)
                endY = newHeight;

            for (int y = startY; y < endY; y++)
            {
                for (int x = 0; x < newWidth; x++)
                {
                    int x1 = (int)(x * ratio);
                    int y1 = (int)(y * ratio);
                    int x2 = Math.Min((int)((x + 1) * ratio), originalData.Width - 1);
                    int y2 = Math.Min((int)((y + 1) * ratio), originalData.Height - 1);

                    byte[] avgColor = WeightedAverageColor(originalBytes, originalData.Stride, x1, y1, x2, y2, ratio, pixelSize);

                    int index = y * newImageData.Stride + x * pixelSize;

                    downsizedImageBytes[index] = avgColor[0];
                    downsizedImageBytes[index + 1] = avgColor[1];
                    downsizedImageBytes[index + 2] = avgColor[2];

                    if (pixelSize == 4)
                    {
                        downsizedImageBytes[index + 3] = avgColor[3];
                    }


                }
            }
        }


        private byte[] WeightedAverageColor(byte[] originalPixels, int originalStride, int x1, int y1, int x2, int y2, double ratio, int pixelSize)
        {
            double totalWeight = 0;
            double totalB = 0;
            double totalG = 0;
            double totalR = 0;
            double totalA = 0;


            for (int y = y1; y <= y2; y++)
            {
                for (int x = x1; x <= x2; x++)
                {
                    double weightX = 1 - Math.Abs(x / ratio - Math.Floor(x / ratio));
                    double weightY = 1 - Math.Abs(y / ratio - Math.Floor(y / ratio));
                    double weight = weightX * weightY;

                    totalWeight += weight;

                    int index = y * originalStride + x * pixelSize;

                    totalB += originalPixels[index] * weight;
                    totalG += originalPixels[index + 1] * weight;
                    totalR += originalPixels[index + 2] * weight;

                    if (pixelSize == 4)
                    {
                        totalA += originalPixels[index + 3] * weight;
                    }

                }
            }

            byte averageB = (byte)(totalB / totalWeight);
            byte averageG = (byte)(totalG / totalWeight);
            byte averageR = (byte)(totalR / totalWeight);
            byte averageA = 255; 

            if (pixelSize == 4)
            {
                averageA = (byte)(totalA / totalWeight);
            }

            return new byte[] { averageB, averageG, averageR, averageA };
        }

    }
}
