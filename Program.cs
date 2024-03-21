using System;
public class Program
{
    //ExamUnit 3
    //Task 1: Functions are a popping
    //- A function that returns the square of a number
    public static double Square(double number)
    {
        return Math.Pow(number, 2);
    }

    public static void Task1()
    {
        double number = 5.0;
        double result = Square(number);
        Console.WriteLine($"The square of {number} is {result}");
    }

    //- A function that returns a length in mm assuming it has been given a length in inches.

    public static double InchesToMillimeters(double lengthInInches)
    {
        return lengthInInches * 25.4;
    }

    public static void Task2()
    {
        double lengthInInches = 10.0;
        double lengthInMillimeters = InchesToMillimeters(lengthInInches);
        Console.WriteLine($"{lengthInInches} inches is equal to {lengthInMillimeters} millimeters");
    }

    //- A function that returns the root of a number
    public static double SquareRoot(double number)
    {
        return Math.Sqrt(number);
    }

    public static void Task3()
    {
        double number = 25.0;
        double result = SquareRoot(number);
        Console.WriteLine($"The square root of {number} is {result}");
    }

    //- A function that returns the cube of a number 
    public static double Cube(double number)
    {
        return Math.Pow(number, 3);
    }

    public static void Task4()
    {
        double number = 3.0;
        double result = Cube(number);
        Console.WriteLine($"Cube of {number}={result}");
    }
    //- A function that returns the area of a circle given the radius. 

    public static double CalculateCircleArea(double radius)
    {
        return Math.PI * Math.Pow(radius, 2);
    }

public static void Task5()
{
        double radius = 5.0;
    double area = CalculateCircleArea(radius);
    Console.WriteLine($"The area of a circle with radius {radius} is {area}");
    }

//- A function that returns a greeting, given a name.
 public static string GenerateGreeting(string name)
    {
        return $"Hello, {name}! Welcome!";
    }

public static void Task6(){
    string name ="Tony";
    string greeting = GenerateGreeting(name);
    Console.WriteLine(greeting);
}

public static void Main(string[] args)
{
    Task1();
    Task2();
    Task3();
    Task4();
    Task5();
    Task6();
}

}