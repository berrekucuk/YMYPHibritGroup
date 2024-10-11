// See https://aka.ms/new-console-template for more information
 
using DelegateAndEvents;

Console.WriteLine("Hello, World!");

// Built-int Delegates

//action delegate (void return type)(one parameter) => parametre alan geriye void dönen metotları temsil eder.
Action<int> actionDelegate = (x) => Console.WriteLine(x);

Action<int> actionDelegate2 = ActionMethod;
Action<double> actionDelegate3 = ActionMethod3;

actionDelegate(10);
actionDelegate.Invoke(10);

//predicate delegate (bool return type)(one parameter))=> parametre alan geriye bool dönen metotları temsil eder.

Predicate<int> predicateDelegate = x => x > 5;
Predicate<int> predicateDelegate2 = PredicateMethod;
var result = predicateDelegate(10);

Console.WriteLine(result);

//func delegate (return type, parameters) => istenildiği kadar parametre alır ve geriye istenilen tipi belirtebildiğimiz methodları temsil eder.
Func<int, double, bool> myfunc = (x, y) => x > y;
Func<int, double, bool> myfunc2 = MyFuncMethod;

Func<string, string, string> myFunc3 = (x, y) => x + y;


var names = new List<string> { "John", "Jane", "Jack", "Jill" };

//LinQ = Language Integrated Query / LinQ to Collection
names.Where(x => x == "ahmet");

var y = names.First(x =>
{
    var result = x == "John";
    return result;
});

//var f = names.First(x => x == "John");
//var z = names.Find(MathNames);

////delegate bool Math(string name);

//var mathCalculator = new MathCalculator();

//mathCalculator.MathCalculate(10, 20, SumMath);
//mathCalculator.MathCalculate(10, 20, (a, b) => a + b * (a * b));

//mathCalculator.MathCalculate(10, 20, MultiplyMath);
//mathCalculator.MathCalculate(10, 20, (a, b) => a * b * 2);



//Delegate

//var delegateMethodObject = new AddDelegate(Add);

//var delegateMethodMultiplyObject = new MultiplyDelegate(Multiply);

//var delegateMethodMultiplyObjectSum = new MultiplyDelegate(Sum);

//var calculator = new Calculator();

//var result1 = calculator.Calculate(5, 5, 5, delegateMethodMultiplyObject);
//var result2 = calculator.Calculate(5,5,5, delegateMethodMultiplyObjectSum);

//Console.WriteLine(result1);

//Console.WriteLine(result2);

//Add(10, 20);
//delegateMethodObject(10, 20);
//delegeteMethodObject.Incoke(10, 20);

//int result = delegateMethodMultiplyObject(1, 2, 3);

//int result2 = Multiply(1,2,3);
//Console.WriteLine(result);

bool MyFuncMethod(int a, double b)
{
    return a > b;
}

bool PredicateMethod(int a)
{
    return a > 10;
}

void ActionMethod(int a)
{
    Console.WriteLine(a);
}

void ActionMethod3(double a)
{
    Console.WriteLine(a);
}

void Add(int a , int b)
{
    Console.WriteLine(a+b);
}

int Multiply(int x, int y, int z)
{
    return x * y * z;
}

int Sum(int x, int y, int z)
{
    return x + y + z;
}

int SumMath(int a, int b)
{
    return a + b * ( a * b );    
}

int MultiplyMath(int a, int b)
{
    return a * b;
}

bool MathNames(string name)
{
    return name == "John";
}

public delegate void AddDelegate(int x, int y);

public delegate int MultiplyDelegate(int a , int b, int c);

delegate bool Math(string name);