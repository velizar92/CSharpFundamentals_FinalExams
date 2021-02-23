using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberPattern = @"\d";                               //found all numbers in the text
            string emojiPattern = @"(\:{2}|\*{2})[A-Z][a-z]{2,}\1";     //found all emojis in the text

            Regex numReg = new Regex(numberPattern);
            Regex emojiReg = new Regex(emojiPattern);

            string text = Console.ReadLine();                           //text input
            int coolThreshold = 1;

            numReg.Matches(text)
                .Select(m => m.Value)
                .Select(int.Parse)
                .ToList()
                .ForEach(x => coolThreshold *= x);

            var matches = emojiReg.Matches(text);
            int totalEmojis = matches.Count;

            List<string> coolEmojis = new List<string>();

            foreach(Match match in matches)
            {
                long coolIndex = match.Value
                    .Substring(2, match.Value.Length - 4)
                    .ToCharArray()
                    .Sum(x => (int)x);

                if(coolIndex > coolThreshold)
                {
                    coolEmojis.Add(match.Value);
                }
            }

            //Printing: 

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{totalEmojis} emojis found in the text. The cool ones are:");

           
            foreach(var emoji in coolEmojis)
            {
                Console.WriteLine(emoji);
            }



        }
    }
}
