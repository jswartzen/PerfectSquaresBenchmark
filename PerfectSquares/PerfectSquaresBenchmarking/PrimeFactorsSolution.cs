// <copyright file="Program.cs" company="OSIsoft, LLC">
// Copyright © 2016 John L. Swartzentruber
// </copyright>
namespace PerfectSquaresBenchmarking
{
    /// <summary>
    /// This solution is based on the fact that every perfect square has an even
    /// number of each prime factor greater than 1.
    /// </summary>
    public class PrimeFactorsSolution : IPerfectSquareSolution
    {
        public string Name { get { return "Prime Factors"; } }

        /// <summary>
        /// Determins if a number is a perfect square by factoring it. If a factor
        /// does not occur in pairs, the number is not a perfect square.
        /// </summary>
        /// <param name="value">The value being checked</param>
        /// <returns>True if it is a perfect square</returns>
        public bool IsPerfectSquare(long value)
        {
            if (value == 0)
            {
                return false;
            }

            // Optimize by processing 2s first, then we only need to process odd numbers
            while (value % 4 == 0)
            {
                value /= 4;
            }

            for (int factor = 3; value / factor >= factor; factor += 2)
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

            return value == 1;
        }
    }
}
