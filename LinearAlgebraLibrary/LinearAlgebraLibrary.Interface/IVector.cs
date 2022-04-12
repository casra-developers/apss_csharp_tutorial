using System;

namespace LinearAlgebraLibrary.Interface
{
    /// <summary>
    /// Vector that has no fixed dimension
    /// </summary>
    public interface IVector : IVectorBase<IVector>
    {
        /// <summary>
        /// Gets or sets vector component
        /// </summary>
        /// <param name="i">component index</param>
        /// <returns></returns>
        double this[int i] { get; set; }

        /// <summary>
        /// Try to generate <see cref="IVector2"/> from vector
        /// </summary>
        /// <param name="vector2">result</param>
        /// <returns>Returns true if successful</returns>
        bool TryGetVector2(out IVector2? vector2);

        /// <summary>
        /// Try to generate <see cref="IVector3"/> from vector
        /// </summary>
        /// <param name="vector3">result</param>
        /// <returns>Returns true if successful</returns>
        bool TryGetVector3(out IVector3? vector3);

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="vector2">other vector to calculate the dot product with</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        double DotProduct(IVector2 vector2);

        /// <summary>
        /// Returns the dot product of two vectors
        /// </summary>
        /// <param name="vector3">other vector to calculate the dot product with</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
        double DotProduct(IVector3 vector3);
    }
}
