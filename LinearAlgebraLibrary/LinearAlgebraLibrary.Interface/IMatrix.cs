using System;

namespace LinearAlgebraLibrary.Interface
{
    /// <summary>
    /// A matrix that stores data in row-major format
    /// </summary>
    public interface IMatrix : IMatrixBase<IMatrix>
    {
        /// <summary>
        /// Multiplies matrix with vector
        /// </summary>
        /// <param name="vector">vector to multiply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        IVector Multiply(IVector vector);
    }
}
