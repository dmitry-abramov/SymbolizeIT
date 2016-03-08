using System;
using System.Drawing;

namespace SymbolizeIT
{
    public class ToneBasedSymbolizer : ISymbolizer
    {
        public Font DefaultFont
        {
            get;
            set;
        }

        public AsciiPalette DefaultPalette
        {
            get;
            set;
        }

        public Size DefaultBlockSize
        {
            get;
            set;
        }

        public ToneBasedSymbolizer()
        {
            DefaultFont = DefaultValue.Font;
            DefaultBlockSize = DefaultValue.BlockSize;
            DefaultPalette = DefaultValue.Palette;
        }

        public IAsciiImage GetAsciiArt(Image image)
        {
            return GetAsciiArt(image, DefaultFont, DefaultPalette, DefaultBlockSize);
        }

        public IAsciiImage GetAsciiArt(Image image, Size pixelBlockSize)
        {
            return GetAsciiArt(image, DefaultFont, DefaultPalette, pixelBlockSize);
        }

        public IAsciiImage GetAsciiArt(Image image, Font font)
        {
            return GetAsciiArt(image, font, DefaultPalette, DefaultBlockSize);
        }

        public IAsciiImage GetAsciiArt(Image image, Font font, AsciiPalette palette)
        {
            return GetAsciiArt(image, font, palette, DefaultBlockSize);
        }

        public IAsciiImage GetAsciiArt(Image image, Font font, AsciiPalette palette, Size pixelBlockSize)
        {
            Args.IsNotNull(image, "image");
            Args.IsNotNull(font, "font");
            Args.IsNotNull(palette, "palette");

            var imageAsBitmap = new Bitmap(image);
            var asciiImageSize = GetAsciiImageSize(imageAsBitmap.Size, pixelBlockSize);
            var asciiImage = new char[asciiImageSize.Height, asciiImageSize.Width];

            for (int i = 0; i < asciiImageSize.Width; i++)
            {
                for (int j = 0; j < asciiImageSize.Height; j++)
                {
                    var currentBlockStartX = j * pixelBlockSize.Width;
                    var currentBlockStartY = i * pixelBlockSize.Height;

                    var currentBlockEndX = 0;
                    var currentBlockEndY = 0;

                    if (imageAsBitmap.Width - currentBlockStartX >= pixelBlockSize.Width)
                    {
                        currentBlockEndX = currentBlockStartX + pixelBlockSize.Width;
                    }
                    else
                    {
                        currentBlockEndX = imageAsBitmap.Width - currentBlockStartX;
                    }

                    if (imageAsBitmap.Height - currentBlockStartY >= pixelBlockSize.Height)
                    {
                        currentBlockEndY = currentBlockStartY + pixelBlockSize.Height;
                    }
                    else
                    {
                        currentBlockEndY = imageAsBitmap.Height - currentBlockStartY;
                    }

                    var brightnessSum = 0;

                    for (int x = currentBlockStartX; x < currentBlockEndX; x++)
                    {
                        for (int y = currentBlockStartY; y < currentBlockEndY; y++)
                        {
                            brightnessSum += GetBrightness(imageAsBitmap.GetPixel(x, y));
                        }
                    }

                    var averageBrightness = (byte)(brightnessSum / ((currentBlockEndX - currentBlockStartX) * ((currentBlockEndY - currentBlockStartY))));

                    asciiImage[i, j] = palette.GetSymbolByBrightness(averageBrightness);
                }
            }

            return new AsciiImage(asciiImage, font);
        }

        private Size GetAsciiImageSize(Size originalImageSize, Size pixelBlockSize)
        {
            var asciiImageWidth = (int)Math.Ceiling(((double)originalImageSize.Width) / pixelBlockSize.Width);
            var asciiImageHeight = (int)Math.Ceiling(((double)originalImageSize.Height) / pixelBlockSize.Height);

            return new Size(asciiImageWidth, asciiImageHeight);
        }

        private byte GetBrightness(Color color)
        {
            return (byte)(0.587 * color.G + 0.299 * color.R + 0.114 * color.B);
        }
    }
}
