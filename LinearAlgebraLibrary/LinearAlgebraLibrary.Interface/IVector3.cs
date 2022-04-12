namespace LinearAlgebraLibrary.Interface
{
    /// <summary>
    /// Vector with X, Y and Y components
    /// </summary>
    public interface IVector3 : IVectorBase<IVector3>
    {
        /// <summary>
        /// Gets or sets the X component of this vector
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the Y component of this vector
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the Z component of this vector
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Returns the cross product of two vectors
        /// </summary>
        /// <param name="otherVector">other vector to calculate the cross product with</param>
        /// <returns></returns>
        IVector3 CrossProduct(IVector3 otherVector);
    }
}
