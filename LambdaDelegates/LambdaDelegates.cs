// See https://aka.ms/new-console-template for more information
public delegate void myEventHandler(string value);

class MyClass
{
    private string theValue;

    public event myEventHandler valueChanged;

    public string Val
    {
        set
        {
            this.theValue = value;
            this.valueChanged(theValue);
        }
    }
}

class LambdaDelegates
{
    static void Main(string[] args)
    {
        MyClass myClass = new MyClass();

        //Use a Lambda expression to define an event handler
        //Note that this is a statement lambda, due to use of {}

        myClass.valueChanged += (x) =>
        {
            Console.WriteLine("The value changed to {0}", x);
        };

        string str;

        do
        {
            str = Console.ReadLine();
            if (!str.Equals("exit"))
            {
                myClass.Val = str;
            }
        }
        while (!str.Equals("exit"));

        Console.WriteLine("Goodbye!");
    }
}