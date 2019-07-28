using System;
using System.Collections.Generic;
using System.Linq;

namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var bands = new Dictionary<string, List<string>>();

            var playTime = new Dictionary<string, int>();

            while (input != "start of concert")
            {
                var command = input.Split("; ");

                switch(command[0])
                {
                    case "Add":
                        if (!bands.ContainsKey(command[1]))
                        {
                            bands.Add(command[1], new List<string>());
                        }

                        if (!playTime.ContainsKey(command[1]))
                        {
                            playTime.Add(command[1], 0);
                        }

                        var musicians = command[2].Split(", ");

                        foreach (var musician in musicians)
                        {
                            if (!bands[command[1]].Contains(musician))
                            {
                                bands[command[1]].Add(musician);
                            }
                        }
                        break;
                    case "Play":
                        if (!bands.ContainsKey(command[1]))
                        {
                            bands.Add(command[1], new List<string>());
                        }

                        if (!playTime.ContainsKey(command[1]))
                        {
                            playTime.Add(command[1], 0);
                        }

                        playTime[command[1]] += int.Parse(command[2]);
                        break;
                }
                input = Console.ReadLine();
            }
            playTime = playTime.OrderByDescending(p => p.Value).ThenBy(p => p.Key).ToDictionary(p => p.Key, p => p.Value);

            var bandName = Console.ReadLine();

            Console.WriteLine($"Total time: {playTime.Sum(p => p.Value)}");

            foreach (var band in playTime)
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            var bandToShow = bands.First(b => b.Key == bandName);

            Console.WriteLine(bandName);

            foreach (var member in bandToShow.Value)
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}
