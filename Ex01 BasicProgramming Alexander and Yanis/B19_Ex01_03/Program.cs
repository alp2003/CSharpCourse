using System;
using System.Text;
using B19Ex02 = B19_Ex01_02.Program;

namespace B19_Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Ex03 Sand Clock For Advanced");
            Console.WriteLine("================================");
            sandClockForAdvanced();
            Console.ReadKey();
        }

        private static void sandClockForAdvanced()
        {
            int numberOfStarsLines = userInput();
            if (numberOfStarsLines % 2 == 0)
            {
                numberOfStarsLines += 1;
            }

            StringBuilder stringBuilderForRecursion = new StringBuilder();
            string sandClock = B19Ex02.SandClock(stringBuilderForRecursion, 0, numberOfStarsLines);
            Console.WriteLine(sandClock);
        }

        private static int userInput()
        {
            int numberOfStarsLines = 0;
            Console.Write("Please enter number of lines for Sand Clock: ");
            string userInput = Console.ReadLine();
            bool isLegalInput = int.TryParse(userInput, out numberOfStarsLines) && numberOfStarsLines > 0;
            while (!isLegalInput)
            {
                Console.WriteLine("{0}Illegal Input, Please Try Again", Environment.NewLine);
                Console.Write("Please enter number of lines for Sand Clock: ");
                userInput = Console.ReadLine();
                isLegalInput = int.TryParse(userInput, out numberOfStarsLines) && numberOfStarsLines > 0;
            }

            return numberOfStarsLines;
        }
    }
}
