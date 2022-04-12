# Excersice 4: More flexible vectors
This exercise is the forth one in a series to provide an introduction into the C# language and various programing concepts within an example project. The example project is a simple linear algebra library that can perform mathematical operations on vectors and matrices.<br>

In this excersice the focus will be on passing all tests related to <b>Vector.cs</b> found in "LinearAlgebraLibrary/LinearAlgebraLibrary.Tests/Excercise04_Tests.cs":
- Ex04_Task01_Dimensions
- Ex04_Task02_L2Norm
- Ex04_Task03_Adding
- Ex04_Task03_Adding_NonMatchingDimensions
- Ex04_Task04_Subtracting
- Ex04_Task04_Subtracting_NonMatchingDimensions
- Ex04_Task05_ScalarMultiplication
- Ex04_Task06_DotProduct
- Ex04_Task06_DotProduct_NonMatchingDimensions
- Ex04_Task07_AddingOperator
- Ex04_Task08_SubtractingOperator
- Ex04_Task09_ScalarMultiplicationOperator
- Ex04_Task10_TryGetVector23
- Ex04_Task11_FromVector23
- Ex04_Task12_OperatorOverloads_2d
- Ex04_Task12_OperatorOverloads_3d

Many of the tasks will be very similar to excercies 2, with a few exceptions.

## Task 1: Vector dimensions
Since the interface <b>IVectorBase< T></b> which is inherited by <b>IVector3</b> demands a property for the number of vector dimensions, the class <b>Vector2</b> also needs to to implement this.<br>

<b>TODO:</b> Add your implementation:
```Csharp
/// <summary>
/// Dimension count of this vector
/// </summary>
public int Dimensions => throw new NotImplementedException();
```
NOTE: Here we are using a lambda expression instead of a getter method, which would also be possible.


## Task 2: Length of the vector (L2-Norm)
The length of a vector is often determined by the L2-Norm. For a 3-dimensional vector this is defined by: 
```math
L = sqrt(x^2 + y^2 + z^2)
```

<b>TODO:</b> Add your implementation:
```Csharp
/// <summary>
/// Gets the L2 norm of this vector
/// </summary>
public double Length => throw new NotImplementedException();
```
NOTE: Here we are using a lambda expression instead of a getter method, which would also be possible.


## Task 3: Vector addition
Vector addtion works by adding all components seperately and using the summed components for the resulting vector.<br>
<b>TODO:</b> Add your implementation:
```Csharp
/// <summary>
/// Adds another vector to this vector and returns the result as a new vector
/// </summary>
/// <param name="otherVector">vector to add</param>
/// <returns></returns>
public IVector3 Add(IVector3 otherVector)
{
    throw new NotImplementedException();
}
```

## Task 4: Vector subtraction
Vector addtion works by subtracting all components seperately and using the summed components for the resulting vector.<br>
<b>TODO:</b> Add your implementation:
```Csharp
/// <summary>
/// Subtracts another vector to this vector and returns the result as a new vector
/// </summary>
/// <param name="otherVector">vector to subtract</param>
/// <returns></returns>
public IVector3 Subtract(IVector3 otherVector)
{
    throw new NotImplementedException();
}
```

## Task 5: Scalar multiplication
Vectors can be multiplied with scalars by multipliying every component of the vector seperately with the scalar number.<br>
<b>TODO:</b> Add your implementation:
```Csharp
/// <summary>
/// Multiplies vector by a scalar factor
/// </summary>
/// <param name="factor">Scalar factor to multiply vector by</param>
/// <returns></returns>
public IVector3 Multiply(double factor)
{
    throw new NotImplementedException();
}
```

## Task 6: The dot product
The dot product between two vectors is the projected length of one vector on the other vector. Mathematically it is defined as follows:
```math
d = x1*x2 + y1*y2 + z1*z2
```
<b>TODO:</b> Add your implementation:
```Csharp
/// <summary>
/// Returns the dot product of two vectors
/// </summary>
/// <param name="otherVector">other vector to calculate the dot product with</param>
/// <returns></returns>
public double DotProduct(IVector3 otherVector)
{
    throw new NotImplementedException();
}
```

## Task 7: Pseudo cross product
The cross product between two vectors defines the vector which is perpendicular to the plane spanned by those vectors. Mathematically it is defined as follows:
```math
    |y1*z2 - z1*y2|
n = |z1*x2 - x1*z2|
    |x1*y2 - y1*x2|
```
<b>TODO:</b> Add your implementation:
```Csharp
/// <summary>
/// Returns the cross product of two vectors
/// </summary>
/// <param name="otherVector">other vector to calculate the cross product with</param>
/// <returns></returns>
public IVector3 CrossProduct(IVector3 otherVector)
{
    throw new NotImplementedException();
}
```

## Task 8, 9, 10: Operators
<b>TODO:</b> Use the methods you have implemented so war to get the operators to work.
