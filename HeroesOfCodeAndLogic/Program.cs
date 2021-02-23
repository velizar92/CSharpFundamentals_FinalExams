using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogic
{
    class Program
    {
        static void Main(string[] args)
        {

            var heroHp = new Dictionary<string, int>();
            var heroMp = new Dictionary<string, int>();
            int hpMax = 100;
            int manaMax = 200;

            int n = int.Parse(Console.ReadLine());

            //For heroes:
            for (int i = 0; i < n; i++)
            {

                string[] heroTokens = Console.ReadLine().Split().ToArray();

                string heroName = heroTokens[0];
                int hp = int.Parse(heroTokens[1]);
                int mp = int.Parse(heroTokens[2]);


                heroHp[heroName] = hp > hpMax ? hpMax : hp;
                heroMp[heroName] = mp > manaMax ? manaMax : mp;

            }

            string command = Console.ReadLine();

            while (command != "End")
            {

                string[] cmndArgs = command.Split(" - ");
                string comnd = cmndArgs[0];
                string heroName = cmndArgs[1];

                if (comnd == "CastSpell")
                {
                    int mpNeeded = int.Parse(cmndArgs[2]);
                    string spellName = cmndArgs[3];

                    if (heroMp[heroName] >= mpNeeded)
                    {
                        heroMp[heroName] -= mpNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroMp[heroName]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (comnd == "TakeDamage")
                {
                    int damage = int.Parse(cmndArgs[2]);
                    string attacker = cmndArgs[3];

                    heroHp[heroName] -= damage;

                    if (heroHp[heroName] > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroHp[heroName]} HP left!");
                    }
                    else
                    {
                        heroHp.Remove(heroName);
                        heroMp.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }

                else if (comnd == "Recharge")
                {
                    int amount = int.Parse(cmndArgs[2]);
                    int mpBefore = heroMp[heroName];

                    heroMp[heroName] += amount;

                    if (heroMp[heroName] > manaMax)
                    {
                        heroMp[heroName] = manaMax;
                    }


                    int mpAfter = heroMp[heroName];
                    int totalAmount = mpAfter - mpBefore;

                    Console.WriteLine($"{heroName} recharged for {totalAmount} MP!");
                }

                 


                command = Console.ReadLine();
            }

            foreach(var hero in heroHp.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"HP: {hero.Value}");
                Console.WriteLine($"MP: {heroMp[hero.Key]}");            
            }




        }
    }
}
