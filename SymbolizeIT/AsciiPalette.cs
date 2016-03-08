using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SymbolizeIT
{
    public class AsciiPalette : List<char>
    {
        public static AsciiPalette FullPalette
        {
            get 
            {
                return new AsciiPalette(
                    Enumerable.Range(char.MinValue, 255)
                    .Select(i => (char) i)
                    .Where(c => !char.IsControl(c)));
            }
        }

        public AsciiPalette()
            : this(new List<char>(), false)
        {
        }

        public AsciiPalette(IEnumerable<char> chars)
            : this(chars, false)
        {
        }

        public AsciiPalette(IEnumerable<char> chars, bool isBrightnessSorted)
            : base(chars)
        {
            IsBrightnessSorted = isBrightnessSorted;
        }

        public bool IsBrightnessSorted
        {
            get;
            set;
        }

        public char GetSymbolByBrightness(byte brightness)
        {
            if (IsBrightnessSorted)
            {
                var rangeSize = byte.MaxValue / Count + 1;
                return this[brightness / rangeSize];
            }

            throw new InvalidOperationException();
        }
    }
}
