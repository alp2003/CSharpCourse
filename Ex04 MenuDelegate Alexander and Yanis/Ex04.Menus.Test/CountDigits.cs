using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountDigits : IMenuClickListener
    {
        public void MenuClick()
        {
            countDigits();
        }

        private void countDigits()
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
    }
}
