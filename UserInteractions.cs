using System;

namespace TicTacToe
{
    public class UI
    {
        private Logic _gameLogic;

        public UI()
        {
            _gameLogic = new Logic();
        }

        public void StartGame()
        {
            DisplayWelcomeMessage();

            while (!_gameLogic.IsGameOver())
            {
                DisplayBoard();
                
                // Player Turn
                var playerMove = GetPlayerMove();
                _gameLogic.MakeMove(playerMove, 'X');

                if (_gameLogic.IsGameOver()) break;

                // AI Turn
                var aiMove = _gameLogic.GetAIMove();
                _gameLogic.MakeMove(aiMove, 'O');
            }

            DisplayBoard();
            DisplayResult(_gameLogic.GetWinner());
        }

        private void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("You are 'X', and the AI is 'O'.");
        }

        private void DisplayBoard()
        {
            Console.WriteLine("\nCurrent Board:");
            var board = _gameLogic.Board;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" {board[i, j]} ");
                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("---+---+---");
            }
        }

        private (int row, int col) GetPlayerMove()
        {
            while (true)
            {
                Console.Write("Enter your move (row and column: 1 2): ");
                var input = Console.ReadLine()?.Split();

                if (input != null && input.Length == 2 &&
                    int.TryParse(input[0], out int row) && int.TryParse(input[1], out int col) &&
                    row >= 1 && row <= 3 && col >= 1 && col <= 3 &&
                    _gameLogic.Board[row - 1, col - 1] == ' ')
                {
                    return (row - 1, col - 1);
                }

                Console.WriteLine("Invalid move. Please try again.");
            }
        }

        private void DisplayResult(char winner)
        {
            if (winner == 'X')
                Console.WriteLine("Congratulations! You win!");
            else if (winner == 'O')
                Console.WriteLine("The AI wins. Better luck next time!");
            else
                Console.WriteLine("It's a tie!");
        }
    }
}
