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
        public void GivenSetOfTemperaturesThenInterpolateApproximateValue()
        {
            double[] interpolateNodes = { 12, 13, 14, 15, 16 };
            double[] valuesFunctionOfNodes = { 24, 25, 23, 20, 16 };
            double lookingArgument = 14.5;
            double expectedValue = 21.6;

            double result = 0;

            double firstValue = 1;
            for (int i = 0; i < interpolateNodes.GetLength(0); i++)
            {
                firstValue *= (lookingArgument - interpolateNodes[i]);
            }

            double secondValue = 0;

            for (int i = 0; i < valuesFunctionOfNodes.GetLength(0); i++)
            {
                double thirdValue = 1;
                for (int j = 0; j < interpolateNodes.GetLength(0); j++)
                {
                    if (i != j)
                    {
                        thirdValue *= interpolateNodes[i] - interpolateNodes[j];
                    }
                    else
                    {
                        thirdValue *= lookingArgument - interpolateNodes[i];
                    }
                }

                secondValue += (valuesFunctionOfNodes[i]) / (thirdValue);
            }

            result = firstValue * secondValue;

            result.Should().BeApproximately(expectedValue, 0.1);
        }
    }
}
