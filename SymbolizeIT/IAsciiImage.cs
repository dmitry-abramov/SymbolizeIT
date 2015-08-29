using System.Drawing;

namespace SymbolizeIT
{
    public interface IAsciiImage
    {
        char this[int x, int y] { get; set; }

        Font Font { get; set; }

        int Width { get; }

        int Height { get; }

        Size Size { get; }
    }
}
