using System;
namespace Pokemon
{
    public class Pokemon
    {
        #region Member Variables
        private int hp;
        private int attackLevel;
        private int defenseLevel;
        private string name;
        private string type;
        private int wins;
        #endregion

        #region Member Methods
        public Pokemon()
        {

        }
        public int Hp { get { return hp; } set { hp = value; } }

        public int AttackLevel { get { return attackLevel; } set { attackLevel = value; } }

        public int DefenseLevel { get { return defenseLevel; } set { defenseLevel = value; } }

        public string Name { get { return name; } set { name = value; } }

        public string Type { get { return type; } set { type = value; } }

        public int Wins { get { return wins; } set { wins = value; }}
        #endregion

    }
}
