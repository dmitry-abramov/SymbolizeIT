using NUnit.Framework;
using SymbolizeIT;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class ToneBasedSymbolizerTests
    {
        ISymbolizer symbolizer;

        [SetUp]
        public void SetUp()
        {
            symbolizer = new ToneBasedSymbolizer();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ImageArgumentValidation()
        {
            symbolizer.GetAsciiArt((Image)null, new Font("", 12.0f), new AsciiPalette(), new Size(1, 1));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FontArgumentValidation()
        {
            symbolizer.GetAsciiArt(new Bitmap(1, 1), (Font)null, new AsciiPalette(), new Size(1, 1));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PaletteArgumentValidation()
        {
            symbolizer.GetAsciiArt(new Bitmap(1, 1), new Font("", 12.0f), (AsciiPalette)null, new Size(1, 1));
        }
    }
}
