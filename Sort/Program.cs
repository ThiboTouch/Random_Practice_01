using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public class Program
    {
        static Encoding asciiEncoding = Encoding.ASCII;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            /*Pipeline starts here*/
            /*===================*/

            var letters = getLetters(input);

            var sortedLetters = sortLetters(letters);

            var sortedLettersString = lettersToString(sortedLetters);

            /*==================*/
            /*Pipeline ends here*/

            Console.WriteLine(sortedLettersString);

            Console.ReadKey();
        }

        public static byte[] getLetters(string text)
        {
            byte[] textArray = asciiEncoding.GetBytes(text.ToLower());
            List<byte> newTextArray = new List<byte>();

            const int lowerCaseAsciiLowerBound = 97;
            const int lowerCaseAsciiUpperBound = 122;

            foreach (var token in textArray)
            {
                if (token >= lowerCaseAsciiLowerBound && token <= lowerCaseAsciiUpperBound)
                {
                    newTextArray.Add(token);
                }
            }

            return newTextArray.ToArray();
        }

        public static byte[] sortLetters(byte[] letters)
        {
            byte[] count = new byte[256];

            for(int i = 0; i < letters.Length; i++)
            {
                int value = letters[i];
                count[value]++;
            }

            for(int i = 1; i < count.Length; i++)
            {
                count[i] = (byte)(count[i] + count[i - 1]);
            }

            byte[] sorted = new byte[letters.Length];

            for(int i = letters.Length - 1; i >= 0; i--)
            {
                byte value = letters[i];
                byte position = (byte)(count[value] - 1);
                sorted[position] = value;

                count[value]--;
            }

            return sorted;
        }

        public static string lettersToString(byte[] letters)
        {
            return asciiEncoding.GetString(letters);
        }
    }
}
