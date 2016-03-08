using System.Drawing;

namespace SymbolizeIT
{
    public interface ISymbolizer
    {
        Font DefaultFont { get; set; }

        AsciiPalette DefaultPalette { get; set; }

        Size DefaultBlockSize { get; set; }

        IAsciiImage GetAsciiArt(Image image);

        IAsciiImage GetAsciiArt(Image image, Size pixelBlockSize);

        IAsciiImage GetAsciiArt(Image image, Font font);

        IAsciiImage GetAsciiArt(Image image, Font font, AsciiPalette palette);

        IAsciiImage GetAsciiArt(Image image, Font font, AsciiPalette palette, Size pixelBlockSize);
    }
}
