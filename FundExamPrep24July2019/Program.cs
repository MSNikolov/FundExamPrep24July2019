using System;
using System.Text.RegularExpressions;

namespace FundExamPrep24July2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameOfRacerRegex = @"(?<=([""#$%*&]))[A-Za-z]+(?=(\1))";

            var lengthOfGeohashcodeRegex = @"(?<==)[0-9]+";

            var encryptedGeoHashRegex = @"(?<=[!][!]).+$";

            bool found = false;

            while (true)
            {
                var input = Console.ReadLine();

                if (Regex.IsMatch(input, nameOfRacerRegex))
                {
                    var nameOfRacer = Regex.Match(input, nameOfRacerRegex).ToString();

                    input = input.Substring(nameOfRacer.Length + 2);

                    if (Regex.IsMatch(input, lengthOfGeohashcodeRegex))
                    {
                        var lengthOfGeohashcodeString = Regex.Match(input, lengthOfGeohashcodeRegex).ToString();

                        var lengthOfGeohashcode = int.Parse(lengthOfGeohashcodeString);

                        input = input.Substring(lengthOfGeohashcodeString.Length + 1);

                        if (Regex.IsMatch(input, encryptedGeoHashRegex))
                        {
                            var encryptedGeoHash = Regex.Match(input, encryptedGeoHashRegex).ToString();

                            if (encryptedGeoHash.Length == lengthOfGeohashcode)
                            {
                                var result = "";

                                foreach (var character in encryptedGeoHash)
                                {
                                    result += (char)(character + lengthOfGeohashcode);
                                }

                                Console.WriteLine($"Coordinates found! {nameOfRacer} -> {result}");

                                found = true;
                            }
                        }
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Nothing found!");
                }

                else
                {
                    break;
                }
            }
        }
    }
}
