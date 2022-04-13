# Excersice 5: The Matrix
This exercise is the fifth one in a series to provide an introduction into the C# language and various programming concepts within an example project. The example project is a simple linear algebra library that can perform mathematical operations on vectors and matrices.<br>

In this excersice the focus will be on passing all tests related to <b>Vector.cs</b> found in "LinearAlgebraLibrary/LinearAlgebraLibrary.Tests/Excercise05_Tests.cs":



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
