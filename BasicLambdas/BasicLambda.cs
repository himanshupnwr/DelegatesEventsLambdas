// See https://aka.ms/new-console-template for more information
public delegate int LambdaDelegate(int x);
public delegate void LambdaDelegatePrefix(int x, string prefix);
public delegate bool ExprDelegate(int x);

class BasicLambda
{
    static void Main(string[] args)
    {

        //create a basic delegate that squares a number
        LambdaDelegate ld = (x) => x * x;
        Console.WriteLine("The result of the lambda delegate is: {0}", ld(5));

        //Dynamically change the delegate to something else
        ld = (x) => x * 10;
        Console.WriteLine("The result of d1 is: {0}", ld(5));

        //create a delegate that takes multiple argurments
        LambdaDelegatePrefix ldp = (x, y) =>
        {
            Console.WriteLine("The two - args lambda: {1}, {0}", x * 10, y);
        };

        ldp(25, "Some String");

        //Define an expression delegate
        ExprDelegate ed = (x) => x > 10;

        Console.WriteLine("Calling d3 with 5: {0}", ed(5));
        Console.WriteLine("Calling d3 with 15: {0}", ed(15));
    }
}