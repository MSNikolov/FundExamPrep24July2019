using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var artistRegex = @"^[A-Z][a-z' ]+$";

            var songRegex = @"^[A-Z ]+$";

            while (input != "end")
            {
                var artistAndSong = input.Split(':');

                var artist = artistAndSong[0];

                var song = artistAndSong[1];

                if (Regex.IsMatch(artist, artistRegex) && Regex.IsMatch(song, songRegex))
                {
                    var key = artist.Length;

                    var result = "";

                    foreach (var letter in input)
                    {
                        if (letter != ' ' && letter != '\'' && letter != ':')
                        {
                            var res = letter + key;

                            if ((int)letter >= 65 && (int)letter <= 90 && res > 90 || (int)letter >= 97 && (int)letter <= 122 && res > 122)
                            {
                                res -= 26;
                            }

                            result += Convert.ToChar(res);
                        }

                        else if (letter == ':')
                        {
                            result += '@';
                        }

                        else
                        {
                            result += letter;
                        }
                    }

                    Console.WriteLine($"Successful encryption: {result}");
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }


        }
    }
}
