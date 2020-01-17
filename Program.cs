using System;

namespace Advent3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You selected option # " + args[0]);
            if (args[0] == "2") {
                Console.WriteLine("Paste intcode OR paste nothing to use default input - ");
                string intCode = Console.ReadLine();
                Advent2 advent2 = new Advent2();
                var result = advent2.getUpdatedIntCode(intCode);
                Console.WriteLine("Result- ");
                foreach (var code in result) { Console.Write(code+",");}
                Console.WriteLine(" ");
            }
            if (args[0] == "3") {
                Advent3 advent3 = new Advent3();
                Tuple<int, int> path = advent3.getShortestPath();
                Console.WriteLine("Shortest path is " + path.Item1 
                    + " + " + path.Item2+". Total - "+(path.Item1 + path.Item2));
            }
            if (args[0] == "51") {
                Console.WriteLine("Paste intcode OR paste nothing to use default input - ");
                string intCode = Console.ReadLine();
                Console.WriteLine("Enter input - ");
                string input = Console.ReadLine();
                var result = new Advent5().getUpdatedIntCode(intCode, input);
            }
            if (args[0] == "5") {
                Console.WriteLine("Paste intcode OR paste nothing to use default input - ");
                string intCode = Console.ReadLine();
                Console.WriteLine("Enter input - ");
                string input = Console.ReadLine();
                var result = new Advent5p2().getUpdatedIntCode(intCode, input);
            }
        }
    }
}
