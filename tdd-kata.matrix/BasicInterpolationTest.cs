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
    public class BasicInterpolationTest
    {
        [Test]
        public void GivenSetOfTemperaturesThenInterpolateByLagrangeValue()
        {
            //arrange
            double[] interpolationNodes = { 12, 13, 14, 15, 16 };
            double[] valuesOfFunctionForNodes = { 24, 25, 23, 20, 16 };
            double lookingArgument = 14.5;
            double expectedValue = 21.6;

            //act
            var result = LagrangeInterpolationMethod(interpolationNodes, valuesOfFunctionForNodes, lookingArgument);

            //assert
            result.Should().BeApproximately(expectedValue, 0.1);
        }

        private double LagrangeInterpolationMethod(double[] interpolationNodes, double[] valuesOfFunctionForNodes, double lookingArgument)
        {           
            double result = 0;

            double firstSectionOfEquation = 1;
            for (int i = 0; i < interpolationNodes.GetLength(0); i++)
            {
                firstSectionOfEquation *= (lookingArgument - interpolationNodes[i]);
            }

            double secondSectionOfEquation = 0;

            for (int i = 0; i < valuesOfFunctionForNodes.GetLength(0); i++)
            {
                double denominator = 1;
                for (int j = 0; j < interpolationNodes.GetLength(0); j++)
                {
                    if (i != j)
                    {
                        denominator *= interpolationNodes[i] - interpolationNodes[j];
                    }
                    else
                    {
                        denominator *= lookingArgument - interpolationNodes[i];
                    }
                }

                secondSectionOfEquation += (valuesOfFunctionForNodes[i]) / (denominator);
            }

            result = firstSectionOfEquation * secondSectionOfEquation;

            return result;
        }
    }
}
