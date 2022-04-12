namespace LinearAlgebraLibrary.Interface
{
    /// <summary>
    /// Interface which has to be implemented by all vectors
    /// </summary>
    /// <typeparam name="TVector">Type of the vector implementing the interface</typeparam>
    public interface IVectorBase<TVector> where TVector : IVectorBase<TVector>
    {
        /// <summary>
        /// Dimension count of this vector
        /// </summary>
        int Dimensions { get; }

        /// <summary>
        /// Gets the L2 norm of this vector
        /// </summary>
        double Length { get; }

        /// <summary>
        /// Adds another vector to this vector and returns the result as a new vector
        /// </summary>
        /// <param name="otherVector">vector to add</param>
        /// <returns></returns>
        TVector Add(TVector otherVector);

        /// <summary>
        /// Subtracts another vector to this vector and returns the result as a new vector
        /// </summary>
        /// <param name="otherVector">vector to subtract</param>
        /// <returns></returns>
        TVector Subtract(TVector otherVector);

        /// <summary>
        /// Multiplies vector by a scalar factor
        /// </summary>
        /// <param name="factor">Scalar factor to multiply vector by</param>
        /// <returns></returns>
        TVector Multiply(double factor);

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="otherVector">other vector to calculate the dot product with</param>
        /// <returns></returns>
        double DotProduct(TVector otherVector);
    }
}
