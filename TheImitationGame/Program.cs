using System;
using System.Linq;

namespace TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {

            string message = Console.ReadLine();

            string input = Console.ReadLine();

            while(input != "Decode")
            {

                string[] inputTokens = input.Split('|').ToArray();

                string command = inputTokens[0];

                if(command == "Move")
                {
                    int numLetters = int.Parse(inputTokens[1]);

                    string movedString = message.Substring(0, numLetters);
                    message = message.Remove(0, numLetters);
                    message += movedString;   
                }

                else if(command == "Insert")
                {
                    int index = int.Parse(inputTokens[1]);
                    string value = inputTokens[2];

                    message = message.Insert(index, value);
                }


                else if(command == "ChangeAll")
                {
                    string subString = inputTokens[1];
                    string replacement = inputTokens[2];

                    if(message.Contains(subString))
                    {
                        message = message.Replace(subString, replacement);
                    } 
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");


        }
    }
}
