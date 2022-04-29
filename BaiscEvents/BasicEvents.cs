public delegate void myEventHandler(string value);

class EventPublisher
{
    public event myEventHandler valueChanged;

    private string theVal;

    public string Val
    {
        set { theVal = value; this.valueChanged(theVal); }
    }
}

class BasicEvents
{
    static void Main(string[] args)
    {
        // use a named function as an event handler
        EventPublisher obj = new EventPublisher();
        obj.valueChanged += new myEventHandler(obj_valueChanged);

        // use an anonymous delegate as an event handler
        obj.valueChanged += delegate (string val)
        {
            Console.WriteLine("The value is changed to {0}", val);
        };

        string str;

        do
        {
            Console.WriteLine("Enter a value");
            str = Console.ReadLine();
            if (!str.Equals("exit"))
            {
                obj.Val = str;
            }
        }
        while (!str.Equals("exit"));
        Console.WriteLine("Goodbye!");
    }

    // This function will be called when the value changes in the EventPublisher class
    static void obj_valueChanged(string value)
    {
        Console.WriteLine("The value changed to {0}",value);
    }
}