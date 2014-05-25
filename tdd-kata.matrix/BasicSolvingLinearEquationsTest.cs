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
                    matrix[j,i] = values[j];
                }

                result[i] = matrix.Determinant() / mainDeterminant;
            }

            return result;
        }
    }
}
