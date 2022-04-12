using System;
using System.Linq;
using LinearAlgebraLibrary.Interface;

namespace LinearAlgebraLibrary.Solution
{
    /// <summary>
    /// Vector that has no fixed dimension
    /// </summary>
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
            get => _storage[i];
            set => _storage[i] = value;
        }

        /// <summary>
        /// Dimension count of this vector
        /// </summary>
        public int Dimensions => _storage.Length;

        /// <summary>
        /// Gets the L2 norm of this vector
        /// </summary>
        public double Length => Math.Sqrt(_storage.Select(x => x * x).Sum());

        /// <summary>
        /// Creates vector with all zero components
        /// </summary>
        /// <param name="dimensions">Dimensions of vector</param>
        public Vector(int dimensions)
        {
            _storage = new double[dimensions];
        }

        /// <summary>
        /// Creates vector from array
        /// </summary>
        /// <param name="vectorSource"></param>
        public Vector(params double[] vectorSource)
        {
            _storage = vectorSource;
        }
        
        /// <summary>
        /// Try to generate <see cref="IVector2"/> from vector
        /// </summary>
        /// <param name="vector2">result</param>
        /// <returns>Returns true if successful</returns>
        public bool TryGetVector2(out IVector2? vector2)
        {
            if (Dimensions != 2)
            {
                vector2 = null;
                return false;
            }

            vector2 = new Vector2(this[0], this[1]);
            return true;
        }

        /// <summary>
        /// Try to generate <see cref="IVector3"/> from vector
        /// </summary>
        /// <param name="vector3">result</param>
        /// <returns>Returns true if successful</returns>
        public bool TryGetVector3(out IVector3? vector3)
        {
            if (Dimensions != 3)
            {
                vector3 = null;
                return false;
            }

            vector3 = new Vector3(this[0], this[1], this[2]);
            return true;
        }

        /// <summary>
        /// Generate vector from <see cref="IVector2"/>
        /// </summary>
        /// <param name="vector2">source vector</param>
        /// <returns></returns>
        public static IVector FromVector2(IVector2 vector2) => new Vector(vector2.X, vector2.Y);

        /// <summary>
        /// Generate vector from <see cref="IVector3"/>
        /// </summary>
        /// <param name="vector3">source vector</param>
        /// <returns></returns>
        public static IVector FromVector3(IVector3 vector3) => new Vector(vector3.X, vector3.Y, vector3.Z);

        /// <summary>
        /// Adds another vector to this vector and returns the result as a new vector
        /// </summary>
        /// <param name="otherVector">vector to add</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public IVector Add(IVector otherVector)
        {
            if (Dimensions != otherVector.Dimensions)
            {
                throw new ArgumentException($"Dimensions of vectors do not match, cannot add: {Dimensions}, {otherVector.Dimensions}");
            }

            var source = new double[Dimensions];
            for (var i = 0; i < Dimensions; ++i)
            {
                source[i] = this[i] + otherVector[i];
            }

            return new Vector(source);
        }

        /// <summary>
        /// Subtracts another vector to this vector and returns the result as a new vector
        /// </summary>
        /// <param name="otherVector">vector to subtract</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public IVector Subtract(IVector otherVector)
        {
            if (Dimensions != otherVector.Dimensions)
            {
                throw new ArgumentException($"Dimensions of vectors do not match, cannot subtract: {Dimensions}, {otherVector.Dimensions}");
            }

            var source = new double[Dimensions];
            for (var i = 0; i < Dimensions; ++i)
            {
                source[i] = this[i] - otherVector[i];
            }

            return new Vector(source);
        }

        /// <summary>
        /// Multiplies vector by a scalar factor
        /// </summary>
        /// <param name="factor">Scalar factor to multiply vector by</param>
        /// <returns></returns>
        public IVector Multiply(double factor) => new Vector(_storage.Select(x => x * factor).ToArray());

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="otherVector">other vector to calculate the dot product with</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public double DotProduct(IVector otherVector)
        {
            if (Dimensions != otherVector.Dimensions)
            {
                throw new ArgumentException($"Dimensions of vectors do not match, cannot calculate dot product: {Dimensions}, {otherVector.Dimensions}");
            }

            var dotProduct = 0.0;
            for (var i = 0; i < Dimensions; ++i)
            {
                dotProduct += this[i] * otherVector[i];
            }

            return dotProduct;
        }

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="vector2">other vector to calculate the dot product with</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public double DotProduct(IVector2 vector2)
        {
            return DotProduct(FromVector2(vector2));
        }

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="vector3">other vector to calculate the dot product with</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        public double DotProduct(IVector3 vector3)
        {
            return DotProduct(FromVector3(vector3));
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
            return a.Add(b);
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
            return a.Add(FromVector2(b));
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
            return a.Add(FromVector3(b));
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
            return a.Subtract(b);
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
            return a.Subtract(FromVector2(b));
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
            return a.Subtract(FromVector3(b));
        }

        /// <summary>
        /// Multiplies vector and scalar
        /// </summary>
        /// <param name="vector">vector</param>
        /// <param name="factor">scalar to multiply vector by</param>
        /// <returns></returns>
        public static IVector operator *(Vector vector, double factor)
        {
            return vector.Multiply(factor);
        }
    }
}
