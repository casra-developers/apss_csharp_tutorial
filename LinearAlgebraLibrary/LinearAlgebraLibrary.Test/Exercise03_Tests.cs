using System;
using LinearAlgebraLibrary.Exercise;
using NUnit.Framework;

namespace LinearAlgebraLibrary.Test
{
    public class Exercise03_Tests
    {
        [Test]
        public void Ex03_Task01_Dimensions()
        {
            // create test vector
            var vector = LinearAlgebraFactory.MakeVector3(1, 2, 3);

            // check if vector has proper dimensionality
            Assert.AreEqual(3, vector.Dimensions);
        }

        [Test]
        public void Ex03_Task02_L2Norm()
        {
            // create test vector
            var vector = LinearAlgebraFactory.MakeVector3(4, 3, 5);
            var expectedResult = Math.Sqrt(50);

            // check if vector has proper length
            Assert.AreEqual(expectedResult, vector.Length, double.Epsilon);

            // create test vector
            vector = LinearAlgebraFactory.MakeVector3(4, -3, 5);

            // check if vector has proper length
            Assert.AreEqual(expectedResult, vector.Length, double.Epsilon);

            // create test vector
            vector = LinearAlgebraFactory.MakeVector3(-4, -3, 5);

            // check if vector has proper length
            Assert.AreEqual(expectedResult, vector.Length, double.Epsilon);

            // create test vector
            vector = LinearAlgebraFactory.MakeVector3(-4, 3, 5);

            // check if vector has proper length
            Assert.AreEqual(expectedResult, vector.Length, double.Epsilon);
        }

        [Test]
        public void Ex03_Task03_Adding()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector3(1.2, 2, 4);
            var b = LinearAlgebraFactory.MakeVector3(6, 0.7, -3);

            // check if sum is correct
            AssertionTools.AssertVector(7.2, 2.7, 1, a.Add(b));

            // check if sum is correct
            AssertionTools.AssertVector(8.4, 4.7, 5, a.Add(b).Add(a));

            // check if sum is correct
            AssertionTools.AssertVector(14.4, 5.4, 2, a.Add(b).Add(a).Add(b));

            // create test vectors
            a = LinearAlgebraFactory.MakeVector3(-1.2, 2, -4);
            b = LinearAlgebraFactory.MakeVector3(6, -0.7, 3);

            // check if sum is correct
            AssertionTools.AssertVector(4.8, 1.3, -1, a.Add(b));

            // test if instances are handled correctly
            var c = a.Add(b);
            AssertionTools.AssertDistinctInstances(a, c);
            AssertionTools.AssertDistinctInstances(b, c);
        }

        [Test]
        public void Ex03_Task04_Subtracting()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector3(2, 6, 3);
            var b = LinearAlgebraFactory.MakeVector3(6, -2.5, 3);

            // check if result is correct
            AssertionTools.AssertVector(-4, 8.5, 0, a.Subtract(b));

            // check if result is correct
            AssertionTools.AssertVector(-6, 2.5, -3, a.Subtract(b).Subtract(a));

            // test if instances are handled correctly
            var c = a.Subtract(b);
            AssertionTools.AssertDistinctInstances(a, c);
            AssertionTools.AssertDistinctInstances(b, c);
        }

        [Test]
        public void Ex03_Task05_ScalarMultiplication()
        {
            // create test data
            var vector = LinearAlgebraFactory.MakeVector3(2, 6, -3);
            var scalar = 0.5;

            // check if result is correct
            AssertionTools.AssertVector(1, 3, -1.5, vector.Multiply(scalar));

            // check if result is correct
            AssertionTools.AssertVector(0.5, 1.5, -0.75, vector.Multiply(scalar).Multiply(scalar));

            // check if result is correct
            AssertionTools.AssertVector(-5, -15, 7.5, vector.Multiply(scalar).Multiply(scalar).Multiply(-10));

            // test if instances are handled correctly
            var b = vector.Multiply(scalar);
            AssertionTools.AssertDistinctInstances(vector, b);
        }

        [Test]
        public void Ex03_Task06_DotProduct()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector3(2, 0, 1);
            var b = LinearAlgebraFactory.MakeVector3(0, -3.4, 0);

            // check if result is correct
            Assert.AreEqual(0, a.DotProduct(b), double.Epsilon);

            // check if result is correct
            a = LinearAlgebraFactory.MakeVector3(2, 5, 3.3);
            b = LinearAlgebraFactory.MakeVector3(4, -3.4, 0.9);
            Assert.AreEqual(-6.03, a.DotProduct(b), double.Epsilon);
        }

        [Test]
        public void Ex03_Task07_CrossProduct()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector3(1, 0, 0);
            var b = LinearAlgebraFactory.MakeVector3(0, 1, 0);

            // check if result is correct
            AssertionTools.AssertVector(0, 0, 1, a.CrossProduct(b));

            // check if result is correct
            a = LinearAlgebraFactory.MakeVector3(2, 5, 6);
            b = LinearAlgebraFactory.MakeVector3(4, -3.4, 9);
            AssertionTools.AssertVector(65.4, 6,-26.8, a.CrossProduct(b));

            // test if instances are handled correctly
            var c = a.CrossProduct(b);
            AssertionTools.AssertDistinctInstances(a, c);
            AssertionTools.AssertDistinctInstances(b, c);
        }

        [Test]
        public void Ex03_Task08_AddingOperator()
        {
            // create test vectors
            var a = new Vector3(1.2, 2, 4);
            var b = new Vector3(6, 0.7, -3);

            // check if sum is correct
            AssertionTools.AssertVector(7.2, 2.7, 1, a + b);

            // create test vectors
            a = new Vector3(-1.2, 2, -4);
            b = new Vector3(6, -0.7, 3);

            // check if sum is correct
            AssertionTools.AssertVector(4.8, 1.3, -1, a + b);

            // test if instances are handled correctly
            var c = a + b;
            AssertionTools.AssertDistinctInstances(a, c);
            AssertionTools.AssertDistinctInstances(b, c);
        }

        [Test]
        public void Ex03_Task09_SubtractingOperator()
        {
            // create test vectors
            var a = new Vector3(2, 6, 3);
            var b = new Vector3(6, -2.5, 3);

            // check if result is correct
            AssertionTools.AssertVector(-4, 8.5, 0,a - b);

            // test if instances are handled correctly
            var c = a + b;
            AssertionTools.AssertDistinctInstances(a, c);
            AssertionTools.AssertDistinctInstances(b, c);
        }

        [Test]
        public void Ex03_Task10_ScalarMultiplicationOperator()
        {
            // create test data
            var vector = new Vector3(2, 6, -3);
            var scalar = 0.5;

            // check if result is correct
            AssertionTools.AssertVector(1, 3, -1.5, vector * scalar);

            // test if instances are handled correctly
            var b = vector * scalar;
            AssertionTools.AssertDistinctInstances(vector, b);
        }
    }
}
