using System;
using System.Drawing;

namespace SymbolizeIT
{
    public class Symbolizer : ISymbolizer
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

        public Symbolizer()
        {
            DefaultFont = DefaultValue.Font;
            DefaultBlockSize = DefaultValue.BlockSize;
            DefaultPalette = DefaultValue.Palette;
        }

        public IAsciiImage GetAsciiArt(Image image)
        {
            throw new NotImplementedException();
        }

        public IAsciiImage GetAsciiArt(Image image, Size size)
        {
            throw new NotImplementedException();
        }

        public IAsciiImage GetAsciiArt(Image image, Font font)
        {
            throw new NotImplementedException();
        }

        public IAsciiImage GetAsciiArt(Image image, Font font, AsciiPalette palette)
        {
            throw new NotImplementedException();
        }

        public IAsciiImage GetAsciiArt(Image image, Font font, AsciiPalette palette, Size size)
        {
            throw new NotImplementedException();
        }
    }
}
