using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4inarow
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            //Declate game boards
            long[,] gameField = new long[6, 7] {
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0 }
                };

            //Get row and column length
            int rowLength = gameField.GetLength(0);
            int colLength = gameField.GetLength(1);

            //display gmae field for start
            void GameFieldStart()
            {
                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        Console.Write(string.Format("{0} ", gameField[i, j]));
                    }
                    Console.Write(Environment.NewLine);
                }
            }

            //Player id
            int playerId = 2;

            //Methods
            //Update Game
            void UpdateGame(int column, int player)
            {
                //Clear board
                Console.Clear();
                //In which row should the chip go
                int row = 5;

                //check if column exists
                if(column >= 7)
                {
                    GameFieldStart();
                    Console.WriteLine("this column does not exist! You lost your turn!");
                    NextMove();
                }

                //Insert Chip
                void insertChip()
                {
                    try
                    {
                        if (gameField[row, column] == 0)
                        {
                            //Ittarate trough arrey and display it
                            for (int i = 0; i < rowLength; i++)
                            {
                                for (int j = 0; j < colLength; j++)
                                {
                                    //Insert value on the board
                                    gameField[row, column] = player;
                                    Console.Write(string.Format("{0} ", gameField[i, j]));
                                }
                                Console.Write(Environment.NewLine);
                            }
                        }
                        else
                        {
                            row--;
                            insertChip();
                        }
                    }
                    catch
                    {
                        GameFieldStart();
                        Console.WriteLine("This Column is Full! You lost your turn!");
                    }

                }
                insertChip();

                //Check for victory
                void checkForVictory()
                {   //Check for vertical win
                    for (int i = 0; i < rowLength; i++)
                    { 
                        for (int j = 0; j < colLength; j++)
                        {
                            //Check for Win conditions
                            try
                            {
                                if (gameField[i, j] == player && gameField[i - 1, j] == player && gameField[i - 2, j] == player && gameField[i - 3, j] == player)
                                {
                                    Console.WriteLine(player + " win");
                                }
                                // out of bounds NO WIN
                                if (gameField[i, j] == player && gameField[i, j - 1] == player && gameField[i, j - 2] == player && gameField[i, j - 3] == player)
                                {
                                    Console.WriteLine(player + " win");
                                }
                                //check for diognal win left to right
                                if (gameField[i, j] == player && gameField[i - 1, j - 1] == player && gameField[i - 2, j - 2] == player && gameField[i - 3, j - 3] == player)
                                {
                                    Console.WriteLine(player + " win");
                                }
                                //check for diognal win right to left
                                if (gameField[i, j] == player && gameField[i + 1, j - 1] == player && gameField[i + 2, j - 2] == player && gameField[i + 3, j - 3] == player)
                                {
                                    Console.WriteLine(player + " win");
                                }
                            }
                            catch
                            {
                               //Do nothing
                            }
                        }
                    }
                }
                checkForVictory();

                
                //Iniate next move
                NextMove();      
            }          
           
            //Next move
            void NextMove()
            {                
                //Change player
                if (playerId == 2)
                {
                    playerId = 1;
                } else
                {
                    playerId = 2;
                }

                //Insert value to arrey 
                Console.WriteLine("Player: " + playerId + " turn");
                Console.WriteLine("Type COLUMN number (0-6) you want to insert your chip:");
                string line = Console.ReadLine(); // Read string from console
                int value;
                if (int.TryParse(line, out value)) // Parse the string as an integer
                {
                    UpdateGame(value, playerId);
                }
                else
                {
                    Console.WriteLine("Not an integer!");
                    NextMove();
                }
            }

            //start game
            GameFieldStart();
            NextMove();

            
        }
    }
}
