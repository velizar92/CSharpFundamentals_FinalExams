using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfTheCodeAndLogicWithClasses
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Hero> heroes = new List<Hero>();
            int numberOfHeroes = int.Parse(Console.ReadLine());
            int maxHealth = 100;
            int maxMana = 200;

            for (int i = 0; i < numberOfHeroes; i++)
            {

                string line = Console.ReadLine();

                string[] lineArgs = line.Split(' ').ToArray();

                string heroName = lineArgs[0];
                int health = int.Parse(lineArgs[1]);
                int mana = int.Parse(lineArgs[2]);

                if(!heroes.Any(x => x.HeroName == heroName))
                {
                    heroes.Add(new Hero(heroName, health, mana));
                }

            }

            string cmdLine = Console.ReadLine();

            while(cmdLine != "End")
            {

                string[] cmdLineArgs = cmdLine.Split(" - ").ToArray();
                string command = cmdLineArgs[0];
                string heroName = cmdLineArgs[1];

                if(command == "CastSpell")
                {
                    int manaNeeded = int.Parse(cmdLineArgs[2]);
                    string spellName = cmdLineArgs[3];

                    Hero hero = heroes.FirstOrDefault(x => x.HeroName == heroName);
                    //if(hero != null)
                   // {
                        if(hero.HeroMana - manaNeeded < 0)
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {hero.HeroMana - manaNeeded} MP!");
                            hero.HeroMana -= manaNeeded;
                        }
                   // }
                }

                else if(command == "TakeDamage")
                {
                    int damage = int.Parse(cmdLineArgs[2]);
                    string attacker = cmdLineArgs[3];

                    Hero hero = heroes.FirstOrDefault(x => x.HeroName == heroName);
                    hero.HeroHealth -= damage;

                    if(hero.HeroHealth > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {hero.HeroHealth} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.Remove(hero);
                    }
                }

                else if(command == "Recharge")
                {
                    int amount = int.Parse(cmdLineArgs[2]);

                    Hero hero = heroes.FirstOrDefault(x => x.HeroName == heroName);
                    int previousMana = hero.HeroMana;
                    hero.HeroMana += amount;

                    if(hero.HeroMana > maxMana)
                    {
                        hero.HeroMana = maxMana;
                    }

                    int afterMana = hero.HeroMana;
                    int rechargedMana = afterMana - previousMana;

                    Console.WriteLine($"{heroName} recharged for {rechargedMana} MP!");

                }
                else if(command == "Heal")
                {
                    int amount = int.Parse(cmdLineArgs[2]);

                    Hero hero = heroes.FirstOrDefault(x => x.HeroName == heroName);
                    int previousHealth = hero.HeroHealth;
                    hero.HeroHealth += amount;

                    if (hero.HeroHealth > maxHealth)
                    {
                        hero.HeroHealth = maxHealth;
                    }

                    int afterHealth = hero.HeroHealth;
                    int healedHealth = afterHealth - previousHealth;

                    Console.WriteLine($"{heroName} healed for {healedHealth} HP!");
                }


                cmdLine = Console.ReadLine();
            }



            //Printing: 
            foreach(Hero hero in heroes.OrderByDescending(x => x.HeroHealth).ThenBy(x => x.HeroName))
            {
                Console.WriteLine(hero);
            }
        }


        class Hero
        {

            public string HeroName { get; set; }

            public int HeroHealth { get; set; }

            public int HeroMana { get; set; }


            public Hero(string _heroName, int _heroHealth, int _heroMana)
            {
                HeroName = _heroName;
                HeroHealth = _heroHealth;
                HeroMana = _heroMana;
            }


            public override string ToString()
            {
                string heroName = HeroName + "\n";
                string HP = "  HP: " + HeroHealth.ToString() + "\n";
                string MP = "  MP: " + HeroMana.ToString();

                return heroName + HP + MP;
            }



        }
    }
}
