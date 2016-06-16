// <copyright file="Program.cs" company="OSIsoft, LLC">
// Copyright © 2016 John L. Swartzentruber
// </copyright>
namespace PerfectSquaresTesting
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PerfectSquaresBenchmarking;

    [TestClass]
    public class PerfectSquaresSolutionTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestAllSolutions()
        {
            var solutions = new IPerfectSquareSolution[]
            {
                new BruteForceSolution(),
                new BinarySearchSolution(),
                new OddNumberSumSolution()
            };

            foreach (var solution in solutions)
            {
                this.TestContext.WriteLine($"Testing solution: {solution.Name}");
                Assert.IsNotNull(solution.Name, "Name property has a value");
                Assert.IsFalse(string.IsNullOrWhiteSpace(solution.Name), $"Solution name ({solution.Name}) is non-empty");

                var perfectSquares = new long[] { 1, 4, 9, 100, 625, (long)int.MaxValue * 2 + 2 };
                var nonSquares = new long[] { 0, 2, 3, 5, 8, 99, 101, 65535, int.MaxValue };

                foreach (var square in perfectSquares)
                {
                    Assert.IsTrue(solution.IsPerfectSquare(square), $"{square} is a perfect square");
                }

                foreach (var nonsquare in nonSquares)
                {
                    Assert.IsTrue(!solution.IsPerfectSquare(nonsquare), $"{nonsquare} is not a perfect square");
                }
            }
        }
    }
}
