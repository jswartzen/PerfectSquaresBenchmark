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

            const int loops = 500000;
            var solutions = new SolutionTimer[]
            {
                new SolutionTimer(new BruteForceSolution(), loops),
                new SolutionTimer(new OddNumberSumSolution(), loops),
                new SolutionTimer(new BinarySearchSolution(), loops),
                new SolutionTimer(new PrimeFactorsSolution(), loops)
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
                var binarySolver = new BinarySearchSolution();
                for (var value = 1L; value <= limit; value = (long)(value * 1.08 + 1))
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
            limit = 10000;

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
