using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Catel.MVVM;

namespace ConvolutionWpf.Commands
{
    public class FlipCommand : Command
    {
        private readonly Func<WriteableBitmap> _imageFactory;

        public event Action<WriteableBitmap> OnImageChanged;

        public FlipCommand(Func<WriteableBitmap> imageFactory)
            : base(() => { })
        {
            _imageFactory = imageFactory;
        }

        static private bool isHorizontalFlip = false;
        public void ExecuteCommand()
        {
            var image = _imageFactory();
            if (image == null)
                return;

            var pixels = new byte[image.PixelHeight * image.BackBufferStride];
            image.CopyPixels(pixels, image.BackBufferStride, 0);

            var imageRes = new WriteableBitmap((isHorizontalFlip ? 1 : 2) * image.PixelWidth, (isHorizontalFlip ? 2 : 1) * image.PixelHeight, image.DpiX, image.DpiY, image.Format, image.Palette);
            var resultPixels = new byte[imageRes.PixelHeight * imageRes.BackBufferStride];

            //todo
            for (int i = 0; i < image.PixelHeight; ++i)
            {
                for (int j = 0; j < image.PixelWidth; ++j)
                {
                    int index = i * image.BackBufferStride + 4 * j;
                    int indexRes = i * imageRes.BackBufferStride + 4 * j;
                    int indexFlip;
                    if (isHorizontalFlip)
                    {
                        indexFlip = (imageRes.PixelHeight - i - 1) * imageRes.BackBufferStride + 4 * j;
                    }
                    else
                    {
                        indexFlip = (i + 1) * imageRes.BackBufferStride - 4 * (j + 1);
                    }
                    
                    for (int k = 0; k < 3; ++k)
                    {
                        resultPixels[indexRes + k] = pixels[index + k];
                        resultPixels[indexFlip + k] = pixels[index + k];
                    }
                }
            }

            isHorizontalFlip = !isHorizontalFlip;
            
            imageRes.WritePixels(new Int32Rect(0, 0, imageRes.PixelWidth, imageRes.PixelHeight), resultPixels, imageRes.BackBufferStride, 0);

            OnImageChanged?.Invoke(imageRes);
        }

        protected override void Execute(object parameter, bool ignoreCanExecuteCheck)
        {
            ExecuteCommand();
        }
    }
}