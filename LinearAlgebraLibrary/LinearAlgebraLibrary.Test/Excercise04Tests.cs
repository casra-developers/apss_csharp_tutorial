using System;
using LinearAlgebraLibrary.Exercise;
using NUnit.Framework;

namespace LinearAlgebraLibrary.Test
{
    public class Excercise04_Tests
    {
        [Test]
        public void Ex04_Task01_Dimensions()
        {
            // create test vector
            var vector = LinearAlgebraFactory.MakeVector(1, 2, 3, 5);

            // check if vector has proper dimensionality
            Assert.AreEqual(4, vector.Dimensions);

            // create test vector
            vector = LinearAlgebraFactory.MakeVector(1, 2, 3);

            // check if vector has proper dimensionality
            Assert.AreEqual(3, vector.Dimensions);

            // create test vector
            vector = LinearAlgebraFactory.MakeVector(1, 2);

            // check if vector has proper dimensionality
            Assert.AreEqual(2, vector.Dimensions);

            // create test vector
            vector = LinearAlgebraFactory.MakeVector(1);

            // check if vector has proper dimensionality
            Assert.AreEqual(1, vector.Dimensions);
        }

        [Test]
        public void Ex04_Task02_L2Norm()
        {
            // check if vector has proper length
            Assert.AreEqual(Math.Sqrt(50), LinearAlgebraFactory.MakeVector(4, 3, 5).Length, double.Epsilon);

            // create test vector
            Assert.AreEqual(5, LinearAlgebraFactory.MakeVector(4, 3).Length, double.Epsilon);

            // check if vector has proper length
            Assert.AreEqual(10, LinearAlgebraFactory.MakeVector(1, 5, 7, 4, 3).Length, double.Epsilon);
        }

        [Test]
        public void Ex04_Task03_Adding()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector(1.2, 2, 4);
            var b = LinearAlgebraFactory.MakeVector(6, 0.7, -3);

            // check if sum is correct
            AssertionTools.AssertVector(a.Add(b), 7.2, 2.7, 1);

            // check if sum is correct
            AssertionTools.AssertVector(a.Add(b).Add(a), 8.4, 4.7, 5);

            // check if sum is correct
            AssertionTools.AssertVector(a.Add(b).Add(a).Add(b), 14.4, 5.4, 2);

            // create test vectors
            a = LinearAlgebraFactory.MakeVector(1.2, 2, 4, 5, 10);
            b = LinearAlgebraFactory.MakeVector(6, 0.7, -3, 6, 10);

            // check if sum is correct
            AssertionTools.AssertVector(a.Add(b), 7.2, 2.7, 1, 11, 20);
        }

        [Test]
        public void Ex04_Task03_Adding_NonMatchingDimensions()
        {
            // test edge cases
            var a = LinearAlgebraFactory.MakeVector(1.2, 2, 4);
            var b = LinearAlgebraFactory.MakeVector(6, 0.7);

            Assert.Throws<ArgumentException>(() => a.Add(b));
        }

        [Test]
        public void Ex04_Task04_Subtracting()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector(2, 6, 3);
            var b = LinearAlgebraFactory.MakeVector(6, -2.5, 3);

            // check if result is correct
            AssertionTools.AssertVector(a.Subtract(b), -4, 8.5, 0);

            // check if result is correct
            AssertionTools.AssertVector(a.Subtract(b).Subtract(a), -6, 2.5, -3);

            // create test vectors
            a = LinearAlgebraFactory.MakeVector(1.2, 2, 4, 5, 10);
            b = LinearAlgebraFactory.MakeVector(6, 0.7, -3, 6, 10);

            // check if sum is correct
            AssertionTools.AssertVector(a.Subtract(b), -4.8, 1.3, 7, -1, 0);
        }

        [Test]
        public void Ex04_Task04_Subtracting_NonMatchingDimensions()
        {
            // test edge cases
            var a = LinearAlgebraFactory.MakeVector(1.2, 2, 4);
            var b = LinearAlgebraFactory.MakeVector(6, 0.7);

            Assert.Throws<ArgumentException>(() => a.Subtract(b));
        }

        [Test]
        public void Ex04_Task05_ScalarMultiplication()
        {
            // create test data
            var vector = LinearAlgebraFactory.MakeVector(2, 6, -3);
            var scalar = 0.5;

            // check if result is correct
            AssertionTools.AssertVector(vector.Multiply(scalar), 1, 3, -1.5);

            // check if result is correct
            AssertionTools.AssertVector(vector.Multiply(scalar).Multiply(scalar), 0.5, 1.5, -0.75);

            // check if result is correct
            AssertionTools.AssertVector(vector.Multiply(scalar).Multiply(scalar).Multiply(-10), -5, -15, 7.5);

            vector = LinearAlgebraFactory.MakeVector(2, 6, -3, 7, 2, 1);
            AssertionTools.AssertVector(vector.Multiply(2), 4, 12, -6, 14, 4, 2);
        }

        [Test]
        public void Ex04_Task06_DotProduct()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector(2, 0, 1);
            var b = LinearAlgebraFactory.MakeVector(0, -3.4, 0);

            // check if result is correct
            Assert.AreEqual(0, a.DotProduct(b), double.Epsilon);

            // check if result is correct
            a = LinearAlgebraFactory.MakeVector(2, 5, 3.3);
            b = LinearAlgebraFactory.MakeVector(4, -3.4, 0.9);
            Assert.AreEqual(-6.03, a.DotProduct(b), double.Epsilon);

            // check if result is correct
            a = LinearAlgebraFactory.MakeVector(2, 5, 3.3, 5);
            b = LinearAlgebraFactory.MakeVector(4, -3.4, 0.9, 6);
            Assert.AreEqual(23.97, a.DotProduct(b), double.Epsilon);
        }

        [Test]
        public void Ex04_Task06_DotProduct_NonMatchingDimensions()
        {
            // test edge cases
            var a = LinearAlgebraFactory.MakeVector(1.2, 2, 4);
            var b = LinearAlgebraFactory.MakeVector(6, 0.7);

            Assert.Throws<ArgumentException>(() => a.DotProduct(b));
        }

        [Test]
        public void Ex04_Task07_AddingOperator()
        {
            // create test vectors
            var a = new Vector(1.2, 2, 4);
            var b = new Vector(6, 0.7, -3);

            // check if sum is correct
            AssertionTools.AssertVector(a + b, 7.2, 2.7, 1);

            // create test vectors
            a = new Vector(-1.2, 2, -4);
            b = new Vector(6, -0.7, 3);

            // check if sum is correct
            AssertionTools.AssertVector(a + b, 4.8, 1.3, -1);
        }

        [Test]
        public void Ex04_Task08_SubtractingOperator()
        {
            // create test vectors
            var a = new Vector(2, 6, 3);
            var b = new Vector(6, -2.5, 3);

            // check if result is correct
            AssertionTools.AssertVector(a - b, -4, 8.5, 0);
        }

        [Test]
        public void Ex04_Task09_ScalarMultiplicationOperator()
        {
            // create test data
            var vector = new Vector(2, 6, -3);
            var scalar = 0.5;

            // check if result is correct
            AssertionTools.AssertVector(vector * scalar, 1, 3, -1.5);
        }

        [Test]
        public void Ex04_Task10_TryGetVector23()
        {
            var vector2 = LinearAlgebraFactory.MakeVector(4, 2);
            var vector3 = LinearAlgebraFactory.MakeVector(5, 1, 6);

            // test valid cases
            Assert.True(vector2.TryGetVector2(out var vector2Result));
            Assert.NotNull(vector2Result);
            AssertionTools.AssertVector(4, 2, vector2Result);

            Assert.True(vector3.TryGetVector3(out var vector3Result));
            Assert.NotNull(vector3Result);
            AssertionTools.AssertVector(5, 1, 6, vector3Result);

            // test invalid cases
            Assert.False(vector2.TryGetVector3(out var fail3));
            Assert.Null(fail3);

            Assert.False(vector3.TryGetVector2(out var fail2));
            Assert.Null(fail2);
        }

        [Test]
        public void Ex04_Task11_FromVector23()
        {
            var vector2 = LinearAlgebraFactory.MakeVector2(4, 2);
            var vector3 = LinearAlgebraFactory.MakeVector3(5, 1, 6);

            AssertionTools.AssertVector(Vector.FromVector2(vector2), 2, 4);
            AssertionTools.AssertVector(Vector.FromVector3(vector3), 5, 1, 6);
        }

        [Test]
        public void Ex04_Task12_OperatorOverloads_3d()
        {
            // ADD
            // create test vectors
            var a = new Vector(1.2, 2, 4);
            var b = LinearAlgebraFactory.MakeVector3(6, 0.7, -3);
            AssertionTools.AssertVector(a + b, 7.2, 2.7, 1);


            // SUBTRACT
            // create test vectors
            a = new Vector(2, 6, 3);
            b = LinearAlgebraFactory.MakeVector3(6, -2.5, 3);

            // check if result is correct
            AssertionTools.AssertVector(a - b, -4, 8.5, 0);


            // DOT PRODUCT
            // create test vectors
            a = new Vector(2, 0, 1);
            b = LinearAlgebraFactory.MakeVector3(0, -3.4, 0);

            // check if result is correct
            Assert.AreEqual(0, a.DotProduct(b), double.Epsilon);
        }


        [Test]
        public void Ex04_Task12_OperatorOverloads_2d()
        {
            // ADD
            // create test vectors
            var a = new Vector(1.2, 2);
            var b = LinearAlgebraFactory.MakeVector2(6, 0.7);
            AssertionTools.AssertVector(a + b, 7.2, 2.7);


            // SUBTRACT
            // create test vectors
            a = new Vector(2, 6);
            b = LinearAlgebraFactory.MakeVector2(6, -2.5);

            // check if result is correct
            AssertionTools.AssertVector(a - b, -4, 8.5);


            // DOT PRODUCT
            // create test vectors
            a = new Vector(2, 0);
            b = LinearAlgebraFactory.MakeVector2(0, -3.4);

            // check if result is correct
            Assert.AreEqual(0, a.DotProduct(b), double.Epsilon);
        }
    }
}
