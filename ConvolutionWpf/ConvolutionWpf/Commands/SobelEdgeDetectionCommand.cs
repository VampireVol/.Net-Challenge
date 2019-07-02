using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Catel.MVVM;

namespace ConvolutionWpf.Commands
{
    public class SobelEdgeDetectionCommand : Command
    {
        private readonly Func<WriteableBitmap> _imageFactory;

        public SobelEdgeDetectionCommand(Func<WriteableBitmap> imageFactory)
            : base(() => { })
        {
            _imageFactory = imageFactory;
        }

        private void ExecuteCommand()
        {
            var image = _imageFactory();
            if (image == null)
                return;

            byte[] resultPixels = DetectEdges(image);

            image.WritePixels(new Int32Rect(0, 0, image.PixelWidth, image.PixelHeight), resultPixels, image.BackBufferStride, 0);
        }

        private byte[] DetectEdges(WriteableBitmap image)
        {
            //todo
            var resultPixels = new byte[image.PixelHeight * image.BackBufferStride];
            int sizePixels = image.PixelHeight * image.BackBufferStride;
            int kernelSize = 3;
            int halfKernelSize = kernelSize / 2;
            double[,] kernelX = new double[kernelSize, kernelSize];
            double[,] kernelY = new double[kernelSize, kernelSize];
            double kernelValue = -1.0 / (kernelSize * kernelSize);

            for (int i = 0; i < kernelSize; ++i)
            {
                for (int j = 0; j < kernelSize; ++j)
                {
                    if (j == 1)
                    {
                        kernelX[i, j] = 0;
                    }
                    else if (j == 0)
                    {
                        if (i == 1)
                        {
                            kernelX[i, j] = 2 * kernelValue;
                        }
                        else
                        {
                            kernelX[i, j] = kernelValue;
                        }
                    }
                    else if (j == 2)
                    {
                        if (i == 1)
                        {
                            kernelX[i, j] = -2 * kernelValue;
                        }
                        else
                        {
                            kernelX[i, j] = -kernelValue;
                        }
                    }
                }
            }

            for (int i = 0; i < kernelSize; ++i)
            {
                for (int j = 0; j < kernelSize; ++j)
                {
                    if (i == 1)
                    {
                        kernelY[i, j] = 0;
                    }
                    else if (i == 0)
                    {
                        if (j == 1)
                        {
                            kernelY[i, j] = 2 * kernelValue;
                        }
                        else
                        {
                            kernelY[i, j] = kernelValue;
                        }
                    }
                    else if (i == 2)
                    {
                        if (j == 1)
                        {
                            kernelY[i, j] = -2 * kernelValue;
                        }
                        else
                        {
                            kernelY[i, j] = -kernelValue;
                        }
                    }
                }
            }

            var resultPixelsX = Convolution(image, kernelX, kernelSize);
            var resultPixelsY = Convolution(image, kernelY, kernelSize);
            for (int i = 0; i < sizePixels; ++i)
            {
                resultPixels[i] = (byte)Math.Sqrt(Math.Pow(resultPixelsX[i], 2) + Math.Pow(resultPixelsY[i], 2));
            }

            return resultPixels;

        }

        private double[] Convolution(WriteableBitmap image, double[,] kernel, int kernelSize)
        {
            var resultPixels = new double[image.PixelHeight * image.BackBufferStride];
            var pixels = new byte[image.PixelHeight * image.BackBufferStride];
            image.CopyPixels(pixels, image.BackBufferStride, 0);
            int halfKernelSize = kernelSize / 2;
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

                        resultPixels[index + k] = blurPixel;
                    }

                    resultPixels[index + 3] = pixels[index + 3];
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