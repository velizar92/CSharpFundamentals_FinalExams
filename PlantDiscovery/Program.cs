using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();
            string inputLine = "";

            for (int i = 0; i < n; i++)
            {

                inputLine = Console.ReadLine();
                string[] inputArgs = inputLine.Split("<->", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string plantName = inputArgs[0];
                int plantRarity = int.Parse(inputArgs[1]);

                if (!plants.Any(x => x.Name == plantName))
                {
                    plants.Add(new Plant(plantName, plantRarity));
                }
                else
                {
                    Plant currentPlant = plants.FirstOrDefault(x => x.Name == plantName);
                    currentPlant.Rarity += plantRarity;
                }
            }

            string command = Console.ReadLine();

            while (command != "Exhibition")
            {

                string[] commandArgs = command.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmnd = commandArgs[0].Trim();
                string secondCmndPart = commandArgs[1];
                string[] secondCmndArgs = secondCmndPart.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string plantName = secondCmndArgs[0].Trim();


                Plant currentPlantTest = plants.FirstOrDefault(p => p.Name == plantName);

                //Check if exists in the plant:

                if (currentPlantTest == null)
                {
                    Console.WriteLine("error");
                    command = Console.ReadLine();
                    continue;
                }


                if (cmnd == "Rate")
                {
                    string srating = secondCmndArgs[1].Trim();
                    int rating = int.Parse(srating);
                    Plant currentPlant = plants.FirstOrDefault(x => x.Name == plantName);
                    currentPlant.ratings.Add(rating);
                }

                else if (cmnd == "Update")
                {
                    string snewRariry = secondCmndArgs[1].Trim();
                    int newRarity = int.Parse(snewRariry);
                    Plant currentPlant = plants.FirstOrDefault(x => x.Name == plantName);
                    currentPlant.Rarity = newRarity;
                }

                else if (cmnd == "Reset")
                {
                    Plant currentPlant = plants.FirstOrDefault(x => x.Name == plantName);
                    if (currentPlant.ratings.Count > 0)
                    {
                        currentPlant.ratings.Clear();
                    }
                }



                command = Console.ReadLine();

            }


            Console.WriteLine("Plants for the exhibition:");

            foreach (Plant plant in plants.OrderByDescending(x => x.Rarity).ThenByDescending(x => x.AverageRating))
            {
                Console.WriteLine(plant);
            }

        }




        class Plant
        {

            public string Name { get; set; }

            public int Rarity { get; set; }

            public double AverageRating
            {

                get
                {
                    if (ratings.Count == 0)
                    {
                        return 0.00;
                    }
                    else if (ratings.Count == 1)
                    {
                        return ratings[0];
                    }
                    else
                    {
                        return ratings.Sum() / ratings.Count;
                    }
                }

                set { }
            }


            public List<double> ratings = new List<double>();

            public Plant(string _name, int _rarity)
            {
                Name = _name;
                Rarity = _rarity;
            }

            public override string ToString()
            {

                return $"- {Name}; Rarity: {Rarity}; Rating: {AverageRating:f2}";
            }




        }
    }
}
