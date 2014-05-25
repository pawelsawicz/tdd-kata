using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
namespace tdd_kata.matrix
{
    [TestFixture]
    public class BasicSolvingLinearEquationsTest
    {
        [Test]
        public void GivenThreeLinearEquationsThenSolveItByCramerAndReturnSolution()
        {
            //arrange
            int[,] equationToSolve = { { 2, 1, 3 }, { 1, 6, 7 }, { 3, 7, 9 } };
            int[] values = { 2, -1, 2 };
            double[] expectedVariables = { 2.2, 0.7, -1 };

            //act
            double[] result = CramerSolve(equationToSolve, values);

            //assert
            result[0].Should().BeApproximately(expectedVariables[0], 0.1);
            result[1].Should().BeApproximately(expectedVariables[1], 0.1);
            result[2].Should().BeApproximately(expectedVariables[2], 0.1);
        }

        [Test]
        public void GivenThreeLinearEquationsThenSolveItByDecomposeAndReturnsolution()
        {
            int[,] equationToSolve = { { 4, -2, 4, -2 }, { 3, 1, 4, 2 }, { 2, 4, 2, 1 }, { 2, -2, 4, 2 } };
            double[] values = { 8, 7, 10, 2 };
            double[] expectedSolve = { -1, 2, 3, -2 };

            var result = DecomposeSolve(equationToSolve, values);

            result[0].Should().BeApproximately(expectedSolve[0], 0.1);
            result[1].Should().BeApproximately(expectedSolve[1], 0.1);
            result[2].Should().BeApproximately(expectedSolve[2], 0.1);
            result[3].Should().BeApproximately(expectedSolve[3], 0.1);

        }

        private double[] CramerSolve(int[,] equationToSolve, int[] values)
        {
            var result = new double[equationToSolve.GetLength(0)];
            var mainDeterminant = equationToSolve.Determinant();

            for (int i = 0; i < equationToSolve.GetLength(0); i++)
            {
                int[,] matrix = new int[equationToSolve.GetLength(0), equationToSolve.GetLength(1)];
                Array.Copy(equationToSolve, matrix, equationToSolve.Length);

                for (int j = 0; j < equationToSolve.GetLength(1); j++)
                {
                    matrix[j, i] = values[j];
                }

                result[i] = matrix.Determinant() / mainDeterminant;
            }

            return result;
        }

        private double[] DecomposeSolve(int[,] equationToSolve, double[] values)
        {
            var yVector = new double[equationToSolve.GetLength(0)];
            var xVector = new double[equationToSolve.GetLength(0)];
            var decomposedMatrix = equationToSolve.Decompose();            

            for (int i = 0; i < equationToSolve.GetLength(0); i++)
            {
                if (i == 0)
                {
                    yVector[i] = values[i];
                }
                else
                {
                    double tempSum = 0.0;

                    for (int j = 0; j <= i; j++)
                    {
                        tempSum += (decomposedMatrix.LowerTriangleMatrix[i, j] * yVector[j]);
                    }

                    yVector[i] = values[i] - tempSum;
                }
            }

            for (int i = equationToSolve.GetLength(0) - 1; i >= 0; i--)
            {
                if (i == equationToSolve.GetLength(0) - 1)
                {
                    xVector[i] = yVector[i] / decomposedMatrix.UpperTriangleMatrix[i, i];
                }
                else
                {
                    double tempSum = 0.0;
                    for (int j = i + 1; j < equationToSolve.GetLength(0); j++)
                    {
                        tempSum += decomposedMatrix.UpperTriangleMatrix[i, j] * xVector[j];
                    }

                    xVector[i] = (1 / decomposedMatrix.UpperTriangleMatrix[i, i]) * (yVector[i] - tempSum);
                }
            }

            return xVector;
        }
    }
}
