using System;
using System.Collections;
using System.Collections.Generic;

namespace Pokemon
{
    public class MoveIndex
    {
        public MoveIndex()
        {
            Initialize();
        }
        //List<string> ChooseableMoves = new List<string>();
        List<Move> Moves = new List<Move>();
        private void Initialize()
        {
            Moves.Add(new Move() {name = "Swipe", moveType = "Physical", group = "all", special = false, hitChance = 80, maxDamage = 30});
            Moves.Add(new Move() { name = "Pounce", moveType = "Physical", group = "all", special = false, hitChance = 55, maxDamage = 45 });
            Moves.Add(new Move() { name = "FireBall", moveType = "Element", group = "Fire", special = false, hitChance = 70, maxDamage = 27 });
            Moves.Add(new Move() { name = "Napalm", moveType = "Element", group = "Fire", special = true, hitChance = 40, maxDamage = 80 });
            Moves.Add(new Move() { name = "Sprinkler", moveType = "Element", group = "Water", special = true, hitChance = 90, maxDamage = 27 });
            Moves.Add(new Move() { name = "Hail", moveType = "Element", group = "Water", special = true, hitChance = 100, maxDamage = 80 });
            Moves.Add(new Move() {name = "Defend", moveType = "Defense", group = "all", special = true, hitChance = 100, maxDamage = 0});
        }
        public List<Move> GetChooseableMoves(string userGroup)
        {
            List<Move> ChooseableMoves = new List<Move>();
            foreach (Move move in Moves)
                if (move.group == "all" || move.group == userGroup)
                    ChooseableMoves.Add(move);

            return ChooseableMoves;
        }
    }
    public class SpecialMoveIndex
    {
        public SpecialMoveIndex()
        {
            
        }
    }


}