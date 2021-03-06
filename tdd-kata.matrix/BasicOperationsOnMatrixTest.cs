﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

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
            double[,] matrixToTranspose = { { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 1, 2, 3, 4 } };
            double[,] expectedMatrix = { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 }, { 4, 4, 4 } };

            var result = matrixToTranspose.Transpose();

            Assert.AreEqual(expectedMatrix, result);
        }

        [Test]
        public void Given2DimentionalMatrixOfSize3of3ThenCalcualteDeterminantAndReturnValue()
        {
            int[,] matrixToCalculate = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            double expectedValue = 0;

            var result = matrixToCalculate.Determinant();

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void Given2DimensionalMatrixOfSize2for2ThenCalculateDeterminantAndReturnValue()
        {
            int[,] matrixToCalculate = { { 1, 2 }, { 3, 4 } };
            double expectedDeterminant = -2;

            var result = matrixToCalculate.Determinant();

            Assert.AreEqual(expectedDeterminant, result);
        }

        [Test]
        public void Given2DimentionalMatrixOfSize1for1ThenCalculateDeterminantAndReturnValue()
        {
            int[,] matrixToCalculate = { { 1 } };
            double expectedDeterminant = 1;

            var result = matrixToCalculate.Determinant();

            Assert.AreEqual(expectedDeterminant, result);
        }

        [Test]
        public void Given2DimentionalMatrixOfSize3for3ThenInvertAndReturnInvertedValue()
        {
            //arrange
            int[,] matrixToInvert = { { 1, 2, -2 }, { 1, 1, 1 }, { 1, 4, 1 } };
            int[,] expectedMatrix = { { 3, 10, -4 }, { 0, -3, 3 }, { -3, 2, 1 } };
            double expectedDeterminant = ((double)1 / 9);
            var expectedInvertedMatrix = expectedMatrix.Multiply(expectedDeterminant);

            //act
            var result = matrixToInvert.Invert();

            //assert
            Assert.AreEqual(expectedInvertedMatrix, result);
        }

        [Test]
        public void Given2DimentionalMatrixThenTryInvertAndReturnException()
        {
            int[,] matrixToInvert = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            Assert.Throws<InvertedMatrixDoesntExist>(() => matrixToInvert.Invert());
        }

        [Test]
        public void Given2DimentionalMatrixOfSize3of3ThenGetMinorAndReturnValue()
        {
            int[,] matrixToConvert = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] expectedMatrix = { { 1, 3 }, { 7, 9 } };

            var result = matrixToConvert.GetMinor(1, 1);

            Assert.AreEqual(expectedMatrix, result);
            Assert.AreEqual(expectedMatrix.GetLength(0), matrixToConvert.GetLength(0) - 1);
            Assert.AreEqual(expectedMatrix.GetLength(1), matrixToConvert.GetLength(1) - 1);

        }

        [Test]
        public void Given2DimentionalMatrixThenMultiplyAndReturnValue()
        {
            int[,] matrixToConvert = { { 1, 2 }, { 3, 4 } };
            double[,] expectedMatrix = { { 0.5, 1 }, { 1.5, 2 } };

            var result = matrixToConvert.Multiply(0.5);

            Assert.AreEqual(expectedMatrix, result);
        }

        [Test]
        public void Given2DimentionalMatrixThenCheckIfIsSquareMatrixAndReturnTrue()
        {
            int[,] squareMatrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            bool expectedResult = true;

            var result = squareMatrix.IsSquare();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Given2DimentionalMatrixThenCheckIfSquareAndReturnFalse()
        {
            int[,] notSuareMatrix = { { }, { } };
            bool expectedResult = false;

            var result = notSuareMatrix.IsSquare();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Given2DimentionalMatrixThenDecomposeMatrixToTwoTriangleMatrix()
        {
            int[,] matrixToDecompose = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            double[,] expectedDecomposedUpperTriangleMatrix = { { 1, 2, 3 }, { 0, -3, -6 }, { 0, 0, 0 } };
            double[,] expectedDecomposedLowerTriangleMatrix = { { 1, 0, 0 }, { 4, 1, 0 }, { 7, 2, 1 } };

            var result = matrixToDecompose.Decompose();

            Assert.AreEqual(expectedDecomposedUpperTriangleMatrix, result.UpperTriangleMatrix);
            Assert.AreEqual(expectedDecomposedLowerTriangleMatrix, result.LowerTriangleMatrix);

        }

        [Test]
        public void Given2DimentionalMatrix4of4ThenCalculateDeterminantAndReturnValue()
        {
            int[,] matrixToCalculate = { { 1, 9, 3, 7 }, { 5, 5, 7, 7 }, { 10, 11, 10, 10 }, { 13, 14, 15, -6 } };
            double expectedValue = -3544;

            var result = matrixToCalculate.Determinant();

            result.Should().BeApproximately(expectedValue, 0.1);
        }
    }

    public class Matrix
    {
        public double[,] UpperTriangleMatrix { get; set; }
        public double[,] LowerTriangleMatrix { get; set; }
        public int Determinant { get; set; }
    }

    public class DiffrentSizeOfMarix : Exception
    {
         
    }

    public class WrongSizeOfMatrixToMultiply : Exception
    {

    }

    public class InvertedMatrixDoesntExist : Exception
    {
    }

    public class NotSquareMatrix : Exception
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

        public static double[,] Transpose(this double[,] matrixToTranspose)
        {
            var result = new double[matrixToTranspose.GetLength(1), matrixToTranspose.GetLength(0)];

            for (int i = 0; i < matrixToTranspose.GetLength(1); i++)
            {
                for (int j = 0; j < matrixToTranspose.GetLength(0); j++)
                {
                    result[i, j] = matrixToTranspose[j, i];
                }
            }


            return result;
        }

        public static double Determinant(this int[,] matrixToCalculate )
        {
            var result = 0.0;
            
            if (matrixToCalculate.IsSquare())
            {  
                if (matrixToCalculate.GetLength(0) == 1)
                {
                    result = (double)matrixToCalculate[0, 0];
                }                
                if (matrixToCalculate.GetLength(0) > 1)
                {
                    var matrix = matrixToCalculate.Decompose();

                    var lowerTriangleMatrixDeterminant = 1.0;
                    for (int i = 0; i < matrix.LowerTriangleMatrix.GetLength(0); i++)
                    {
                        lowerTriangleMatrixDeterminant *= matrix.LowerTriangleMatrix[i, i];
                    }

                    var upperTriangleMatrixDeterminant = 1.0;
                    for (int i = 0; i < matrix.UpperTriangleMatrix.GetLength(1); i++)
                    {
                        upperTriangleMatrixDeterminant *= matrix.UpperTriangleMatrix[i, i];
                    }

                    result = lowerTriangleMatrixDeterminant * upperTriangleMatrixDeterminant;
                }
            }
            else
            {
                throw new NotSquareMatrix();
            }

            return result;
        }

        public static double[,] Invert(this int[,] matrixToConvert)
        {
            double[,] result = new double[matrixToConvert.GetLength(0), matrixToConvert.GetLength(1)];
            double determinant = matrixToConvert.Determinant();
            if (matrixToConvert.IsSquare())
            {
                if (determinant != 0)
                {
                    for (int i = 0; i < matrixToConvert.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrixToConvert.GetLength(1); j++)
                        {
                            result[i, j] = Math.Pow(-1, i + j) * matrixToConvert.GetMinor(i, j).Determinant() * (1 / determinant);
                        }
                    }

                    return result.Transpose();
                }
                else
                {
                    throw new InvertedMatrixDoesntExist();
                }
            }
            else
            {
                throw new NotSquareMatrix();
            }
        }

        public static int[,] GetMinor(this int[,] matrixToConvert, int xPosition, int yPosition)
        {
            int[,] result = new int[matrixToConvert.GetLength(0) - 1, matrixToConvert.GetLength(1) - 1];
            int xNewValue = 0;
            int yNewValue = 0;
            for (int i = 0; i < matrixToConvert.GetLength(0); i++)
            {
                for (int j = 0; j < matrixToConvert.GetLength(1); j++)
                {
                    if (i != xPosition && j != yPosition)
                    {                                           
                        result[xNewValue, yNewValue] = matrixToConvert[i, j];
                        yNewValue++;
                        if (yNewValue > result.GetLength(1) - 1)
                        {
                            xNewValue++;
                            yNewValue = 0;
                        }                        
                    }                    
                }
            }

            return result;
        }

        public static double[,] Multiply(this int[,] matrixToMultiply, double multiplyBy)
        {
            double[,] result = new double[matrixToMultiply.GetLength(0), matrixToMultiply.GetLength(1)];

            for (int i = 0; i < matrixToMultiply.GetLength(0); i++)
            {
                for (int j = 0; j < matrixToMultiply.GetLength(1); j++)
                {
                    result[i, j] = (double)matrixToMultiply[i, j] * multiplyBy;
                }
            }

            return result;
        }

        public static bool IsSquare(this int[,] matrixToCheck)
        {
            if (matrixToCheck.GetLength(0) != matrixToCheck.GetLength(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Matrix Decompose(this int[,] matrixToDecompose)
        {
            var result = new Matrix();
            double[,] upperTriangleMatrix = new double[matrixToDecompose.GetLength(0), matrixToDecompose.GetLength(1)];
            double[,] lowerTriangleMatrix = new double[matrixToDecompose.GetLength(0), matrixToDecompose.GetLength(1)];            

            for (int i = 0; i < lowerTriangleMatrix.GetLength(1); i++)
            {
                lowerTriangleMatrix[i, i] = 1;
            }

            for (int i = 0; i < matrixToDecompose.GetLength(0); i++)
            {
                for (int j = 0; j < matrixToDecompose.GetLength(1); j++)
                {
                    if (i <= j)
                    {
                        double tempSumToDelete = 0;
                        for (int k = 0; k <= i; k++)
                        {
                            tempSumToDelete += lowerTriangleMatrix[i, k] * upperTriangleMatrix[k, j];
                        }

                        upperTriangleMatrix[i, j] = matrixToDecompose[i, j] - tempSumToDelete;
                    }
                    else
                    {
                        double tempSumToDelete = 0;
                        for (int k = 0; k <= j; k++)
                        {
                            tempSumToDelete += lowerTriangleMatrix[i, k] * upperTriangleMatrix[k, j];
                        }
                        
                        lowerTriangleMatrix[i, j] = (1 / upperTriangleMatrix[j, j]) * (matrixToDecompose[i, j] - tempSumToDelete);
                    }
                }
            }

            result.UpperTriangleMatrix = upperTriangleMatrix;
            result.LowerTriangleMatrix = lowerTriangleMatrix;
            return result;
        }
        
    }
}
