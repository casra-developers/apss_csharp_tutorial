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
    }
}
