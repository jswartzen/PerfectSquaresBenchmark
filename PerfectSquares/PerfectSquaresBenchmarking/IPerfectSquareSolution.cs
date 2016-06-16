// <copyright file="Program.cs" company="OSIsoft, LLC">
// Copyright © 2016 John L. Swartzentruber
// </copyright>

namespace PerfectSquaresBenchmarking
{
    public interface IPerfectSquareSolution
    {
        /// <summary>
        /// Gets the name associated with this solver.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Checks if the input value is a perfect square
        /// </summary>
        /// <param name="value">Value being checked</param>
        /// <returns>true if it is a perfect square, false if it is not</returns>
        bool IsPerfectSquare(long value);
    }
}
