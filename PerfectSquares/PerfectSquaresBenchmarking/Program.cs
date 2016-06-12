// <copyright file="Program.cs" company="OSIsoft, LLC">
// Copyright © 2016 John L. Swartzentruber
// </copyright>

namespace PerfectSquaresBenchmarking
{
    /// <summary>
    /// Main program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Program entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Brute force approach
        /// </summary>
        /// <param name="value">Number we are checking</param>
        /// <returns>true if perfect square</returns>
        private bool IsPerfectSquareBrute(long value)
        {
            for (long i = 1; i < value; ++i)
            {
                var squared = i * i;
                if (squared == value)
                {
                    return true;
                }

                if (squared > value)
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Binary search approach
        /// </summary>
        /// <param name="value">Number we are checking</param>
        /// <returns>true if perfect square</returns>
        private bool IsPerfectSquareBinary(long value)
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
