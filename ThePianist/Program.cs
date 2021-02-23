using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Piece> pieces = new List<Piece>();


            int numberPieces = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberPieces; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split('|').ToArray();

                string piece = inputArgs[0];
                string composer = inputArgs[1];
                string key = inputArgs[2];

                if(!pieces.Any(x => x.PieceName == piece))
                {
                    pieces.Add(new Piece(piece, composer, key));
                }
            }



            string inputLine = Console.ReadLine();

            while (inputLine != "Stop")
            {

                string[] inputArgs = inputLine.Split('|').ToArray();

                string command = inputArgs[0];
                string pieceName = inputArgs[1];

                if (command == "Add")
                {
                    string composer = inputArgs[2];
                    string key = inputArgs[3];
                    if (!pieces.Any(x => x.PieceName == pieceName))
                    {
                        pieces.Add(new Piece(pieceName, composer, key));
                        Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                    }
                }

                else if (command == "Remove")
                {

                    Piece currentPiece = pieces.FirstOrDefault(x => x.PieceName == pieceName);
                    if (currentPiece == null)
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                    else
                    {
                        pieces.Remove(currentPiece);
                        Console.WriteLine($"Successfully removed {pieceName}!");
                    }
                }

                else if (command == "ChangeKey")
                {
                    string newKey = inputArgs[2];

                    Piece currentPiece = pieces.FirstOrDefault(x => x.PieceName == pieceName);
                    if (currentPiece == null)
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                    else
                    {
                        currentPiece.Key = newKey;
                        Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
                    }
                }


                inputLine = Console.ReadLine();
            }


            //Printing: 

            foreach(Piece piece in pieces.OrderBy(x => x.PieceName).ThenBy(x => x.Composer))
            {
                Console.WriteLine(piece);
            }

        }


        class Piece
        {

            public string PieceName { get; set; }
            public string Composer { get; set; }
            public string Key { get; set; }


            public Piece(string _pieceName, string _composer, string _key)
            {
                PieceName = _pieceName;
                Composer = _composer;
                Key = _key;
            }

            //"{Piece} -> Composer: {composer}, Key: {key}"
            public override string ToString()
            {
                return $"{PieceName} -> Composer: {Composer}, Key: {Key}";
            }

        }



    }
}
