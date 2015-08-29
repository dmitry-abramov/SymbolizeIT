using System.Drawing;

namespace SymbolizeIT
{
    internal static class DefaultValue
    {
        public static Font Font
        {
            get
            {
                return new Font(FontFamily.GenericMonospace, 12.0f);
            }
        }

        public static Size BlockSize
        {
            get 
            {
                return new Size(10, 10);
            } 
        }

        public static AsciiPalette Palette 
        {
            get
            {
                return AsciiPalette.FullPalette;
            }
        }
    }
}
