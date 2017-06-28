using System;
using static System.Console;

namespace Pokemon
{
    public class Colosseum
    {
        Pokemon player1;
        Pokemon player2;
        Dice d2;
        Dice d6;
        Dice d20;

        public Colosseum()
        {
            PokemonBuild(player1);
            PokemonBuild(player2);
        }
        public void Play()
        {
            Battle(player1, player2);
		}
        public void Battle(Pokemon player1, Pokemon player2)
        {
            
        }
        private void Attack(Pokemon attacker, Pokemon defender)
        {
            
        }

        private void PokemonBuild(Pokemon pokemon) //error checking on input
        {
            pokemon = new Pokemon();
            WriteLine("Player, please build your Pokemon!");
            WriteLine("Enter its name");
            pokemon.Name = ReadLine();
            WriteLine("Choose its type (number) \n1) Grass\n2) Fire\n3) Water\n4) Rock\n5) Mystic");
            int.TryParse(ReadLine(), out int type);
            switch(type)
            {
                case 1:
                    pokemon.Type = "Grass";
                    break;
				case 2:
					pokemon.Type = "Fire";
					break;
				case 3:
					pokemon.Type = "Water";
					break;
				case 4:
					pokemon.Type = "Rock";
					break;
                case 5:
                    pokemon.Type = "Mystic";
                    break;
            }
            WriteLine("Divide 100 points between Attack and Defense");
            WriteLine("Enter attack points (0 - 100)");
            int.TryParse(ReadLine(),out int attack);
            WriteLine("Enter defense points (0 - " + (100 - attack) + ")");
            int.TryParse(ReadLine(), out int defense);
            pokemon.AttackLevel = attack;
            pokemon.DefenseLevel = defense;

            WriteLine(pokemon.Name);
            WriteLine(pokemon.Type);
            WriteLine(pokemon.AttackLevel);
            WriteLine(pokemon.DefenseLevel);
		}
    }
}
