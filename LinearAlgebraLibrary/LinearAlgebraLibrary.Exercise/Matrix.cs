using System;
using LinearAlgebraLibrary.Interface;

namespace LinearAlgebraLibrary.Exercise
{
    public class Matrix : IMatrix
    {
        public double this[int row, int col]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public int Rows { get; }
        public int Cols { get; }
        
        public bool IsSingular { get; }

        public bool IsSquare { get; }

        public IMatrix T { get; }

        public double Determinant { get; }

        public Matrix(int rows, int cols)
        {
            throw new NotImplementedException();
        }

        public Matrix(double[,] matrixSource)
        {
            throw new NotImplementedException();
        }

        public IMatrix Add(IMatrix otherMatrix)
        {
            throw new NotImplementedException();
        }

        public IMatrix Subtract(IMatrix otherMatrix)
        {
            throw new NotImplementedException();
        }

        public IMatrix Multiply(IMatrix otherMatrix)
        {
            throw new NotImplementedException();
        }

        public IVector Multiply<TV>(TV vector) where TV : IVectorBase<TV>
        {
            throw new NotImplementedException();
        }

        public IVector Multiply(IVector vector)
        {
            throw new NotImplementedException();
        }

        public IMatrix SubMatrix(int rowIndex, int rowCount, int colIndex, int colCount)
        {
            throw new NotImplementedException();
        }
    }
}
