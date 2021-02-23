using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AddAstra
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();
            int totalCalories = 0;
            int days = 0; //totalKilos / 2000kcal
            List<string> foodItems = new List<string>();

            string foodPattern = @"(#|\|)([A-Za-z\s]+)\1(\d{2,2}/\d{2,2}/\d{2,2})\1(\d{1,5})\1"; //#Bread#19/03/21#4000№ //|Apples|08/10/20|200| //|Carrots|06/08/20|500| -> matches
            MatchCollection matches = Regex.Matches(text, foodPattern);

            foreach(Match match in matches)
            {
                var calories = match.Groups[4].Value;
                int intCalories = int.Parse(calories);
                totalCalories += intCalories;

                //"Item: {item name}, Best before: {expiration date}, Nutrition: {calories}"
                string foodItem = $"Item: {match.Groups[2].Value}, Best before: {match.Groups[3].Value}, Nutrition: {match.Groups[4].Value}";
                foodItems.Add(foodItem);
            }

            days = totalCalories / 2000;


            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach(var item in foodItems)
            {
                Console.WriteLine(item);
            }

        }
    }
}
