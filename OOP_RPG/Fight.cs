using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Fight
    {
        List<Monster> Monsters { get; set; }
        public Game game { get; set; }
        public Hero hero { get; set; }
        public Monster monster { get; set; }

        public Fight(Hero hero, Game game) {
            this.Monsters = new List<Monster>();
            this.hero = hero;
            this.game = game;
            this.AddMonster("Squid", 9, 8, 20);
            this.AddMonster("moli", 15, 18, 29);
            this.AddMonster("yoli", 7, 38, 18);
            this.AddMonster("doli", 19, 11, 14);

        }
        
        public void AddMonster(string name, int strength, int defense, int hp) {
            var monster = new Monster(name,strength,defense,hp,hp);
            monster.Name = name;
            monster.Strength = strength;
            monster.Defense = defense;
            monster.OriginalHP = hp;
            monster.CurrentHP = hp;
            this.Monsters.Add(monster);
        }
        

        public void Start() {
            var Random = this.Monsters.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            var LastMonster = this.Monsters.Last();
            var SecondMonster = this.Monsters[1];
            var lessHpEnemy = (from p in this.Monsters select p.CurrentHP < 20).FirstOrDefault();
            var lessStrengthEnemy = (from p in this.Monsters select p.Strength >= 11).FirstOrDefault();
            var enemy = Random;
            Console.WriteLine("You've1" +
                " encountered a " + enemy.Name + "! " + enemy.Strength + " Strength/" + enemy.Defense + " Defense/" + 
            enemy.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            var input = Console.ReadLine();
            if (input == "1") {
                this.HeroTurn(enemy);
            }
            else { 
                this.game.Main();
            }
        }
        
        public void HeroTurn(Monster monster){
           var enemy = monster;
           var compare = hero.Strength - enemy.Defense;
           int damage;
           
           if(compare <= 0) {
               damage = 1;
               enemy.CurrentHP -= damage;
           }
           else{
               damage = compare;
               enemy.CurrentHP -= damage;
           }
           Console.WriteLine("You did " + damage + " damage!");
           
           if(enemy.CurrentHP <= 0){
               this.Win(enemy);
           }
           else
           {
               this.MonsterTurn(enemy);
           }
           
        }
        
        public void MonsterTurn(Monster monster){
           var enemy = monster;
           int damage;
           var compare = enemy.Strength - hero.Defense;
           if(compare <= 0) {
               damage = 1;
               hero.CurrentHP -= damage;
           }
           else{
               damage = compare;
               hero.CurrentHP -= damage;
           }
           Console.WriteLine(enemy.Name + " does " + damage + " damage!");
           if(hero.CurrentHP <= 0){
               this.Lose();
           }
           else
           {
               this.Start();
           }
        }
        
        public void Win(Monster monster) {
            hero.Gold = monster.Gold;
            var enemy = monster;
            Console.WriteLine(enemy.Name + " has been defeated! You win the battle!");
            game.Main();
        }
        
        public void Lose() {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }
        
    }
    
}