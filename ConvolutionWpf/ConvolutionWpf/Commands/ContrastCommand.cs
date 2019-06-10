using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Catel.MVVM;

namespace ConvolutionWpf.Commands
{
    public class ContrastCommand : Command
    {
        private readonly Func<WriteableBitmap> _imageFactory;

        public ContrastCommand(Func<WriteableBitmap> imageFactory)
            : base(() => { })
        {
            _imageFactory = imageFactory;
        }

        public void ExecuteCommand()
        {
            var image = _imageFactory();
            if (image == null)
                return;

            var pixels = new byte[image.PixelHeight * image.BackBufferStride];
            image.CopyPixels(pixels, image.BackBufferStride, 0);

            var resultPixels = new byte[image.PixelHeight * image.BackBufferStride];

            var cumHist = new int[256];
            var pixelCount = image.PixelHeight * image.PixelWidth * 3;
            var p = 0.005;
            var aLow = 0;
            var aHigh = 0;

            for (int i = 0; i < image.PixelHeight; ++i)
            {
                for (int j = 0; j < image.PixelWidth; ++j)
                {
                    int index = i * image.BackBufferStride + 4 * j;
                    for (int k = 0; k < 3; k++)
                    {
                        cumHist[pixels[index + k]] += 1;
                    }
                }
            }

            for (int i = 1; i < 256; ++i)
            {
                cumHist[i] = cumHist[i - 1] + cumHist[i];
            }

            for (int i = 0; i < 256; ++i)
            {
                if (cumHist[i] > pixelCount * p)
                {
                    aLow = i;
                    break;
                }
            }

            for (int i = 255; i >= 0; --i)
            {
                if (cumHist[i] <= pixelCount * (1 - p))
                {
                    aHigh = i;
                    break;
                }
            }

            for (int i = 0; i < image.PixelHeight; ++i)
            {
                for (int j = 0; j < image.PixelWidth; ++j)
                {
                    int index = i * image.BackBufferStride + 4 * j;
                    for (int k = 0; k < 3; ++k)
                    {
                        if (pixels[index + k] <= aLow)
                        {
                            resultPixels[index + k] = 0;
                        }
                        else if (pixels[index + k] >= aHigh)
                        {
                            resultPixels[index + k] = 255;
                        }
                        else
                        {
                            resultPixels[index + k] =
                                (byte) ((double) (pixels[index + k] - aLow) / (aHigh - aLow) * 255);
                        }
                    }
                    resultPixels[index + 3] = pixels[index + 3];
                }
            }
            image.WritePixels(new Int32Rect(0, 0, image.PixelWidth, image.PixelHeight), resultPixels, image.BackBufferStride, 0);
        }

        protected override void Execute(object parameter, bool ignoreCanExecuteCheck)
        {
            ExecuteCommand();
        }
    }
}