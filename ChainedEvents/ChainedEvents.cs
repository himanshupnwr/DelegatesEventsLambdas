public delegate void myEventHandler(string value);

class EventPublisher
{
    private string theVal;
    public event myEventHandler valueChanged;
    public event EventHandler<ObjChangeEventArgs> objChanged;

    public string Val
    {
        set
        {
            this.theVal = value;
            //when the value changes fire the event
            this.valueChanged(theVal);
            this.objChanged(this, new ObjChangeEventArgs()
            {
                propChanged = "Val"
            });
        }
    }
}

class ObjChangeEventArgs : EventArgs
{
    public string propChanged;
}

class ChainedEvents
{
    static void Main(string[] args)
    {
        EventPublisher epObj = new EventPublisher();
        //connect multiple event handlers
        epObj.valueChanged += new myEventHandler(changeListener1);
        epObj.valueChanged += new myEventHandler(changeListener2);

        //use an anonymous delegate as the event handler

        epObj.valueChanged += delegate (string s) {
            Console.WriteLine("This came from the anonymous handler!");
        };

        epObj.objChanged += delegate (object sender, ObjChangeEventArgs e)
        {
            Console.WriteLine("{0} has the {1} property changed", sender.GetType(), e.propChanged);
        };

        string str;
        do
        {
            Console.WriteLine("Enter a value");
            str = Console.ReadLine();
            if(!str.Equals("exit"))
            {
                epObj.Val = str;
            }
        }
        while(!str.Equals("exit"));
        Console.WriteLine("GoodBye!");

    }

    private static void changeListener2(string value)
    {
        Console.WriteLine("The value changed to {0}", value);
    }

    private static void changeListener1(string value)
    {
        Console.WriteLine("I also listen to the event, and the value we got is {0}", value);
    }
}

//Output
//Enter a value
//himanshu
//I also listen to the event, and the value we got is himanshu
//The value changed to himanshu
//This came from the anonymous handler!
//EventPublisher has the Val property changed