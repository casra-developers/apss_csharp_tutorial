using LinearAlgebraLibrary.Exercise;
using NUnit.Framework;

namespace LinearAlgebraLibrary.Test
{
    public class Excercise02_Tests
    {
        [Test]
        public void Ex02_Task01_Dimensions()
        {
            // create test vector
            var vector = LinearAlgebraFactory.MakeVector2(1, 2);

            // check if vector has proper dimensionality
            Assert.AreEqual(2, vector.Dimensions);
        }

        [Test]
        public void Ex02_Task02_L2Norm()
        {
            // create test vector
            var vector = LinearAlgebraFactory.MakeVector2(4, 3);

            // check if vector has proper length
            Assert.AreEqual(5, vector.Length, double.Epsilon);

            // create test vector
            vector = LinearAlgebraFactory.MakeVector2(4, -3);

            // check if vector has proper length
            Assert.AreEqual(5, vector.Length, double.Epsilon);

            // create test vector
            vector = LinearAlgebraFactory.MakeVector2(-4, -3);

            // check if vector has proper length
            Assert.AreEqual(5, vector.Length, double.Epsilon);

            // create test vector
            vector = LinearAlgebraFactory.MakeVector2(-4, 3);

            // check if vector has proper length
            Assert.AreEqual(5, vector.Length, double.Epsilon);
        }

        [Test]
        public void Ex02_Task03_Adding()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector2(1.2, 2);
            var b = LinearAlgebraFactory.MakeVector2(6, 0.7);

            // check if sum is correct
            AssertionTools.AssertVector(7.2, 2.7, a.Add(b));

            // check if sum is correct
            AssertionTools.AssertVector(8.4, 4.7, a.Add(b).Add(a));

            // check if sum is correct
            AssertionTools.AssertVector(14.4, 5.4, a.Add(b).Add(a).Add(b));

            // create test vectors
            a = LinearAlgebraFactory.MakeVector2(-1.2, 2);
            b = LinearAlgebraFactory.MakeVector2(6, -0.7);

            // check if sum is correct
            AssertionTools.AssertVector(4.8, 1.3, a.Add(b));
        }

        [Test]
        public void Ex02_Task03_Adding_InstanceCheck()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector2(1.2, 2);
            var b = LinearAlgebraFactory.MakeVector2(6, 0.7);
            var c = a.Add(b);
            AssertionTools.AssertDistinctInstances(a, c);
            AssertionTools.AssertDistinctInstances(b, c);
        }

        [Test]
        public void Ex02_Task04_Subtracting()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector2(2, 6);
            var b = LinearAlgebraFactory.MakeVector2(6, -2.5);

            // check if result is correct
            AssertionTools.AssertVector(-4, 8.5, a.Subtract(b));

            // check if result is correct
            AssertionTools.AssertVector(-6, 2.5, a.Subtract(b).Subtract(a));
        }

        [Test]
        public void Ex02_Task04_Subtracting_InstanceCheck()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector2(1.2, 2);
            var b = LinearAlgebraFactory.MakeVector2(6, 0.7);
            var c = a.Subtract(b);
            AssertionTools.AssertDistinctInstances(a, c);
            AssertionTools.AssertDistinctInstances(b, c);
        }

        [Test]
        public void Ex02_Task05_ScalarMultiplication()
        {
            // create test data
            var vector = LinearAlgebraFactory.MakeVector2(2, 6);
            var scalar = 0.5;

            // check if result is correct
            AssertionTools.AssertVector(1, 3, vector.Multiply(scalar));

            // check if result is correct
            AssertionTools.AssertVector(0.5, 1.5, vector.Multiply(scalar).Multiply(scalar));

            // check if result is correct
            AssertionTools.AssertVector(-5, -15, vector.Multiply(scalar).Multiply(scalar).Multiply(-10));
        }

        [Test]
        public void Ex02_Task05_ScalarMultiplication_InstanceCheck()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector2(1.2, 2);
            var c = a.Multiply(3);
            AssertionTools.AssertDistinctInstances(a, c);
        }

        [Test]
        public void Ex02_Task06_DotProduct()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector2(2, 0);
            var b = LinearAlgebraFactory.MakeVector2(0, -3.4);

            // check if result is correct
            Assert.AreEqual(0, a.DotProduct(b), double.Epsilon);

            // check if result is correct
            a = LinearAlgebraFactory.MakeVector2(2, 5);
            b = LinearAlgebraFactory.MakeVector2(4, -3.4);
            Assert.AreEqual(-9, a.DotProduct(b), double.Epsilon);
        }

        [Test]
        public void Ex02_Task07_PseudoCrossProduct()
        {
            // create test vectors
            var a = LinearAlgebraFactory.MakeVector2(2, 0);
            var b = LinearAlgebraFactory.MakeVector2(0, -3.4);

            // check if result is correct
            Assert.AreEqual(-6.8, a.CrossProduct(b), double.Epsilon);

            // check if result is correct
            a = LinearAlgebraFactory.MakeVector2(2, 5);
            b = LinearAlgebraFactory.MakeVector2(4, -3.4);
            Assert.AreEqual(-26.8, a.CrossProduct(b), double.Epsilon);
        }

        [Test]
        public void Ex02_Task08_AddingOperator()
        {
            // create test vectors
            var a = new Vector2(1.2, 2);
            var b = new Vector2(6, 0.7);

            // check if sum is correct
            AssertionTools.AssertVector(7.2, 2.7, a + b);

            // create test vectors
            a = new Vector2(-1.2, 2);
            b = new Vector2(6, -0.7);

            // check if sum is correct
            AssertionTools.AssertVector(4.8, 1.3, a + b);

            var c = a + b;
            AssertionTools.AssertDistinctInstances(a, c);
            AssertionTools.AssertDistinctInstances(b, c);
        }

        [Test]
        public void Ex02_Task09_SubtractingOperator()
        {
            // create test vectors
            var a = new Vector2(2, 6);
            var b = new Vector2(6, -2.5);

            // check if result is correct
            AssertionTools.AssertVector(-4, 8.5, a - b);

            var c = a - b;
            AssertionTools.AssertDistinctInstances(a, c);
            AssertionTools.AssertDistinctInstances(b, c);
        }

        [Test]
        public void Ex02_Task10_ScalarMultiplicationOperator()
        {
            // create test data
            var vector = new Vector2(2, 6);
            var scalar = 0.5;

            // check if result is correct
            AssertionTools.AssertVector(1, 3, vector * scalar);

            var b = vector * 5.1;
            AssertionTools.AssertDistinctInstances(vector, b);
        }
    }
}
