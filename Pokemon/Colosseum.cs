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
            d2 = new Dice(2);
            d6 = new Dice(6);
            d20 = new Dice(20);
            player1 = new Pokemon();
            player2 = new Pokemon();
            PokemonBuild(player1);
            PokemonBuild(player2);
        }
        public void Play()
        {
            int roll = d2.Roll();
            if (roll == 1)
                Battle(player1, player2);
            else
                Battle(player2, player1);
		}
        public void Battle(Pokemon player1, Pokemon player2)
        {
            Console.WriteLine(player1.Name + " will go first!\n");
            while(true)//neither is dead
            {
                if(true) //neither is dead
                {
                    Attack(player1, player2);
                }
                if(true) //neither is dead
                {
                    Attack(player2,player1);
                }
            }
            if(player1.Hp <= 0)
            {
                GameOver(player2);
            }
            else
            {
                GameOver(player1);
            }
        }
        private void Attack(Pokemon attacker, Pokemon defender)
        {
            
        }

        private void PokemonBuild(Pokemon pokemon) //error checking on input
        {
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
            AssignMove(pokemon, 1);
            AssignMove(pokemon, 2);
            AssignMove(pokemon, 3);
            AssignMove(pokemon, 4);
            WriteLine(pokemon.Name);
            WriteLine(pokemon.Type);
            WriteLine(pokemon.AttackLevel);
            WriteLine(pokemon.DefenseLevel);
		}

        private void AssignMove(Pokemon pokemon,int moveNum)
        {
            Console.WriteLine("Please choose Move " + moveNum + ":");
            MoveIndex index = new MoveIndex();
            var moves = index.GetChooseableMoves(pokemon.Type);
            foreach(var move in moves)
            {
                Console.WriteLine("[" + move.moveType + "] " + move.name);
            }
        }

        private void GameOver(Pokemon winner)
        {
            
        }
    }
}
