// <copyright file="Program.cs" company="OSIsoft, LLC">
// Copyright © 2016 John L. Swartzentruber
// </copyright>
namespace PerfectSquaresBenchmarking
{
    class BinarySearchSolution : IPerfectSquareSolution
    {
        public string Name { get { return "Binary Search"; } }

        /// <summary>
        /// Binary search approach
        /// </summary>
        /// <param name="value">Number we are checking</param>
        /// <returns>true if perfect square</returns>
        public bool IsPerfectSquare(long value)
        {
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
