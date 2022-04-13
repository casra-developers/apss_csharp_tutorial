using System;
using LinearAlgebraLibrary.Interface;

namespace LinearAlgebraLibrary.Exercise
{
    public class Matrix : IMatrix
    {
        //
        // private members
        //
        private readonly double[,] _storage;

        /// <summary>
        /// Gets the number of rows of the matrix
        /// </summary>
        public int Rows => throw new NotImplementedException();

        /// <summary>
        /// Gets the numbers of columns of the matrix
        /// </summary>
        public int Cols => throw new NotImplementedException();

        /// <summary>
        /// True if this matrix is a square matrix
        /// </summary>
        public bool IsSquare => Rows == Cols;

        /// <summary>
        /// True if this matrix is singular
        /// </summary>
        public bool IsSingular => Determinant < double.Epsilon;

        /// <summary>
        /// Gets or sets component of matrix
        /// </summary>
        /// <param name="row">row index</param>
        /// <param name="col">column index</param>
        /// <returns></returns>
        public double this[int row, int col]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Get transposed matrix
        /// </summary>
        public IMatrix T
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Get matrix determinant (NaN if matrix is not square)
        /// </summary>
        public double Determinant
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Create matrix filled with zeros
        /// </summary>
        /// <param name="rows">row count</param>
        /// <param name="cols">column count</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception if invalid dimensions are given</exception>
        public Matrix(int rows, int cols)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create matrix from 2D array source
        /// </summary>
        /// <param name="matrixSource">matrix source data</param>
        public Matrix(double[,] matrixSource)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create identity matrix
        /// </summary>
        /// <param name="dimension">Length of matrix diagonal</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception if invalid dimension is given</exception>
        public static Matrix CreateIdentityMatrix(int dimension)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stack two matrices horizontally
        /// </summary>
        /// <param name="otherMatrix">second matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the rows of the matrices do not match</exception>
        public IMatrix HStack(IMatrix otherMatrix)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stack two matrices vertically
        /// </summary>
        /// <param name="otherMatrix">second matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the columns of the matrices do not match</exception>
        public IMatrix VStack(IMatrix otherMatrix)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the components of two matrices and returns a new matrix
        /// </summary>
        /// <param name="otherMatrix">matrix to add</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public IMatrix Add(IMatrix otherMatrix)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subtracts the components of two matrices and returns a new matrix
        /// </summary>
        /// <param name="otherMatrix">matrix to subtract</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public IMatrix Subtract(IMatrix otherMatrix)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplies scalar to matrix
        /// </summary>
        /// <param name="scalar">scalar to multiply matrix with</param>
        /// <returns></returns>
        public IMatrix Multiply(double scalar)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplies two matrices and returns resulting matrix
        /// </summary>
        /// <param name="otherMatrix">matrix to multiply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public IMatrix Multiply(IMatrix otherMatrix)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplies matrix with vector
        /// </summary>
        /// <param name="vector">vector to multiply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public IVector Multiply(IVector vector)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplies matrix with vector
        /// </summary>
        /// <param name="vector">vector to multiply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public IVector Multiply<TV>(TV vector) where TV : IVectorBase<TV>
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the components of two matrices and returns a new matrix
        /// </summary>
        /// <param name="a">first matrix</param>
        /// <param name="b">second matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public static Matrix operator +(Matrix a, Matrix b) => (Matrix) a.Add(b);

        /// <summary>
        /// Subtracts the components of two matrices and returns a new matrix
        /// </summary>
        /// <param name="a">first matrix</param>
        /// <param name="b">second matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public static Matrix operator -(Matrix a, Matrix b) => (Matrix)a.Subtract(b);

        /// <summary>
        /// Multiplies two matrices and returns resulting matrix
        /// </summary>
        /// <param name="a">first matrix</param>
        /// <param name="b">second matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public static Matrix operator *(Matrix a, Matrix b) => (Matrix)a.Multiply(b);

        /// <summary>
        /// Multiplies scalar to matrix
        /// </summary>
        /// <param name="b">scalar to multiply matrix with</param>
        /// <returns></returns>
        public static Matrix operator *(Matrix a, double b) => (Matrix) a.Multiply(b);

        /// <summary>
        /// Multiplies matrix with vector
        /// </summary>
        /// <param name="matrix">matrix to multiply</param>
        /// <param name="vector">vector to multiply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public static IVector operator *(Matrix matrix, IVector vector) => matrix.Multiply(vector);

        /// <summary>
        /// Multiplies matrix with vector
        /// </summary>
        /// <param name="matrix">matrix to multiply</param>
        /// <param name="vector">vector to multiply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public static IVector operator *(Matrix matrix, IVector2 vector) => matrix.Multiply(vector);

        /// <summary>
        /// Multiplies matrix with vector
        /// </summary>
        /// <param name="matrix">matrix to multiply</param>
        /// <param name="vector">vector to multiply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public static IVector operator *(Matrix matrix, IVector3 vector) => matrix.Multiply(vector);

        /// <summary>
        /// Extract sub-matrix
        /// </summary>
        /// <param name="rowIndex">Start row index</param>
        /// <param name="rowCount">Row count of sub-matrix</param>
        /// <param name="colIndex">Start column index</param>
        /// <param name="colCount">Column count of sub-matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception if sub-matrix parameters are out of range.</exception>
        public IMatrix SubMatrix(int rowIndex, int rowCount, int colIndex, int colCount)
        {
            if (rowIndex < 0 || rowIndex >= Rows || rowCount < 0 || rowIndex + rowCount > Rows
                || colIndex < 0 || colIndex >= Cols || colCount < 0 || colIndex + colCount > Cols)
            {
                throw new ArgumentOutOfRangeException($"Cannot create sub-matrix, range given not valid: [{rowIndex}:{rowIndex + rowCount}, {colIndex}:{colIndex + colCount}]");
            }

            var source = new double[rowCount, colCount];
            for (var i = 0; i < rowCount; ++i)
            {
                for (var j = 0; j < colCount; ++j)
                {
                    source[i, j] = this[rowIndex + i, colIndex + j];
                }
            }

            return new Matrix(source);
        }
    }
}
