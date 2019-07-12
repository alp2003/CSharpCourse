using System;
using System.Text;

namespace B19_Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Ex02 Sand Clock For Beginners");
            Console.WriteLine("================================");
            sandClockForBeginners();
            Console.ReadKey();
        }

        private static void sandClockForBeginners()
        {
            int numberOfStarsLines = 5;
            StringBuilder stringBuilderForRecursion = new StringBuilder();
            string sandClockString = SandClock(stringBuilderForRecursion, 0, numberOfStarsLines);
            Console.WriteLine(sandClockString);
        }

        public static string SandClock(StringBuilder i_StringBuilder, int i_RowNumber, int i_NumberOfStarsLines)
        {
            if (i_RowNumber == i_NumberOfStarsLines)
            {
                return i_StringBuilder.ToString();
            }

            int currentNumberOfStars;
            if (i_RowNumber < i_NumberOfStarsLines / 2)
            {
                currentNumberOfStars = i_NumberOfStarsLines - (2 * i_RowNumber);
                i_StringBuilder.AppendLine(new string(' ', i_RowNumber) + new string('*', currentNumberOfStars));
            }
            else
            {
                currentNumberOfStars = (2 * i_RowNumber) - i_NumberOfStarsLines + 2;
                i_StringBuilder.AppendLine(new string(' ', i_NumberOfStarsLines - i_RowNumber - 1) + new string('*', currentNumberOfStars));
            }

            SandClock(i_StringBuilder, i_RowNumber + 1, i_NumberOfStarsLines);
            return i_StringBuilder.ToString();
        }
    }
}
