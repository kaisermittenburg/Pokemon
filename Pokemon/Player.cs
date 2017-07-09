using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    public class Player
    {
        private string name;
        private int wins;
        Pokemon pokemon;
        public Player()
        {
            pokemon = new Pokemon();
        }
        public string Name { get { return name; } set { name = value; } }
        public int Wins { get { return wins; } set { wins = value; } }
        public Pokemon Pokemon { get { return pokemon; } set { pokemon = value; } }
    }
}
