using System;
using System.Linq;

namespace ShutTheBox
{
    public class Player :PairOfDice
    {
        public string Navn { get; set; }
        public int Point { get; set; }
        public Gameboard Gameboard;

        public Player(string Navn)
        {
            this.Navn = Navn;
            this.Point = 0;
            this.Gameboard = new Gameboard();
        }

        public int GetPoints()
        {
            return this.Point;
        }
        public void ResetPoints()
        {
            this.Point = 0;
        }
        public int RoundPoints()
        {
            int sum = 0;
            foreach(int i in Gameboard.Board)
            {
                sum += i;
            }
            Point += sum;
            return sum;
        }

        public void Shut(int a, int b = -1)
        {
            int index1 = Array.IndexOf(Gameboard.Board, a);
            Gameboard.Board[index1] = 0;
            if (b > 0)
            {
                int index2 = Array.IndexOf(Gameboard.Board, b);
                Gameboard.Board[index2] = 0;
            }
        }
        public string LogBoard()
        {
            string board = "|";
            foreach(int i in Gameboard.Board)
            {
                board += i.ToString();
                board += "|";
            }
            return board;
        }

        public void ResetBoard()
        {
            int index = 0;
            int nytTal = 1;
            foreach(int i in Gameboard.Board)
            {
                Gameboard.Board[index] = nytTal;
                index++;
                nytTal++;
            }
        }
    }
}
