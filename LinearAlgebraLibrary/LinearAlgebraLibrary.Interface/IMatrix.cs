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

        /// <summary>
        /// Extract sub-matrix
        /// </summary>
        /// <param name="rowIndex">Start row index</param>
        /// <param name="rowCount">Row count of sub-matrix</param>
        /// <param name="colIndex">Start column index</param>
        /// <param name="colCount">Column count of sub-matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception if sub-matrix parameters are out of range.</exception>
        IMatrix SubMatrix(int rowIndex, int rowCount, int colIndex, int colCount);
    }
}
