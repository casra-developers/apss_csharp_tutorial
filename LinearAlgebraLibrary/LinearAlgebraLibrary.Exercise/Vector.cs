using System;
using LinearAlgebraLibrary.Interface;

namespace LinearAlgebraLibrary.Exercise
{
    public class Vector : IVector
    {
        public int Dimensions { get; }
        public double Length { get; }

        public double this[int i]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public Vector(int dimensions)
        {
            throw new NotImplementedException();
        }

        public Vector(double[] vectorSource)
        {
            throw new NotImplementedException();
        }


        public IVector Add(IVector otherVector)
        {
            throw new NotImplementedException();
        }

        public IVector Subtract(IVector otherVector)
        {
            throw new NotImplementedException();
        }

        public IVector Multiply(double factor)
        {
            throw new NotImplementedException();
        }

        public double DotProduct(IVector otherVector)
        {
            throw new NotImplementedException();
        }

        public bool TryGetVector2(out IVector2? vector2)
        {
            throw new NotImplementedException();
        }

        public bool TryGetVector3(out IVector3? vector3)
        {
            throw new NotImplementedException();
        }

        public double DotProduct(IVector2 vector2)
        {
            throw new NotImplementedException();
        }

        public double DotProduct(IVector3 vector2)
        {
            throw new NotImplementedException();
        }
    }
}
