using System;
namespace ShutTheBox
{
    public class PairOfDice
    {
        public Dice Dice1 { get; set; }
        public Dice Dice2 { get; set; }

        public PairOfDice()
        {
            this.Dice1 = new Dice();
            this.Dice2 = new Dice();
        }

        public void ThrowDices()
        {
            Dice1.Throw();
            Dice2.Throw();
        }
        public int AddedDices()
        {
            return Dice1.show() + Dice2.show();
        }
    }
}
