using System;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {

            int barcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < barcodes; i++)
            {

                string barcode = Console.ReadLine();
                CheckBarcode(barcode);
            }

        }


        public static void CheckBarcode(string _barcode)
        {
            string barcodePattern = @"@#+[A-Z][A-Za-z\d]{4,}[A-Z]@#+";  //Mathces: @#FreshFisH@#, @###Brea0D@###, @##Che46sE@##, @##Che46sE@##
            string productGroup = "";


            Regex barcodeRegex = new Regex(barcodePattern);

            Match match = barcodeRegex.Match(_barcode);
            string stringMatch = match.Value.ToString();

            if(match.Success)
            {
                productGroup = CheckForDigit(stringMatch);
                Console.WriteLine($"Product group: {productGroup}");
                productGroup = "";
            }
            else
            {
                Console.WriteLine("Invalid barcode");
            }
        }


        public static string CheckForDigit(string _matchedBarcode)
        {
            string productGroup = "";

            for (int i = 0; i < _matchedBarcode.Length; i++)
            {
                if (Char.IsDigit(_matchedBarcode[i]))
                {
                    productGroup += _matchedBarcode[i];
                }
            }
            if(productGroup == "")
            {
                productGroup = "00";
            }
            return productGroup;
        }


    }
}
