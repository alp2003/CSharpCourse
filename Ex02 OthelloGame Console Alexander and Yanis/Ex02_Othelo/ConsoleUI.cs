using System;
using System.Text;

namespace Ex02_Othelo
{
    public class ConsoleUI
    {
        public enum eGameMenuOptions
        {
            PlayerVsPlayer = 1,
            PlayerVsComputer,
            EndGame
        }

        private const char k_BlackCharForConsole = 'X';
        private const char k_WhiteCharForConsole = 'O';

        private OthelloGameLogic m_BoardGame;

        private OthelloGameLogic BoardGame
        {
            get
            {
                return m_BoardGame;
            }

            set
            {
                m_BoardGame = value;
            }
        }

        public ConsoleUI()
        {
            BoardGame = null;
        }
        
        public void BeginGame()
        {
            startApp();
        }

        private void startApp()
        {
            eGameMenuOptions menuOption = eGameMenuOptions.EndGame;
            int anotherGameOption = 0;
            const bool v_IsComputer = true;
            mainMenuOptions(out menuOption);

            
            while (true)
            {
                if(menuOption == eGameMenuOptions.PlayerVsPlayer)
                {
                    startGame(!v_IsComputer);
                }
                else if(menuOption == eGameMenuOptions.PlayerVsComputer)
                {
                    startGame(v_IsComputer);
                }
                else if(menuOption == eGameMenuOptions.EndGame)
                {
                    Console.WriteLine("Goodbye See You Again!!!");
                    return;
                }

                checkIfPlayerWantToPlayAnotherGame(out anotherGameOption);
                
                if (anotherGameOption == 0)
                {
                    Console.WriteLine("Goodbye See You Again!!!");
                    return;
                }

                Ex02.ConsoleUtils.Screen.Clear();
                mainMenuOptions(out menuOption);
            }
        }

        private void startGame(bool i_IsComputer)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            string firstPlayerName = string.Empty;
            string secondPlayerName = string.Empty;
            int anotherGame = 0;
            int boardSize = 0;
            bool isUserAskToExit = false;
            bool isPlayerComputer = i_IsComputer;
            bool v_FirstPlayerPC = false;

            gamePlayTitle();
            if (i_IsComputer)
            {
                secondPlayerName = "Computer";
                createPlayerAndComputer(out firstPlayerName);

            }
            else
            {
                createPlayerAndPlayer2(out firstPlayerName, out secondPlayerName);
            }

            while (!isUserAskToExit)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                gamePlayTitle();
                getFromUserBoardDimension(out boardSize);

                isUserAskToExit = startGameLogicEngine(boardSize, firstPlayerName, v_FirstPlayerPC, secondPlayerName, isPlayerComputer);
                if (!isUserAskToExit)
                {
                    checkIfPlayerWantToPlayAnotherRound(out anotherGame, secondPlayerName);

                    if (anotherGame == 0)
                    {
                        return;
                    }
                }
            }
        }


        private void createPlayerAndPlayer2(out string o_PlayerOne, out string o_PlayerTwo)
        {
            o_PlayerOne = string.Empty;
            o_PlayerTwo = string.Empty;
            Console.Write("Please enter first player name: ");
            checkIfLegalName(out o_PlayerOne);
            Console.WriteLine();
            Console.Write("Please enter second player name: ");
            checkIfLegalName(out o_PlayerTwo);
            Console.WriteLine();
        }

        private void checkIfLegalName(out string o_PlayerName)
        {
            o_PlayerName = Console.ReadLine();
            
            while (string.IsNullOrEmpty(o_PlayerName) || o_PlayerName.Trim().Length == 0)
            {
                Console.Write("{0}Please name can't be empty string: ", Environment.NewLine);
                o_PlayerName = Console.ReadLine();
            }

            o_PlayerName = o_PlayerName.Trim();
        }

        private void checkIfPlayerWantToPlayAnotherGame(out int o_AnotherGameOption)
        {
            o_AnotherGameOption = 0;
            string strAnotherGameOption = string.Empty;
            Console.Write("Do you want to play another game 1-Yes or 0-No? ");
            strAnotherGameOption = Console.ReadLine();
            while (!int.TryParse(strAnotherGameOption, out o_AnotherGameOption) || !checkUserInput(o_AnotherGameOption))
            {
                Console.Write("{0}Do you want to play another game 1-Yes or 0-No? ", Environment.NewLine);
                strAnotherGameOption = Console.ReadLine();
            }
        }

        private void mainMenuOptions(out eGameMenuOptions o_menuOption)
        {
            o_menuOption = eGameMenuOptions.EndGame;
            string stringUserChoice = string.Empty;
            int value = 0;
            gameMenuText();
            stringUserChoice = Console.ReadLine();
            while ((!int.TryParse(stringUserChoice, out value)) || (!checkUserDecision(value)))
            {
                Console.Write("{0}Invalid choice, press 1, 2 or 3 please:", Environment.NewLine);
                stringUserChoice = Console.ReadLine();
            }

            if (value == 1)
            {
                o_menuOption = eGameMenuOptions.PlayerVsPlayer;
            }
            else if (value == 2)
            {
                o_menuOption = eGameMenuOptions.PlayerVsComputer;
            }
            else
            {
                o_menuOption = eGameMenuOptions.EndGame;
            }
        }

        private bool checkUserInput(int i_AnotherGameOption)
        {
            const bool v_IsItlegalChoice = true;
            if (i_AnotherGameOption == 0 || i_AnotherGameOption == 1)
            {
                    return v_IsItlegalChoice;
            }

            return !v_IsItlegalChoice;
        }

        private bool startGameLogicEngine(int i_BoardSize, string i_PlayerOneName, bool i_IsPlayerOneComputer, string i_PlayerTwoName, bool i_IsPlayerTwoComputer)
        {
            int rowForNewDisk = 0;
            int columnForNewDisk = 0;
            int blackPlayerScore = 0;
            int whitePlayerScore = 0;
            bool isUserAskToExit = false;
            bool isGoodLogicMove = true;
            string messageToUser = string.Empty;

            messageToUser = string.Format("Input is not correct logically");
            BoardGame = new OthelloGameLogic(i_BoardSize, i_PlayerOneName, i_IsPlayerOneComputer, i_PlayerTwoName, i_IsPlayerTwoComputer);

            while (!BoardGame.GameOver && !isUserAskToExit)
            {
                if (!isGoodLogicMove)
                {
                    Console.WriteLine(messageToUser);
                }
                else
                {
                    printBoard();
                }

                isUserAskToExit = getMoveFromPlayer(out rowForNewDisk, out columnForNewDisk);

                if (BoardGame.IsBlackTurn)
                {
                    isGoodLogicMove = BoardGame.BlackMakeMove(rowForNewDisk, columnForNewDisk);
                }
                else
                {
                    OthelloGameLogic.s_IsItHumanPlaying = true;
                    isGoodLogicMove = BoardGame.WhiteMakeMove(rowForNewDisk, columnForNewDisk);
                }
            }

            printBoard();
            if (!isUserAskToExit)
            {
                BoardGame.CalculateScore(out blackPlayerScore, out whitePlayerScore);
                messageToUser = string.Format(
                "Black score is {0}, White score {1}. And the winner is {2}",
                blackPlayerScore,
                whitePlayerScore,
                blackPlayerScore > whitePlayerScore ? "Black" : blackPlayerScore == whitePlayerScore ? "Both" : "White");
                Console.WriteLine(messageToUser);
            }
            
            return isUserAskToExit;
        }

        private bool getMoveFromPlayer(out int o_RowForNewDisk, out int o_ColumnForNewDisk)
        {
            o_RowForNewDisk = o_ColumnForNewDisk = 0;
            bool isGameOver = false;
            const int k_ColumnLocationString = 0;
            const int k_RowLocationString = 1;
            const char k_FirstCapitalLetter = 'A';
            const char k_LastCapitalLetterIn8Board = 'H';
            const char k_LastCapitalLetterIn6Board = 'F';
            const char k_QuitGameChar = 'Q';
            string inputStringFromUser = string.Empty;
            string messageToUser = string.Format("{0} (player sign '{1}'), please enter a valid disk location: ", BoardGame.IsBlackTurn ? BoardGame.PlayerTwo.PlayerName : BoardGame.PlayerOne.PlayerName, BoardGame.IsBlackTurn ? k_BlackCharForConsole : k_WhiteCharForConsole);

            Console.Write(messageToUser);
            inputStringFromUser = Console.ReadLine();
            
            while (
                !isGameOver
                && !(inputStringFromUser.Length == 2
                && char.IsLetter(inputStringFromUser[k_ColumnLocationString])
                && ((BoardGame.BoardLength == 8 && inputStringFromUser[k_ColumnLocationString] <= k_LastCapitalLetterIn8Board) || (BoardGame.BoardLength == 6 && inputStringFromUser[k_ColumnLocationString] <= k_LastCapitalLetterIn6Board))
                && char.IsDigit(inputStringFromUser[k_RowLocationString])
                && ((BoardGame.BoardLength == 8 && inputStringFromUser[k_RowLocationString] <= '8') || (BoardGame.BoardLength == 6 && inputStringFromUser[k_RowLocationString] <= '6'))))
            {
                if (inputStringFromUser.Length == 1 && (inputStringFromUser[k_ColumnLocationString] == k_QuitGameChar || inputStringFromUser[k_ColumnLocationString] == char.ToLower(k_QuitGameChar)))
                {
                    isGameOver = !isGameOver;
                }
                else
                {
                    Console.Write("{0}The input entered is invalid. Format should be as E6, Please Try Again: ", Environment.NewLine);
                    inputStringFromUser = Console.ReadLine();
                }
            }

            if (!isGameOver)
            {
                int.TryParse(inputStringFromUser[k_RowLocationString].ToString(), out o_RowForNewDisk);
                o_ColumnForNewDisk = inputStringFromUser[k_ColumnLocationString] - k_FirstCapitalLetter;
                o_ColumnForNewDisk++;
            }

            return isGameOver;
        }

        private void printBoard()
        {
            BoardGame.CopyBoard();
            Ex02.ConsoleUtils.Screen.Clear();
            BoardGame.BoardForUi.PrintBoard();
        }

        private void checkIfPlayerWantToPlayAnotherRound(out int o_AnotherGame, string i_AgainstWho)
        {
            o_AnotherGame = 0;
            Console.Write("Do you want play vs {0} another round 1-Yes, 0-No? ", i_AgainstWho);
            string strAnotherGame = string.Empty;
            strAnotherGame = Console.ReadLine();
            while (!int.TryParse(strAnotherGame, out o_AnotherGame) || !checkUserInput(o_AnotherGame))
            {
                Console.Write("{0}Do you want play vs {1} another round 1-Yes, 0-No? ", Environment.NewLine, i_AgainstWho);
                strAnotherGame = Console.ReadLine();
            }
        }

        private void getFromUserBoardDimension(out int o_BoardSize)
        {
            o_BoardSize = 0;
            string strBoardSize = string.Empty;
            Console.Write("Please enter the board dimension (available options are 6,8): ");
            strBoardSize = Console.ReadLine();
            while (!int.TryParse(strBoardSize, out o_BoardSize) || !Board.CheckDimension(o_BoardSize))
            {
                Console.Write("{0}Please enter the board dimension (available options are 6,8): ", Environment.NewLine);
                strBoardSize = Console.ReadLine();
            }
        }

        private void createPlayerAndComputer(out string o_Player)
        {
            o_Player = string.Empty;
            Console.Write("Please enter your name: ");
            checkIfLegalName(out o_Player);
            Console.WriteLine();
        }
        
        private void gamePlayTitle()
        {
            Console.WriteLine("Othello Game");
            Console.WriteLine("==============");
        }

        private void gameMenuText()
        {
            StringBuilder stringBuilder = new StringBuilder("Welcome To Othello Game");
            stringBuilder.Append(string.Format("{0}==========================", Environment.NewLine));
            stringBuilder.Append(string.Format("{0}Menu", Environment.NewLine));
            stringBuilder.Append(string.Format("{0}=======", Environment.NewLine));
            stringBuilder.Append(string.Format("{0}1 - Play against another player", Environment.NewLine));
            stringBuilder.Append(string.Format("{0}2 - Play against computer", Environment.NewLine));
            stringBuilder.Append(string.Format("{0}3 - Exit the Game", Environment.NewLine));
            stringBuilder.Append(string.Format("{0}press: ", Environment.NewLine));
            Console.Write(stringBuilder.ToString());
        }

        private bool checkUserDecision(int i_UserDecision)
        {
            const bool v_IsItlegalChoice = true;
            if(i_UserDecision >= 1 && i_UserDecision <= 3)
            {
                    return v_IsItlegalChoice;
            }
           
            return !v_IsItlegalChoice;
        }
    }
}
