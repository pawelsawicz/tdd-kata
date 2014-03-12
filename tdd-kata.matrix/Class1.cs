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
        /* Theoretical intro
         * 
         * 
         * 
         * 
         * 
         * 
         */
        [Test]
        public void GivenTwoVectorsThenAdd()
        {
            int[] firstVector = { 1, 2, 3, 4 };
            int[] secondVector = { 1, 2, 3, 4 };
            int[] expectedVector = {2,4,6,8};

            var result = AddTwoVectors(firstVector, secondVector);

            Assert.AreEqual(expectedVector, result);
        }

        [Test]        
        public void IfVectorDimentionAreNotEqual()
        {
            int[] firstVector = { 1, 2, 3 };
            int[] secondVector = { 1, 2 };            

            Assert.Throws<DiffrentDimensionException>(() => AddTwoVectors(firstVector, secondVector));
        }

        [Test]
        public void GivenTwoVectorsThenSubtract()
        {
            int[] firstVector = { 1, 2, 3, 4 };
            int[] secondVector = { 2, 3, 4, 5 };
            int[] expectedVector = { -1, -1, -1, -1 };

            var result = SubtractTwoVectors(firstVector, secondVector);

            Assert.AreEqual(expectedVector, result);

        }

        [Test]
        public void GivenVectorAndNumberThenMultiply()
        {
            int[] vector = { 1, 2, 3, 4 };
            int number = 5;
            int[] expectedVector = { 5, 10, 15, 20 };


            var result = MultiplyVectorByNumber(vector, number);

            Assert.AreEqual(expectedVector, result);
        }

        private int[] MultiplyVectorByNumber(int[] firstVector, int number)
        {

            int[] multiplied = new int[firstVector.Length];

            for (int i = 0; i < firstVector.Length; i++)
            {
                multiplied[i] = firstVector[i] * number;
            }

            return multiplied;
        }

        private int[] SubtractTwoVectors(int[] firstVector, int[] secondVector)
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


        private int[] AddTwoVectors(int[] firstVector, int[] secondVector)
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

        public class DiffrentDimensionException : Exception
        {

        }
    }
}
