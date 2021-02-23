using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {

            string password = Console.ReadLine();
            string command = Console.ReadLine();

            while(command != "Done")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(command == "TakeOdd")
                {
                    List<char> textSymbols = password.ToList();
                    string newString = "";
                    for (int i = 0; i < textSymbols.Count; i++)
                    {
                        if(i % 2 != 0)
                        {
                            newString += textSymbols[i];
                        }
                    }
                    password = newString;
                    Console.WriteLine(password);                   
                }
                else
                {
                    if (tokens[0] == "Cut")
                    {
                        int index = int.Parse(tokens[1]);
                        int length = int.Parse(tokens[2]);

                        password = password
                            .Remove(index, length);                            
                        Console.WriteLine(password);
                    }

                    else if (tokens[0] == "Substitute")
                    {
                        string substring = tokens[1];
                        string substitute = tokens[2];

                        if (password.Contains(substring))
                        {
                            password = password.Replace(substring, substitute);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                    }
                }

                
                command = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");

        }
    }
}
