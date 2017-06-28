using System;
namespace Pokemon
{
    public class Dice
    {
        private int sides;
        Random rand = new Random();

        public Dice(int numSides)
        {
            sides = numSides;
        }

        public int Sides { get { return sides; } set { sides = value; }}

        public int Roll()
        {
            return rand.Next(1, sides+1);
        }
    }
}
