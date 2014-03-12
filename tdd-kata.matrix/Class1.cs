using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace tdd_kata.matrix
{
    [TestFixture]
    public class Class1
    {

        private IVectorOperations _vectorOperations { get; set; }

        /* Theoretical intro
         * 
         * 
         * 
         * 
         * 
         * 
         */

        [SetUp]
        public void SetUp()
        {
            _vectorOperations = new VectorOperations();
        }


        [Test]
        public void GivenTwoVectorsThenAdd()
        {
            int[] firstVector = { 1, 2, 3, 4 };
            int[] secondVector = { 1, 2, 3, 4 };
            int[] expectedVector = {2,4,6,8};

            var result = _vectorOperations.AddTwoVectors(firstVector, secondVector);

            Assert.AreEqual(expectedVector, result);
        }

        [Test]        
        public void IfVectorDimentionAreNotEqual()
        {
            int[] firstVector = { 1, 2, 3 };
            int[] secondVector = { 1, 2 };

            Assert.Throws<DiffrentDimensionException>(() => _vectorOperations.AddTwoVectors(firstVector, secondVector));
        }

        [Test]
        public void GivenTwoVectorsThenSubtract()
        {
            int[] firstVector = { 1, 2, 3, 4 };
            int[] secondVector = { 2, 3, 4, 5 };
            int[] expectedVector = { -1, -1, -1, -1 };

            var result = _vectorOperations.SubtractTwoVectors(firstVector, secondVector);

            Assert.AreEqual(expectedVector, result);

        }

        [Test]
        public void GivenVectorAndNumberThenMultiply()
        {
            int[] vector = { 1, 2, 3, 4 };
            int number = 5;
            int[] expectedVector = { 5, 10, 15, 20 };


            var result = _vectorOperations.MultiplyVectorByNumber(vector, number);

            Assert.AreEqual(expectedVector, result);
        }

        [Test]
        public void GivenTwoVectorsThenScalarMultiply()
        {
            int[] firstVector = { 1, 2, 3, 4 };
            int[] secondVector = { 7, 3, 7, 5 };
            int expectedValue = 54;

            var result = _vectorOperations.ScalarMultiply(firstVector, secondVector);

            Assert.AreEqual(expectedValue, result);
        }

        [Test]
        public void GivenVectorThenFindLenght()
        {
            int[] vector = { 2, 2, 1 };
            double expectedLenghtOfVector = 3;

            var result = _vectorOperations.LenghtOfVector(vector);

            Assert.AreEqual(expectedLenghtOfVector, result);
        }        

        public interface IVectorOperations
        {
            double LenghtOfVector(int[] vector);
            int ScalarMultiply(int[] firstVector, int[] secondVector);
            int[] MultiplyVectorByNumber(int[] firstVector, int number);
            int[] SubtractTwoVectors(int[] firstVector, int[] secondVector);
            int[] AddTwoVectors(int[] firstVector, int[] secondVector);
        }

        public class VectorOperations : IVectorOperations
        {

            public double LenghtOfVector(int[] vector)
            {
                double sumUp = 0;
                for (int i = 0; i < vector.Length; i++)
                {
                    sumUp += vector[i] * vector[i];
                }

                return Math.Sqrt(sumUp);
            }

            public int ScalarMultiply(int[] firstVector, int[] secondVector)
            {
                int result = 0;

                for (int i = 0; i < firstVector.Length; i++)
                {
                    result += firstVector[i] * secondVector[i];
                }

                return result;
            }

            public int[] MultiplyVectorByNumber(int[] firstVector, int number)
            {
                int[] multiplied = new int[firstVector.Length];

                for (int i = 0; i < firstVector.Length; i++)
                {
                    multiplied[i] = firstVector[i] * number;
                }

                return multiplied;
            }

            public int[] SubtractTwoVectors(int[] firstVector, int[] secondVector)
            {
                if (firstVector.Length != secondVector.Length)
                {
                    throw new DiffrentDimensionException();
                }

                int[] subtracted = new int[firstVector.Length];

                for (int i = 0; i < firstVector.Length; i++)
                {
                    subtracted[i] = firstVector[i] - secondVector[i];
                }

                return subtracted;
            }

            public int[] AddTwoVectors(int[] firstVector, int[] secondVector)
            {
                if (firstVector.Length != secondVector.Length)
                {
                    throw new DiffrentDimensionException();
                }

                int[] sumeUp = new int[firstVector.Length];

                for (int i = 0; i < firstVector.Length; i++)
                {
                    sumeUp[i] = firstVector[i] + secondVector[i];
                }
                return sumeUp;
            }
        }

        public class DiffrentDimensionException : Exception
        {

        }
    }
}
