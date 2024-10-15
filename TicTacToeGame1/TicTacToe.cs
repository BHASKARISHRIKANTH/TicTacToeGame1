namespace TicTacToeGame1;

using System;

class TicTacToe
{
    static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char currentPlayer = 'X';

    static void Main(string[] args)
    {
        int gameStatus;
        do
        {
            Console.Clear();
            DisplayBoard();
            PlayerTurn();
            gameStatus = CheckWin();
            if (gameStatus != 0) break;
            SwitchPlayer();
        } while (gameStatus == 0);

        Console.Clear();
        DisplayBoard();
        if (gameStatus == 1)
            Console.WriteLine($"Player {currentPlayer} wins!");
        else
            Console.WriteLine("It's a draw!");
    }

    static void DisplayBoard()
    {
        Console.WriteLine("   |   |   \n" +
        $" {board[0]} | {board[1]} | {board[2]} \n" +
        "___|___|___\n" +
        "   |   |   \n" +
        $" {board[3]} | {board[4]} | {board[5]} \n" +
        "___|___|___\n" +
        "   |   |   \n" +
        $" {board[6]} | {board[7]} | {board[8]} \n" +
        "   |   |   ");
    }

    static void PlayerTurn()
    {
        int choice;
        bool validInput;
        do
        {
            Console.WriteLine($"Player {currentPlayer}, enter your choice (1-9): ");
            validInput = int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O';
            if (!validInput)
            {
                Console.WriteLine("Invalid move, try again.");
            }
        } while (!validInput);

        board[choice - 1] = currentPlayer;
    }

    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    static int CheckWin()
    {
        // Horizontal lines
        if (board[0] == board[1] && board[1] == board[2]) return 1;
        if (board[3] == board[4] && board[4] == board[5]) return 1;
        if (board[6] == board[7] && board[7] == board[8]) return 1;

        // Vertical lines
        if (board[0] == board[3] && board[3] == board[6]) return 1;
        if (board[1] == board[4] && board[4] == board[7]) return 1;
        if (board[2] == board[5] && board[5] == board[8]) return 1;

        // Diagonals
        if (board[0] == board[4] && board[4] == board[8]) return 1;
        if (board[2] == board[4] && board[4] == board[6]) return 1;

        // Check for draw
        foreach (char c in board)
        {
            if (c != 'X' && c != 'O')
                return 0;
        }

        return -1; // Draw
    }
}


