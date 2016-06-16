// <copyright file="Program.cs" company="OSIsoft, LLC">
// Copyright © 2016 John L. Swartzentruber
// </copyright>

namespace PerfectSquaresBenchmarking
{
    /// <summary>
    /// Perfect square solution using a brute force approach
    /// </summary>
    public class BruteForceSolution : IPerfectSquareSolution
    {
        /// <summary>
        /// Gets the name of this solution
        /// </summary>
        public string Name { get { return "Brute Force"; } }

        /// <summary>
        /// Finds if the input number is a perfect square using a semi-optimized
        /// brute force approach
        /// </summary>
        /// <param name="value">Number being checked</param>
        /// <returns>True if the input is a perfect square</returns>
        public bool IsPerfectSquare(long value)
        {
            for (long i = 1; i <= value; ++i)
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
    }
}
