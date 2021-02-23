using System;
using System.Linq;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {

            string activationKey = Console.ReadLine();
            string command = "";


            //Main logic:
            while(true)
            {

                command = Console.ReadLine();
                if(command == "Generate")
                {
                    break;
                }
                else
                {
                    string[] commandParts = command.Split(">>>").ToArray();


                    if(commandParts[0] == "Slice")
                    {
                        int startIndex = int.Parse(commandParts[1]);
                        int endIndex = int.Parse(commandParts[2]);

                        int countRemovedCharacters = endIndex - startIndex;

                        activationKey = activationKey.Remove(startIndex, countRemovedCharacters);

                        Console.WriteLine(activationKey); //Activation key after remove manipulation

                    }

                    else if(commandParts[0] == "Flip")
                    {
                        int startIndex = int.Parse(commandParts[2]);
                        int endIndex = int.Parse(commandParts[3]);

                        int length = endIndex - startIndex;

                        string subsString = activationKey.Substring(startIndex, length);

                        if (commandParts[1] == "Upper")
                        {
                            string upperSubString = subsString.ToUpper();
                            activationKey = activationKey.Replace(subsString, upperSubString);

                            Console.WriteLine(activationKey);
                        }

                        else if(commandParts[1] == "Lower")
                        {
                            string lowerSubString = subsString.ToLower();
                            activationKey = activationKey.Replace(subsString, lowerSubString);

                            Console.WriteLine(activationKey);
                        }
                    }

                    else if(commandParts[0] == "Contains")
                    {
                        string subString = commandParts[1];
                        if (activationKey.Contains(subString))
                        {
                            Console.WriteLine($"{activationKey} contains {subString}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                    }
                }
            }


            //Output:

            Console.WriteLine($"Your activation key is: {activationKey}");

        }
    }
}
