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

            int kernelSize = 3;
            int halfKernelSize = kernelSize / 2;
            double[,] kernel = new double[kernelSize, kernelSize];
            double kernelValue = 1.0 / (kernelSize * kernelSize);

            for (int i = 0; i < kernelSize; ++i)
            {
                for (int j = 0; j < kernelSize; ++j)
                {
                    kernel[i, j] = kernelValue;
                } 
            }

            for (int i = halfKernelSize; i < image.PixelWidth - halfKernelSize; ++i)
            {
                for (int j = halfKernelSize; j < image.PixelHeight - halfKernelSize; ++j)
                {
                    int index = j * image.BackBufferStride + 4 * i;

                    for (int k = 0; k < 3; ++k)
                    {
                        double blurPixel = 0;
                        for (int m = 0; m < kernelSize; ++m)
                        {
                            for (int n = 0; n < kernelSize; ++n)
                            {
                                int indexKernel = (j + n - halfKernelSize) * image.BackBufferStride + 4 * (i + m - halfKernelSize);
                                blurPixel += kernel[m, n] * pixels[indexKernel + k];
                            }
                        }

                        resultPixels[index + k] = (byte) blurPixel;
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