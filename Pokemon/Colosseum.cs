using System;
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

            Battle(player1, player2);
        }

        public void Battle(Pokemon player1, Pokemon player2)
        {
            
        }
        private void Attack(Pokemon attacker, Pokemon defender)
        {
            
        }

        private void PokemonBuild(Pokemon pokemon)
        {
            
        }
    }
}
