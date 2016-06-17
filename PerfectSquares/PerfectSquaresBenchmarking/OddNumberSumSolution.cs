// <copyright file="Program.cs" company="OSIsoft, LLC">
// Copyright © 2016 John L. Swartzentruber
// </copyright>
namespace PerfectSquaresBenchmarking
{
    /// <summary>
    /// This solution is based on the property that all perfect squares are the
    /// sequential sum of odd numbers. For example 1 + 3 = 4, 1 + 3 + 5 = 9, etc.
    /// n squared + 2n + 1 = (n+1) squared.
    /// </summary>
    public class OddNumberSumSolution : IPerfectSquareSolution
    {
        /// <summary>
        /// Gets the name of this solution
        /// </summary>
        public string Name => "Odd Number Sum";

        /// <summary>
        /// Determine if the input value is a perfect square
        /// </summary>
        /// <param name="value">The value being checked</param>
        /// <returns>True if perfect square</returns>
        public bool IsPerfectSquare(long value)
        {
            // Note: all solutions assume 0 is not a perfect square. If this
            // is not the case, an exception should be made because 0 is not 
            // the sum of the preceeding odd numbers
            long sum = 0;
            for (long i = 1; i <= value; i += 2)
            {
                sum += i;
                if (sum == value)
                {
                    return true;
                }
                else if (sum > value)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
