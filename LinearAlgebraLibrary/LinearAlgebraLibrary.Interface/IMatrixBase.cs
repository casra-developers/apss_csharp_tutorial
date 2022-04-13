using System;

namespace LinearAlgebraLibrary.Interface
{
    /// <summary>
    /// Interface that needs to be implemented by all matrix types
    /// </summary>
    /// <typeparam name="TMatrix">Matrix type</typeparam>
    public interface IMatrixBase<TMatrix> where TMatrix : IMatrixBase<TMatrix>
    {
        /// <summary>
        /// Gets or sets component of matrix
        /// </summary>
        /// <param name="row">row index</param>
        /// <param name="col">column index</param>
        /// <returns></returns>
        double this[int row, int col] { get; set; }

        /// <summary>
        /// Gets the number of rows of the matrix
        /// </summary>
        int Rows { get; }

        /// <summary>
        /// Gets the numbers of columns of the matrix
        /// </summary>
        int Cols { get; }

        /// <summary>
        /// Get matrix determinant (NaN if matrix is not square)
        /// </summary>
        double Determinant { get; }

        /// <summary>
        /// True if this matrix is singular
        /// </summary>
        bool IsSingular { get; }

        /// <summary>
        /// True if this matrix is a square matrix
        /// </summary>
        bool IsSquare { get; }

        /// <summary>
        /// Get transposed matrix
        /// </summary>
        TMatrix T { get; }

        /// <summary>
        /// Adds the components of two matrices and returns a new matrix
        /// </summary>
        /// <param name="otherMatrix">matrix to add</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        TMatrix Add(TMatrix otherMatrix);

        /// <summary>
        /// Subtracts the components of two matrices and returns a new matrix
        /// </summary>
        /// <param name="otherMatrix">matrix to subtract</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        TMatrix Subtract(TMatrix otherMatrix);

        /// <summary>
        /// Multiplies scalar to matrix
        /// </summary>
        /// <param name="scalar">scalar to multiply matrix with</param>
        /// <returns></returns>
        TMatrix Multiply(double scalar);

        /// <summary>
        /// Multiplies two matrices and returns resulting matrix
        /// </summary>
        /// <param name="otherMatrix">matrix to multiply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        TMatrix Multiply(TMatrix otherMatrix);

        /// <summary>
        /// Extract sub-matrix
        /// </summary>
        /// <param name="rowIndex">Start row index</param>
        /// <param name="rowCount">Row count of sub-matrix</param>
        /// <param name="colIndex">Start column index</param>
        /// <param name="colCount">Column count of sub-matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception if sub-matrix parameters are out of range.</exception>
        TMatrix SubMatrix(int rowIndex, int rowCount, int colIndex, int colCount);

        /// <summary>
        /// Stack two matrices horizontally
        /// </summary>
        /// <param name="otherMatrix">second matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the rows of the matrices do not match</exception>
        TMatrix HStack(TMatrix otherMatrix);

        /// <summary>
        /// Stack two matrices vertically
        /// </summary>
        /// <param name="otherMatrix">second matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the columns of the matrices do not match</exception>
        TMatrix VStack(TMatrix otherMatrix);

        /// <summary>
        /// Multiplies matrix with vector
        /// </summary>
        /// <param name="vector">vector to multiply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        IVector Multiply<TV>(TV vector) where TV : IVectorBase<TV>;
    }
}
