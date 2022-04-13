using LinearAlgebraLibrary.Interface;

namespace LinearAlgebraLibrary.Test
{
    internal static class LinearAlgebraFactory
    {
        private const bool UseImplementationFromSolution = true;

        internal static IVector2 MakeVector2()
        {
            return UseImplementationFromSolution
                ? new LinearAlgebraLibrary.Solution.Vector2()
                : new LinearAlgebraLibrary.Exercise.Vector2();
        }

        internal static IVector2 MakeVector2(double x, double y)
        {
            return UseImplementationFromSolution
                ? new LinearAlgebraLibrary.Solution.Vector2(x, y)
                : new LinearAlgebraLibrary.Exercise.Vector2(x, y);
        }

        internal static IVector3 MakeVector3()
        {
            return UseImplementationFromSolution
                ? new LinearAlgebraLibrary.Solution.Vector3()
                : new LinearAlgebraLibrary.Exercise.Vector3();
        }

        internal static IVector3 MakeVector3(double x, double y, double z)
        {
            return UseImplementationFromSolution
                ? new LinearAlgebraLibrary.Solution.Vector3(x, y, z)
                : new LinearAlgebraLibrary.Exercise.Vector3(x, y, z);
        }

        internal static IVector MakeVector(int dimensions)
        {
            return UseImplementationFromSolution
                ? new LinearAlgebraLibrary.Solution.Vector(dimensions)
                : new LinearAlgebraLibrary.Exercise.Vector(dimensions);
        }

        internal static IVector MakeVector(params double[] components)
        {
            return UseImplementationFromSolution
                ? new LinearAlgebraLibrary.Solution.Vector(components)
                : new LinearAlgebraLibrary.Exercise.Vector(components);
        }

        internal static IMatrix MakeMatrix(int rows, int cols)
        {
            return UseImplementationFromSolution
                ? new LinearAlgebraLibrary.Solution.Matrix(rows, cols)
                : new LinearAlgebraLibrary.Exercise.Matrix(rows, cols);
        }

        internal static IMatrix MakeMatrix(double[,] matrixSource)
        {
            return UseImplementationFromSolution
                ? new LinearAlgebraLibrary.Solution.Matrix(matrixSource)
                : new LinearAlgebraLibrary.Exercise.Matrix(matrixSource);
        }

    }
}
