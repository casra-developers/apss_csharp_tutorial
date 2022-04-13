# Excersice 2: C# coding concepts
This exercise is the second one in a series to provide an introduction into the C# language and various programing concepts within an example project. The example project is a simple linear algebra library that can perform mathematical operations on vectors and matrices.<br>

In this excersice the focus will be on passing all tests related to <b>Vector2.cs</b> found in "LinearAlgebraLibrary/LinearAlgebraLibrary.Tests/Excercise02_Tests.cs":
- Ex02_Task01_Dimensions
- Ex02_Task02_L2Norm
- Ex02_Task03_Adding
- Ex02_Task04_Subtracting
- Ex02_Task05_ScalarMultiplication
- Ex02_Task06_DotProduct
- Ex02_Task07_PseudoCrossProduct
- Ex02_Task08_AddingOperator
- Ex02_Task09_SubtractingOperator
- Ex02_Task10_ScalarMultiplicationOperator

## Task 1: Vector dimensions
Since the interface <b>IVectorBase< T></b> which is inherited by <b>IVector2</b> demands a property for the number of vector dimensions, the class <b>Vector2</b> also needs to to implement this.<br>

<b>TODO:</b> Add your implementation:
```Csharp
/// <summary>
/// Dimension count of this vector
/// </summary>
public int Dimensions => throw new NotImplementedException();
```
NOTE: Here we are using a lambda expression instead of a getter method, which would also be possible.


## Task 2: Length of the vector (L2-Norm)
The length of a vector is often determined by the L2-Norm. For a 2-dimensional vector this is defined by: 
```math
L = sqrt(x^2 + y^2)
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
public IVector2 Add(IVector2 otherVector)
{
    throw new NotImplementedException();
}
```

## Task 4: Vector subtraction
Vector subtraction works by subtracting all components seperately and using the summed components for the resulting vector.<br>
<b>TODO:</b> Add your implementation:
```Csharp
/// <summary>
/// Subtracts another vector to this vector and returns the result as a new vector
/// </summary>
/// <param name="otherVector">vector to subtract</param>
/// <returns></returns>
public IVector2 Subtract(IVector2 otherVector)
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
public IVector2 Multiply(double factor)
{
    throw new NotImplementedException();
}
```

## Task 6: The dot product
The dot product between two vectors is the projected length of one vector on the other vector. Mathematically it is defined as follows:
```math
d = x1*x2 + y1*y2
```
<b>TODO:</b> Add your implementation:
```Csharp
/// <summary>
/// Returns the dot product of two vectors
/// </summary>
/// <param name="otherVector">other vector to calculate the dot product with</param>
/// <returns></returns>
public double DotProduct(IVector2 otherVector)
{
    throw new NotImplementedException();
}
```

## Task 7: Pseudo cross product
Strictly speaking the cross-prodcut is defined for 3 dimensions, but the pseudo cross product sometimes can be useful. Mathematically it is defined as follows:
```math
p = x1*y2 - x2*y1
```
<b>TODO:</b> Add your implementation:
```Csharp
/// <summary>
/// Returns the pseudo cross product of two vectors
/// </summary>
/// <param name="otherVector">other vector to calculate the pseudo cross product with</param>
/// <returns></returns>
public double CrossProduct(IVector2 otherVector)
{
    throw new NotImplementedException();
}
```

## Task 8, 9, 10: Operators
C# allows classes to override mathematical operators (e.g. +, -, *, ...). If we implement these operator, working with out vectors will be much more intuitive.<br>
<b>TODO:</b> Use the methods you have implemented so war to get the operators to work.
