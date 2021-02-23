using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeed3
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string inputLine = Console.ReadLine();

                string[] inputArgs = inputLine.Split('|').ToArray();

                string carName = inputArgs[0];
                double mileage = double.Parse(inputArgs[1]);
                double fuel = double.Parse(inputArgs[2]);
                
                if(!cars.Any(x => x.Name == carName))
                {
                    cars.Add(new Car(carName, mileage, fuel)); 
                }            
            }

            string input = Console.ReadLine();

            while(input != "Stop")
            {

                string[] inputTokens = input.Split(" : ").ToArray();
                string command = inputTokens[0];
                string carName = inputTokens[1];

                if (command == "Drive")
                {
                    double carDistance = double.Parse(inputTokens[2]); 
                    double carFuel = double.Parse(inputTokens[3]);

                    Car currentCar = cars.FirstOrDefault(x => x.Name == carName);

                    if(currentCar.Fuel - carFuel < 0)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        currentCar.Fuel = currentCar.Fuel - carFuel;
                        currentCar.Mileage = currentCar.Mileage + carDistance;
                        Console.WriteLine($"{carName} driven for {carDistance} kilometers. {carFuel} liters of fuel consumed.");
                        if (currentCar.Mileage >= 100000)
                        {
                            cars.Remove(currentCar);
                            Console.WriteLine($"Time to sell the {carName}!");
                        }
                     
                    }
                     
                }

                else if (command == "Refuel")
                {
                    double carFuel = double.Parse(inputTokens[2]);
                    Car currentCar = cars.FirstOrDefault(x => x.Name == carName);
                    double previousFuel = currentCar.Fuel;
                    currentCar.Fuel = currentCar.Fuel + carFuel;

                    if (currentCar.Fuel > 75.00)
                    {
                        currentCar.Fuel = 75.00; 
                    }


                    double afterFuel = currentCar.Fuel;
                    double totalFuel = afterFuel - previousFuel;                  
                    Console.WriteLine($"{carName} refueled with {totalFuel} liters");
                }

                else if (command == "Revert")
                {
                    double kilometers = double.Parse(inputTokens[2]);
                    Car currentCar = cars.FirstOrDefault(x => x.Name == carName);

                    currentCar.Mileage -= kilometers;
                    if(currentCar.Mileage < 10000)
                    {
                        currentCar.Mileage = 10000;
                    }
                    else
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                }


                input = Console.ReadLine();

            }

            //Printing:
            foreach(Car car in cars.OrderByDescending(x => x.Mileage).ThenBy(x => x.Name))
            {
                Console.WriteLine(car);
            }


        }


        class Car
        {
            public string Name { get; set; }
            public double Mileage { get; set; }
            public double Fuel { get; set; }

            public Car(string _name, double _mileage, double _fuel) 
            {
                Name = _name;
                Mileage = _mileage;
                Fuel = _fuel;
            }


            public override string ToString()
            {
                return $"{Name} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
            }


        }
    }
}
