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
    public class NumericalIntegrationMethodsTest
    {
        [Test]
        public void GivenSinFunctionThenCalculateNumericIntegralAndReturnArea()
        {
            //arrange
            var lowerRange = 0;
            var upperRange = Math.PI;
            int countOfPoints = 4;
            double[] points = new double[countOfPoints + 1];
            double[] valuesOfFunction = new double[countOfPoints + 1];
            double sumOfAreas = 0;
            double expectedArea = 1.8961;

            //act
            var dx = (upperRange - lowerRange) / countOfPoints;
            for (int i = 0; i < points.GetLength(0); i++)
            {
                points[i] = lowerRange + (((double)i / (double)countOfPoints) * (upperRange - lowerRange));
            }

            for (int i = 0; i < points.GetLength(0); i++)
            {
                valuesOfFunction[i] = Math.Sin(points[i]);
            }

            double tempValue = 0;
            for (int i = 0; i < valuesOfFunction.GetLength(0); i++)
            {
                if (i <= countOfPoints - 1 && i != 0)
                {
                    tempValue += valuesOfFunction[i];
                }
                if (i > countOfPoints - 1)
                {
                    tempValue += (valuesOfFunction[0] + valuesOfFunction[i]) / 2;
                }
            }
            sumOfAreas = dx * tempValue;

            //assert
            sumOfAreas.Should().BeApproximately(expectedArea, 0.1);

        }
    }
}
