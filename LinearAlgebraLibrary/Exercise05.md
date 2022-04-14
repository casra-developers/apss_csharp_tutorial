# Exercise 5: The Matrix
This exercise is the fifth one in a series to provide an introduction into the C# language and various programming concepts within an example project. The example project is a simple linear algebra library that can perform mathematical operations on vectors and matrices.<br>

In this exercise the focus will be on passing all tests related to <b>Vector.cs</b> found in "LinearAlgebraLibrary/LinearAlgebraLibrary.Tests/Excercise05_Tests.cs":

- Ex05_Task01_Constructors
- Ex05_Task01_Constructors_EdgeCase
- Ex05_Task02_ComponentAccess
- Ex05_Task03_TransposeMatrix
- Ex05_Task04_Adding
- Ex05_Task04_Adding_EdgeCases
- Ex05_Task04_Subtraction
- Ex05_Task04_Subtraction_EdgeCases
- Ex05_Task05_ScalarMultiplication
- Ex05_Task06_IdentityCreation
- Ex05_Task06_IdentityCreation_EdgeCases
- Ex05_Task07_HStack
- Ex05_Task07_HStack_EdgeCases
- Ex05_Task08_VStack
- Ex05_Task08_VStack_EdgeCases
- Ex05_Task09_SubMatrix
- Ex05_Task09_SubMatrix_EdgeCases
- Ex05_Task10_MatrixMultiplication
- Ex05_Task10_MatrixMultiplication_EdgeCases
- Ex05_Task11_VectorMultiplication
- Ex05_Task11_VectorMultiplication_EdgeCases
- Ex05_Task12_MatrixDeterminant

So far we have implemented several kinds of vectors and are capable of performing operations involving them. However, anyone who knows about linear algebra knows that matrices are the key to performing many important operations such as solving linear equations, performing spatial manipulations on vectors or analyzing the stability of a mechanical system. In this tutorial we will not implement all the important methods to do all those things, but will limit ourselves to some basic operations.<br>
Take a look at "LinearAlgebraLibrary/LinearAlgebraLibrary.Exercise/Matrix.cs":
```Csharp
public class Matrix : IMatrix
{
    //
    // private members
    //
    private readonly double[,] _storage;
    ...
```
As you can see, like with the generalized vector, the matrix uses an array for internal storage. This time, the matrix is two-dimensional, reflecting the layout of the mathematical object. There are some important differences between 2D arrays and arrays containing arrays.
```Csharp
// 2D array
var arr1 = new double[5, 6];
arr1[0, 0] = 5.2;
arr1[1, 4] = 3.3;
var rows1 = arr1.GetLength(0);
var cols1 = arr1.GetLength(1);

// array of arrays
var arr2 = new double[5][];
arr2[0] = new [] {0.0, 0.0, 0.0};
arr2[1] = new [] {0.0, 0.0, 0.0, 0.0, 0.0};
arr2[0][0] = 5.2;
arr2[1][4] = 5.2;
var rows2 = arr2.Length;
var cols2 = arr2[0].Length;     // not equal to arr2[1].Length!!!!
```
The snipped above serves to illustrate how the two array storage methods differ. For a matrix with fixed row and column count, the second approach is very complicated and also contains potential for many errors.

## Task 1: Matrix constructors
The first task is concerned with the constructors of the matrix. One contructor allows the matrix to be instantiated with all zeros and given dimensions (rows and columns). Make sure that you raise exceptions if the row and column counts are invalid. The second constructor takes a 2D double array as input and uses it as storage.<br>
**TODO:** Implement the constructors. Use the test cases for this task to verify that your implementation meets the requirements.
```Csharp
/// <summary>
/// Create matrix from 2D array source
/// </summary>
/// <param name="matrixSource">matrix source data</param>
public Matrix(double[,] matrixSource)
{
    throw new NotImplementedException();
}

/// <summary>
/// Create identity matrix
/// </summary>
/// <param name="dimension">Length of matrix diagonal</param>
/// <returns></returns>
/// <exception cref="ArgumentOutOfRangeException">Throws exception if invalid dimension is given</exception>
public static Matrix CreateIdentityMatrix(int dimension)
{
    throw new NotImplementedException();
}
```

## Task 2: Matrix components
Now that the matrix can be created we also want access to its components. You can once again rely on the default exception handling for invalid inputs in the getter and setter methods like in the case of **Vector.cs**.<br>
**TODO:** Implement the getter and setter methods for the matrix components.
```CSharp
/// <summary>
/// Gets or sets component of matrix
/// </summary>
/// <param name="row">row index</param>
/// <param name="col">column index</param>
/// <returns></returns>
public double this[int row, int col]
{
    get => throw new NotImplementedException();
    set => throw new NotImplementedException();
}
```

## Task 3: Transpose the matrix
Transposing a matrix means to "rotate" it in such a way that the rows become the columns and the columns become the rows:
```math
    | 1 2 3 |
A = | 4 5 6 |
    | 7 8 9 |

      | 1 4 7 |
A.T = | 2 5 8 |
      | 3 6 9 |
```
This operation can be useful when solving systems of linear equations.<br>

**TODO:** Implement the getter of the **T** property, which returns a new matrix that is the transposed.
```Csharp
/// <summary>
/// Get transposed matrix
/// </summary>
public IMatrix T
{
    get
    {
        throw new NotImplementedException();
    }
}
```

## Task 4: Adding and subtracting matrices
To add two matrices, their dimensions need to match exactly (same amount of columns and rows). The addtition itself is then the sum of every individual component:
```math
    | 1 0 2 |
A = | 4 5 4 |
    | 3 2 1 |

    | 8 8 1 |
B = | 0 0 2 |
    | 1 3 2 |

            | 9 8 3 |
C = A + B = | 4 5 6 |
            | 4 5 3 |
```
**TODO:** Implement this in the code.
```CSharp
/// <summary>
/// Adds the components of two matrices and returns a new matrix
/// </summary>
/// <param name="otherMatrix">matrix to add</param>
/// <returns></returns>
/// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
public IMatrix Add(IMatrix otherMatrix)
{
    throw new NotImplementedException();
}
```
Subtracting matrices works very similar to adding. Now instead of adding two elements from each matrix, they are subtracted.<br>
**TODO:** Implement this in the code.
```Csharp
/// <summary>
/// Subtracts the components of two matrices and returns a new matrix
/// </summary>
/// <param name="otherMatrix">matrix to subtract</param>
/// <returns></returns>
/// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
public IMatrix Subtract(IMatrix otherMatrix)
{
    throw new NotImplementedException();
}
```

## Task 5: Multiplying matrices with scalars
To multiply a matrix by a scalar number, every component in the result matrix is multiplied by the scalar.<br>
**TODO:** Implement this in the code. Ignore the overloaded method with the matrix as parameter for now.
```Csharp
/// <summary>
/// Multiplies scalar to matrix
/// </summary>
/// <param name="scalar">scalar to multiply matrix with</param>
/// <returns></returns>
public IMatrix Multiply(double scalar)
{
    throw new NotImplementedException();
}
```

## Task 6: The identity matrix
The identity matrix is a square matrix which when can be multiplied with another square matrix of the same dimensions and does not change it. This matrix is important when doing Eivenvalue problems for example.
```Csharp
    | 1 0 0 |
A = | 0 1 0 |
    | 0 0 1 |
```
As you can see, the matrix is all zeros except on the main diagonal where there are only ones.<br>
**TODO:** Our class has a static method which is called **CreateIdentityMatrix**, implement this method and handle edge cases.
```CSharp
/// <summary>
/// Create identity matrix
/// </summary>
/// <param name="dimension">Length of matrix diagonal</param>
/// <returns></returns>
/// <exception cref="ArgumentOutOfRangeException">Throws exception if invalid dimension is given</exception>
public static Matrix CreateIdentityMatrix(int dimension)
{
    throw new NotImplementedException();
}
```

## Task 7: Stacking matrices (horizontally)
Sometimes it can be useful to stack matrices thogether to build a new matrix. If a matrix is used as a table for instance to store numeric data, additional data can be added this way.
```math
    | 1 0 2 |
A = | 4 5 4 |
    | 3 2 1 |

    | 8 8 1 |
B = | 0 0 2 |
    | 1 3 2 |

             | 1 0 2 9 8 3 |
C = [A, B] = | 4 5 4 4 5 6 |
             | 3 2 1 4 5 3 |
```
Obviously, the row counts need to match, otherwise horizontal stacking does not work.<br>
**TODO:** Implement the horizontal stacking.
```Csharp
/// <summary>
/// Stack two matrices horizontally
/// </summary>
/// <param name="otherMatrix">second matrix</param>
/// <returns></returns>
/// <exception cref="ArgumentException">Throws exception if the rows of the matrices do not match</exception>
public IMatrix HStack(IMatrix otherMatrix)
{
    throw new NotImplementedException();
}
```

## Task 8: Stacking matrices (vertically)
If we can stack matrices horizontally, it can be expected that sometimes we also want to stack them vertically.
```math
    | 1 0 2 |
A = | 4 5 4 |

    | 8 8 1 |
B = | 0 0 2 |
    | 1 3 2 |

             | 1 0 2 |
C = [A, B] = | 4 5 4 |
             | 8 8 1 |
             | 0 0 2 |
             | 1 3 2 |
```
Obviously, the column counts need to match, otherwise vertical stacking does not work.<br>
**TODO:** Implement the vertical stacking.
```Csharp
/// <summary>
/// Stack two matrices horizontally
/// </summary>
/// <param name="otherMatrix">second matrix</param>
/// <returns></returns>
/// <exception cref="ArgumentException">Throws exception if the rows of the matrices do not match</exception>
public IMatrix HStack(IMatrix otherMatrix)
{
    throw new NotImplementedException();
}
```

## Task 9: Sub-Matrix
For certain calculations a matrix can be described in terms of block-matrices where the calculations are then performed on these smaller matrices first and then the results used to complete the full calculation (more on this later). To extract block matrices we have to implement the method **SubMatrix**.
```math
    | 8 8 1 |
A = | 0 0 2 |
    | 1 3 2 |

B = A.SubMatrix(1, 2, 1, 2) = | 0 2 |
                              | 3 2 |
```
**TODO:** Implement the **SubMatrix** method, the error handling is already taken care of this time.
```Csharp
/// <summary>
/// Extract sub-matrix
/// </summary>
/// <param name="rowIndex">Start row index</param>
/// <param name="rowCount">Row count of sub-matrix</param>
/// <param name="colIndex">Start column index</param>
/// <param name="colCount">Column count of sub-matrix</param>
/// <returns></returns>
/// <exception cref="ArgumentOutOfRangeException">Throws exception if sub-matrix parameters are out of range.</exception>
public IMatrix SubMatrix(int rowIndex, int rowCount, int colIndex, int colCount)
{
    if (rowIndex < 0 || rowIndex >= Rows || rowCount < 0 || rowIndex + rowCount > Rows
        || colIndex < 0 || colIndex >= Cols || colCount < 0 || colIndex + colCount > Cols)
    {
        throw new ArgumentOutOfRangeException($"Cannot create sub-matrix, range given not valid: [{rowIndex}:{rowIndex + rowCount}, {colIndex}:{colIndex + colCount}]");
    }

    throw new NotImplementedException();
}
```

## Task 10: Matrix multiplication
The most important operation that can be performed on matrices is arguably the matrix multiplication. It has several interesting properties like for instance that it is not commutative which means that **A * B** is not equal to **B * A**. The way two matrices are multiplied is as follows:
- for every row in the first matrix:
  - for every column in the second matrix:
    - build the sum the products of all the elements in the selected row of the first matrix and the selected column of the second matrix -> this becomes an element of the product matrix

This algorithm is probably not easy to understand but you will find many resources online, describing this operation. Additionally, look at the following example:
```math
    | 1 5 |
A = | 0 2 |
    | 2 3 |

B = | 5 5 1 |
    | 0 2 4 |

            | (1*5 + 5*0) (1*5 + 5*2) (1*1 + 5*4) |   |  5 15 21 |
C = A * B = | (0*5 + 2*0) (0*5 + 2*2) (0*1 + 2*4) | = |  0  4  8 |
            | (2*5 + 3*0) (2*5 + 3*2) (2*1 + 3*4) |   | 10 16 14 |
```

This algorithm leads to a matrix which has the same amount of rows as the first matrix and the same amount of columns as the second matrix. This only works if and only if the amount of columns of the first matrix is equal to the amount of rows of the second matrix.<br>
**TODO:** Implement the matrix multiplication for two matrices. Use online resources if you get stuck. Make sure to handle invalid matrix pairings with the proper exceptions.
```Csharp
/// <summary>
/// Multiplies two matrices and returns resulting matrix
/// </summary>
/// <param name="otherMatrix">matrix to multiply</param>
/// <returns></returns>
/// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
public IMatrix Multiply(IMatrix otherMatrix)
{
    throw new NotImplementedException();
}
```

## Task 11: Matrix-vector multiplication
Matrices can also by multiplied by vectors. This operation is often used to transform vectors. Vectors can be translated, rotated or scaled by matrix multiplications, just to name a few examples. On a technical leve, the matrix-matrix multiplication is more difficult than the matrix-vector multiplication. Strictly speaking, a vector is a matrix with just one column. One approach could be to generate a new matrix from a vector and use the matrix multiplication from the last task to do the work. On the other hand since there is only one column present in the vector, the calculation can be optimized. A matrix-vector multiplication always yields a vector as output.
```Csharp
    | 1 5 |
A = | 0 2 |
    | 2 3 |

_
v = | 5 |
    | 0 |

_            | (1*5 + 5*0) |   |  5 |
v2 = A * B = | (0*5 + 2*0) | = |  0 |
             | (2*5 + 3*0) |   | 10 |
```
**TODO:** Implement the non-generic matrix-vector multiplication:
```Csharp
/// <summary>
/// Multiplies matrix with vector
/// </summary>
/// <param name="vector">vector to multiply</param>
/// <returns></returns>
/// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
public IVector Multiply(IVector vector)
{
    throw new NotImplementedException();
}
```
As you might remember in other excercises we implement the more specialied vectors **Vector2** and **Vector3**. With the method we just implemented, we can only handle vectors which implement **IVector**, that is **Vector**. To support all vectors in our library, we need to implement the generic method as well:
```Csharp
/// <summary>
/// Multiplies matrix with vector
/// </summary>
/// <param name="vector">vector to multiply</param>
/// <returns></returns>
/// <exception cref="ArgumentException">Throws exception if the matrix dimensions do not match</exception>
public IVector Multiply<TV>(TV vector) where TV : IVectorBase<TV>
{
    throw new NotImplementedException();
}
```
To do this use the non-generic method, as well as the **Vector.FromVector2, Vector.FromVector3** methods. Another useful hint is a C# feature called **pattern-matching**. This in combination with **switch-case** blocks can be used to get cast types in an efficient manner.
```Csharp
void WhatIsThis(object obj){
    switch(obj){
        case string text:
            Console.WriteLine($"Object is text and can be printed: {text}");
            break;
        case int wholeNumber:
            Console.WriteLine($"Object is whole number, one can be added to get: {(wholeNumber + 1)}")
            break;
        case Car car:
            Console.WriteLine($"Object is a car and has {car.WheelCount} wheels.")
            break;
        default:
            Console.WriteLine("No idea what kind of object this is.")
            break;
    }
}
```
From the snipped above you probably can get an idea on how to use pattern-matching in the generic version of the matrix-vector multiplication. Obviously, this could also be done by using method overloading for all different vector types, but the generic lets the compiler do this work instead of us.<br>
**TODO:** Use what you have done so far in this tasks and the knowledge on pattern-matching to implement the generic matrix-vector multiplication.

## Task 12: Matrix determinant
The determinant of a matrix is a number that is only defined for square matrices (same amount of rows as there are columns). The determinant is very important when using matrices to solve systems of linear equations or when modeling systems based on differential equations.<br>
Determinants are calculated differently based on the dimensions of the matrix:
- 2x2 Matrix:
  ```math
  A = | a b |
      | c d |

  det(A) = a*d - c*d
  ```
- 3x3 Matrix:
  ```math
      | a b c |
  A = | d e f |
      | g h i |

  det(A) = a*e*i + b*f*g + c*d*h - g*e*c - h*f*a - i*d*b   (Sarrus' rule)
  ```
To create the determinant for a matrix bigger than 3x3, recursion and block matrices can be used.
```math
    | a b c d |
A = | e f g h |
    | i j k l |
    | m n o p |


                | f g h |          | e g h |          | e f h |          | e f g |
det(A) = a * det| j k l | - b * det| i k l | + c * det| i j l | - d * det| i j k |
                | n o p |          | m o p |          | m n p |          | m n o |
```
As you can see from the example above through this **recursive** approach this problem can be solved for any NxN matrix.<br>
**TODO:** Implement the getter of the determinant property. If the matrix is not square, return **double.NaN**. This is the hardest task of all the excercises, you will have to use some of the tools we have developed so far and some other concepts:
- SubMatrix
- HStack
- IsSquare
- recursion
- the modulo operator (%)
```Csharp
/// <summary>
/// Get matrix determinant (NaN if matrix is not square)
/// </summary>
public double Determinant
{
    get
    {
        throw new NotImplementedException();
    }
}
```

Good Luck!
