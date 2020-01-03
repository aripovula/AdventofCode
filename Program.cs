using System;

namespace Advent3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You selected option # " + args[0]);
            if (args[0] == "3") {
                Advent3 advent3 = new Advent3();
                Tuple<int, int> path = advent3.getShortestPath();
                Console.WriteLine("Shortest path is " + path.Item1 
                    + " + " + path.Item2+". Total - "+(path.Item1 + path.Item2));
            }

        }
    }
}
