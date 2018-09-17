using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Monster
    {
        private int hp1;
        private int hp2;

        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public int Gold { get; set; }
        public int Speed { get; set; }


        public Monster(string name, int strength, int defense, int originalHP, int currentHP, int speed)
        {
            this.Name = name;
            this.Strength = strength;
            this.Defense = defense;
            this.OriginalHP = originalHP;
            this.CurrentHP = currentHP;
            this.Gold = 5;
            this.Speed = speed;
        }

        public Monster(string name, int strength, int defense, int hp1, int hp2)
        {
            Name = name;
            Strength = strength;
            Defense = defense;
            this.hp1 = hp1;
            this.hp2 = hp2;
        }
    }
}