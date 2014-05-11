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

        [Test]
        public void Given2DimentionalMatrixOfSize3of3ThenCalcualteDeterminantAndReturnValue()
        {
            int[,] matrixToCalculate = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int expectedValue = 0;

            var result = matrixToCalculate.Determinant();

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void Given2DimensionalMatrixOfSize2for2ThenCalculateDeterminantAndReturnValue()
        {
            int[,] matrixToCalculate = { { 1, 2 }, { 3, 4 } };
            int expectedDeterminant = -2;

            var result = matrixToCalculate.Determinant();

            Assert.AreEqual(expectedDeterminant, result);
        }

        [Test]
        public void Given2DimentionalMatrixOfSize1for1ThenCalculateDeterminantAndReturnValue()
        {
            int[,] matrixToCalculate = { { 1 } };
            int expectedDeterminant = 1;

            var result = matrixToCalculate.Determinant();

            Assert.AreEqual(expectedDeterminant, result);
        }

        [Test]
        public void Given2DimentionalMatrixOfSize3for3ThenInvertAndReturnInvertedValue()
        {
            //arrange
            int[,] matrixToInvert = { { 1, 2, -2 }, { 1, 1, 1 }, { 1, 4, 1 } };
            int[,] expectedMatrix = { { 3, 10, -4 }, { 0, -3, 3 }, { -3, 2, 1 } };
            double expectedDeterminant = 1 / 9;
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

        public static int Determinant(this int[,] matrixToCalculate )
        {
            var result = 0;
            
            if (matrixToCalculate.GetLength(0) == matrixToCalculate.GetLength(1))
            {  
                if (matrixToCalculate.GetLength(0) == 1)
                {
                    result = matrixToCalculate[0, 0];
                }
                else if (matrixToCalculate.GetLength(0) == 2)
                {
                    //to refactor
                    result = (matrixToCalculate[0, 0] * matrixToCalculate[1, 1]) - (matrixToCalculate[1, 0] * matrixToCalculate[0, 1]);
                }
                else if (matrixToCalculate.GetLength(0) > 2)
                {
                    //to refactor 
                    var firstValue = (matrixToCalculate[0,0] * matrixToCalculate[1,1] * matrixToCalculate[2,2]) + (matrixToCalculate[1,0] * matrixToCalculate[2,1] * matrixToCalculate[0,2])
                        + (matrixToCalculate[2,0] * matrixToCalculate[0,1] * matrixToCalculate[1,2]);

                    var secondValue = (matrixToCalculate[0, 2] * matrixToCalculate[1, 1] * matrixToCalculate[2, 0]) + (matrixToCalculate[1, 2] * matrixToCalculate[2, 1] * matrixToCalculate[0, 0]) 
                        + (matrixToCalculate[2, 2] * matrixToCalculate[1, 0] * matrixToCalculate[0, 1]);

                    result = firstValue - secondValue;
                }
            }
            else
            {
                throw new DiffrentSizeOfMarix();
            }

            return result;
        }

        public static double[,] Invert(this int[,] matrixToConvert)
        {
            double[,] result = new double[matrixToConvert.GetLength(0), matrixToConvert.GetLength(1)];
            int determinant = matrixToConvert.Determinant();
            if (matrixToConvert.GetLength(0) == matrixToConvert.GetLength(1))
            {
                if (determinant != 0)
                {
                    for (int i = 0; i < matrixToConvert.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrixToConvert.GetLength(1); j++)
                        {
                            result[i, j] = matrixToConvert.GetMinor(i, j).Determinant() * (1 / determinant);
                        }
                    }

                    return result;
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
    }
}
