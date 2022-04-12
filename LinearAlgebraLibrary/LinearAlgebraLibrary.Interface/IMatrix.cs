namespace LinearAlgebraLibrary.Interface
{
    public interface IMatrix : IMatrixBase<IMatrix>
    {
        IVector Multiply(IVector vector);

        IMatrix SubMatrix(int rowIndex, int rowCount, int colIndex, int colCount);
    }
}
