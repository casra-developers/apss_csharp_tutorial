using System;
using LinearAlgebraLibrary.Exercise;
using NUnit.Framework;

namespace LinearAlgebraLibrary.Test
{
    public class Excercise01_Tests
    {
        [Test]
        public void Ex01_Task2_hello_world()
        {
            Console.WriteLine("Hello World!");
            Assert.Pass("Hello World, you've passed this test just by running it.");
        }

        [Test]
        public void Ex01_Task3_instantiate_vector2_no_args()
        {
            // create zero vector
            var myVector = new Vector2();
            Assert.AreEqual(0, myVector.X, double.Epsilon);
            Assert.AreEqual(0, myVector.Y, double.Epsilon);
        }

        [Test]
        public void Ex01_Task3_instantiate_vector2_args()
        {
            // create non-zero vector
            var anotherVector = new Vector2(1, 2);
            Assert.AreEqual(1, anotherVector.X, double.Epsilon);
            Assert.AreEqual(2, anotherVector.Y, double.Epsilon);
        }
    }
}
