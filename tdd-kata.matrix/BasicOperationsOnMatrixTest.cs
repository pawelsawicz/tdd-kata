using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace tdd_kata.matrix
{
    [TestFixture]
    public class BasicOperationsOnMatrixTest
    {
        [Test]
        public void Given2DimensionalMatrixThenAdd()
        {
            int[,] firstMatrix = { { 1, 2 }, { 1, 2 } };
            int[,] secondMatrix = { { 2, 1 }, { 2, 1 } };
            int[,] expectedMatrix = { { 3, 3 }, { 3, 3 } };

            var result = firstMatrix.Add(secondMatrix);

            Assert.AreEqual(expectedMatrix, result);
        }

    }

    public static class MatrixHelpers
    {
        public static int[,] Add(this int[,] firstMatrix, int[,] secondMatrix)
        {
            int[,] result = new int[firstMatrix.GetLength(0), firstMatrix.GetLength(1)];

            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    result[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                }
            }

            return result;
        }
    }
}
