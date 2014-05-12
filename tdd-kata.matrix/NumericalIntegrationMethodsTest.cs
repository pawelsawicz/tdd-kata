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
        public void GivenSinFunctionThenCalculateNumericIntegralByTrapezoidalAndReturnArea()
        {
            //arrange   
            double expectedArea = 1.8961;
            double lowerRange = 0;
            double upperRange = Math.PI;
            int countOfPoints = 4;

            //act
            var result = TrapezoidalMethod(lowerRange, upperRange, countOfPoints);

            //assert
            result.Should().BeApproximately(expectedArea, 0.1);

        }

        private double TrapezoidalMethod(double lowerRange, double upperRange, int countOfPoints)
        {
            double result = 0;
            double[] points = new double[countOfPoints + 1];
            double[] valuesOfFunction = new double[countOfPoints + 1];
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
            result = dx * tempValue;

            return result;
        }
    }
}
