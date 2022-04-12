using System;
using LinearAlgebraLibrary.Interface;

namespace LinearAlgebraLibrary.Solution
{
    /// <summary>
    /// A matrix that stores data in row-major format
    /// </summary>
    public class Matrix : IMatrix
    {
        //
        // private members
        //
        private readonly double[,] _storage;

        /// <summary>
        /// Gets the number of rows of the matrix
        /// </summary>
        public int Rows => _storage.GetLength(0);

        /// <summary>
        /// Gets the numbers of columns of the matrix
        /// </summary>
        public int Cols => _storage.GetLength(1);

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
            get => _storage[row, col];
            set => _storage[row, col] = value;
        }

        /// <summary>
        /// Get transposed matrix
        /// </summary>
        public IMatrix T
        {
            get
            {
                var source = new double[Cols, Rows];
                for (var i = 0; i < Rows; ++i)
                {
                    for (var j = 0; j < Cols; ++j)
                    {
                        source[j, i] = this[i, j];
                    }
                }

                return new Matrix(source);
            }
        }

        /// <summary>
        /// Get matrix determinant (NaN if matrix is not square)
        /// </summary>
        public double Determinant
        {
            get
            {
                if (!IsSquare || Rows == 0) return double.NaN;

                switch (Rows)
                {
                    case 1: return this[0, 0];
                    case 2: return this[0, 0] * this[1, 1] - this[1, 0] * this[0, 1];
                    default:
                        var determinant = 0.0;
                        for (var j = 0; j < Cols; ++j)
                        {
                            IMatrix subMatrix;
                            if (j == 0)
                            {
                                subMatrix = SubMatrix(1, Rows - 1, 1, Cols - 1);
                            }
                            else if (j == Cols - 1)
                            {
                                subMatrix = SubMatrix(1, Rows - 1, 0, Cols - 1);
                            }
                            else
                            {
                                var subMatrix1 = SubMatrix(1, Rows - 1, 0, j);
                                var subMatrix2 = SubMatrix(1, Rows - 1, j + 1, Cols - j - 1);
                                subMatrix = HStack(subMatrix1, subMatrix2);
                            }

                            determinant += (j % 2 == 0 ? 1 : -1) * this[0, j] * subMatrix.Determinant;
                        }

                        return determinant;
                }
            }
        }

        /// <summary>
        /// Create matrix filled with zeros
        /// </summary>
        /// <param name="rows">row count</param>
        /// <param name="cols">column count</param>
        public Matrix(int rows, int cols)
        {
            _storage = new double[rows, cols];
        }

        /// <summary>
        /// Create matrix from 2D array source
        /// </summary>
        /// <param name="matrixSource">matrix source data</param>
        public Matrix(double[,] matrixSource)
        {
            _storage = matrixSource;
        }

        /// <summary>
        /// Create identity matrix
        /// </summary>
        /// <param name="dimension">Length of matrix diagonal</param>
        /// <returns></returns>
        public static Matrix CreateIdentityMatrix(int dimension)
        {
            var source = new double[dimension, dimension];
            for (var i = 0; i < dimension; ++i)
            {
                source[i, i] = 1;
            }

            return new Matrix(source);
        }

        /// <summary>
        /// Stack two matrices horizontally
        /// </summary>
        /// <param name="a">first matrix</param>
        /// <param name="b">second matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the rows of the matrices do not match</exception>
        public static IMatrix HStack(IMatrix a, IMatrix b)
        {
            if (a.Rows != b.Rows)
            {
                throw new ArgumentException($"The matrices have to have the same amount of rows: {a.Rows}, {b.Rows}");
            }

            var source = new double[a.Rows, a.Cols + b.Cols];
            for (var i = 0; i < a.Rows; ++i)
            {
                for (var j = 0; j < a.Cols; ++j)
                {
                    source[i, j] = a[i, j];
                }

                for (var j = 0; j < b.Cols; ++j)
                {
                    source[i, j + a.Cols] = b[i, j];
                }
            }

            return new Matrix(source);
        }

        /// <summary>
        /// Stack two matrices vertically
        /// </summary>
        /// <param name="a">first matrix</param>
        /// <param name="b">second matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the columns of the matrices do not match</exception>
        public static IMatrix VStack(IMatrix a, IMatrix b)
        {
            if (a.Cols != b.Cols)
            {
                throw new ArgumentException($"The matrices have to have the same amount of columns: {a.Cols}, {b.Cols}");
            }

            var source = new double[a.Rows + a.Rows, a.Cols];
            for (var j = 0; j < a.Cols; ++j)
            {
                for (var i = 0; i < a.Rows; ++i)
                {
                    source[i, j] = a[i, j];
                }

                for (var i = 0; i < a.Rows; ++i)
                {
                    source[i+a.Rows, j] = b[i, j];
                }
            }

            return new Matrix(source);
        }

        /// <summary>
        /// Adds the components of two matrices and returns a new matrix
        /// </summary>
        /// <param name="otherMatrix">matrix to add</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public IMatrix Add(IMatrix otherMatrix)
        {
            if (otherMatrix.Rows != Rows || otherMatrix.Cols != Cols)
            {
                throw new ArgumentException($"The matrices do not have the same dimensionality: [{Rows}, {Cols}], [{otherMatrix.Rows}, {otherMatrix.Cols}]");
            }

            var result = new Matrix(Rows, Cols);
            for (var i = 0; i < Rows; ++i)
            {
                for (var j = 0; j < Cols; ++j)
                {
                    result[i, j] = this[i, j] + otherMatrix[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Subtracts the components of two matrices and returns a new matrix
        /// </summary>
        /// <param name="otherMatrix">matrix to subtract</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public IMatrix Subtract(IMatrix otherMatrix)
        {
            if (otherMatrix.Rows != Rows || otherMatrix.Cols != Cols)
            {
                throw new ArgumentException($"The matrices do not have the same dimensionality: [{Rows}, {Cols}], [{otherMatrix.Rows}, {otherMatrix.Cols}]");
            }

            var result = new Matrix(Rows, Cols);
            for (var i = 0; i < Rows; ++i)
            {
                for (var j = 0; j < Cols; ++j)
                {
                    result[i, j] = this[i, j] - otherMatrix[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies two matrices and returns resulting matrix
        /// </summary>
        /// <param name="otherMatrix">matrix to multiply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public IMatrix Multiply(IMatrix otherMatrix)
        {
            if (otherMatrix.Rows != Cols || otherMatrix.Cols != Rows)
            {
                throw new ArgumentException($"The matrices cannot be multiplied, wrong dimensionality: [{Rows}, {Cols}], [{otherMatrix.Rows}, {otherMatrix.Cols}]");
            }

            var result = new Matrix(Rows, otherMatrix.Cols);
            for (var i = 0; i < Rows; ++i)
            {
                for (var j = 0; j < otherMatrix.Cols; ++j)
                {
                    for (var k = 0; k < Cols; ++k)
                    {
                        result[i, j] += this[i, k] * otherMatrix[k, j];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies matrix with vector
        /// </summary>
        /// <param name="vector">vector to multiply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public IVector Multiply(IVector vector)
        {
            if (vector.Dimensions != Cols)
            {
                throw new ArgumentException($"The matrix and the vector cannot be multiplied: [{Rows}, {Cols}], [{vector.Dimensions}]");
            }

            var resultSource = new double[Rows];
            for (var i = 0; i < Rows; ++i)
            {
                for (var j = 0; j < Cols; ++j)
                {
                    resultSource[i] += this[i, j] * vector[j];
                }
            }

            return new Vector(resultSource);
        }

        /// <summary>
        /// Multiplies matrix with vector
        /// </summary>
        /// <param name="vector">vector to multiply</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public IVector Multiply<TV>(TV vector) where TV : IVectorBase<TV>
        {
            switch (vector)
            {
                case IVector2 vector2:
                    return Multiply(Vector.FromVector2(vector2));
                case IVector3 vector3:
                    return Multiply(Vector.FromVector3(vector3));
                case IVector generalVector:
                    return Multiply(generalVector);
                default:
                    throw new NotSupportedException("Vector type cannot be multiplied with matrix.");
            }
        }

        /// <summary>
        /// Adds the components of two matrices and returns a new matrix
        /// </summary>
        /// <param name="a">first matrix</param>
        /// <param name="b">second matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public static IMatrix operator +(Matrix a, Matrix b) => a.Add(b);

        /// <summary>
        /// Subtracts the components of two matrices and returns a new matrix
        /// </summary>
        /// <param name="a">first matrix</param>
        /// <param name="b">second matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public static IMatrix operator -(Matrix a, Matrix b) => a.Subtract(b);

        /// <summary>
        /// Multiplies two matrices and returns resulting matrix
        /// </summary>
        /// <param name="a">first matrix</param>
        /// <param name="b">second matrix</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
        public static IMatrix operator *(Matrix a, Matrix b) => a.Multiply(b);

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
