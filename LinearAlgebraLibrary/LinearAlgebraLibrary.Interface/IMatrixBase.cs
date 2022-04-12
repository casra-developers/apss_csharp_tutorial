namespace LinearAlgebraLibrary.Interface
{
    public interface IMatrixBase<TMatrix> where TMatrix : IMatrixBase<TMatrix>
    {
        double this[int row, int col] { get; set; }

        int Rows { get; }

        int Cols { get; }

        double Determinant { get; }

        bool IsSingular { get; }

        bool IsSquare { get; }

        TMatrix T { get; }

        TMatrix Add(TMatrix otherMatrix);

        TMatrix Subtract(TMatrix otherMatrix);

        TMatrix Multiply(TMatrix otherMatrix);

        IVector Multiply<TV>(TV vector) where TV : IVectorBase<TV>;
    }
}
