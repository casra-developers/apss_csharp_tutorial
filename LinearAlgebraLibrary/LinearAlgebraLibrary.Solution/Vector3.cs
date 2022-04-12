using System;
using LinearAlgebraLibrary.Interface;

namespace LinearAlgebraLibrary.Solution
{
    /// <summary>
    /// Vector with X, Y and Y components
    /// </summary>
    public class Vector3 : IVector3
    {
        /// <summary>
        /// Dimension count of this vector
        /// </summary>
        public int Dimensions => 3;

        /// <summary>
        /// Gets the L2 norm of this vector
        /// </summary>
        public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);

        /// <summary>
        /// Gets or sets the X component of this vector
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the Y component of this vector
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the Z component of this vector
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Creates a new vector with X, Y and Z set to zero
        /// </summary>
        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        /// <summary>
        /// Creates a new vector with X, Y and Y components
        /// </summary>
        /// <param name="x">X component value</param>
        /// <param name="y">Y component value</param>
        /// <param name="z">Z component value</param>
        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Adds another vector to this vector and returns the result as a new vector
        /// </summary>
        /// <param name="otherVector">vector to add</param>
        /// <returns></returns>
        public IVector3 Add(IVector3 otherVector)
        {
            return new Vector3(X + otherVector.X, Y + otherVector.Y, Z + otherVector.Z);
        }

        /// <summary>
        /// Subtracts another vector to this vector and returns the result as a new vector
        /// </summary>
        /// <param name="otherVector">vector to subtract</param>
        /// <returns></returns>
        public IVector3 Subtract(IVector3 otherVector)
        {
            return new Vector3(X - otherVector.X, Y - otherVector.Y, Z - otherVector.Z);
        }

        /// <summary>
        /// Multiplies vector by a scalar factor
        /// </summary>
        /// <param name="factor">Scalar factor to multiply vector by</param>
        /// <returns></returns>
        public IVector3 Multiply(double factor)
        {
            return new Vector3(X * factor, Y * factor, Z * factor);
        }

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="otherVector">other vector to calculate the dot product with</param>
        /// <returns></returns>
        public double DotProduct(IVector3 otherVector)
        {
            return X * otherVector.X + Y * otherVector.Y + Z * otherVector.Z;
        }

        /// <summary>
        /// Returns the cross product of two vectors
        /// </summary>
        /// <param name="otherVector">other vector to calculate the cross product with</param>
        /// <returns></returns>
        public IVector3 CrossProduct(IVector3 otherVector)
        {
            return new Vector3(
                Y * otherVector.Z - Z * otherVector.Y,
                Z * otherVector.X - X * otherVector.Z,
                X * otherVector.Y - Y * otherVector.X
            );
        }

        /// <summary>
        /// Adds two vectors
        /// </summary>
        /// <param name="a">first vector</param>
        /// <param name="b">second vector</param>
        /// <returns></returns>
        public static IVector3 operator +(Vector3 a, Vector3 b)
        {
            return a.Add(b);
        }

        /// <summary>
        /// Subtracts two vectors
        /// </summary>
        /// <param name="a">first vector</param>
        /// <param name="b">second vector</param>
        /// <returns></returns>
        public static IVector3 operator -(Vector3 a, Vector3 b)
        {
            return a.Subtract(b);
        }

        /// <summary>
        /// Multiplies vector and scalar
        /// </summary>
        /// <param name="vector">vector</param>
        /// <param name="factor">scalar to multiply vector by</param>
        /// <returns></returns>
        public static IVector3 operator *(Vector3 vector, double factor)
        {
            return vector.Multiply(factor);
        }

        public override string ToString()
        {
            return $"Vector3(X = {X:##.000}, Y = {Y:##.000}, Z = {Z:##.000})";
        }
    }
}
