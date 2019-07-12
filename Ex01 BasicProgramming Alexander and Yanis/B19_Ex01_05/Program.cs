using System;

namespace B19_Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Ex05 Numbers Statistics");
            Console.WriteLine("================================");
            numbersStatistics();
            Console.ReadKey();
        }

        private static void numbersStatistics()
        {
            string inputFromUser = userInput();
            int userNumber = int.Parse(inputFromUser);
            Console.WriteLine("Statistics:");
            Console.WriteLine("Biggest digit is {0}.", biggestDigit(userNumber));
            Console.WriteLine("Smallest digit is {0}.", smallestDigit(userNumber));
            Console.WriteLine("There are {0} digits divided by 3.", numberOfDigitsThatDividedBy3(userNumber));
            Console.WriteLine("There are {0} digits that higher than the last digit ({1}).", higherThanLastDigit(userNumber), userNumber % 10);
        }

        private static int numberOfDigitsThatDividedBy3(int i_UserNumber)
        {
            int countDigits = 0;
            while (i_UserNumber > 0)
            {
                int remainder = i_UserNumber % 10;
                if (remainder % 3 == 0)
                {
                    countDigits++;
                }

                i_UserNumber /= 10;
            }

            return countDigits;
        }

        private static int higherThanLastDigit(int i_UserNumber)
        {
            int lastDigit = i_UserNumber % 10;
            int numberOfDigitsThatHigherThanLast = 0;
           
            while (i_UserNumber > 0)
            {
                if (lastDigit < i_UserNumber % 10)
                {
                    numberOfDigitsThatHigherThanLast++;
                }

                i_UserNumber /= 10;
            }

            return numberOfDigitsThatHigherThanLast;
        }

        private static int smallestDigit(int i_UserNumber)
        {
            int minDigit = i_UserNumber % 10;
            while (i_UserNumber > 0)
            {
                minDigit = Math.Min(minDigit, i_UserNumber % 10);
                i_UserNumber /= 10;
            }

            return minDigit;
        }

        private static int biggestDigit(int i_UserNumber)
        {
            int maxDigit = i_UserNumber % 10;
            while (i_UserNumber > 0)
            {
                maxDigit = Math.Max(maxDigit, i_UserNumber % 10);
                i_UserNumber /= 10;
            }
            
            return maxDigit;
        }

        private static string userInput()
        {
            string inputFromUser = string.Empty;
            bool inputWasCorrect;
            do
            {
                Console.Write("Please enter positive number (in length of 8): ");
                inputFromUser = Console.ReadLine();
                inputWasCorrect = (inputFromUser.Length == 8) && isItANumber(inputFromUser);
                if (!inputWasCorrect)
                {
                    Console.WriteLine("Illegal Input, Try Again!");
                }
            }
            while (!inputWasCorrect);

            return inputFromUser;
        }

        private static bool isItANumber(string i_InputFromUser)
        {
            const bool v_IsItDigitsSequence = true;
            for (int i = 0; i < i_InputFromUser.Length; i++)
            {
                if (!char.IsNumber(i_InputFromUser[i]))
                {
                    return !v_IsItDigitsSequence;
                }
            }

            return v_IsItDigitsSequence;
        }
    }
}
