using System;

namespace DvirSolitare
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck d = new Deck();
            Console.WriteLine(d.getCard(4).getType());
            Console.WriteLine(d.getCard(20).getType());
            Console.WriteLine(d.areDifferentcolors(d.getCard(4), d.getCard(20)));
        }
    }
}