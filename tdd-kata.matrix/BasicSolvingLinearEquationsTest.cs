using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace tdd_kata.matrix
{
    [TestFixture]
    public class BasicSolvingLinearEquationsTest
    {
        [Test]
        public void GivenTwoLinearEquationsThenSolveItByCramerAndReturnValue()
        {
            int[,] equationToSolve = { { 4, 4, 4 }, { 4, 8, 8 }, { 4, 8, 12 } };
            int[] values = { 0, -4, -16 };
            int[] expectedVariables = { 1, 2, -3 };

            int[] result = new int[equationToSolve.GetLength(0)];
            int mainDeterminant = equationToSolve.Determinant();
            int xDeterminant = 0;
            int[,] xMatrix = { { 4, 4, 4 }, { 4, 8, 8 }, { 4, 8, 12 } };
            int yDeterminant = 0;
            int[,] yMatrix = { { 4, 4, 4 }, { 4, 8, 8 }, { 4, 8, 12 } };
            int zDeterminant = 0;
            int[,] zMatrix = { { 4, 4, 4 }, { 4, 8, 8 }, { 4, 8, 12 } };

            for (int i = 0; i < equationToSolve.GetLength(1); i++)
            {
                xMatrix[i, 0] = values[i];
            }

            xDeterminant = xMatrix.Determinant();

            for (int i = 0; i < equationToSolve.GetLength(1); i++)
            {
                yMatrix[i, 1] = values[i];
            }

            yDeterminant = yMatrix.Determinant();

            for (int i = 0; i < equationToSolve.GetLength(1); i++)
            {
                zMatrix[i, 2] = values[i];
            }

            zDeterminant = zMatrix.Determinant();

            result[0] = xDeterminant / mainDeterminant;
            result[1] = yDeterminant / mainDeterminant;
            result[2] = zDeterminant / mainDeterminant;

            Assert.AreEqual(expectedVariables, result);

        }
    }
}
