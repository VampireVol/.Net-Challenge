using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using Catel.MVVM;

namespace ConvolutionWpf.Commands
{
    public class ImpulseNoiseCommand : Command
    {
        private readonly Func<WriteableBitmap> _imageFactory;

        public ImpulseNoiseCommand(Func<WriteableBitmap> imageFactory)
            : base(() => { })
        {
            _imageFactory = imageFactory;
        }

        private void ExecuteCommand()
        {
            var image = _imageFactory();
            if (image == null)
                return;

            byte[] resultPixels = RemoveNoise(image, sensetivity: 3);

            image.WritePixels(new Int32Rect(0, 0, image.PixelWidth, image.PixelHeight), resultPixels, image.BackBufferStride, 0);

        }

        private byte[] RemoveNoise(WriteableBitmap image, int sensetivity)
        {
            var pixels = new byte[image.PixelHeight * image.BackBufferStride];
            var resultPixels = new byte[image.PixelHeight * image.BackBufferStride];
            image.CopyPixels(pixels, image.BackBufferStride, 0);

            //todo
            int sampleSize = 3;
            List<int> indexList = new List<int>();
            List<byte> redPixels = new List<byte>();
            List<byte> greenPixels = new List<byte>();
            List<byte> bluePixels = new List<byte>();
            for (int i = 0; i < sampleSize; ++i)
            {
                indexList.Add(i * image.BackBufferStride);
                redPixels.Add(pixels[indexList[i]]);
                greenPixels.Add(pixels[indexList[i] + 1]);
                bluePixels.Add(pixels[indexList[i] + 2]);
            }
            for (int i = 0; i < image.PixelWidth; ++i)
            {
                for (int j = sampleSize; j < image.PixelHeight; ++j)
                {
                    int index = (j - 2) * image.BackBufferStride + 4 * i;
                    redPixels.Sort();
                    greenPixels.Sort();
                    bluePixels.Sort();

                    resultPixels[index] = redPixels[1];
                    resultPixels[index + 1] = greenPixels[1];
                    resultPixels[index + 2] = bluePixels[1];
                    resultPixels[index + 3] = pixels[index + 3];

                    indexList.Remove(0);
                    redPixels.Remove(0);
                    greenPixels.Remove(0);
                    bluePixels.Remove(0);

                    indexList.Add(j * image.BackBufferStride + 4 * i);
                    redPixels.Add(pixels[indexList[i]]);
                    greenPixels.Add(pixels[indexList[i] + 1]);
                    bluePixels.Add(pixels[indexList[i] + 2]);
                }
            }

            return resultPixels;
        }

        protected override void Execute(object parameter, bool ignoreCanExecuteCheck)
        {
            ExecuteCommand();
        }
    }
}