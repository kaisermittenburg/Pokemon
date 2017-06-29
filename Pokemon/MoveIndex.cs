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

        List<Move> Moves = new List<Move>();
        private void Initialize()
        {
            Moves.Add(new Move() {name = "Swipe", moveType = "Physical", group = "all", special = false, hitChance = 80, maxDamage = 18});
            Moves.Add(new Move() { name = "Pounce", moveType = "Physical", group = "all", special = false, hitChance = 55, maxDamage = 29 });
            Moves.Add(new Move() { name = "FireBall", moveType = "Element", group = "Fire", special = false, hitChance = 70, maxDamage = 20 });
            Moves.Add(new Move() { name = "Napalm", moveType = "Element", group = "Fire", special = true, hitChance = 35, maxDamage = 35 });
            Moves.Add(new Move() { name = "Sprinkler", moveType = "Element", group = "Water", special = true, hitChance = 90, maxDamage = 15 });
            Moves.Add(new Move() { name = "Hail", moveType = "Element", group = "Water", special = true, hitChance = 100, maxDamage = 15 });
            Moves.Add(new Move() {name = "Defend", moveType = "Defense", group = "all", special = true, hitChance = 100, maxDamage = 0});
        }
    }
    public class SpecialMoveIndex
    {
        public SpecialMoveIndex()
        {
            
        }
    }


}