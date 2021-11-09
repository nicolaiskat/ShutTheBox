using System;
using System.Collections.Generic;

namespace ShutTheBox
{
    class Program
    {
        static void Main(string[] args)
        {
            //Introduction to game
            Console.WriteLine("Lets play ShutTheBox\n" +
                "How many would you like to play?\n" +
                "Min 1 and Max 4 players\n");

            Console.WriteLine("How many players would you like to play?:");
            int CountPlayers = int.Parse(Console.ReadLine());

            //Players list
            List<Player> Players = new();

            //Create x number of players and adding to players list
            Console.WriteLine("\n~~~~~ Choose players ~~~~~");
            for (int i = 0; i < CountPlayers; i++)
            {
                Console.WriteLine($"\nPlayer {i + 1} name: ");
                Player Player = new(Console.ReadLine());
                Players.Add(Player);
            }

            Console.WriteLine("");
            foreach (var Player in Players)
            {
                Console.WriteLine($"Welcome to the game {Player.Navn}");
            }

            var GameTrue = true;
            //Game loop
            while (GameTrue)
            {
                Console.WriteLine("\n\n\n~~~~~New round ~~~~~");

                //Current player playing
                foreach (var Player in Players)
                {
                    int Dices = 0;
                   

                    //Round loop
                    while (true)
                    {
                        while (Dices != 1 && Dices != 2)
                        {
                            Console.WriteLine("\n" + Player.Navn + ", it is your turn now\n" +
                                              "How many dices would you like to throw? (1 or 2)");
                            Dices = int.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("\n~~~~~~~~~~~~~~\n" +
                                            "Throwing dices\n" +
                                            "~~~~~~~~~~~~~~\n" +
                                            Player.Navn);
                        if (Dices == 1)
                        {
                            //Throwing dices
                            Player.Dice1.Throw();

                            //Current dice rolls
                            Console.WriteLine("You rolled a:  " + Player.Dice1.show());
                        }

                        else if (Dices == 2)
                        {
                            //Throwing dices
                            Player.ThrowDices();

                            //Current dice rolls
                            Console.WriteLine("You rolled a:  " + Player.Dice1.show() + "\n" +
                                                    "And a:         " + Player.Dice2.show() + "\n" +
                                                    "Total sum is:  " + Player.AddedDices());
                        }

                        //Gameboard as text output |1|2|3|4|5|6|7|8|9|
                        Console.WriteLine("\nYou have the numbers left below to shut");
                        Console.WriteLine(Player.LogBoard());
                        Console.WriteLine("You have the following options\n");



                        //Intialising game
                        int valg;
                        if (Dices == 1)
                        {
                            if (Player.LogBoard().Contains(Player.Dice1.show().ToString()))
                            {
                                Console.WriteLine("1: Shut " + Player.Dice1.show());
                                valg = int.Parse(Console.ReadLine());
                                if (valg == 1)
                                {
                                    Player.Shut(Player.Dice1.show());
                                }
                                if (Player.LogBoard() == "|0|0|0|0|0|0|0|0|0|")
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                             //if sentences to direct the user to correct options
                            if (Player.LogBoard().Contains(Player.AddedDices().ToString()) &&
                                Player.LogBoard().Contains(Player.Dice1.show().ToString()) &&
                                Player.LogBoard().Contains(Player.Dice2.show().ToString()))
                            {
                                //User options
                                Console.WriteLine("1: Shut " + Player.AddedDices());
                                Console.WriteLine("2: Shut " + Player.Dice1.show());
                                Console.WriteLine("3: Shut " + Player.Dice2.show());

                                //Choosing the number to shut
                                valg = int.Parse(Console.ReadLine());
                                if (valg == 1)
                                {
                                    Player.Shut(Player.AddedDices());
                                }
                                else if (valg == 2)
                                {
                                    Player.Shut(Player.Dice1.show());
                                }
                                else if (valg == 3)
                                {
                                    Player.Shut(Player.Dice2.show());
                                }
                                if (Player.LogBoard() == "|0|0|0|0|0|0|0|0|0|")
                                {
                                    break;
                                }

                                //Next option
                            }
                            else if (Player.LogBoard().Contains(Player.Dice1.show().ToString()) &&
                                Player.LogBoard().Contains(Player.Dice2.show().ToString()))
                            {
                                Console.WriteLine("1: Shut " + Player.Dice1.show());
                                Console.WriteLine("2: Shut " + Player.Dice2.show());
                                valg = int.Parse(Console.ReadLine());
                                if (valg == 1)
                                {
                                    Player.Shut(Player.Dice1.show());
                                }
                                else if (valg == 2)
                                {
                                    Player.Shut(Player.Dice2.show());
                                }
                                if (Player.LogBoard() == "|0|0|0|0|0|0|0|0|0|")
                                {
                                    break;
                                }
                            }
                            //Next option
                            else if (Player.LogBoard().Contains(Player.Dice1.show().ToString()) &&
                                    Player.LogBoard().Contains(Player.AddedDices().ToString()))
                            {
                                Console.WriteLine("1: Shut " + Player.Dice1.show());
                                Console.WriteLine("2: Shut " + Player.AddedDices());
                                valg = int.Parse(Console.ReadLine());
                                if (valg == 1)
                                {
                                    Player.Shut(Player.Dice1.show());
                                }
                                else if (valg == 2)
                                {
                                    Player.Shut(Player.AddedDices());
                                }
                                if (Player.LogBoard() == "|0|0|0|0|0|0|0|0|0|")
                                {
                                    break;
                                }
                            }
                            //Next option
                            else if (Player.LogBoard().Contains(Player.Dice2.show().ToString()) &&
                                    Player.LogBoard().Contains(Player.AddedDices().ToString()))
                            {
                                Console.WriteLine("1: Shut " + Player.Dice2.show());
                                Console.WriteLine("2: Shut " + Player.AddedDices());
                                valg = int.Parse(Console.ReadLine());
                                if (valg == 1)
                                {
                                    Player.Shut(Player.Dice2.show());
                                }
                                else if (valg == 2)
                                {
                                    Player.Shut(Player.AddedDices());
                                }
                                if (Player.LogBoard() == "|0|0|0|0|0|0|0|0|0|")
                                {
                                    break;
                                }
                            }
                            //Next option
                            else if (Player.LogBoard().Contains(Player.Dice1.show().ToString()))
                            {
                                Console.WriteLine("1: Shut " + Player.Dice1.show());
                                valg = int.Parse(Console.ReadLine());
                                if (valg == 1)
                                {
                                    Player.Shut(Player.Dice1.show());
                                }
                                if (Player.LogBoard() == "|0|0|0|0|0|0|0|0|0|")
                                {
                                    break;
                                }
                            }
                            //Next option
                            else if (Player.LogBoard().Contains(Player.Dice2.show().ToString()))
                            {
                                Console.WriteLine("1: Shut " + Player.Dice2.show());
                                valg = int.Parse(Console.ReadLine());
                                if (valg == 1)
                                {
                                    Player.Shut(Player.Dice2.show());
                                }
                                if (Player.LogBoard() == "|0|0|0|0|0|0|0|0|0|")
                                {
                                    break;
                                }
                            }
                            //Next option
                            else if (Player.LogBoard().Contains(Player.AddedDices().ToString()))
                            {
                                Console.WriteLine("1: Shut " + Player.AddedDices());
                                valg = int.Parse(Console.ReadLine());
                                if (valg == 1)
                                {
                                    Player.Shut(Player.AddedDices());
                                }
                                if (Player.LogBoard() == "|0|0|0|0|0|0|0|0|0|")
                                {
                                    break;
                                }
                            }
                            //if dices are already shut - Round ends and breaks out of current "player round" 
                            else
                            {
                                Console.WriteLine("Dices thrown are already shut\n" +
                                    "Round over.");
                                break;
                            }
                        }
                        //Reset dices variable

                        Dices = 0;
                        //End of while
                    }
                    //Summary of round for player
                    Console.WriteLine(Player.Navn + " has lost " + Player.RoundPoints() + " points");
                }
                //Output of current player scores and/or exiting game if a player has won
                Console.WriteLine("\n\nThe current standings are:");
                foreach (var Player in Players)
                {
                    if (Player.LogBoard() == "|0|0|0|0|0|0|0|0|0|")
                    {
                        int lowest = 99999999;
                        string winner = "";
                        foreach (var Score in Players)
                        {
                            if(Score.GetPoints() < lowest)
                            {
                                lowest = Score.GetPoints();
                                winner = Score.Navn;
                            }
                        }
                        Console.WriteLine("\n" + winner + " has won the game of ShutTheBox");
                        GameTrue = false;
                    }
                    Console.WriteLine(Player.Navn + " has -" + Player.GetPoints());
                }

                //End of while game
            }
        }
    }
}
