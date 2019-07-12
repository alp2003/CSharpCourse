namespace Ex02_Othelo
{
    public class Player
    {
        private string m_PlayerName;
        private int m_PlayerScore;
        private char m_SymbolOfPlayer;
        private int m_NumberOfCoins;
        private bool m_IsComputer;

        public string PlayerName
        {
            get { return m_PlayerName; }
            set { m_PlayerName = value; }
        }

        public int PlayerScore
        {
            get { return m_PlayerScore; }
            set { m_PlayerScore = value; }
        }

        public int NumberOfCoins
        {
            get { return m_NumberOfCoins; }
            set { m_NumberOfCoins = value; }
        }

        public char SymbolOfPlayer
        {
            get { return m_SymbolOfPlayer; }
            set { m_SymbolOfPlayer = value; }
        }

        public bool IsComputer
        {
            get { return m_IsComputer; }
            set { m_IsComputer = value; }
        }

        public Player(string i_PlayerName, char i_PlayerSymbol, bool i_IsComputer)
        {
            m_PlayerName = i_PlayerName;
            m_SymbolOfPlayer = i_PlayerSymbol;
            m_PlayerScore = 0;
            m_NumberOfCoins = 2;
            m_IsComputer = i_IsComputer;
        }
    }
}
