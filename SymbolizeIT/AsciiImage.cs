using System;
using System.Drawing;

namespace SymbolizeIT
{
    public class AsciiImage: IAsciiImage 
    {
        public AsciiImage(Size size)
            : this(new char[size.Height, size.Width], DefaultValue.Font)
        {
        }

        public AsciiImage(char[,] image)
            : this(image, DefaultValue.Font)
        {
        }

        public AsciiImage(char[,] image, Font font)
        {
            this.image = image;
            Font = font;
        }

        public AsciiImage(AsciiImage image)
        {
            throw new NotImplementedException();
        }

        public char this[int x, int y]
        {
            get
            {
                return image[x, y];
            }
            set
            {
                image[x, y] = value;
            }
        }

        public Font Font
        {
            get;
            set;
        }

        public int Width
        {
            get { return image.GetLength(1); }
        }

        public int Height
        {
            get { return image.GetLength(0); }
        }

        public Size Size
        {
            get { return new Size(Width, Height); }
        }

        protected char[,] image; 
    }
}
