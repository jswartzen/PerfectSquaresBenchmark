// <copyright file="Program.cs" company="OSIsoft, LLC">
// Copyright © 2016 John L. Swartzentruber
// </copyright>

namespace PerfectSquaresBenchmarking
{
    class BruteForceSolution : IPerfectSquareSolution
    {
        public string Name { get { return "Brute Force"; } }

        public bool IsPerfectSquare(long value)
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
    }
}
