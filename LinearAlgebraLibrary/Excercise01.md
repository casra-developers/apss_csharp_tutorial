# Excersice 1: C# projects and the excersice solution
This exercise is the first one in a series to provide an introduction into the C# language and various programing concepts within an example project. The example project is a simple linear algebra library that can perform mathematical operations on vectors and matrices.

## Task 1: Getting to know the Solution
Software developed in C# usually takes the form of a "Solution" (LinearAlgebraLibrary.sln). The solution itself is a folder containing the solution file which contains meta-information about the software and all the projects its made off. A solution can contain one or multiple "Projects". Projects usually are contained within their own sub-folders (e.g. LinearAlgebraLibrary.Exercise/LinearAlgebraLibrary.Exercise.csproj). Similar to the solution file, Projects also store meta-data in Project files with the extension *.csproj.
<br><br>
Our solution has the following structure:
- LinearAlgebraLibrary.sln
  - LinearAlgebraLibrary.Interface.csproj
  - LinearAlgebraLibrary.Exercise.csproj
  - LinearAlgebraLibrary.Solution.csproj
  - LinearAlgebraLibrary.Test.csproj

All projects (except LinearAlgebraLibrary.Test.csproj) use .NET Standard 2.1 as their target framework. This framework allows C# libraries to be written and used by many other frameworks (.NET Core 3.1, .NET 5.0, .NET 6.0, etc.) but .NET Standard projects cannot be run as applications themselves. In contrast, LinearAlgebraLibrary.Test.csproj uses .NET 6.0 as target framework and is configured to actually run as an application. This project will be used to verify that the excersises were solved correctly.<br>

<b>TODO:</b> Open one of the code files (*.cs) in the folder "LinearAlgebraLibrary/LinearAlgebraLibrary.Exercise". You will find many methods in the code like the following example:
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
Everywhere where the line 
```Csharp
throw new NotImplementedException(); 
```
is present, the goal is to replace those with solutions for the problems.

## Task 2: Running and debugging tests
This task will show how the excersises will be checked after they have been worked on. To do this the project "LinearAlgebraLibrary.Test.csproj" can be used which contains Unit-Tests. Unit-Tests are snippets of code that can be run seperately and usually assert a certain behaviour. In development it is generally good practice to have automated tests that check code for expected behaviour and even better try to provoke edge-cases.<br>

<b>TODO:</b> Open the file "LinearAlgebraLibrary/LinearAlgebraLibrary.Tests/Excercise01_Tests.cs" at the top you will see a method like this.

```Csharp
[Test]
public void Ex01_Task2_hello_world()
{
    Console.WriteLine("Hello World!");
    Assert.Pass("Hello World, you've passed this test just by running it.");
}
```

This is a unit-test. To run this test go to the menu bar of Visual Studio 2019 / 2022 and look for <b>Test -> Test Explorer</b>. In the test explorer you should see the test project and be able to run the tests for all the excersises. Run the first test. The test shoul complete successfully, clicking on it should reveal further information, like the console output "Hello World!" or the assertion output "Hello World, you've passed this test just by running it.". This output will provide you with valuable information in case someting fails.<br>

<b>TODO:</b> In the file "Excercise01_Tests.cs" place your text-cursor on the line
```Csharp
Console.WriteLine("Hello World!");
```
then use the shortcut <b>CTRL+F9</b> or right-click and choose <b>Toggle breakpoint</b>, if done correctly, you should see a red dot at the line number. Right-click the test in the test explorer and this time instead of clicking run, choose "Debug" instead. This time once the test starts running you should actually hit the breakpoint and pause execution of the test. You can press <b>F10</b> to continue one line or <b>F5</b> to run to either the next breakpoint or the end of the program. Debugging is extremely useful if you want to know what happes during execution of your code and is one of the most important tools when working with C#.

## Task 3: Classes and interfaces
C# is like Java and many other languages a so called <b>Object-Oriented</b> programing language. This means that developers can create their own data structures (Classes) which can have their own attributes, properties, methods and operators. Furthermore, classes can also inherit other classes, thereby gaining all their properties which they then can also extend or change. In this task we are not going too deep into the theoretical aspects of OOP but rather illustrate how the cocept is used in the LinearAlgebraLibrary.

<b>TODO:</b> Open the file "LinearAlgebraLibrary/LinearAlgebraLibrary.Excercise/Vector2.cs". Have a look at the following block:
```Csharp
public class Vector2 : IVector2
{
    ...
}
```
This code block defines a C# class. The <b>public</b> keyword defines that this class is visible from outside the namespace "LinearAlgebraLibrary.Exercise", <b>class</b> class means that this defines a class (other possibilites would be <b>struct</b> or <b>interface</b>), <b>Vector2</b> is the type- or class-name and <b>: IVector2</b> means that this class inherits or implements something called <b>IVector2</b>. This could be a class or an interface (more on that later).<br>
Run the test <b>Ex01_Task3_instantiate_vector2_no_args</b>. The test will fail. In the test you see this code:
```Csharp
// create zero vector
var myVector = new Vector2();
```
This code is used to create an object instance from the class <b>Vector2</b>. Note that in this excersise auto-typing is used for local variables, if you prefer you can also define them like this:
```Csharp
// create zero vector
Vector2 myVector = new Vector2();
```
To make the test pass, you need to implement the constructor of <b>Vector2</b>.
```Csharp
/// <summary>
/// Creates a new vector with X and Y set to zero
/// </summary>
public Vector2()
{
    throw new NotImplementedException();
}
```
Once you have added your implementation re-run the test.<br>

<b>TODO:</b> Run the test <b>Ex01_Task3_instantiate_vector2_args</b>. As you will notice, the test fails even after the you have implemented the constructer in the last section. This is due to the fact that this class has multiple overloads for the constructor. An overload allows a method to be defined multiple times with different parameters and even return values. Add your implementation at the second constructor:
```Csharp
/// Creates a new vector with X and Y components
/// </summary>
/// <param name="x">X component value</param>
/// <param name="y">Y component value</param>
public Vector2(double x, double y)
{
    throw new NotImplementedException();
}
```
<br>

<b>TODO:</b> Open the file "LinearAlgebraLibrary/LinearAlgebraLibrary.Interface/IVector2.cs". You will see the follwing content:
```Csharp
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
```
As you can see <b>IVector2</b> is not a base-class but rather a interface. The difference between classes and interfaces is that interfaces cannot implement logic themselves. Interfaces only define what classes which implement the interface need to define in terms of properties and methods. If you were to remove the method <b>CrossProduct</b> from the class <b>Vector2</b>, the code would no longer compile. You can imagine interfaces as being like a contract with conditions a class has to fulfill to be able to call itself comliant with that interface. Interfaces can also inherit base interfaces but they cannot inherit classes since they are not allowed to implement any logic. Interfaces are very powerfull tools to define interaction between different projects. Also it is possible to have different implementations for the same interface. An example of this can be found in "LinearAlgebraFactory.cs":

```Csharp
internal static IVector2 MakeVector2()
{
    return UseImplementationFromSolution
        ? new LinearAlgebraLibrary.Solution.Vector2()
        : new LinearAlgebraLibrary.Exercise.Vector2();
}
```
Since the classes of both projects, the Exercise and the Solution, implement the same interfaces, all code using <b>IVector2</b> instead of <b>Vector2</b> doesn't care which one of the two implementations is being used.
