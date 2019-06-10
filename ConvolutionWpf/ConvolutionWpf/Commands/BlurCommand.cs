using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Catel.MVVM;

namespace ConvolutionWpf.Commands
{
    public class BlurCommand : Command
    {
        private readonly Func<WriteableBitmap> _imageFactory;

        public BlurCommand(Func<WriteableBitmap> imageFactory)
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

            int kernel = 3;

            for (int i = kernel / 2; i < image.PixelWidth - kernel / 2; i++)
            {
                for (int j = kernel / 2; j < image.PixelHeight - kernel / 2; j++)
                {
                    int index = j * image.BackBufferStride + 4 * i;

                    for (int c = 0; c < 3; c++)
                    {
                        int blurPixel = (pixels[index + c - 4] * (1) + pixels[index + c + 4] * (1)
                                    + pixels[index + c - image.BackBufferStride] * (1) + pixels[index + c + image.BackBufferStride] * (1)) / 4;
                        if (blurPixel < 0)
                        {
                            blurPixel = 0;
                        }
                        else if (blurPixel > 255)
                        {
                            blurPixel = 255;
                        }
                        resultPixels[index + c] = (byte)(blurPixel);
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