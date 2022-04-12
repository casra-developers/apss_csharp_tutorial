using System;
using LinearAlgebraLibrary.Interface;

namespace LinearAlgebraLibrary.Exercise
{
    public class Vector3 : IVector3
    {
        public int Dimensions { get; }
        public double Length { get; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3()
        {
            throw new NotImplementedException();
        }

        public Vector3(double x, double y, double z)
        {
            throw new NotImplementedException();
        }

        public IVector3 Add(IVector3 otherVector)
        {
            throw new NotImplementedException();
        }

        public IVector3 Subtract(IVector3 otherVector)
        {
            throw new NotImplementedException();
        }

        public IVector3 Multiply(double factor)
        {
            throw new NotImplementedException();
        }

        public double DotProduct(IVector3 otherVector)
        {
            throw new NotImplementedException();
        }
        
        public IVector3 CrossProduct(IVector3 otherVector)
        {
            throw new NotImplementedException();
        }
    }
}
