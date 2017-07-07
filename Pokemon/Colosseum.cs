using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace Pokemon
{
    public class Colosseum
    {
        #region Member Variables
        Pokemon player1;
        Pokemon player2;
        Dice d2;
        Dice d6;
        Dice d20;
        #endregion

        #region Member Methods
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
            while(player1.Hp >= 1 && player2.Hp >= 1)//neither is dead
            {
                if(player1.Hp >= 1 && player2.Hp >= 1) //neither is dead
                {
                    Attack(player1, player2);
                }
                if(player1.Hp >= 1 && player2.Hp >= 1) //neither is dead
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
            throw new NotImplementedException();
        }

        private void PokemonBuild(Pokemon pokemon) 
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
            while(attack < 0 || attack > 100)
            {
                Console.WriteLine("Your entry is invalid, please enter a number between 0 and 100.");
                int.TryParse(ReadLine(), out attack);
            }
            WriteLine("Enter defense points (0 - " + (100 - attack) + ")");
            int.TryParse(ReadLine(), out int defense);
            while (defense < 0 || defense > 100 - attack)
            {
                Console.WriteLine("Your entry is invalid, please enter a number between 0 and " + (100-attack) + ".");
                int.TryParse(ReadLine(), out defense);
            }
            pokemon.AttackLevel = attack;
            pokemon.DefenseLevel = defense;
            Console.Clear();
            AssignMove(pokemon);
            
            Console.Clear();

            WriteLine("Pokemon Summary \n-------------- ");
            WriteLine("Name: " + pokemon.Name);
            WriteLine("Type: " + pokemon.Type);
            WriteLine("Attack: " + pokemon.AttackLevel);
            WriteLine("Defense: " + pokemon.DefenseLevel);
            WriteLine("Move 1: " + pokemon.MoveSet.move1.name);
            WriteLine("Move 2: " + pokemon.MoveSet.move2.name);
            WriteLine("Move 3: " + pokemon.MoveSet.move3.name);
            WriteLine("Move 4: " + pokemon.MoveSet.move4.name);
            WriteLine("Please hit enter to continue");
            ReadKey();
            Console.Clear();
		}

        private void AssignMove(Pokemon pokemon)
        {
            int moveNum = 1;
            MoveIndex index = new MoveIndex();
            var moves = index.GetChooseableMoves(pokemon.Type);
            List<string> moveNames = new List<string>();
            foreach (var thing in moves)
                moveNames.Add(thing.name);

            do
            {
                Console.WriteLine("Please choose Move " + moveNum + ":");
                
                foreach (var move in moves)
                    Console.WriteLine("[" + move.moveType + "] " + move.name);
                
                string choice;
                choice = ReadLine();
                while (!moveNames.Contains(choice))
                {
                    Console.WriteLine("You did not enter a valid move. Please type the name [case sensitive]");
                    choice = ReadLine();
                }
                if (pokemon.MoveSet.move1.name == null)
                {
                    pokemon.MoveSet.move1 = moves.Find(x => x.name.Equals(choice));
                    moves.RemoveAll(x => x.name.Equals(choice));
                    moveNames.RemoveAll(x => x.Equals(choice));
                }
                else if (pokemon.MoveSet.move2.name == null)
                {
                    pokemon.MoveSet.move2 = moves.Find(x => x.name.Equals(choice));
                    moves.RemoveAll(x => x.name.Equals(choice));
                    moveNames.RemoveAll(x => x.Equals(choice));
                }
                else if (pokemon.MoveSet.move3.name == null)
                {
                    pokemon.MoveSet.move3 = moves.Find(x => x.name.Equals(choice));
                    moves.RemoveAll(x => x.name.Equals(choice));
                    moveNames.RemoveAll(x => x.Equals(choice));
                }
                else
                {
                    pokemon.MoveSet.move4 = moves.Find(x => x.name.Equals(choice));
                    moves.RemoveAll(x => x.name.Equals(choice));
                    moveNames.RemoveAll(x => x.Equals(choice));
                }
                moveNum++;
                Console.Clear();
            } while (pokemon.MoveSet.move1.name == null || pokemon.MoveSet.move2.name == null || pokemon.MoveSet.move3.name == null || pokemon.MoveSet.move4.name == null);
        }

        private void GameOver(Pokemon winner)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
