using Sort;
using Xunit;

namespace Sorting.Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("HellO woRld")]
        [InlineData("This is JusT a TeST16^;")]
        [InlineData("KileO Hyshdj EW35;;")]
        [InlineData("Hyh%% hy;' ue")]
        /*
         * The function tested here runs at a time complexity of O(n).
         * This is the entry point for the input data.
         * Ascii encoded lower-case characters are placed in a new collection of an undefined size which is then converted to an array.
         */
        public void convertsTextToLowerCaseAsciiEncodedAlphaArray(string text)
        {
            const int lowerCaseAsciiLowerBound = 97;
            const int lowerCaseAsciiUpperBound = 122;

            byte[] letters = Program.getLetters(text);

            foreach(var letter in letters)
            {
                Assert.True(letter >= lowerCaseAsciiLowerBound && letter <= lowerCaseAsciiUpperBound);
            }
        }

        [Theory]
        [InlineData((byte)1, (byte)6, (byte)3, (byte)4, (byte)5, (byte)55)]
        [InlineData((byte)22, (byte)111, (byte)153, (byte)203, (byte)12, (byte)76)]
        [InlineData((byte)12, (byte)46, (byte)75, (byte)111, (byte)34, (byte)162, (byte)21)]
        [InlineData((byte)32, (byte)52, (byte)16, (byte)69, (byte)176, (byte)22, (byte)93)]
        /*
         * The function tested here runs at a time complexity of O(n).
         * The function assumes that the values in the input array are in the range of 0...255 (ascii range).
         * The returned value is an array of the bytes values sorted in ascending order.
         */
        public void sortsBytesInAsciiRangeToAscendingOrder(params byte[] numbers)
        {
            var bytes = Program.sortLetters(numbers);

            for(int i = 1; i < numbers.Length; i++)
            {
                Assert.True(bytes[i] >= bytes[i - 1]);
            }
        }

        [Theory]
        [InlineData((byte)1, (byte)6, (byte)3, (byte)4, (byte)5, (byte)55)]
        [InlineData((byte)22, (byte)111, (byte)153, (byte)203, (byte)12, (byte)76)]
        [InlineData((byte)12, (byte)46, (byte)75, (byte)111, (byte)34, (byte)162, (byte)21)]
        [InlineData((byte)32, (byte)52, (byte)16, (byte)69, (byte)176, (byte)22, (byte)93)]
        /*
         * The function tested here runs at a time complexity of O(n).
         * The function assumes that the values in the input array are in the range of 0...255 (ascii range).
         * The returned value is a string from the bytes converted to their character values in the Ascii encoding.
         */
        public void convertsIntegersInAsciiRangeToString(params byte[] numbers)
        {
            var newString = Program.lettersToString(numbers);

            Assert.True(typeof(string) == newString.GetType());
        }
    }
}
