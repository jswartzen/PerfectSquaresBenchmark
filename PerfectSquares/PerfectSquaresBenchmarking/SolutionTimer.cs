// <copyright file="PerfectSquaresBenchmarking.cs" company="OSIsoft, LLC">
// Copyright © 2016 John L. Swartzentruber
// </copyright>
namespace PerfectSquaresBenchmarking
{
    using System;

    /// <summary>
    /// Helper class that times how long it takes to determine if a number is a perfect square
    /// </summary>
    public class SolutionTimer
    {
        public IPerfectSquareSolution Solver { get; }

        private readonly int loopCount;

        /// <summary>
        /// Creates an object used to time a solution
        /// </summary>
        /// <param name="solver">The IPerfectSquareSolution under analysis</param>
        /// <param name="loopCount">How many loops we should test with</param>
        public SolutionTimer(IPerfectSquareSolution solver, int loopCount)
        {
            this.Solver = solver;
            this.loopCount = loopCount;
        }

        /// <summary>
        /// Time how long it takes to solve with our solver
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <returns>Ticks required to solve</returns>
        public long TimeToSolve(long value)
        {
            var now = DateTime.UtcNow;
            for (int i = 0; i < this.loopCount; ++i)
            {
                this.Solver.IsPerfectSquare(value);
            }

            return (long)(DateTime.UtcNow - now).TotalMilliseconds;
        }
    }
}
