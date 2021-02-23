using System;
using System.Linq;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();
            string input = Console.ReadLine();

            while(input != "Travel")
            {

                string[] inputArgs = input.Split(':').ToArray();

                if(inputArgs[0] == "Add Stop")
                {
                    int index = int.Parse(inputArgs[1]);
                    string valueString = inputArgs[2];

                    //If the index is valid
                    if(index >= 0 && index <= text.Length)
                    {
                        text = text.Insert(index, valueString);
                    }
                    Console.WriteLine(text);
                }

                else if(inputArgs[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(inputArgs[1]);
                    int endIndex = int.Parse(inputArgs[2]);

                    if((startIndex >= 0 && startIndex < text.Length) && (endIndex > 0 && endIndex < text.Length))
                    {
                        text = text.Remove(startIndex, (endIndex - startIndex)+1);
                    }
                    Console.WriteLine(text);
                }

                else if(inputArgs[0] == "Switch")
                {
                    string oldString = inputArgs[1];
                    string newString = inputArgs[2];

                    if(text.Contains(oldString))
                    {
                        text = text.Replace(oldString, newString);
                    }
                    Console.WriteLine(text);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {text}");




        }
    }
}
