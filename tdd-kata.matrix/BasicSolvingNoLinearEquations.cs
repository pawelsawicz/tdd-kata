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
    public class BasicSolvingNoLinearEquations
    {       

        [Test]
        public void GivenNoLinearFunctionAsVectorThenCalculateValue()
        {
            double[] functionToCalculate = { -5, -1, 1 };
            int argumentOfFunction = 1;
            double expectedResult = -5;

            var result = GetFunctionValue(functionToCalculate, argumentOfFunction);

            result.Should().Be(expectedResult);

        }

        [Test]
        public void GivenNoLinearFunctionThirdDegreeAsVectorThenCalculateValue()
        {
            double[] functionToCalculate = { -3, -5, -2, -3 };
            int argumentOfFunction = 2;
            double expectedValue = -45;

            var result = GetFunctionValue(functionToCalculate, argumentOfFunction);

            result.Should().Be(expectedValue);
        }

        private double GetFunctionValue(double[] functionToCalculate, int argumentOfFunction)
        {
            double result = 0.0;

            for (int i = 0; i < functionToCalculate.GetLength(0); i++)
            {
                if (i == 0)
                {
                    result += functionToCalculate[i];
                }
                else
                {
                    result += (functionToCalculate[i] * Math.Pow(argumentOfFunction, i));
                }
            }

            return result;
        }
    }
}
