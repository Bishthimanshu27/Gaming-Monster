using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    class Shop
    {
        public Hero hero { get; set; }
        public List<Armor> armor { get; set; }
        public List<Potion> potion { get; set; }
        public List<Weapon> weapons { get; set; }
        public Game game { get; set; }


        public Shop(Game game, Hero hero)
        {
            this.weapons = new List<Weapon>();
            this.potion = new List<Potion>();
            this.armor = new List<Armor>();
            this.game = game;
            this.hero = hero;
            this.weapons.Add(new Weapon("Sword", 10, 2, 3));
            this.weapons.Add(new Weapon("Axe", 12, 3, 4));
            this.weapons.Add(new Weapon("Longsword", 20, 5, 7));

            this.armor.Add(new Armor("Wooden Armor", 10, 2, 3));
            this.armor.Add(new Armor("Metal Armor", 20, 5, 7));

            this.potion.Add(new Potion("Healing Potion", 10, 10, 5));

        }

        public void Menu()
        {
            Console.WriteLine("Welcome to My Shop What you want?");
            Console.WriteLine("1.Buy Item");
            Console.WriteLine("2.Sell Item");
            Console.WriteLine("3.Return to the game");
            var input = Console.ReadLine();
            if (input == "1")
            {
                this.ShowInventory();
            }
            else if (input == "2")
            {
                this.BuyFromUser();
            }
            else if (input == "3")
            {
                this.game.Main();
            }
        }

        public void ShowInventory()
        {

        }

        public void BuyFromUser()
        {

        }

    }
}