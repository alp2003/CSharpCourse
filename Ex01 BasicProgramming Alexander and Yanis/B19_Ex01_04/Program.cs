using System;

namespace B19_Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Ex04 String Analysis");
            Console.WriteLine("================================");
            stringAnalysis();
            Console.ReadKey();
        }

        private static void stringAnalysis()
        {
            string kindOfInput;
            string inputFromUser = userInput(out kindOfInput);
            string palindromCheckString = string.Format("The String {0} is {1} Palindrome.", inputFromUser, isStringPalindrome(inputFromUser) ? "a" : "not");
            Console.WriteLine();
            Console.WriteLine(palindromCheckString);
            if (kindOfInput == "digits")
            {
                checkIfCurrentNumberDividedby3(inputFromUser);
            }
            else if (kindOfInput == "letters")
            {
                countNumberOfLowerLetters(inputFromUser);
            }
        }

        private static string userInput(out string o_KindOfInput)
        {
            string inputFromUser = string.Empty;
            o_KindOfInput = string.Empty;
            bool inputWasCorrect;
            do
            {
                inputWasCorrect = true;
                Console.Write("Please enter char sequence" +
                    " (only letters or only digits) in Length 12: ");
                inputFromUser = Console.ReadLine();
                if (inputFromUser.Length == 12)
                {
                    if (isItOnlyLettersSequence(inputFromUser))
                    {
                        o_KindOfInput = "letters";
                    }
                    else if (isItOnlyDigitsSequence(inputFromUser))
                    {
                        o_KindOfInput = "digits";
                    }
                    else
                    {
                        Console.WriteLine("Illegal Input, Try Again!");
                        inputWasCorrect = false;
                    }
                }
                else
                {
                    Console.WriteLine("Illegal Input, Try Again!");
                    inputWasCorrect = false;
                }
            }
            while (!inputWasCorrect);

            return inputFromUser;
        }

        private static bool isItOnlyDigitsSequence(string i_InputFromUser)
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

        private static bool isItOnlyLettersSequence(string i_InputFromUser)
        {
            const bool v_IsItLettersSequence = true;
            for (int i = 0; i < i_InputFromUser.Length; i++)
            {
                if (!char.IsLetter(i_InputFromUser[i]))
                {
                    return !v_IsItLettersSequence;
                }
            }

            return v_IsItLettersSequence;
        }

        private static bool isStringPalindrome(string i_InputFromUser)
        {
            const bool v_IsPalindrome = true;
            int stringSize = i_InputFromUser.Length;
            if (stringSize == 0 || stringSize == 1)
            {
                return v_IsPalindrome;
            }

            if (i_InputFromUser[0] != i_InputFromUser[stringSize - 1])
            {
                return !v_IsPalindrome;
            }

            return isStringPalindrome(i_InputFromUser.Substring(1, stringSize - 2));
        }

        private static void checkIfCurrentNumberDividedby3(string i_InputFromUser)
        {
            int sumOfDigits = 0;
            for (int i = 0; i < i_InputFromUser.Length; i++)
            {
                string digit = string.Format("{0}", i_InputFromUser[i]);
                sumOfDigits += int.Parse(digit);
            }

            if (sumOfDigits % 3 == 0)
            {
                Console.WriteLine("The number {0} is divisible by 3.", i_InputFromUser);
            }
            else
            {
                Console.WriteLine("The number {0} is not divisible by 3.", i_InputFromUser);
            }
        }

        private static void countNumberOfLowerLetters(string i_InputFromUser)
        {
            int numberOfLowerLetters = 0;
            for (int i = 0; i < i_InputFromUser.Length; i++)
            {
                if (char.IsLower(i_InputFromUser[i]))
                {
                    numberOfLowerLetters++;
                }
            }

            Console.WriteLine("The string {0} has {1} lower letters.", i_InputFromUser, numberOfLowerLetters);
        }
    }
}
