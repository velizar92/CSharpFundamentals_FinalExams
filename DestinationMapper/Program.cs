using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string placesPattern = @"(=|\/)[A-Z][[A-Za-z]{2,}\1"; //1. =Hawai=  2.  /Cyprus/
            int commonPoints = 0;
            List<string> clearMatchNames = new List<string>();

            string inputText = Console.ReadLine();

            MatchCollection matches = Regex.Matches(inputText, placesPattern);

            List<string> stringMatches = matches
                .Select(x => x.ToString())
                .ToList();



            foreach (var match in stringMatches)
            {
                string clearName = match.Substring(1, match.Length - 2); //cut clear name

                clearMatchNames.Add(clearName);

            }


            foreach (var match in clearMatchNames)
            {
                commonPoints += match.Length;
            }


            //Printing:

            Console.WriteLine("Destinations: " + string.Join(", ", clearMatchNames));
            Console.WriteLine("Travel Points: " + commonPoints);


        }
    }
}
