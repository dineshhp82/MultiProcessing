using MultiProcessing.Basic;
using System;

namespace MultiProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Threading");

            TheadingBasicDemo.Demo();

            Console.Read();
        }
    }
}
