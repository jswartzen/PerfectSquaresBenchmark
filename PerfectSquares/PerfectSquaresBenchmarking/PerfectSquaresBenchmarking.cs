// <copyright file="Program.cs" company="OSIsoft, LLC">
// Copyright © 2016 John L. Swartzentruber
// </copyright>

namespace PerfectSquaresBenchmarking
{
    using System;
    using System.Linq;

    /// <summary>
    /// Main program class
    /// </summary>
    class PerfectSquaresBenchmarking
    {
        /// <summary>
        /// Program entry point
        /// </summary>
        /// <param name="args">Program arguments</param>
        static void Main(string[] args)
        {
            bool onlySquares;
            bool onlyNonSquares;
            long limit;
            ProcessCommandLine(args, out onlySquares, out onlyNonSquares, out limit);

            const int Loops = 125000;
            var solutions = new[]
            {
                // new SolutionTimer(new BruteForceSolution(), Loops),
                // new SolutionTimer(new OddNumberSumSolution(), Loops),
                new SolutionTimer(new BinarySearchSolution(), Loops),
                new SolutionTimer(new HybridSolution(), Loops),
                // new SolutionTimer(new PrimeFactorsSolution(), Loops)
            };

            Console.WriteLine("Value," + string.Join(",", solutions.Select(p => p.Solver.Name)));

            if (onlySquares)
            {
                long value = 1;
                int add = 1;
                while (value <= limit)
                {
                    add += 2;
                    Console.Write(value);
                    foreach (var solution in solutions)
                    {
                        Console.Write($",{solution.TimeToSolve(value)}");
                    }

                    value += add;
                    Console.WriteLine(string.Empty);
                }
            }
            else
            {
                const int ArraySize = 300;
                var random = new Random();
                var values = new long[ArraySize];
                for (int i = 0; i < ArraySize; ++i)
                {
                    values[i] = (long) Math.Round(random.NextDouble() * limit);
                }
                Array.Sort(values);

                var binarySolver = new BinarySearchSolution();
                foreach(var value in values)
                {
                    if (!onlyNonSquares || !binarySolver.IsPerfectSquare(value)) {
                        Console.Write(value);
                        foreach (var solution in solutions)
                        {
                            Console.Write($",{solution.TimeToSolve(value)}");
                        }

                        Console.WriteLine(string.Empty);
                    }
                }
            } 
        }

        /// <summary>
        /// Try to parse the command line arguments. They can be in any order and indicate
        /// whether we want to only test perfect squares, only test values that are not
        /// perfect squares, and an integer indicating the largest value to test against
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <param name="onlySquares">Output bool for only showing perfect squares</param>
        /// <param name="onlyNonSquares">Output bool for only showing values that are not perfect squares</param>
        /// <param name="limit">Output value for the largest value to test against</param>
        private static void ProcessCommandLine(string[] args, out bool onlySquares, out bool onlyNonSquares, out long limit)
        {
            onlySquares = false;
            onlyNonSquares = false;
            limit = 300000;

            foreach (var arg in args)
            {
                if (string.Equals("squares", arg, StringComparison.CurrentCultureIgnoreCase))
                {
                    onlySquares = true;
                }
                else if (string.Equals("nonsquares", arg, StringComparison.CurrentCultureIgnoreCase))
                {
                    onlyNonSquares = true;
                }
                else
                {
                    long val;
                    if (long.TryParse(arg, out val) && val > 0)
                    {
                        limit = val;
                    }
                }
            }
        }
    }
}
