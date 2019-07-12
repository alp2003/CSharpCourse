using System;
using System.Text;

namespace Ex02_Othelo
{
    public class Board
    {
        private readonly char[,] r_OtheloBoard;
        private readonly int r_BoardLength;

        public char[,] OtheloBoard
        {
            get { return r_OtheloBoard; }
        }

        public int BoardLength
        {
            get { return r_BoardLength; }
        }

        public Board(int i_BoardSize)
        {
            r_BoardLength = i_BoardSize;
            r_OtheloBoard = new char[r_BoardLength, r_BoardLength];
            initiateBoard();
        }

        private void initiateBoard()
        {
            for (int i = 0; i < BoardLength; i++)
            {
                for (int j = 0; j < BoardLength; j++)
                {
                    OtheloBoard[i, j] = ' ';
                }
            }

            OtheloBoard[BoardLength / 2, BoardLength / 2] = 'O';
            OtheloBoard[(BoardLength / 2) - 1, BoardLength / 2] = 'X';
            OtheloBoard[BoardLength / 2, (BoardLength / 2) - 1] = 'X';
            OtheloBoard[(BoardLength / 2) - 1, (BoardLength / 2) - 1] = 'O';
        }

        public void PrintBoard()
        {
            Console.WriteLine("Othello Game");
            Console.WriteLine("==============");
            char currentCharToPrint = 'A';
            StringBuilder borderLine = new StringBuilder("  =");
            StringBuilder currentLine = new StringBuilder(string.Empty);

            currentLine.Append(" ");
            for (int i = 0; i < BoardLength; i++)
            {
                currentLine.Append("   ").Append(currentCharToPrint++);
                borderLine.Append("====");
            }

            Console.WriteLine(currentLine);
            Console.WriteLine(borderLine);

            for (int i = 1; i <= BoardLength; i++)
            {
                currentLine = new StringBuilder(string.Empty);
                currentLine.Append(i).Append(" |");
                for (int j = 1; j <= BoardLength; j++)
                {
                    currentLine.Append(' ').Append(OtheloBoard[i - 1, j - 1]).Append(" |");
                }

                Console.WriteLine(currentLine);
                Console.WriteLine(borderLine);
            }
        }

        public static bool CheckDimension(int i_Dimention)
        {
            const bool v_IsDimentionCorrect = true;
            if(i_Dimention == 6 || i_Dimention == 8)
            {
                    return v_IsDimentionCorrect;
            }

            return !v_IsDimentionCorrect;
        }
    }
}
