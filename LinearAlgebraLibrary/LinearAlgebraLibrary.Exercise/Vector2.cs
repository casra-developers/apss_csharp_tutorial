using System;
using LinearAlgebraLibrary.Interface;

namespace LinearAlgebraLibrary.Exercise
{
    public class Vector2 : IVector2
    {
        public int Dimensions { get; }
        public double Length { get; }
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2()
        {
            throw new NotImplementedException();
        }

        public Vector2(double x, double y)
        {
            throw new NotImplementedException();
        }

        public IVector2 Add(IVector2 otherVector)
        {
            throw new NotImplementedException();
        }

        public IVector2 Subtract(IVector2 otherVector)
        {
            throw new NotImplementedException();
        }

        public IVector2 Multiply(double factor)
        {
            throw new NotImplementedException();
        }

        public double DotProduct(IVector2 otherVector)
        {
            throw new NotImplementedException();
        }
        
        public double CrossProduct(IVector2 otherVector)
        {
            throw new NotImplementedException();
        }
    }
}
