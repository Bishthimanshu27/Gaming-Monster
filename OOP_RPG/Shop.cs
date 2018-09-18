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
        public List<Armor> armors { get; set; }
        public List<Potion> potions { get; set; }
        public List<Weapon> weapons { get; set; }
        public Game game { get; set; }


        public Shop(Game game, Hero hero)
        {
            this.weapons = new List<Weapon>();
            this.potions = new List<Potion>();
            this.armors = new List<Armor>();
            this.game = game;
            this.hero = hero;
            this.weapons.Add(new Weapon("Sword", 11, 20, 30));
            this.weapons.Add(new Weapon("Axe", 12, 3, 4));
            this.weapons.Add(new Weapon("Longsword", 20, 5, 7));

            this.armors.Add(new Armor("Wooden Armor", 10, 2, 3));
            this.armors.Add(new Armor("Metal Armor", 20, 5, 7));

            this.potions.Add(new Potion("Healing Potion", 10, 10, 5));

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
            Console.WriteLine(" What would you like to buy?");
            Console.WriteLine("1. Weapon");
            Console.WriteLine("2. Armor");
            Console.WriteLine("3. Potion");
            Console.WriteLine("4. Return");

            var buyitem = Console.ReadLine();

            if (buyitem == "1")
            {
                Console.WriteLine("Enter Number of the item");
                for (int i = 0; i < weapons.Count; i++)
                {
                    Console.WriteLine((i + 1) + " " + weapons[i].Name + " $" + weapons[i].OriginalValue);
                }
                var inputvalue = Console.ReadLine();

                Sell(Convert.ToInt32(inputvalue), "weapons");
            }

            else if (buyitem == "2")
            {
                Console.WriteLine("Enter Number of the item");
                for (int i = 0; i < armors.Count; i++)
                {
                    Console.WriteLine((i + 1) + " " + armors[i].Name + " $" + armors[i].OriginalValue);
                }
                var inputvalue = Console.ReadLine();

                Sell(Convert.ToInt32(inputvalue), "armor");
            }

            else if (buyitem == "3")
            {
                Console.WriteLine("Enter Number of the item");
                for (int i = 0; i < potions.Count; i++)
                {
                    Console.WriteLine((i + 1) + " " + potions[i].Name + " $" + potions[i].OriginalValue);
                }
                var inputvalue = Console.ReadLine();

                Sell(Convert.ToInt32(inputvalue), "potion");
            }


        }

        public void Sell(int index, string itemType)
        {
            if (itemType == "weapons")
            {
                var weapon = weapons[index - 1];

                if (this.game.hero.Gold >= weapon.OriginalValue)
                {
                    this.game.hero.Gold = this.game.hero.Gold - weapon.OriginalValue;

                    this.game.hero.WeaponsBag.Add(weapon);
                }
                else
                {
                    Console.WriteLine("Out of Gold");
                }
                this.Menu();
            }

            else if (itemType == "armor")
            {
                var armor = armors[index - 1];

                if (game.hero.Gold >= armor.OriginalValue)
                {
                    this.game.hero.Gold = this.game.hero.Gold - armor.OriginalValue;

                    this.game.hero.ArmorsBag.Add(armor);
                }
                else
                {
                    Console.WriteLine("Out of Gold");
                }
                this.Menu();
            }

            else if (itemType == "potion")
            {
                var potion = potions[index - 1];

                if (game.hero.Gold >= potion.OriginalValue)
                {
                    this.game.hero.Gold = this.game.hero.Gold - potion.OriginalValue;

                    this.game.hero.PotionsBag.Add(potion);
                }
                else
                {
                    Console.WriteLine("Out of Gold");
                    this.Menu();
                }
                
            }    



            }

        public void BuyFromUser()
        {
            Console.WriteLine(" What would you like to sell?");
            Console.WriteLine("1. Weapon");
            Console.WriteLine("2. Armor");
            Console.WriteLine("3. Potion");
            Console.WriteLine("4. Main menu");

            var input = Console.ReadLine();
            if (input == "1")
            {
                if (this.hero.WeaponsBag.Count > 0)
                {
                    Console.WriteLine("Enter Number of the item Or press r to return menu");
                    for (int i = 0; i < this.hero.WeaponsBag.Count; i++)
                    {
                        Console.WriteLine((i + 1) + " " + this.hero.WeaponsBag[i].Name + " $" + this.hero.WeaponsBag[i].ResellValue);
                    }
                    var inputNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (inputNumber < this.hero.WeaponsBag.Count)
                    {
                        this.sell2(inputNumber, "weapons");
                    }
                    else
                    {
                        this.Menu();
                    }
                }
                else
                {
                    Console.WriteLine("You don't have any weapons to sell");
                    this.Menu();
                }

            }
            else if (input == "2")
            {
                if (this.hero.ArmorsBag.Count > 0)
                {
                    Console.WriteLine("Enter Number of the item Or press r to return menu");
                    for (int i = 0; i < this.hero.ArmorsBag.Count; i++)
                    {
                        Console.WriteLine((i + 1) + " " + this.hero.ArmorsBag[i].Name + " $" + this.hero.ArmorsBag[i].ResellValue);
                    }
                    var inputNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (inputNumber < this.hero.ArmorsBag.Count)
                    {
                        this.sell2(inputNumber, "armor");
                    }
                    else
                    {
                        this.Menu();
                    }
                }
                else
                {
                    Console.WriteLine("You don't have any Armors to sell");
                    this.Menu();
                }
            }
            else if (input == "3")
            {
                if (this.hero.PotionsBag.Count > 0)
                {
                    Console.WriteLine("Enter Number of the item Or press r to return menu");
                    for (int i = 0; i < this.hero.PotionsBag.Count; i++)
                    {
                        Console.WriteLine((i + 1) + " " + this.hero.PotionsBag[i].Name + " $" + this.hero.PotionsBag[i].ResellValue);
                    }
                    var inputNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (inputNumber < this.hero.PotionsBag.Count)
                    {
                        this.sell2(inputNumber, "potion");
                    }
                    else
                    {
                        this.Menu();
                    }
                }
                else
                {
                    Console.WriteLine("You don't have any Potion to sell");
                    this.Menu();
                }
            }
            else
            {
                this.Menu();
            }
        }

        public void sell2(int inputNumber, string bag)
        {
            if (bag == "weapons")
            {
                this.hero.Gold += this.hero.WeaponsBag[inputNumber].ResellValue;
                this.hero.WeaponsBag.RemoveAt(inputNumber);
                Console.WriteLine("You successfully sold the weapon");
                this.Menu();
            }
            else if (bag == "armor")
            {
                this.hero.Gold += this.hero.ArmorsBag[inputNumber].ResellValue;
                this.hero.ArmorsBag.RemoveAt(inputNumber);
                Console.WriteLine("You successfully sold the Armor");
                this.Menu();
            }
            else
            {
                this.hero.Gold += this.hero.PotionsBag[inputNumber].ResellValue;
                this.hero.PotionsBag.RemoveAt(inputNumber);
                Console.WriteLine("You successfully sold the Potion");
                this.Menu();
            }
        }
    }
}

    