using System;
namespace Pokemon
{
    public class Move
    {
        public Move(string type)
        {
            Initialize(type);
        }
        public string name;
        public string moveType;
        public int hitChance;
        public int maxDamage;

        private void Initialize(string type)
        {
            
        }
    }
}
