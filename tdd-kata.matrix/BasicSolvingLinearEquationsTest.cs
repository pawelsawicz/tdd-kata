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
            //arrange
            int[,] equationToSolve = { { 4, 4, 4 }, { 4, 8, 8 }, { 4, 8, 12 } };
            int[] values = { 0, -4, -16 };
            int[] expectedVariables = { 1, 2, -3 };

            //act
            int[] result = CramerSolve(equationToSolve, values);                      

            //assert
            Assert.AreEqual(expectedVariables, result);
        }

        private int[] CramerSolve(int[,] equationToSolve, int[] values)
        {
            var result = new int[equationToSolve.GetLength(0)];
            int mainDeterminant = equationToSolve.Determinant();

            for (int i = 0; i < equationToSolve.GetLength(0); i++)
            {
                int[,] matrix = new int[equationToSolve.GetLength(0), equationToSolve.GetLength(1)];
                Array.Copy(equationToSolve, matrix, equationToSolve.Length);                

                for (int j = 0; j < equationToSolve.GetLength(1); j++)
                {
                    matrix[j,i] = values[j];
                }

                result[i] = matrix.Determinant() / mainDeterminant;
            }

            return result;
        }
    }
}
