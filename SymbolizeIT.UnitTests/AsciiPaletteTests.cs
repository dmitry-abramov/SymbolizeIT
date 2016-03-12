using System.Collections.Generic;
using NUnit.Framework;

using SymbolizeIT;

namespace SymbolizeIT.UnitTests
{
    [TestFixture]
    public class AsciiPaletteTests
    {
        [Test]
        public void CreatePalette()
        {
            var characters = new List<char> { 'a', 'b', 'c' };
            var palette = new AsciiPalette(characters, true);

            CollectionAssert.AreEqual(characters, palette);
            Assert.IsTrue(palette.IsBrightnessSorted);
        }
    }
}
