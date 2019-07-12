using System;

namespace Ex04.Menus.Test
{
    public class MethodsForMenusDelegates
    {
        public void CountDigits()
        {
            Console.Write("Please enter a sentence: ");
            string sentenceFromUser = Console.ReadLine();
            int numberOfDigitsInSentence = countNumberOfDigitsInSentence(sentenceFromUser);
            Console.WriteLine("There are {0} digits at the current sentence.", numberOfDigitsInSentence);
        }

        private int countNumberOfDigitsInSentence(string i_SentenceFromUser)
        {
            int digitCounter = 0;
            char[] sentenceInChars = i_SentenceFromUser.ToCharArray();
            foreach (char character in sentenceInChars)
            {
                if (char.IsDigit(character))
                {
                    digitCounter++;
                }
            }

            return digitCounter;
        }

        public void ShowDate()
        {
            Console.WriteLine(string.Format("Current Date: {0}", DateTime.Now.ToShortDateString()));
        }

        public void ShowTime()
        {
            Console.WriteLine(string.Format("Current Time: {0}", DateTime.Now.ToString("hh:mm:ss tt")));
        }

        public void ShowVersion()
        {
            Console.WriteLine("Version: 19.2.4.32");
        }
    }
}
