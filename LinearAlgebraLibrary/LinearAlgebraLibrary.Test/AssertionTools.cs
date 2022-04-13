using LinearAlgebraLibrary.Interface;
using NUnit.Framework;

namespace LinearAlgebraLibrary.Test
{
    public static class AssertionTools
    {
        public static void AssertVector(double expectedX, double expectedY, IVector2 actual, double eps = double.Epsilon)
        {
            Assert.AreEqual(expectedX, actual.X, eps);
            Assert.AreEqual(expectedY, actual.Y, eps);
        }

        public static void AssertVector(IVector2 expected, IVector2 actual, double eps = double.Epsilon)
        {
            AssertVector(expected.X, expected.Y, actual);
        }

        public static void AssertVector(double expectedX, double expectedY, double expectedZ, IVector3 actual, double eps = double.Epsilon)
        {
            Assert.AreEqual(expectedX, actual.X, eps);
            Assert.AreEqual(expectedY, actual.Y, eps);
            Assert.AreEqual(expectedZ, actual.Z, eps);
        }

        public static void AssertVector(IVector3 expected, IVector3 actual, double eps = double.Epsilon)
        {
            AssertVector(expected.X, expected.Y, expected.Z, actual);
        }

        public static void AssertVector(double eps, IVector actual, params double[] components)
        {
            Assert.AreEqual(components.Length, actual.Dimensions);

            for (var i = 0; i < components.Length; ++i)
            {
                Assert.AreEqual(components[i], actual[i], eps);
            }
        }

        public static void AssertVector(IVector actual, params double[] components)
        {
            AssertVector(double.Epsilon, actual, components);
        }

        public static void AssertVector(IVector expected, IVector actual, double eps = double.Epsilon)
        {
            var components = new double[expected.Dimensions];
            for (var i = 0; i < expected.Dimensions; ++i)
            {
                components[i] = expected[i];
            }
            AssertVector(eps, actual, components);
        }

        public static void AssertDistinctInstances(object? instance1, object? instance2)
        {
            string className;
            switch (instance1)
            {
                case IVector:
                    className = "Vector";
                    break;
                case IVector2:
                    className = "Vector2";
                    break;
                case IVector3:
                    className = "Vector3";
                    break;
                case IMatrix:
                    className = "Matrix";
                    break;
                default:
                    className = "object";
                    break;
            }

            Assert.AreNotSame(instance1, instance2, $"Make sure to create a new {className} instance that holds the result, not changing the original {className}.");
        }

        public static void AssertDiagonal(double eps, IMatrix matrix, params double[] diagonalComponents)
        {
            Assert.AreEqual(matrix.Rows, matrix.Cols, "Matrix needs to be square.");
            Assert.AreEqual(diagonalComponents, matrix.Cols, "Wrong number of components in diagonal.");

            for (var i = 0; i < matrix.Rows; ++i)
            {
                Assert.AreEqual(diagonalComponents[i], matrix[i, i], eps);
            }
        }

        public static void AssertDiagonal(IMatrix matrix, params double[] diagonalComponents)
        {
            AssertDiagonal(double.Epsilon, matrix, diagonalComponents);
        }

        public static void AssertDiagonal(IVector diagonal, IMatrix matrix, double eps = double.Epsilon)
        {
            var components = new double[diagonal.Dimensions];
            for (var i = 0; i < diagonal.Dimensions; ++i)
            {
                components[i] = diagonal[i];
            }
            AssertDiagonal(eps, matrix, components);
        }

        public static void AssertSingleValue(double expected, IMatrix matrix, double eps = double.Epsilon)
        {
            for (var i = 0; i < matrix.Rows; ++i)
            {
                for (var j = 0; j < matrix.Cols; ++j)
                {
                    Assert.AreEqual(expected, matrix[i, j], eps);
                }
            }
        }

        public static void AssertMatrix(IMatrix expected, IMatrix actual, double eps = double.Epsilon)
        {
            Assert.AreEqual(expected.Rows, actual.Rows);
            Assert.AreEqual(expected.Cols, actual.Cols);

            for (var i = 0; i < expected.Rows; ++i)
            {
                for (var j = 0; j < expected.Cols; ++j)
                {
                    Assert.AreEqual(expected[i, j], expected[i, j], eps);
                }
            }
        }

        public static void AssertMatrix(double[,] expected, IMatrix actual, double eps = double.Epsilon)
        {
            Assert.AreEqual(expected.GetLength(0), actual.Rows);
            Assert.AreEqual(expected.GetLength(1), actual.Cols);

            for (var i = 0; i < actual.Rows; ++i)
            {
                for (var j = 0; j < actual.Cols; ++j)
                {
                    Assert.AreEqual(expected[i, j], expected[i, j], eps);
                }
            }
        }
    }
}
