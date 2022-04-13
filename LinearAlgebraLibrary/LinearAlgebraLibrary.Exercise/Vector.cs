using System;
using System.Linq;
using LinearAlgebraLibrary.Interface;

namespace LinearAlgebraLibrary.Exercise
{
    public class Vector : IVector
    {
        //
        // private members
        //
        private readonly double[] _storage;

        /// <summary>
        /// Gets or sets vector component
        /// </summary>
        /// <param name="i">component index</param>
        /// <returns></returns>
        public double this[int i]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Dimension count of this vector
        /// </summary>
        public int Dimensions => throw new NotImplementedException();

        /// <summary>
        /// Gets the L2 norm of this vector
        /// </summary>
        public double Length => throw new NotImplementedException();

        /// <summary>
        /// Creates vector with all zero components
        /// </summary>
        /// <param name="dimensions">Dimensions of vector</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception if invalid number of components is provided</exception>
        public Vector(int dimensions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates vector from array
        /// </summary>
        /// <param name="vectorSource"></param>
        public Vector(params double[] vectorSource)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Try to generate <see cref="IVector2"/> from vector
        /// </summary>
        /// <param name="vector2">result</param>
        /// <returns>Returns true if successful</returns>
        public bool TryGetVector2(out IVector2? vector2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Try to generate <see cref="IVector3"/> from vector
        /// </summary>
        /// <param name="vector3">result</param>
        /// <returns>Returns true if successful</returns>
        public bool TryGetVector3(out IVector3? vector3)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generate vector from <see cref="IVector2"/>
        /// </summary>
        /// <param name="vector2">source vector</param>
        /// <returns></returns>
        public static IVector FromVector2(IVector2 vector2) => throw new NotImplementedException();

        /// <summary>
        /// Generate vector from <see cref="IVector3"/>
        /// </summary>
        /// <param name="vector3">source vector</param>
        /// <returns></returns>
        public static IVector FromVector3(IVector3 vector3) => throw new NotImplementedException();

        /// <summary>
        /// Adds another vector to this vector and returns the result as a new vector
        /// </summary>
        /// <param name="otherVector">vector to add</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public IVector Add(IVector otherVector)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subtracts another vector to this vector and returns the result as a new vector
        /// </summary>
        /// <param name="otherVector">vector to subtract</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public IVector Subtract(IVector otherVector)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplies vector by a scalar factor
        /// </summary>
        /// <param name="factor">Scalar factor to multiply vector by</param>
        /// <returns></returns>
        public IVector Multiply(double factor) => throw new NotImplementedException();

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="otherVector">other vector to calculate the dot product with</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public double DotProduct(IVector otherVector)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="vector2">other vector to calculate the dot product with</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public double DotProduct(IVector2 vector2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="vector3">other vector to calculate the dot product with</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public double DotProduct(IVector3 vector3)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds two vectors
        /// </summary>
        /// <param name="a">first vector</param>
        /// <param name="b">second vector</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public static IVector operator +(Vector a, Vector b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds two vectors
        /// </summary>
        /// <param name="a">first vector</param>
        /// <param name="b">second vector</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public static IVector operator +(Vector a, IVector2 b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds two vectors
        /// </summary>
        /// <param name="a">first vector</param>
        /// <param name="b">second vector</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public static IVector operator +(Vector a, IVector3 b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subtracts two vectors
        /// </summary>
        /// <param name="a">first vector</param>
        /// <param name="b">second vector</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public static IVector operator -(Vector a, Vector b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subtracts two vectors
        /// </summary>
        /// <param name="a">first vector</param>
        /// <param name="b">second vector</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public static IVector operator -(Vector a, IVector2 b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subtracts two vectors
        /// </summary>
        /// <param name="a">first vector</param>
        /// <param name="b">second vector</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public static IVector operator -(Vector a, IVector3 b)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplies vector and scalar
        /// </summary>
        /// <param name="vector">vector</param>
        /// <param name="factor">scalar to multiply vector by</param>
        /// <returns></returns>
        public static IVector operator *(Vector vector, double factor)
        {
            throw new NotImplementedException();
        }
    }
}
