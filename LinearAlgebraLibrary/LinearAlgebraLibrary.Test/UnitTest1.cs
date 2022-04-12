using LinearAlgebraLibrary.Solution;
using NUnit.Framework;

namespace LinearAlgebraLibrary.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var m = new Matrix(new double[,]
            {
                { 3, 2, 1 },
                { 2, 1, -3 },
                { 4, 0, 1 },
            });
            var det0 = new Matrix(new double[,] { { 1, -3 }, { 0, 1 } }).Determinant;
            var det = m.Determinant;
        }
    }
}