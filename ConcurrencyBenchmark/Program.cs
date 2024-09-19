using System;
using BenchmarkDotNet.Running;

namespace ConcurrencyBenchmark
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<MyGridBenchmarks>();
            Console.ReadKey();
        }
    }
}
