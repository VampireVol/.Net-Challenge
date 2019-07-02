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
            int halfSampleSize = sampleSize / 2;
            int medianSample = sampleSize * sampleSize / 2;
            List<byte> redPixels = new List<byte>();
            List<byte> greenPixels = new List<byte>();
            List<byte> bluePixels = new List<byte>();

            for (int i = halfSampleSize; i < image.PixelWidth - halfSampleSize; ++i)
            {
                for (int j = halfSampleSize; j < image.PixelHeight - halfSampleSize; ++j)
                {
                    for (int m = 0; m < sampleSize; ++m)
                    {
                        for (int n = 0; n < sampleSize; ++n)
                        {
                            int indexSample = (j + n - halfSampleSize) * image.BackBufferStride + 4 * (i + m - halfSampleSize);
                            redPixels.Add(pixels[indexSample]);
                            greenPixels.Add(pixels[indexSample + 1]);
                            bluePixels.Add(pixels[indexSample + 2]);
                        }
                    }

                    int index = j * image.BackBufferStride + 4 * i;
                    redPixels.Sort();
                    greenPixels.Sort();
                    bluePixels.Sort();

                    resultPixels[index] = redPixels[medianSample];
                    resultPixels[index + 1] = greenPixels[medianSample];
                    resultPixels[index + 2] = bluePixels[medianSample];
                    resultPixels[index + 3] = pixels[index + 3];

                    redPixels.Clear();
                    greenPixels.Clear();
                    bluePixels.Clear();
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