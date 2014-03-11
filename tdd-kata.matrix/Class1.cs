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
        public void ICanAddTwoVectors()
        {
            int[] firstVector = { 1, 2, 3, 4 };
            int[] secondVector = { 1, 2, 3, 4 };
            int[] expected = {2,4,6,8};

            var result = AddTwoVectors(firstVector, secondVector);

            Assert.AreEqual(expected, result);
        }

        private int[] AddTwoVectors(int[] firstVector, int[] secondVector)
        {
            int[] sumeUp = new int[firstVector.Length];
            for (int i = 0; i < firstVector.Length; i++)
            {
                sumeUp[i] = firstVector[i] + secondVector[i];
            }
            return sumeUp;
        }
    }
}
