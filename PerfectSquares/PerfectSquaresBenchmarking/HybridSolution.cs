// <copyright file="Program.cs" company="OSIsoft, LLC">
// Copyright © 2016 John L. Swartzentruber
// </copyright>
namespace PerfectSquaresBenchmarking
{
    /// <summary>
    /// Combine different solutions in an attempt to create an optimal solution
    /// </summary>
    public class HybridSolution : IPerfectSquareSolution
    {
        /// <summary>
        /// Fastest general purpose solution
        /// </summary>
        private static readonly IPerfectSquareSolution Solver = new BinarySearchSolution();

        /// <summary>
        /// Gets the name of this solution
        /// </summary>
        public string Name => "Hybrd";

        /// <summary>
        /// Determines if the input value is a perfect square
        /// </summary>
        /// <param name="value">The value being checked</param>
        /// <returns>True if perfect square</returns>
        public bool IsPerfectSquare(long value)
        {
            if (value == 0)
            {
                return false;
            }

            int[] smallPrimes = { 2, 3, 5, 7, 11, 13, 17 };

            // First do prime factor processing to reduce the value
            foreach (var factor in smallPrimes)
            {
                while (value % factor == 0)
                {
                    value /= factor;
                    if (value % factor != 0)
                    {
                        return false;
                    }

                    value /= factor;
                }
            }

            return value == 1 || Solver.IsPerfectSquare(value);

        }
    }
}
