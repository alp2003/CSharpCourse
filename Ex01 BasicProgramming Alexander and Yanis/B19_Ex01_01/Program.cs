using System;

namespace B19_Ex01_01
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Ex01 Binary Series");
            Console.WriteLine("======================");
            binarySeries();
            Console.ReadKey();
        }

        private static void binarySeries()
        {
            string[] binaryNumbers = new string[4];
            int[] decimalNumbers;
            userInput(binaryNumbers);
            decimalNumbers = convertBinaryNumbersToDecimals(binaryNumbers);
            Console.WriteLine();
            Console.Write("The binary numbers: ");
            printBinaryArray(binaryNumbers);
            Console.Write("The decimal numbers: ");
            printDecimalArray(decimalNumbers);
            Console.WriteLine("The average of digit '0' appearance is {0}.", averageOfDigitAppearance(binaryNumbers, '0'));
            Console.WriteLine("The average of digit '1' appearance is {0}.", averageOfDigitAppearance(binaryNumbers, '1'));
            Console.WriteLine("You entered ({0}/{1}) numbers power of 2.", countNumbersPowerOfTwo(decimalNumbers), decimalNumbers.Length);
            Console.WriteLine("You entered ({0}/{1}) numbers that there digits in ascending order.", countNumbersThereDigitsInAscendingOrder(decimalNumbers), decimalNumbers.Length);
            Console.WriteLine("The average of decimal numbers is {0}.", averageOfDecimalNumbers(decimalNumbers));
        }

        private static void userInput(string[] i_BinaryNumbers)
        {
            string binaryNumber;
            bool isItCorrectBinaryNumber = true;
            Console.WriteLine("Please enter 4 binary numbers in length of 8 digits:");
            for (int i = 0; i < i_BinaryNumbers.Length; i++)
            {
                do
                {
                    Console.Write("Please enter {0} binary number: ", i + 1);
                    binaryNumber = Console.ReadLine();
                    isItCorrectBinaryNumber = (binaryNumber.Length == 8) && isItBinaryNumber(binaryNumber);
                    if (isItCorrectBinaryNumber)
                    {
                        i_BinaryNumbers[i] = string.Copy(binaryNumber);
                    }
                    else
                    {
                        Console.WriteLine("Try again, the input was not correct!");
                    }
                }
                while (!isItCorrectBinaryNumber);
            }
        }

        private static bool isItBinaryNumber(string i_BinaryNumber)
        {
            const bool v_IsItBinaryNumber = true;
            for (int i = 0; i < i_BinaryNumber.Length; i++)
            {
                if (!isItBinaryDigit(i_BinaryNumber[i]))
                {
                    return !v_IsItBinaryNumber;
                }
            }

            return v_IsItBinaryNumber;
        }

        private static bool isItBinaryDigit(char i_Digit)
        {
            return i_Digit == '0' || i_Digit == '1';
        }

        private static int[] convertBinaryNumbersToDecimals(string[] i_BinaryNumbers)
        {
            int[] decimalNumbers = new int[i_BinaryNumbers.Length];
            int binaryNumber;
            int decimalNumber;
            for (int i = 0; i < i_BinaryNumbers.Length; i++)
            {
                int.TryParse(i_BinaryNumbers[i], out binaryNumber);
                decimalNumber = binaryToDecimal(binaryNumber);
                decimalNumbers[i] = decimalNumber;
            }

            return decimalNumbers;
        }

        private static int binaryToDecimal(int i_BinaryNumber)
        {
            int decimalNumber = 0;
            int baseNumber = 1;
            int remainder;
            while (i_BinaryNumber > 0)
            {
                remainder = i_BinaryNumber % 10;
                decimalNumber = decimalNumber + (remainder * baseNumber);
                i_BinaryNumber /= 10;
                baseNumber *= 2;
            }

            return decimalNumber;
        }

        private static double averageOfDecimalNumbers(int[] i_DecimalNumbers)
        {
            int totalSum = 0;
            double average = 0.0;
            for (int i = 0; i < i_DecimalNumbers.Length; i++)
            {
                totalSum += i_DecimalNumbers[i];
            }

            average = (double)totalSum / i_DecimalNumbers.Length;
            return average;
        }

        private static void printDecimalArray(int[] i_Numbers)
        {
            for (int i = 0; i < i_Numbers.Length; i++)
            {
                Console.Write("{0}", i_Numbers[i]);
                if (i != i_Numbers.Length - 1)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine();
        }

        private static void printBinaryArray(string[] i_Numbers)
        {
            for (int i = 0; i < i_Numbers.Length; i++)
            {
                Console.Write("{0}", i_Numbers[i]);
                if (i != i_Numbers.Length - 1)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine();
        }
        
        private static double averageOfDigitAppearance(string[] i_BinaryNumbers, char i_Digit)
        {
            int total = 0;
            double average = 0;
            for (int i = 0; i < i_BinaryNumbers.Length; i++)
            {
                total += countDigitAppearance(i_BinaryNumbers[i], i_Digit);
            }

            average = (double)total / i_BinaryNumbers.Length;
            
            return average;
        }

        private static int countDigitAppearance(string i_BinaryNumber, char i_Digit)
        {
            int totalDigitAppeared = 0;
            for (int i = 0; i < i_BinaryNumber.Length; i++)
            {
                if(i_BinaryNumber[i] == i_Digit)
                {
                    totalDigitAppeared++;
                }
            }

            return totalDigitAppeared;
        }

        private static int countNumbersPowerOfTwo(int[] i_DecimalNumbers)
        {
            int numberOfPower2Numbers = 0;
            for (int i = 0; i < i_DecimalNumbers.Length; i++)
            {
                if (isItPowerOfTwoNumber(i_DecimalNumbers[i]))
                {
                    numberOfPower2Numbers++;
                }
            }

            return numberOfPower2Numbers;
        }

        private static bool isItPowerOfTwoNumber(int i_DecimalNumber)
        {
            const bool v_IsItPowerOf2Number = true;
            if (i_DecimalNumber == 0)
            {
                return !v_IsItPowerOf2Number;
            }

            while (i_DecimalNumber != 1)
            {
                if (i_DecimalNumber % 2 != 0)
                {
                    return !v_IsItPowerOf2Number;
                }

                i_DecimalNumber /= 2;
            }

            return v_IsItPowerOf2Number;
        }

        private static int countNumbersThereDigitsInAscendingOrder(int[] i_DecimalNumbers)
        {
            int numberAscendingOrderDigitsNumbers = 0;
            bool isAscendingOrder;
            for (int i = 0; i < i_DecimalNumbers.Length; i++)
            {
                isAscendingOrder = isNumberDigitsInAscendingOrder(i_DecimalNumbers[i]);
                if (isAscendingOrder)
                {
                    numberAscendingOrderDigitsNumbers++;
                }
            }

            return numberAscendingOrderDigitsNumbers;
        }

        private static bool isNumberDigitsInAscendingOrder(int i_DecimalNumber)
        {
            const bool v_IsDigitsInAscendingOrder = true;
            int tempNumber = i_DecimalNumber;
            while (tempNumber > 9)
            {
                int currentDigit = tempNumber % 10;
                int nextDigit = (tempNumber / 10) % 10;
                if (!(currentDigit > nextDigit))
                {
                    return !v_IsDigitsInAscendingOrder;
                }

                tempNumber /= 10;
            }
            
            return v_IsDigitsInAscendingOrder;
        }
    }
}
