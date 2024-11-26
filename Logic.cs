using System;

namespace TicTacToe
{
    public class Logic
    {
        public char[,] Board { get; private set; }
        private const int Size = 3;

        public Logic()
        {
            Board = new char[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Board[i, j] = ' ';
                }
            }
        }

        public void MakeMove((int row, int col) move, char symbol)
        {
            Board[move.row, move.col] = symbol;
        }

        public (int row, int col) GetAIMove()
        {
            // Simple AI: Choose the first available spot
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Board[i, j] == ' ')
                    {
                        return (i, j);
                    }
                }
            }
            throw new InvalidOperationException("No moves left!");
        }

        public bool IsGameOver()
        {
            return GetWinner() != ' ' || IsBoardFull();
        }

        public char GetWinner()
        {
            // Check rows and columns
            for (int i = 0; i < Size; i++)
            {
                if (Board[i, 0] != ' ' && Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2])
                    return Board[i, 0];
                if (Board[0, i] != ' ' && Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i])
                    return Board[0, i];
            }

            // Check diagonals
            if (Board[0, 0] != ' ' && Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
                return Board[0, 0];
            if (Board[0, 2] != ' ' && Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
                return Board[0, 2];

            // No winner
            return ' ';
        }

        private bool IsBoardFull()
        {
            foreach (var cell in Board)
            {
                if (cell == ' ') return false;
            }
            return true;
        }
    }
}
