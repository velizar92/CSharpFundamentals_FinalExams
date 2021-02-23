using System;
using System.Collections.Generic;
using System.Linq;

namespace P_ratesWithClasses
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            List<Town> towns = new List<Town>();

            while (input != "Sail")
            {
                string[] inputArgs = input.Split("||").ToArray();
                string townName = inputArgs[0];
                long townPopulation = long.Parse(inputArgs[1]);
                double townGold = double.Parse(inputArgs[2]);

                if (!towns.Any(x => x.Name == townName))
                {
                    towns.Add(new Town(townName, townPopulation, townGold));
                }
                else
                {
                    Town currentTown = towns.FirstOrDefault(x => x.Name == townName);
                    currentTown.Population += townPopulation;
                    currentTown.Gold += townGold;
                }

                input = Console.ReadLine();

            }

            string secondInput = Console.ReadLine();

            while (secondInput != "End")
            {

                string[] secondInputArgs = secondInput.Split("=>").ToArray();

                string command = secondInputArgs[0];
                string townName = secondInputArgs[1];

                if (command == "Plunder")
                {
                    long people = long.Parse(secondInputArgs[2]);
                    double gold = double.Parse(secondInputArgs[3]);

                    Town town = towns.FirstOrDefault(x => x.Name == townName);

                    if (town == null)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{townName} plundered! {gold} gold stolen, {people} citizens killed.");

                        if (town.Population - people <= 0 || town.Gold - gold <= 0)
                        {
                            Console.WriteLine($"{townName} has been wiped off the map!");
                            towns.Remove(town);
                        }
                        else
                        {
                            town.Population -= people;
                            town.Gold -= gold;
                        }
                    }
                }

                else if (command == "Prosper")
                {

                    long gold = long.Parse(secondInputArgs[2]);
                    Town town = towns.FirstOrDefault(x => x.Name == townName);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        town.Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {townName} now has {town.Gold} gold.");
                    }
                }

                secondInput = Console.ReadLine();
            }



            //Printing:
            Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");

            foreach (Town town in towns.OrderByDescending(x => x.Gold).ThenBy(x => x.Name))
            {
                Console.WriteLine(town);
            }

        }


        class Town
        {

            public string Name { get; set; }
            public long Population { get; set; }
            public double Gold { get; set; }


            public Town(string _name, long _population, double _gold)
            {
                Name = _name;
                Population = _population;
                Gold = _gold;
            }

        
            public override string ToString()
            {
                return $"{Name} -> Population: {Population} citizens, Gold: {Gold} kg";
            }

        }

    }
}
