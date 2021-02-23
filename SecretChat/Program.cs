using System;
using System.Linq;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {

            string hiddenMessage = Console.ReadLine();

            string input = Console.ReadLine();

            while(input != "Reveal")
            {

                string[] inputArgs = input.Split(":|:").ToArray();
                string command = inputArgs[0];

                if(command == "InsertSpace")
                {
                    int index = int.Parse(inputArgs[1]);

                    hiddenMessage = hiddenMessage.Insert(index, " ");
                    Console.WriteLine(hiddenMessage);
                }

                else if(command == "Reverse")
                {
                    string subString = inputArgs[1];
                   
                    if (!hiddenMessage.Contains(subString))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        string reversedString = "";
                        int index = hiddenMessage.IndexOf(subString);
                        string cutString = hiddenMessage.Substring(index, subString.Length);
                        char[] cutCharArray = cutString.ToCharArray();
                        Array.Reverse(cutCharArray);
                        for (int i = 0; i < cutCharArray.Length; i++)
                        {
                            reversedString += cutCharArray[i];
                        }

                        hiddenMessage = hiddenMessage.Remove(index, subString.Length);
                        hiddenMessage = hiddenMessage + reversedString;
                        Console.WriteLine(hiddenMessage);
                    }
                }

                else if(command == "ChangeAll")
                {
                    string subString = inputArgs[1];
                    string replacement = inputArgs[2];
                    if (hiddenMessage.Contains(subString))
                    {
                        hiddenMessage = hiddenMessage.Replace(subString, replacement);
                        Console.WriteLine(hiddenMessage);
                    }
                }

                input = Console.ReadLine();

            }

            Console.WriteLine($"You have a new text message: {hiddenMessage}");
        }
    }
}
