using System;
namespace Pokemon
{
    public class Pokemon
    {
        #region Member Variables
        private double hp;
        private int attackLevel;
        private int defenseLevel;
        private string name;
        private string type;
        private int wins;
        private MoveSet moveSet;
        #endregion

        #region Member Methods
        public Pokemon()
        {
            Hp = 150;
            moveSet = new MoveSet();
        }
        public double Hp { get { return hp; } set { hp = value; } }

        public int AttackLevel { get { return attackLevel; } set { attackLevel = value; } }

        public int DefenseLevel { get { return defenseLevel; } set { defenseLevel = value; } }

        public string Name { get { return name; } set { name = value; } }

        public string Type { get { return type; } set { type = value; } }

        public int Wins { get { return wins; } set { wins = value; }}

        public MoveSet MoveSet { get { return moveSet; } set { moveSet = value; } }

        public void Reset()
        {
            hp = 150;
            attackLevel = 0;
            defenseLevel = 0;
            moveSet = new MoveSet();
        }
        #endregion

    }
}
