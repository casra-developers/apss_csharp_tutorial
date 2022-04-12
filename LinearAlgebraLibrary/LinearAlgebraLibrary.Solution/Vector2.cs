using System;
using LinearAlgebraLibrary.Interface;

namespace LinearAlgebraLibrary.Solution
{
    /// <summary>
    /// Vector with X and Y components
    /// </summary>
    public class Vector2 : IVector2
    {
        /// <summary>
        /// Dimension count of this vector
        /// </summary>
        public int Dimensions => 2;

        /// <summary>
        /// Gets or sets the X component of this vector
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the X component of this vector
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets the L2 norm of this vector
        /// </summary>
        public double Length => Math.Sqrt(X * X + Y * Y);

        /// <summary>
        /// Creates a new vector with X and Y set to zero
        /// </summary>
        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Creates a new vector with X and Y components
        /// </summary>
        /// <param name="x">X component value</param>
        /// <param name="y">Y component value</param>
        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Adds another vector to this vector and returns the result as a new vector
        /// </summary>
        /// <param name="otherVector">vector to add</param>
        /// <returns></returns>
        public IVector2 Add(IVector2 otherVector)
        {
            return new Vector2(X + otherVector.X, Y + otherVector.Y);
        }

        /// <summary>
        /// Subtracts another vector to this vector and returns the result as a new vector
        /// </summary>
        /// <param name="otherVector">vector to subtract</param>
        /// <returns></returns>
        public IVector2 Subtract(IVector2 otherVector)
        {
            return new Vector2(X - otherVector.X, Y - otherVector.Y);
        }

        /// <summary>
        /// Multiplies vector by a scalar factor
        /// </summary>
        /// <param name="factor">Scalar factor to multiply vector by</param>
        /// <returns></returns>
        public IVector2 Multiply(double factor)
        {
            return new Vector2(X * factor, Y * factor);
        }

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="otherVector">other vector to calculate the dot product with</param>
        /// <returns></returns>
        public double DotProduct(IVector2 otherVector)
        {
            return X * otherVector.X + Y * otherVector.Y;
        }

        /// <summary>
        /// Returns the pseudo cross product of two vectors
        /// </summary>
        /// <param name="otherVector">other vector to calculate the pseudo cross product with</param>
        /// <returns></returns>
        public double CrossProduct(IVector2 otherVector)
        {
            return X * otherVector.Y - Y * otherVector.X;
        }

        /// <summary>
        /// Adds two vectors
        /// </summary>
        /// <param name="a">first vector</param>
        /// <param name="b">second vector</param>
        /// <returns></returns>
        public static IVector2 operator +(Vector2 a, Vector2 b)
        {
            return a.Add(b);
        }

        /// <summary>
        /// Subtracts two vectors
        /// </summary>
        /// <param name="a">first vector</param>
        /// <param name="b">second vector</param>
        /// <returns></returns>
        public static IVector2 operator -(Vector2 a, Vector2 b)
        {
            return a.Subtract(b);
        }

        /// <summary>
        /// Multiplies vector and scalar
        /// </summary>
        /// <param name="vector">vector</param>
        /// <param name="factor">scalar to multiply vector by</param>
        /// <returns></returns>
        public static IVector2 operator *(Vector2 vector, double factor)
        {
            return vector.Multiply(factor);
        }

        public override string ToString()
        {
            return $"Vector2(X = {X:##.000}, Y = {Y:##.000})";
        }
    }
}
