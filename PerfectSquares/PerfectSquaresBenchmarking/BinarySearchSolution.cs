// <copyright file="Program.cs" company="OSIsoft, LLC">
// Copyright © 2016 John L. Swartzentruber
// </copyright>
namespace PerfectSquaresBenchmarking
{
    /// <summary>
    /// Perfect square solution using a binary search to find the square root.
    /// </summary>
    public class BinarySearchSolution : IPerfectSquareSolution
    {
        /// <summary>
        /// Gets name of this solution
        /// </summary>
        public string Name => "Binary Search";

        /// <summary>
        /// Binary search approach
        /// </summary>
        /// <param name="value">Number we are checking</param>
        /// <returns>true if perfect square</returns>
        public bool IsPerfectSquare(long value)
        {
            if (value == 1)
            {
                return true;
            }

            long high = value;
            long low = 0;
            while (high > low)
            {
                var mid = (high + low) / 2;
                var square = mid * mid;
                if (square == value)
                {
                    return true;
                }

                if (mid == high || mid == low)
                {
                    return false;
                }

                if (square > value)
                {
                    high = mid;
                }
                else
                {
                    low = mid;
                }
            }

            return false;
        }
    }
}
