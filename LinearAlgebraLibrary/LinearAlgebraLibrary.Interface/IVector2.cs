namespace LinearAlgebraLibrary.Interface
{
    /// <summary>
    /// Vector with X and Y components
    /// </summary>
    public interface IVector2 : IVectorBase<IVector2>
    {
        /// <summary>
        /// Gets or sets the X component of this vector
        /// </summary>
        double X { get; set; }

        /// <summary>
        /// Gets or sets the X component of this vector
        /// </summary>
        double Y { get; set; }

        /// <summary>
        /// Returns the pseudo cross product of two vectors
        /// </summary>
        /// <param name="otherVector">other vector to calculate the pseudo cross product with</param>
        /// <returns></returns>
        double CrossProduct(IVector2 otherVector);
    }
}
