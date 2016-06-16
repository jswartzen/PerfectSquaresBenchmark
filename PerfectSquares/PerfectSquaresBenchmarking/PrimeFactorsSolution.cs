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
            // We could optimize by processing 2s separately, then we would only need to check odd factors
            for (int factor = 2; factor <= value; ++factor)
            {
                while (value % factor == 0)
                {
                    value /= factor;
                    if (value % factor != 0)
                    {
                        return false;
                    } else if (value == factor)
                    {
                        return true;
                    }

                    value /= factor;
                }

                // Stop checking when we pass the largest possible prime factor
                if (value / factor < factor)
                {
                    return false;
                }
            }

            return value == 1;
        }
    }
}
