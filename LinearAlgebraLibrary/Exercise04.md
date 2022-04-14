# Exercise 4: More flexible vectors
This exercise is the forth one in a series to provide an introduction into the C# language and various programming concepts within an example project. The example project is a simple linear algebra library that can perform mathematical operations on vectors and matrices.<br>

In this exercise the focus will be on passing all tests related to <b>Vector.cs</b> found in "LinearAlgebraLibrary/LinearAlgebraLibrary.Tests/Excercise04_Tests.cs":
- Ex04_Task01_Constructors
- Ex04_Task01_ConstructorsWithInvalidArgs
- Ex04_Task02_ComponentAccess
- Ex04_Task03_Dimensions
- Ex04_Task04_L2Norm
- Ex04_Task05_Adding
- Ex04_Task05_Adding_NonMatchingDimensions
- Ex04_Task06_Subtracting
- Ex04_Task06_Subtracting_NonMatchingDimensions
- Ex04_Task07_ScalarMultiplication
- Ex04_Task08_DotProduct
- Ex04_Task08_DotProduct_NonMatchingDimensions
- Ex04_Task09_AddingOperator
- Ex04_Task10_SubtractingOperator
- Ex04_Task11_ScalarMultiplicationOperator
- Ex04_Task12_TryGetVector23
- Ex04_Task13_FromVector23
- Ex04_Task13_OperatorOverloads_2d
- Ex04_Task14_OperatorOverloads_3d

After the last two excercises we have now implemented vectors with two and three components. While this covers many geometry problems, calculations with more than three elements are not possible. In this excercise we will focus on an another vector class called <b>Vector</b>. This vector can have any number of components but also have can be used with calculations with the vector classes we have already implemented. To achive the last goal we need to rely on <b>method overloading</b>.<br>
Have a look at the start of "LinearAlgebraLibrary/LinearAlgebraLibrary.Exercise/Vector.cs":
```Csharp
public class Vector : IVector
{
    //
    // private members
    //
    private readonly double[] _storage;
    ...
```
As you can see the real-valued vector stores its data in a **readonly, private member variable**. Readonly variables can only be set once in the constructor and cannot be set again. This means that the vector can have any number of components but once its created it cannot change the number of components.

## Task 1: The constructors
With these vectors being able to have any number of components, the constructors need to be handled a bit differently than with **Vector2 and Vector3**. Keep in mind that the constructors are the only place where we can set the **_storage** member variable. Once again we have two overloads for the constructor:
```Csharp
/// <summary>
/// Creates vector with all zero components
/// </summary>
/// <param name="dimensions">Dimensions of vector</param>
/// <exception cref="ArgumentOutOfRangeException">Throws exception if invalid number of components is provided</exception>
public Vector(int dimensions)
{
    throw new NotImplementedException();
}

/// <summary>
/// Creates vector from array
/// </summary>
/// <param name="vectorSource"></param>
public Vector(params double[] vectorSource)
{
    throw new NotImplementedException();
}
```
You might have notices the keyword **params** in the signature of the second constructor overload. This keyword allows to have methods in C# a variable amount of parameters. This means that we can use our vector as follows:
```Csharp
var v1 = new Vector(2.5, 3.2, 5.1);
var v2 = new Vector(2.1, 1.3);
var v3 = new Vector(2.1, 1.3, 0.1, 4.8);
```
**TODO:** Add your implementation for the constructors. Use the automated tests to check if your solution is correct. HINT: You also need to handle the case when a user tries to give an invalid dimension. In those cases we want to raise an exception. Exceptions are raise as follows:
```Csharp
// pick the proper one
throw new Exception("message");
throw new ArgumentOutOfRangeException("another message");
throw new ArgumentException("another message yet again");
```

Next point on our agenda is to access the components once the vectors have been constructed.

## Task 2: Component access
Now that our vector can be created, we also need a way to access its components. Before with the other vectors, we have realized this with properties X, Y and Z. This is no longer feasible. What we want todo instead is to be able to use the vector like an array and access the components by using their indices:
```Csharp
var v1 = new Vector(2.5, 3.2, 5.1);

// writes 2.5 to the console output
Console.WriteLine(v1[0]);

// writes 5.1 to the console output
Console.WriteLine(v1[2]);
```
**TODO:** Implement the component access:
```Csharp
/// <summary>
/// Gets or sets vector component
/// </summary>
/// <param name="i">component index</param>
/// <returns></returns>
public double this[int i]
{
    get => throw new NotImplementedException();
    set => throw new NotImplementedException();
}
```
This time you do not need to worry about raising exeptions yoursef, if you use the **_storage** member variable properly, the proper exceptions will be raised if an illegal index is supplied to either the getter or setter methods.

## Task 3: Vector dimensions
For the other vectors this method was basically always returning a constant value. Now that our vector can have any number of dimensions the code will be different.<br>

<b>TODO:</b> Add your implementation:
```Csharp
/// <summary>
/// Dimension count of this vector
/// </summary>
public int Dimensions => throw new NotImplementedException();
```
NOTE: Here we are using a lambda expression instead of a getter method, which would also be possible.


## Task 4: Length of the vector (L2-Norm)
The length of a vector is often determined by the L2-Norm. For vectors with n dimensions is defined by: 
```math
L = sqrt(sum(x_i^2))
```
For the implementation of this task notice the following using statement:
```CSharp
using System.Linq;
```
LINQ adds a number of powerfull extensions to C# programming. Online you can find many tutorials on how to use LINQ properly, here we will just show a few examples how code can be simplified using LINQ:
```Csharp
var values = new [] {1.2, 5.7, 1.1, 6.3, 3.6};
var sum = 0;

// Sum: iterative implementation
foreach (var value in values){
    sum += values;
}

// Sum: LINQ
sum = values.Sum();

// Formula applied accross array (x^2 + 5x - 7): iterative implementation
var formulaResults = new double[values.Length];
for (var i = 0; i < formulaResults.Length; ++i>){
    formulaResults[i] = values[i] * values[i] + 5* values[i] - 7;
}

// Formula applied accross array (x^2 + 5x - 7): LINQ
formulaResults = values.Select(v => v*v + 5*v - 7).ToArray();
```
As you can see, the code can get much shorter. There are two things to note: **v => v*v+5v-7** is an anonymous function or **lambda expression**. This allows you to write inline functions, the expression starts with parameters followed by **=>** after which the function comes. The other thing to note is the **ToArray()** call at the end of the last line. This is needed to evaluate the select LINQ statement on all elements. LINQ will usually generate **IEnummerables** which are not evaluated until elements are accessed or they are cast to lists or arrays. Some examples of lambda expresssions:
```Csharp
// can be saved to variables
var myFun = v => v*v + 5*v -7;
var res1 = myFun(5);
var res2 = myFun.Invoke(6);

// no parameters
var myFun2 = () => Console.WriteLine("hello");

// multiple parameters
var myFun3 = (a, b) => 2*a + 3*b;

// multiple lines (access to local scope)
var myFun4 = (a, b) => {
    res1 = a + b;
    res2 = a - b;
};
```
<b>TODO:</b> Add your implementation, use the lambda expressions to calculate the L2-norm in one line for all components:

```Csharp
/// <summary>
/// Gets the L2 norm of this vector
/// </summary>
public double Length => throw new NotImplementedException();
```

## Task 5: Vector addition
In the previous vector classes, addition was something quite straightforward to implement. With both vectors having a variable amount of components you need to consider some edge cases.<br>
<b>TODO:</b> Add your implementation, raise exceptions if necessary:
```Csharp
/// <summary>
/// Adds another vector to this vector and returns the result as a new vector
/// </summary>
/// <param name="otherVector">vector to add</param>
/// <returns></returns>
/// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
public IVector Add(IVector otherVector)
{
    throw new NotImplementedException();
}
```

## Task 6: Vector subtraction
<b>TODO:</b> Add your implementation, raise exceptions if necessary:
```Csharp
/// <summary>
/// Subtracts another vector to this vector and returns the result as a new vector
/// </summary>
/// <param name="otherVector">vector to subtract</param>
/// <returns></returns>
/// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
public IVector Subtract(IVector otherVector)
{
    throw new NotImplementedException();
}
```

## Task 7: Scalar multiplication
For the scalar multiplication you can use either loops or lambda expressions to implement it. Make sure that you create a new instance as the result and change the original vector.<br>
<b>TODO:</b> Add your implementation:
```Csharp
/// <summary>
/// Multiplies vector by a scalar factor
/// </summary>
/// <param name="factor">Scalar factor to multiply vector by</param>
/// <returns></returns>
public IVector Multiply(double factor)
{
    throw new NotImplementedException();
}
```

## Task 8: The dot product
The dot product between two vectors is the projected length of one vector on the other vector. This is less intuitive if we move to dimensions higher than three, still the dot product is very important in higher dimensions as well. Mathematically it is defined as follows:
```math
d = sum(x1_i * x2_i)
```
<b>TODO:</b> Add your implementation, handle edge cases by raising the appropriate exceptions:
```Csharp
/// <summary>
/// Returns the dot product of two vectors
/// </summary>
/// <param name="otherVector">other vector to calculate the dot product with</param>
/// <returns></returns>
/// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
public double DotProduct(IVector otherVector)
{
    throw new NotImplementedException();
}
```

## Task 9, 10, 11: Operators
**TODO:** Have a look at the operator methods:
```CSharp
/// <summary>
/// Adds two vectors
/// </summary>
/// <param name="a">first vector</param>
/// <param name="b">second vector</param>
/// <returns></returns>
/// <exception cref="ArgumentException">Thrown if dimensions do not match</exception>
public static IVector operator +(Vector a, Vector b)
{
    throw new NotImplementedException();
}
```
For now, ignore the overloaded methods using **IVector2** and **IVector3** and only implement the methods with **Vector** parameters.

## Task 12: The try-get methods
This new **Vector** class we have been working on has the advantage over the **Vector2** and **Vector3** types that it can hold as many components as needed. It can also calculate its norm and perform other operations. What it cannot do is perform operatins only defined on 2- or 3-dimensional vector spaces. One example would be the cross-product: In principle it should be defined if we have a vector like:
```CSharp
var vector = new Vector(1, 2, 3);
```
But since the vector itself is not aware that it is now part of the space of all 3-dimensional vectors, we cannot use the cross product. The goal of this task is to rectify this by implementing methods that can generate more specialized vectors if the dimensions allow it.<br>

**TODO:** Have a look at the following methods:
```Csharp
/// <summary>
/// Try to generate <see cref="IVector2"/> from vector
/// </summary>
/// <param name="vector2">result</param>
/// <returns>Returns true if successful</returns>
public bool TryGetVector2(out IVector2? vector2)
{
    throw new NotImplementedException();
}

/// <summary>
/// Try to generate <see cref="IVector3"/> from vector
/// </summary>
/// <param name="vector3">result</param>
/// <returns>Returns true if successful</returns>
public bool TryGetVector3(out IVector3? vector3)
{
    throw new NotImplementedException();
}
```
You have probably noticed something new in the form of the **out** keyword. This keyword can be used to add multiple return values to a method in C#. It is important to set this value before the return statement within the function, else the code wont run. Also notice the **?** behind the vector types. The **?** marks a type as being **nullable**, which allows it to be set to **Null** even if its a primitive type like **int** or **double**.<br>
In this implementation check if the dimensions of the vector is matching the target type (Vector2, or Vector3) and the assign a new instance of the target type to the **out** parameter. Lastly, either return **true** if the conversion was successful or **false** if it fails. This operation does not generate exceptions but just returns **Null** as the result vector and indicates its success with the boolean return value.

## Task 13: Generation from specialized vectors
In the last task we have implemented as method to generate more specialized vector types to access operations which are only defined on certain vector spaces. So far however it is not possible to do the follwing:
```Csharp
var a = new Vector(1, 2, 3);
var b = new Vector3(4, 5, 5);
var c = a + c;
```
This makes sense from a programming perspective, since both objects are of different classes. On the other hand, since both vectors have three dimensions it should be possible to add them. To solve this we need to implement the following static methods:
```Csharp
/// <summary>
/// Generate vector from <see cref="IVector2"/>
/// </summary>
/// <param name="vector2">source vector</param>
/// <returns></returns>
public static IVector FromVector2(IVector2 vector2) => throw new NotImplementedException();

/// <summary>
/// Generate vector from <see cref="IVector3"/>
/// </summary>
/// <param name="vector3">source vector</param>
/// <returns></returns>
public static IVector FromVector3(IVector3 vector3) => throw new NotImplementedException();
```
Those methods will generate a **Vector** instance from **IVector2** and **IVector3** objects. Static methods are accessible without creating an instance of a class:
```Csharp
var vector3 = new Vector3(4, 5, 5);
var vector3_converted = Vector.FromVector3(vector3);
```
**TODO:** Implement the **FromVector** methods.

## Task 4: More operators
Now that the conversion from and to specialized vector types is implemented, it is time to implement the final missing methods in the **Vector** class. Before we ignored the overloaded operators for **IVector2** and **IVector3**.<br>
**TODO:** Use the conversion methods thogether with the Add and Subtract methods to implement the missing operators.
