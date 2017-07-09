using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace Pokemon
{
    public class Colosseum
    {
        #region Member Variables
        Player player1;
        Player player2;
        Dice d2;
        Dice d6;
        Dice d20;
        Dice d100;
        #endregion

        #region Member Methods
        public Colosseum()
        {
            d2 = new Dice(2);
            d6 = new Dice(6);
            d20 = new Dice(20);
            d100 = new Dice(100);
            player1 = new Player();
            player2 = new Player();
            Console.WriteLine("Player 1, please enter your name:");
            player1.Name = ReadLine();
            Console.Clear();
            Console.WriteLine("Player 2, please enter your name:");
            player2.Name = ReadLine();
            Console.Clear();
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

        public void Battle(Player player1, Player player2)
        {
            Console.WriteLine(player1.Name + " will go first!\n");
            while(player1.Pokemon.Hp >= 1 && player2.Pokemon.Hp >= 1)//neither is dead
            {
                if(player1.Pokemon.Hp >= 1 && player2.Pokemon.Hp >= 1) //neither is dead
                {
                    Attack(player1.Pokemon, player2.Pokemon);
                }
                if(player1.Pokemon.Hp >= 1 && player2.Pokemon.Hp >= 1) //neither is dead
                {
                    Attack(player2.Pokemon,player1.Pokemon);
                }
            }
            if(player1.Pokemon.Hp <= 0)
            {
                GameOver(player2 , player1);
            }
            else
            {
                GameOver(player1, player2);
            }
        }

        private void Attack(Pokemon attacker, Pokemon defender)
        {
            int attackBonus = attacker.AttackLevel;
            int defenseBonus = defender.DefenseLevel;
            var roll = d100.Roll();
            Move attackMove;

            Console.WriteLine(attacker.Name + ", please choose your move: \n");
            Console.WriteLine("[" + attacker.MoveSet.move1.moveType + "] " + attacker.MoveSet.move1.name);
            Console.WriteLine("[" + attacker.MoveSet.move2.moveType + "] " + attacker.MoveSet.move2.name);
            Console.WriteLine("[" + attacker.MoveSet.move3.moveType + "] " + attacker.MoveSet.move3.name);
            Console.WriteLine("[" + attacker.MoveSet.move4.moveType + "] " + attacker.MoveSet.move4.name);

			string choice;
			choice = ReadLine();
            while (choice != attacker.MoveSet.move1.name && choice != attacker.MoveSet.move2.name && choice != attacker.MoveSet.move3.name && choice != attacker.MoveSet.move4.name)
			{
				Console.WriteLine("You did not enter a valid move. Please type the name [case sensitive]");
				choice = ReadLine();
			}
            if(choice == attacker.MoveSet.move1.name)
            {
                attackMove = attacker.MoveSet.move1;
            }
            else if(choice == attacker.MoveSet.move2.name)
            {
                attackMove = attacker.MoveSet.move2;
            }
            else if(choice == attacker.MoveSet.move3.name)
            {
                attackMove = attacker.MoveSet.move3;
            }
            else
            {
                attackMove = attacker.MoveSet.move4;
            }

            if(roll <= attackMove.hitChance) // Not Missed
            {
                double totalDamage = (.5 * attackMove.maxDamage) + ((.5*attackMove.maxDamage)*(attackBonus/100));
                totalDamage = (totalDamage * .75) - ((totalDamage*.25)*(defenseBonus/100));

                Console.WriteLine(attacker.Name + " hit dealing " + totalDamage + " damage!");
                defender.Hp = defender.Hp - totalDamage;
                System.Threading.Thread.Sleep(1000);
                if (defender.Hp <= 0)
                    Console.WriteLine(defender.Name + " has 0 HP left!");
                else
                    Console.WriteLine(defender.Name + " has " + defender.Hp + " HP left!");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();

            }
            else
            {
                Console.WriteLine("The attack missed!");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }
        }

        private void PokemonBuild(Player player) 
        {
            WriteLine(player.Name + ", build your Pokemon!");
            WriteLine("Enter its name");
            player.Pokemon.Name = ReadLine();
            Console.Clear();
            WriteLine("Choose its type (number) \n1) Grass\n2) Fire\n3) Water\n4) Rock\n5) Mystic");
            int.TryParse(ReadLine(), out int type);
            switch(type)
            {
                case 1:
                    player.Pokemon.Type = "Grass";
                    break;
				case 2:
					player.Pokemon.Type = "Fire";
					break;
				case 3:
					player.Pokemon.Type = "Water";
					break;
				case 4:
					player.Pokemon.Type = "Rock";
					break;
                case 5:
                    player.Pokemon.Type = "Mystic";
                    break;
            }
            Console.Clear();
            WriteLine("Divide 100 points between Attack and Defense");
            WriteLine("Enter attack points (0 - 100)");
            int.TryParse(ReadLine(),out int attack);
            while(attack < 0 || attack > 100)
            {
                Console.WriteLine("Your entry is invalid, please enter a number between 0 and 100.");
                int.TryParse(ReadLine(), out attack);
            }
            Console.Clear();
            WriteLine("Enter defense points (0 - " + (100 - attack) + ")");
            int.TryParse(ReadLine(), out int defense);
            while (defense < 0 || defense > 100 - attack)
            {
                Console.WriteLine("Your entry is invalid, please enter a number between 0 and " + (100-attack) + ".");
                int.TryParse(ReadLine(), out defense);
            }
            player.Pokemon.AttackLevel = attack;
            player.Pokemon.DefenseLevel = defense;
            Console.Clear();
            AssignMove(player.Pokemon);
            
            Console.Clear();

            WriteLine(player.Name + "'s Pokemon Summary \n-------------- ");
            WriteLine("Name: " + player.Pokemon.Name);
            WriteLine("Type: " + player.Pokemon.Type);
            WriteLine("Attack: " + player.Pokemon.AttackLevel);
            WriteLine("Defense: " + player.Pokemon.DefenseLevel);
            WriteLine("Move 1: " + player.Pokemon.MoveSet.move1.name);
            WriteLine("Move 2: " + player.Pokemon.MoveSet.move2.name);
            WriteLine("Move 3: " + player.Pokemon.MoveSet.move3.name);
            WriteLine("Move 4: " + player.Pokemon.MoveSet.move4.name);
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

        private void GameOver(Player winner, Player loser)
        {
            Console.Clear();
            Console.WriteLine(winner.Name + " is the victor!");
            winner.Wins++;
            Console.WriteLine(winner.Name + " has " + winner.Wins + " victories!");
            Console.WriteLine("Would you like to play again?");
            var key = ReadLine();
            if (key == "y")
                Reset(winner, loser);
        }

        private void Reset(Player winner, Player loser)
        {
            Console.Clear();
            winner.Pokemon.Reset();
            loser.Pokemon.Reset();
            Console.WriteLine("The winner will build first");
            System.Threading.Thread.Sleep(1500);
            PokemonBuild(winner);
            PokemonBuild(loser);
            Battle(winner, loser);
        }
        #endregion
    }
}
