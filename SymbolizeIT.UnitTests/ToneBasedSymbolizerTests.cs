using NUnit.Framework;
using SymbolizeIT;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolizeIT.UnitTests
{
    [TestFixture]
    public class ToneBasedSymbolizerTests
    {
        ISymbolizer symbolizer;
        AsciiPalette palette;

        [SetUp]
        public void SetUp()
        {
            symbolizer = new ToneBasedSymbolizer();
            palette = new AsciiPalette(new char[] { ' ', '.', '+', 'N', '&' }, true);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ImageArgumentValidation()
        {
            symbolizer.GetAsciiArt((Image)null, new Font("", 12.0f), palette, new Size(1, 1));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FontArgumentValidation()
        {
            symbolizer.GetAsciiArt(new Bitmap(1, 1), (Font)null, palette, new Size(1, 1));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PaletteArgumentValidation()
        {
            symbolizer.GetAsciiArt(new Bitmap(1, 1), new Font("", 12.0f), (AsciiPalette)null, new Size(1, 1));
        }

        [Test]
        public void ImageSizeIsMultipleToBlockSize()
        {
            var image = new Bitmap(4, 4);

            image.SetPixel(0, 0, Color.White);
            image.SetPixel(0, 1, Color.White);
            image.SetPixel(1, 0, Color.White);
            image.SetPixel(1, 1, Color.White);

            image.SetPixel(0, 2, Color.Yellow);
            image.SetPixel(0, 3, Color.Yellow);
            image.SetPixel(1, 2, Color.Yellow);
            image.SetPixel(1, 3, Color.Yellow);

            image.SetPixel(2, 0, Color.Red);
            image.SetPixel(2, 1, Color.Red);
            image.SetPixel(3, 0, Color.Red);
            image.SetPixel(3, 1, Color.Red);

            image.SetPixel(2, 2, Color.Black);
            image.SetPixel(2, 3, Color.Black);
            image.SetPixel(3, 2, Color.Black);
            image.SetPixel(3, 3, Color.Black);

            var asciiImage = symbolizer.GetAsciiArt(image, symbolizer.DefaultFont, palette, new Size(2, 2));

            Assert.AreEqual(new Size(2, 2), asciiImage.Size);
        }

        [Test]
        public void ImageSizeIsNotMultipleToBlockSize()
        {
            var image = new Bitmap(4, 4);

            image.SetPixel(0, 0, Color.White);
            image.SetPixel(0, 1, Color.White);
            image.SetPixel(1, 0, Color.White);
            image.SetPixel(1, 1, Color.White);

            image.SetPixel(0, 2, Color.Yellow);
            image.SetPixel(0, 3, Color.Yellow);
            image.SetPixel(1, 2, Color.Yellow);
            image.SetPixel(1, 3, Color.Yellow);

            image.SetPixel(2, 0, Color.Red);
            image.SetPixel(2, 1, Color.Red);
            image.SetPixel(3, 0, Color.Red);
            image.SetPixel(3, 1, Color.Red);

            image.SetPixel(2, 2, Color.Black);
            image.SetPixel(2, 3, Color.Black);
            image.SetPixel(3, 2, Color.Black);
            image.SetPixel(3, 3, Color.Black);

            var asciiImage = symbolizer.GetAsciiArt(image, symbolizer.DefaultFont, palette, new Size(2, 2));

            Assert.AreEqual(new Size(2, 2), asciiImage.Size);
        }
    }
}
