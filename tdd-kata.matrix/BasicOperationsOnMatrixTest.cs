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
        public void Given2DimensionalMatrixThenAddAndReturnCorrectValue()
        {
            int[,] firstMatrix = { { 1, 2 }, { 1, 2 } };
            int[,] secondMatrix = { { 2, 1 }, { 2, 1 } };
            int[,] expectedMatrix = { { 3, 3 }, { 3, 3 } };

            var result = firstMatrix.Add(secondMatrix);

            Assert.AreEqual(expectedMatrix, result);
        }

        [Test]
        public void Given2DimensionalMatrixButSizeIsDifferentThenAddResturnException()
        {
            int[,] firstMatrix = { { 1, 2, 3 }, { 1, 2, 3 } };
            int[,] secondMatrix = { { 1, 2 }, { 5, 6 } };

            var exceptionResult = Assert.Throws<DiffrentSizeOfMarix>(() => firstMatrix.Add(secondMatrix));

        }

        [Test]
        public void Given2DimensionalMatrixThenSubstractAndReturnCorrectValue()
        {
            int[,] firstMatrix = { { 1, 1, 1 }, { 1, 1, 1 } };
            int[,] secondMatrix = { { 1, 1, 1 }, { 1, 1, 1 } };
            int[,] expectedResult = { { 0, 0, 0 }, { 0, 0, 0 } };

            var result = firstMatrix.Delete(secondMatrix);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Given2DimensionalMatrixThenMultiplyByMatrixAndReturnCorrectValue()
        {
            int[,] firstMatrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] secondMatrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] expectedValue = { { 30, 36, 42 }, { 66, 81, 96 }, { 102, 126, 150 } };

            var result = firstMatrix.Multiply(secondMatrix);

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void Given2DimensionalMatrixThenMultiplyByMatrixAndReturnException()
        {
            int[,] firstMatrix = { {1,2 }, {3,4 } };
            int[,] secondMatrix = { { 1, 2, 3 }, { 3, 4, 5 }, { 6, 7, 8 } };

            Assert.Throws<WrongSizeOfMatrixToMultiply>(() => firstMatrix.Multiply(secondMatrix));
        }

        [Test]
        public void Given2DimensionalMatrixThenTransposeAndReturnTransposedMatrix()
        {
            int[,] matrixToTranspose = { { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 1, 2, 3, 4 } };
            int[,] expectedMatrix = { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 }, { 4, 4, 4 } };

            var result = matrixToTranspose.Transpose();

            Assert.AreEqual(expectedMatrix, result);
        }

    }

    public class DiffrentSizeOfMarix : Exception
    {
         
    }

    public class WrongSizeOfMatrixToMultiply : Exception
    {

    }

    public static class MatrixHelpers
    {
        public static int[,] Add(this int[,] firstMatrix, int[,] secondMatrix)
        {
            if (firstMatrix.GetLength(0) != secondMatrix.GetLength(0) || firstMatrix.GetLength(1) != secondMatrix.GetLength(1))
            {
                throw new DiffrentSizeOfMarix();
            }
            else
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

        public static int[,] Delete(this int[,] firstMatrix, int[,] secondMatrix)
        {
            var result = new int[firstMatrix.GetLength(0), firstMatrix.GetLength(1)];

            if (firstMatrix.GetLength(0) != secondMatrix.GetLength(0) || firstMatrix.GetLength(1) != secondMatrix.GetLength(1))
            {
                throw new DiffrentSizeOfMarix();
            }
            else
            {
                for (int x = 0; x < firstMatrix.GetLength(0); x++)
                {
                    for (int y = 0; y < firstMatrix.GetLength(1); y++)
                    {
                        result[x, y] = firstMatrix[x, y] - secondMatrix[x, y];
                    }
                }

                return result;
            }
        }

        public static int[,] Multiply(this int[,] firstMatrix, int[,] secondMatrix)
        {
            if (firstMatrix.GetLength(0) != secondMatrix.GetLength(1))
            {
                throw new WrongSizeOfMatrixToMultiply();
            }
            else
            {
                var result = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

                for (int i = 0; i < firstMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < secondMatrix.GetLength(0); j++)
                    {
                        for (int k = 0; k < secondMatrix.GetLength(1); k++)
                        {
                            result[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                        }
                    }
                }

                return result;
            }
        }

        public static int[,] Transpose(this int[,] matrixToTranspose)
        {
            var result = new int[matrixToTranspose.GetLength(1), matrixToTranspose.GetLength(0)];

            for (int i = 0; i < matrixToTranspose.GetLength(1); i++)
            {
                for (int j = 0; j < matrixToTranspose.GetLength(0); j++)
                {
                    result[i, j] = matrixToTranspose[j, i];
                }
            }


            return result;
        }
    }
}
